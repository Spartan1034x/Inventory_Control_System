using BullseyeDesktopApp.Models;
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
        List<Inventory> inventory; // All inventory
        List<InventoryDisplay> order; // Order inventory


        public CreateOrder()
        {
            InitializeComponent();
            PopulateLabels();
            ResetOrderList();
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
            if (dgvOrders.CurrentCell.ColumnIndex == 4 && e.Control is TextBox textBox)
            {
                textBox.KeyPress -= CheckInput;
                textBox.KeyPress += CheckInput;
            }
        }
        //
        //
        private void CheckInput(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers and backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //           HIDE/SHOW EMERGENCY LBL
        //
        //
        private void radEmergency_CheckedChanged(object sender, EventArgs e)
        {
            lblEmergency.Visible = radEmergency.Checked;
            lblStandard.Visible = !radEmergency.Checked;
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
            dgvOrders.Columns["Ordered"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            // Set Description column to take 50% of available space
            dgvOrders.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvOrders.Columns["Description"].FillWeight = 50;

            // Only allow editing of ordered column 
            foreach (DataGridViewColumn column in dgvOrders.Columns)
            {
                if (column.Name != "Ordered")
                {
                    column.ReadOnly = true;
                }
                else
                {
                    column.ReadOnly = false;
                }
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


        //            EXIT BUTTON
        //
        //
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //          REMOVE BUTTON
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

            if (selectedItem.ItemId ==0)
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
            order.Add(displayItem);

            FormatAndAttachBindingSource();

            txtSearch.Clear();
        }

    }
}
