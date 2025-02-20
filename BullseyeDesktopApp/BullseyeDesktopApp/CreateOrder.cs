using BullseyeDesktopApp.Models;
using BullseyeDesktopApp.Models.DisplayObjects;
using BullseyeDesktopApp.StaticHelpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BullseyeDesktopApp
{
    public partial class CreateOrder : Form
    {
        List<Inventory> inventory = new List<Inventory>(); // All inventory
        List<InventoryDisplay> order = new List<InventoryDisplay>(); // Order inventory


        //              FORM LOAD
        //
        //
        public CreateOrder()
        {
            InitializeComponent();
        }
        private void CreateOrder_Load(object sender, EventArgs e)
        {
            PopulateLabels();
            ResetOrderList();
            CheckPastOrders();
        }

        //             CHECK PAST ORDERS
        //
        //
        private void CheckPastOrders()
        {
            if (StaticHelpers.UserSession.CurrentUser.PositionId != 9999)
            {
                // If user cannot submit another standard order
                if (!StaticHelpers.DBOperations.CanSubmitOrder(StaticHelpers.UserSession.CurrentUser.SiteId))
                {
                    radEmergency.Checked = true;
                    radRegular.Enabled = false;
                }
            }
        }

        //             SEARCH AUTOFILL
        //
        //
        private void EnableAutoFill()
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            // Add each item name to collection if not already added
            foreach (Inventory i in inventory)
            {
                if (!collection.Contains(i.Item.Name))
                {
                    collection.Add(i.Item.Name);
                }
            }

            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSearch.AutoCompleteCustomSource = collection;
        }

        //           HANDLE DGV QUANtITY CELL
        //
        //
        private void dgvOrders_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvOrders.CurrentCell.OwningColumn.Name == "Ordered" && e.Control is TextBox textBox)
            {
                textBox.KeyPress -= CheckInput;
                textBox.KeyPress += CheckInput;
            }
        }
        //
        //
        private void CheckInput(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers and backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

        }


        //           RAD EMERGENCY CHECKED
        //
        //
        private void radEmergency_CheckedChanged(object sender, EventArgs e)
        {
            // Hide/Show Label
            lblEmergency.Visible = radEmergency.Checked;
            lblStandard.Visible = !radEmergency.Checked;

            // Limit line items to 5
            if (radEmergency.Checked)
            {
                if (order.Count > 5)
                    MessageBox.Show("Max 5 items for emergency order your list will be shortened to 5", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                order = order.Take(5).ToList();
                FormatAndAttachBindingSource();
            }
        }


        //           POPULATE LABELS
        //
        // Populates labels with user data from static class
        private void PopulateLabels()
        {
            lblUser.Text = StaticHelpers.UserSession.CurrentUser?.Username ?? ""; //If null empty string
            lblUser.ForeColor = Color.Red;

            lblLocation.Text = StaticHelpers.UserSession.UserLocation ?? "";
            lblLocation.ForeColor = Color.Red;

        }


        //            REFRESH CLICK
        //
        //
        private void btnOrdersRefresh_Click(object sender, EventArgs e)
        {
            DialogResult dia = MessageBox.Show("You will lose all unsaved work if you refresh", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dia == DialogResult.OK)
            {
                ResetOrderList();
            }
        }
        //
        //
        private void ResetOrderList()
        {
            try
            {
                using (var context = new Models.BullseyeContext())
                {   //Gets all inventory objects from current users store
                    inventory = context.Inventories.Where(i => i.SiteId == StaticHelpers.UserSession.CurrentUser.SiteId).Include(i => i.Item).Include(i => i.Site).ToList();

                    //Displays all results for admin and only items below min redorder quant for everybody else
                    order = (StaticHelpers.UserSession.CurrentUser.PositionId != 9999) ?
                    inventory.Where(i => i.Quantity < i.ReorderThreshold).Select(i => new InventoryDisplay
                    {
                        ItemId = i.ItemId,
                        Description = i.Item.Description,
                        Quantity = i.Quantity,
                        MinimumThreshold = (int)i.ReorderThreshold,
                        CaseSize = i.Item.CaseSize,
                        OptimumThreshold = (int)i.OptimumThreshold,
                        Ordered = CalculateQuantity(i.Quantity, (int)i.ReorderThreshold, i.OptimumThreshold, i.Item.CaseSize)
                    }).ToList()
                    :
                    inventory.Select(i => new InventoryDisplay
                    {
                        ItemId = i.ItemId,
                        Description = i.Item.Description,
                        Quantity = i.Quantity,
                        MinimumThreshold = (int)i.ReorderThreshold,
                        CaseSize = i.Item.CaseSize,
                        OptimumThreshold = (int)i.OptimumThreshold,
                        Ordered = CalculateQuantity(i.Quantity, (int)i.ReorderThreshold, i.OptimumThreshold, i.Item.CaseSize)
                    }).ToList();

                    FormatAndAttachBindingSource();

                    EnableAutoFill(); // Enables autofill after lists have been populated

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error");
            }
        }


        //           FORMAT AND ATTACH BIND SOURCE
        //
        //
        private void FormatAndAttachBindingSource()
        {
            dgvOrders.DataSource = null;
            BindingSource bs = new BindingSource();

            bs.DataSource = order;

            dgvOrders.DataSource = bs;

            dgvOrders.ReadOnly = false;

            // Auto Size columns
            dgvOrders.Columns["ItemId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvOrders.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvOrders.Columns["MinimumThreshold"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvOrders.Columns["OptimumThreshold"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvOrders.Columns["CaseSize"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvOrders.Columns["Ordered"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            // Set Description column to take 50% of available space
            dgvOrders.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvOrders.Columns["Description"].FillWeight = 50;

            // Only allow editing of ordered column 
            foreach (DataGridViewColumn column in dgvOrders.Columns)
            {
                column.ReadOnly = true;

                //if (column.Name != "Ordered")
                //{
                //    column.ReadOnly = true;
                //}
                //else
                //{
                //    column.ReadOnly = false;
                //}
            }
        }


        //               CALCULATE ORDER QUANTITY
        //
        // Calculates suggested order quantity
        private int CalculateQuantity(int currentQuant, int minReorder, int optReorder, int caseSize)
        {
            if (currentQuant >= minReorder)
            {
                return 0; // Order nothing if above reorder (will be filter regardless)
            }

            int needed = optReorder - currentQuant; // Amount needed to meet optimum quant

            int remainder = needed % caseSize; // How much will be left over to reach opt 

            int orderAmount = remainder == 0 ? needed : needed + (caseSize - remainder); // If exact case size works add all of needed, if not add value to bring to case size

            if (currentQuant + orderAmount <= optReorder) // Add another case for safety measure if below or at opt threshhold
            {
                orderAmount += caseSize;
            }

            return orderAmount;
        }


        //               EXIT BUTTON
        //
        //
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //               REMOVE BUTTON
        //
        //
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                // Get the selected row index
                int rowIndex = dgvOrders.SelectedRows[0].Index;

                // Remove from the list
                order.RemoveAt(rowIndex);

                // Refresh DataGridView
                FormatAndAttachBindingSource();
            }
            else
            {
                MessageBox.Show("Please select a row to remove.");
            }
        }


        //              ADD BUTTON
        //              
        //
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Get the item name from txt
            string searchText = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Please enter an item name.");
                return;
            }

            // Find matching inventory item, if not found default object created and error shown
            Inventory selectedItem = inventory.FirstOrDefault(i => i.Item.Name.ToLower() == searchText.ToLower()) ?? new Inventory();

            if (selectedItem.ItemId == 0)
            {
                MessageBox.Show("Item not found in inventory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create an display object from the found item
            InventoryDisplay displayItem = new InventoryDisplay()
            {
                ItemId = selectedItem.ItemId,
                Description = selectedItem.Item.Description,
                Quantity = selectedItem.Quantity,
                MinimumThreshold = (int)selectedItem.ReorderThreshold,
                CaseSize = selectedItem.Item.CaseSize,
                OptimumThreshold = (int)selectedItem.OptimumThreshold,
                Ordered = CalculateQuantity(
                                selectedItem.Quantity,
                                (int)selectedItem.ReorderThreshold,
                                selectedItem.OptimumThreshold,
                                selectedItem.Item.CaseSize)
            };

            // Check for dupes
            if (order.Any(o => o.ItemId == displayItem.ItemId))
            {
                MessageBox.Show("Item already added to the order list.");
                return;
            }

            // Add item and refresh dgv
            if (radEmergency.Checked && order.Count >= 5)
            {
                MessageBox.Show("Emergency orders are limited to 5 line items", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            order.Add(displayItem);

            FormatAndAttachBindingSource();

            txtSearch.Clear();
        }


        //              HELP BUTTON
        //
        //
        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\u2022Use up and down arrows to change order quantity by case size\n\u2022Search and item and press \"Add\" to add to order", "Info");
        }


        //            UP AND DOWN KEY PRESS
        //
        //
        private void dgvOrders_KeyDown(object sender, KeyEventArgs e)
        {

            if (dgvOrders.SelectedRows.Count == 0)
                return;

            InventoryDisplay item = dgvOrders.SelectedRows[0].DataBoundItem as InventoryDisplay ?? new InventoryDisplay();

            if (item.ItemId != 0)
            {
                int caseSize = item.CaseSize ?? 0;
                int quantity = item.Ordered ?? 0;

                if (e.KeyCode == Keys.Up)
                {
                    item.Ordered = quantity + caseSize;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    item.Ordered = Math.Max(0, quantity - caseSize);
                }

                e.Handled = true;
                dgvOrders.RefreshEdit();
            }
        }


        //               SUBMIT ORDER
        //
        //
        async private void btnSubmit_Click(object sender, EventArgs e)
        {   // Does not submit if empty order
            if (order.Count == 0)
            {
                MessageBox.Show("Order is empty. Please add items before submitting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Do not submit if emergency order and over 5 items
            if (order.Count > 5 && radEmergency.Checked)
            {
                MessageBox.Show("Max 5 items for Emergency Order", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Employee user = StaticHelpers.UserSession.CurrentUser ?? new Employee();
            int siteIDTo = user.SiteId;
            int siteIDFrom = 2; // Warehouse for now
            int employeeID = user.EmployeeId;
            string status = "submitted".ToUpper();
            DateTime deliveryDate = StaticHelpers.MiscHelper.CalculateDeliveryDate(user.Site.DayOfWeek.ToUpper());
            string orderType = radRegular.Checked ? "Store Order" : "Emergency Order";
            sbyte emergencyOrder = (sbyte)(radEmergency.Checked ? 1 : 0);
            string barCode = GenerateBarCode();
            string notes = "";
            if (txtNotes.Text != String.Empty)
                notes = "\tUser: " + UserSession.CurrentUser.Username + " - Added At: " + DateTime.Now + " Note:" + txtNotes.Text;
            DateTime createdDate = DateTime.Now; // CREATED DATE MAYBE GOES HERE!!!!!!!!!!!

            Txn newTxn = new Txn(employeeID, siteIDTo, siteIDFrom, status, orderType, deliveryDate, barCode, createdDate, emergencyOrder, notes);

            // Create Item List and add to txn
            List<Txnitem> txnItems = new List<Txnitem>();

            foreach (InventoryDisplay item in order)
            {
                if (item.Ordered > 0)
                {
                    txnItems.Add(new Txnitem()
                    {
                        TxnId = 0,
                        ItemId = item.ItemId,
                        Quantity = item.Ordered ?? 0
                    });
                }
            }

            // Call DBHelper to send txn, txnItems, and Txn audit
            string txnResult = await StaticHelpers.DBOperations.CreateOrderWithAudit(newTxn, txnItems, String.Empty);
            if (txnResult == "ok")
            {
                OrderSuccess();
            }
            else
            {
                MessageBox.Show(txnResult, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //
        //
        private void OrderSuccess() // Shows success and closes form
        {
            MessageBox.Show("Order Placed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        //
        //
        private string GenerateBarCode()
        {
            Random r = new Random();
            string res = "";

            for (int i = 0; i < 10; i++)
            {
                res += r.Next(0, 9).ToString();
            }

            return res;
        }

    }
}
