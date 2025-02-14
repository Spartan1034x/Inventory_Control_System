using BullseyeDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BullseyeDesktopApp.StaticHelpers;
using Microsoft.EntityFrameworkCore;
using BullseyeDesktopApp.Models.DisplayObjects;

namespace BullseyeDesktopApp
{
    public partial class ReceiveOrder : Form
    {
        // Local var for selected order
        private Txn selectedOrder = new Txn();
        private List<Inventory> warehouseInventory = new List<Inventory>();
        private List<ReceiveOrderDisplay> display = new List<ReceiveOrderDisplay>();
        private bool firstLoad = true;
        private Txn backorder = new Txn();

        public ReceiveOrder()
        {
            InitializeComponent();
        }


        //             FORM LOAD
        //
        //
        private void ReceiveOrder_Load(object sender, EventArgs e)
        {
            selectedOrder = UserSession.SelectedOrder ?? new Txn(); // Sets local var to static selected order
            PopulateLabels();
            LoadWarehouseInventory();
            PopulateDGV();
            //TxnReceived(); // Uncomment when live
        }


        //            POPULATE DGV
        //
        //
        private void PopulateDGV()
        {
            if (firstLoad) // Only creates the list to display first run
            {
                foreach (Txnitem i in selectedOrder.Txnitems)
                {
                    // Gets warehouse stock for that item
                    int warehouseStock = warehouseInventory.FirstOrDefault(wi => wi.ItemId == i.ItemId)?.Quantity ?? 0;

                    // Set allocated based on stock and requested
                    int allocated = Math.Min(i.Quantity, warehouseStock); // Returns smallest number, eg. if stock is below requested amount will give that amount

                    // Adds item to display object
                    display.Add(new ReceiveOrderDisplay { Name = i.Item.Name, Allocated = allocated, CaseSize = i.Item.CaseSize, ItemID = i.ItemId, Requested = i.Quantity, InStock = warehouseStock });
                }

                firstLoad = false;
            }

            // Save current index user is on
            int selectedIndex = dgvOrderItems.CurrentRow?.Index ?? 0;

            // Set datasource to local list
            dgvOrderItems.DataSource = new BindingSource() { DataSource = display };

            // Format dgv
            dgvOrderItems.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrderItems.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrderItems.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Only allow editing of ordered column 
            foreach (DataGridViewColumn column in dgvOrderItems.Columns)
            {
                column.ReadOnly = true;
            }

            // Restore selected row
            if (selectedIndex >= 0 && selectedIndex < dgvOrderItems.Rows.Count)
            {
                dgvOrderItems.CurrentCell = dgvOrderItems.Rows[selectedIndex].Cells[0];
                dgvOrderItems.Rows[selectedIndex].Selected = true;
            }

        }


        //            LOAD WAREHOUSE INVENTORY
        //
        //
        private void LoadWarehouseInventory()
        {
            try
            {
                using (var context = new BullseyeContext())
                {
                    // Find list of all warehouse items
                    warehouseInventory = context.Inventories.Where(i => i.SiteId == 2).Include(i => i.Site).Include(i => i.Item).ToList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error");
            }
        }


        //           ORDER RECEIVED
        //
        // Updates order to say received then calls update with audit
        private async void TxnReceived()
        {
            selectedOrder.TxnStatus = "received".ToUpper(); // Set status received

            string resp = await DBOperations.UpdateOrderWithAudit(selectedOrder); // Returns "ok" if success

            if (resp != "ok")
                MessageBox.Show(resp, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        //           POPULATE LABELS
        //
        // Populates labels with user data from static class
        private void PopulateLabels()
        {
            // Sets user labels
            lblUser.Text = StaticHelpers.UserSession.CurrentUser?.Username ?? ""; //If null empty string
            lblUser.ForeColor = Color.Red;

            lblLocation.Text = StaticHelpers.UserSession.UserLocation ?? "";
            lblLocation.ForeColor = Color.Red;

            // Sets Order Labels
            lblStoreTo.Text = selectedOrder.SiteIdtoNavigation.SiteName; // Included when oringinal queried
            lblType.Text = selectedOrder.TxnType;
            lblDate.Text = selectedOrder.CreatedDate.ToString("f");

        }


        //            UP DOWN KEY PRESS FOR ORDER ALLOCATION CHANGE
        //
        //
        private void dgvOrderItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvOrderItems.SelectedRows.Count == 0)
                return;

            ReceiveOrderDisplay item = dgvOrderItems.SelectedRows[0].DataBoundItem as ReceiveOrderDisplay;

            if (item.ItemID != 0)
            {
                int caseSize = item.CaseSize;
                int quantity = item.Allocated;

                if (e.KeyCode == Keys.Up)
                {
                    item.Allocated = quantity + caseSize;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    item.Allocated = Math.Max(0, quantity - caseSize); // Ensures number doesn't go below 0
                }

                e.Handled = true;

                PopulateDGV();
            }
        }


        //            HELP BUTTON
        //
        //
        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\u2022Use up and down arrows to change order quantity by case size\n\u2022Remove item permantly removes", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //           EXIT BUTTON
        //
        //
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //          SUBMIT BUTTON
        //
        //
        async private void btnSubmit_Click(object sender, EventArgs e)
        {
            // CREATE BACKORDER IF NEEDED

            bool needBackorder = false;

            // Create Item List from allocated items and add to txn
            List<Txnitem> backorderItems = new List<Txnitem>();

            // Checks if backorder is needed if so adds all items to itemlist
            foreach (ReceiveOrderDisplay item in display)
            {
                // If in stock amount is less than ordered from store add to backorder
                if (item.Requested > item.InStock)
                {
                    int backorderedAmount = item.Requested - item.Allocated; // Send them the difference of what they wanted and what they got

                    backorderItems.Add(new Txnitem()
                    {
                        TxnId = 0,
                        ItemId = item.ItemID,
                        Quantity = backorderedAmount
                    });

                    needBackorder = true;
                }
            }

            if (needBackorder)
            {
                // Variables for backorder txn
                Employee user = UserSession.CurrentUser;
                int empID = user.EmployeeId;
                int siteIDTo = user.SiteId;
                DateTime deliveryDate = StaticHelpers.MiscHelper.CalculateDeliveryDate(user.Site.DayOfWeek.ToUpper());

                backorder = new Txn(empID, siteIDTo, 2, "SUBMITTED", "Back Order", deliveryDate, "BC1929290", DateTime.Now, 0, "Nil");

                // Call DBHelper to send txn, backorderItems, and Txn audit
                string txnResult = await StaticHelpers.DBOperations.CreateOrderWithAudit(backorder, backorderItems, String.Empty);
                if (txnResult != "ok")
                {
                    MessageBox.Show(txnResult, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            } // Make sure that user cannot go over warehouse stock amount for allocated
            // Order gets changed to assembling
        }
    }
}
