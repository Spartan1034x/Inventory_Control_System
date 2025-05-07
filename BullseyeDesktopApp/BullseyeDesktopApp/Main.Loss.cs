using BullseyeDesktopApp.Models;
using BullseyeDesktopApp.Models.DisplayObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullseyeDesktopApp
{
    public partial class Main
    {
        // Var for selected txn
        Txn SelectedLossTxn = new Txn();

        BindingList<LossItemsDisplay> LossItems = new BindingList<LossItemsDisplay>();

        private List<Item> items = new List<Item>();

        bool DefaultLossLoad = true;



        //            FORMAT LOSS TAB
        //
        // Called from main tab selection changed
        private void FormatLossTab()
        {
            nudLossOrderID.Controls[0].Visible = false;
            PopulateLossCmb();
            PopulateLossItems();
            AttachItemsToTxts();
            DefaultLossLoad = false; // Prevents this ftn from being called every time the tab is selected
        }


        //           ATTACH ITEMS TO TXTs
        //
        // Attaches items to txts for use in search
        private void AttachItemsToTxts()
        {
            var nameSource = new AutoCompleteStringCollection();
            var idSource = new AutoCompleteStringCollection();

            nameSource.AddRange(items.Select(i => i.Name).ToArray());
            idSource.AddRange(items.Select(i => i.ItemId.ToString()).ToArray());

            txtName1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtName1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtName1.AutoCompleteCustomSource = nameSource;
            txtName1.Tag = 1; // Store index for event handlers
            txtName1.TextChanged += NameTxt_TextChanged;

            txtId1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtId1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtId1.AutoCompleteCustomSource = idSource;
            txtId1.Tag = 1; // Store index for event handlers
            txtId1.TextChanged += IdTxt_TextChanged;
        }

        // When a name is selected find the matching ID and update the corresponding field
        private void NameTxt_TextChanged(object sender, EventArgs e)
        {
            TextBox nameTxt = sender as TextBox;
            if (nameTxt != null && !string.IsNullOrWhiteSpace(nameTxt.Text))
            {
                int index = (int)nameTxt.Tag;
                var item = items.FirstOrDefault(i => i.Name.Equals(nameTxt.Text, StringComparison.OrdinalIgnoreCase));
                if (item != null)
                {
                    txtId1.Text = item.ItemId.ToString();
                }
            }
        }

        // When an ID is selected find the matching Name and update the corresponding field
        private void IdTxt_TextChanged(object sender, EventArgs e)
        {
            TextBox idTxt = sender as TextBox;
            if (idTxt != null && int.TryParse(idTxt.Text, out int itemId))
            {
                int index = (int)idTxt.Tag;
                var item = items.FirstOrDefault(i => i.ItemId == itemId);
                if (item != null)
                {
                    txtName1.Text = item.Name;
                }
            }
        }



        //           POPULATE ITEMS
        //
        // Populates items list with data from database
        private void PopulateLossItems()
        {
            try
            {
                using (var context = new BullseyeContext())
                {
                    items = context.Items.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error (Item List)");
            }
        }


        //           POPULATE CMB
        //
        //
        // Populates cmb with locations, sets default to users location
        private void PopulateLossCmb()
        {
            try
            {
                using (var context = new BullseyeContext())
                {
                    var locations = context.Sites
                                    .Where(s => s.SiteName != "All" && s.SiteId != 10000 && s.SiteId != 1 && s.SiteName != "Truck" && s.SiteId != 3)
                                    .ToList();
                    cmbLocations.DataSource = locations;
                    cmbLocations.DisplayMember = "SiteName";
                    cmbLocations.ValueMember = "SiteId";
                    cmbLocations.SelectedValue = StaticHelpers.UserSession.CurrentUser.SiteId != 1 ? StaticHelpers.UserSession.CurrentUser.SiteId : 2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error (Location List)");
            }
        }


        //             CONFIRM ORDER ID
        //
        // Called when confirm order ID button is clicked
        private void btnLossConfirmOrderID_Click(object sender, EventArgs e)
        {
            SelectedLossTxn = new Txn();


            // Disable add button
            btnLossItemAdd.Enabled = false;

            // Disable process return button
            btnLossProcessReturn.Enabled = false;


            if (nudLossOrderID.Value == 0) // Ensure valid int is entered
            {
                MessageBox.Show("Please enter a valid order ID", "Invalid Order ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Query DB for order 
            using (var context = new BullseyeContext())
            {
                SelectedLossTxn = context.Txns
                    .Where(t => t.TxnId == nudLossOrderID.Value)
                    .FirstOrDefault() ?? new Txn();

                if (SelectedLossTxn.TxnId == 0) // If not found display error
                {
                    MessageBox.Show("Order ID not found", "Order ID not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (SelectedLossTxn.TxnStatus != "COMPLETE") // If not received display error and clear values
                {
                    MessageBox.Show("Order must be of type \"COMPLETE\" to be returned", "Order not valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SelectedLossTxn = new Txn();
                    LossItems.Clear();
                    return;
                }

                // If order is found populate dgv with txn Items
                PopulateLossDgv();

                // Enable add button
                btnLossItemAdd.Enabled = true;

                // Enable process return button
                btnLossProcessReturn.Enabled = true;

                // Select location from order
                cmbLocations.SelectedValue = SelectedLossTxn.SiteIdfrom;
            }
        }


        //           POPULATE DGV
        //
        // Populates dgv with txn items
        private void PopulateLossDgv()
        {
            LossItems.Clear(); // Clear list before populating

            using (var context = new BullseyeContext())
            {
                var items = context.Txnitems.Include(i=> i.Item)
                    .Where(t => t.TxnId == SelectedLossTxn.TxnId)
                    .ToList();

                foreach (var item in items)
                {
                    LossItemsDisplay lossItem = new LossItemsDisplay
                    {
                        Name = item.Item.Name,
                        Quantity = item.Quantity,
                        ItemId = item.ItemId,
                        Damaged = false
                    };

                    LossItems.Add(lossItem);
                }

                dgvLossItems.DataSource = LossItems;
                dgvLossItems.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
        }


        //           LOSS BUTTON CLICK
        //
        //
        private void btnLossCreateLoss_Click(object sender, EventArgs e)
        {
            Loss frm = new Loss(new List<int>());
            frm.ShowDialog();
        }


        //           ADD BUTTON CLICK
        //
        //
        private void btnLossItemAdd_Click(object sender, EventArgs e)
        {
            if (SelectedLossTxn.TxnId == 0)
            {
                MessageBox.Show("Please enter a valid order ID before attempting to add items", "Invalid Order ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName1.Text) || string.IsNullOrWhiteSpace(txtId1.Text) || nud1.Value < 1)
            {
                MessageBox.Show("Please fill out all field for adding item and ensure quantity is above 0", "Data Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (LossItems.Any(i => i.ItemId == int.Parse(txtId1.Text)))
            {
                MessageBox.Show("Item already in list", "Duplicate Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LossItems.Add(new LossItemsDisplay
            {
                Name = txtName1.Text,
                Quantity = (int)nud1.Value,
                ItemId = int.Parse(txtId1.Text),
                Damaged = false
            });
        }


        //           PROCESS RETURN BUTTON CLICK
        //
        //
        private async void btnLossProcessReturn_Click(object sender, EventArgs e)
        {
            if (!ValidateReturnInputs())
                return;

            // Update txn status to "RETURNED"
            SelectedLossTxn.TxnType = "Return";
            SelectedLossTxn.Notes += "/nRETURN NOTES:" + txtLossReason.Text;

            // Send updated txn to DB
            string res = await StaticHelpers.DBOperations.UpdateOrderWithAudit(SelectedLossTxn, new List<Txnitem>());
            if (res != "ok")
            {
                MessageBox.Show(res, "DB Error (update order)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get each item in the dgv and add to a list of txnitems (this will add all the quantities to inventory, then damaged will subract if needed)
            List<Txnitem> txnItems = new List<Txnitem>();

            foreach(DataGridViewRow row in dgvLossItems.Rows)
            {
                Txnitem item = new Txnitem
                {
                    TxnId = SelectedLossTxn.TxnId,
                    ItemId = (int)row.Cells["ItemId"].Value,
                    Quantity = (int)row.Cells["Quantity"].Value,
                    ItemLocation = (int)cmbLocations.SelectedValue
                };
                txnItems.Add(item);
            }

            // Process return by adding quantitys to inventory
            res = await StaticHelpers.DBOperations.ProcessReturn(SelectedLossTxn.SiteIdfrom, txnItems);
            if (res != "ok")
            {
                MessageBox.Show(res, "DB Error (process return)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check LossItems for damaged items and add to list
            List<int> damagedItemIds = LossItems.Where(i => i.Damaged).Select(i => i.ItemId).ToList();
            bool damagedItems = damagedItemIds.Count > 0;

            // If theres damaged items open loss form which will subtract from inventory
            if (damagedItems)
            {
                StaticHelpers.UserSession.SelectedReturnSiteId = (int)cmbLocations.SelectedValue;

                Loss frm = new Loss(damagedItemIds);
                frm.ShowDialog();
            }

            MessageBox.Show("Return processed successfully", "Return Processed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear all fields
            SelectedLossTxn = new Txn();
            LossItems.Clear();
            txtLossReason.Text = "";
        }


        // Validates inputs before processing return
        private bool ValidateReturnInputs()
        {
            // Check that an order has been selected
            if (SelectedLossTxn.TxnId == 0)
            {
                MessageBox.Show("Please enter a valid order ID before attempting to process return", "Invalid Order ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check that items have been added
            if (LossItems.Count == 0)
            {
                MessageBox.Show("Please add items to the list before attempting to process return", "No Items Added", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check that all items have a quantity
            if (LossItems.Any(i => i.Quantity == 0))
            {
                MessageBox.Show("Please ensure all items have a quantity greater than 0", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check that the reason has been filled out 
            if (string.IsNullOrWhiteSpace(txtLossReason.Text))
            {
                MessageBox.Show("Please enter a reason for the return", "No Reason Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;    
        }


        //            HELP BUTTON CLICK
        //
        //
        private void picLoss_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\u2022To process a return, enter the order ID and click confirm\n\n" +
                "•Add items to the list by entering the item name or ID and quantity\n\n" +
                "•Remove items from return by selecting them in Data Grid View and pressing \"DEL\"\n\n" +
                "•If any items are damaged, select them and click create loss to process the return", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
