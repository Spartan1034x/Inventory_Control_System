using BullseyeDesktopApp.Models.DisplayObjects;
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

namespace BullseyeDesktopApp
{
    public partial class OrderFulfil : Form
    {
        private Txn selectedOrder = new Txn();
        private List<FulfilOrderDisplay> display = new List<FulfilOrderDisplay>(); // Bound to dgv so changes there reflect here
        private bool firstLoad = true;


        public OrderFulfil()
        {
            InitializeComponent();
        }

        private void FulfilOrder_Load(object sender, EventArgs e)
        {
            selectedOrder = UserSession.SelectedOrder ?? new Txn(); // Sets local var to static selected order
            PopulateLabels();
            PopulateDGV();
        }


        //            UP DOWN KEY PRESS FOR ORDER ALLOCATION CHANGE
        //
        //
        private void dgvOrderItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvOrderItems.SelectedRows.Count == 0)
                return;

            FulfilOrderDisplay item = dgvOrderItems.SelectedRows[0].DataBoundItem as FulfilOrderDisplay; // Changes databound item e.g. the display list

            if (item.ItemID != 0)
            {
                int caseSize = item.CaseSize;
                int quantity = item.Allocated;

                if (e.KeyCode == Keys.Up)
                {
                    if (item.Allocated + caseSize <= item.Requested) // Can't allocate over requested amount
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


        //           POPULATE DGV
        //
        //
        private void PopulateDGV()
        {
            dgvOrderItems.AutoGenerateColumns = true; // Creates columns for dgv based on display object, maybe makes checkbox column???

            if (firstLoad) // Only creates the list to display first run
            {
                foreach (Txnitem i in selectedOrder.Txnitems)
                {
                    // Adds item to display object
                    display.Add(new FulfilOrderDisplay { ItemID = i.ItemId, Name = i.Item.Name, Requested = i.Quantity, CaseSize = i.Item.CaseSize, Allocated = i.Quantity, Verified = false });
                }

                firstLoad = false;
            }
            // Save current index user is on
            int selectedIndex = dgvOrderItems.CurrentRow?.Index ?? 0;

            dgvOrderItems.DataSource = new BindingSource() { DataSource = display };

            dgvOrderItems.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrderItems.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            // No editing allowed except for check box 
            foreach (DataGridViewColumn column in dgvOrderItems.Columns)
            {
                if (column.HeaderText == "Verified")
                    column.ReadOnly = false;
                else
                    column.ReadOnly = true;
            }

            // Restore selected row
            if (selectedIndex >= 0 && selectedIndex < dgvOrderItems.Rows.Count)
            {
                dgvOrderItems.CurrentCell = dgvOrderItems.Rows[selectedIndex].Cells[0];
                dgvOrderItems.Rows[selectedIndex].Selected = true;
            }

            dgvOrderItems.AutoResizeColumns();
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


        //           EXIT BUTTON
        //
        //
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //          HELP BUTTON
        //
        //
        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\u2022Manually confirm items in order\n\u2022Up and Down arrows change quantity" +
                "\n\u2022Check box to confirm quantity was confirmed", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //         SUBMIT BUTTON
        //
        //
        async private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Create new item list of items for quantity packaged, list will be sent in with order update
            List<Txnitem> newItems = new List<Txnitem>();

            // Adds all items to itemlist
            foreach (FulfilOrderDisplay item in display)
            {
                // If item has not been confirmed show error
                if (!item.Verified)
                {
                    MessageBox.Show("You must confirm all items on order\nItem Number: " + item.ItemID + " has not been confirmed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Add item to newItem list in quantity allocated
                newItems.Add(new Txnitem { TxnId = selectedOrder.TxnId, ItemId = item.ItemID, Quantity = item.Allocated });

            }

            // Sets status to assembled if regular order, ready if online, add notes
            if (txtNotes.Text != String.Empty)
                selectedOrder.Notes += "\n\tUser: " + UserSession.CurrentUser.Username + " - Added At: " + DateTime.Now + " Note:" + txtNotes.Text;
            
            if (selectedOrder.TxnType.ToUpper() == "ONLINE".ToUpper())
                selectedOrder.TxnStatus = "READY";
            else
                selectedOrder.TxnStatus = "ASSEMBLED";

            // Submit updated order
            string res = await DBOperations.UpdateOrderWithAudit(selectedOrder, newItems);

            if (res != "ok")
            {
                MessageBox.Show(res, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update Inventory location, if online order use online ftn
            string res2 = "";

            // Create new detached list of items could be causing double tracking error?????
            List<Txnitem> detatchedItems = newItems.Select(i => new Txnitem { TxnId = i.TxnId, ItemId = i.ItemId, Quantity = i.Quantity }).ToList();

            if (selectedOrder.TxnType.ToUpper() == "ONLINE".ToUpper())
            {
                // Create delivery for in store pickup so delivery portal can reconize order
                // Create new order copy of selected order
                res2 = await DBOperations.CreateDeliveryForInStorePickup(selectedOrder.TxnId);
                txtNotes.Text = res2;
            }
            else
                res2 = await DBOperations.MoveInventory(detatchedItems, selectedOrder);

            if (res2 != "ok")
            {
                MessageBox.Show(res2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Close();
        }
    }
}
