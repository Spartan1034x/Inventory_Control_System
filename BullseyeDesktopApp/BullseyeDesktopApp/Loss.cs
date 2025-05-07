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

namespace BullseyeDesktopApp
{
    public partial class Loss : Form
    {
        private List<Item> items = new List<Item>();

        List<int> itemIds;

        public Loss(List<int> itemIds)
        {
            InitializeComponent();
            this.itemIds = itemIds;
        }

        private void Loss_Load(object sender, EventArgs e)
        {
            PopulateLabels();
            PopulateItems();
            AttachItemsToTxts();
            PopulateCmb();
            HandleReturnItems();
        }

        private void HandleReturnItems()
        {
            // Allows user to close if they are not processing a return, else they cannot close unless processed
            if (itemIds.Count == 0) // If no items to process
            {
                StaticHelpers.UserSession.DamagedReturnProcessed = true;
            }
            else // If items to process
            {
                StaticHelpers.UserSession.DamagedReturnProcessed = false;
                radDamage.Checked = true;
                radLoss.Enabled = false;
                cmbLocations.SelectedValue = StaticHelpers.UserSession.SelectedReturnSiteId;
                cmbLocations.Enabled = false;

                PopulateReturnItems();
            }
        }


        //           POPULATE RETURN ITEMS
        //
        //
        private void PopulateReturnItems()
        {
            // Get items from itemIds
            var returnItems = items.Where(i => itemIds.Contains(i.ItemId)).ToList();

            // Populate textboxes with return items
            for (int i = 0; i < returnItems.Count; i++)
            {
                GetNameTextbox(i).Text = returnItems[i].Name;
                GetIdTextbox(i).Text = returnItems[i].ItemId.ToString();
            }
        }


        //           POPULATE CMB
        //
        //
        // Populates cmb with locations, sets default to users location
        private void PopulateCmb()
        {
            try
            {
                using (var context = new BullseyeContext())
                {
                    var locations = context.Sites
                                    .Where(s => s.SiteName != "All" && s.SiteId != 10000 && s.SiteId != 1)
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


        //           ATTACH ITEMS TO TXTs
        //
        // Attaches items to txts for use in search
        private void AttachItemsToTxts()
        {
            var nameSource = new AutoCompleteStringCollection();
            var idSource = new AutoCompleteStringCollection();

            nameSource.AddRange(items.Select(i => i.Name).ToArray());
            idSource.AddRange(items.Select(i => i.ItemId.ToString()).ToArray());

            TextBox[] nameTxts = { txtName1, txtName2, txtName3, txtName4 };
            TextBox[] idTxts = { txtId1, txtId2, txtId3, txtId4 };

            for (int i = 0; i < nameTxts.Length; i++)
            {
                nameTxts[i].AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                nameTxts[i].AutoCompleteSource = AutoCompleteSource.CustomSource;
                nameTxts[i].AutoCompleteCustomSource = nameSource;
                nameTxts[i].Tag = i; // Store index for event handlers
                nameTxts[i].TextChanged += NameTxt_TextChanged;

                idTxts[i].AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                idTxts[i].AutoCompleteSource = AutoCompleteSource.CustomSource;
                idTxts[i].AutoCompleteCustomSource = idSource;
                idTxts[i].Tag = i; // Store index for event handlers
                idTxts[i].TextChanged += IdTxt_TextChanged;
            }
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
                    GetIdTextbox(index).Text = item.ItemId.ToString();
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
                    GetNameTextbox(index).Text = item.Name;
                }
            }
        }

        // Helper methods to get the corresponding textboxes
        private TextBox GetNameTextbox(int index)
        {
            return new[] { txtName1, txtName2, txtName3, txtName4 }[index];
        }

        private TextBox GetIdTextbox(int index)
        {
            return new[] { txtId1, txtId2, txtId3, txtId4 }[index];
        }



        //           POPULATE ITEMS
        //
        // Populates items list with data from database
        private void PopulateItems()
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


        //           EXIT BUTTON
        //
        // Closes the form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //           SAVE BUTTON
        //
        // Saves the loss to the database
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                MessageBox.Show("Please enter a reason for the loss", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Txnitem> txnItems = new List<Txnitem>();

            // Array of textboxes and corresponding numeric up-down controls
            var itemInputs = new (TextBox txtId, NumericUpDown nud, string itemName)[]
            {
                (txtId1, nud1, "1"),
                (txtId2, nud2, "2"),
                (txtId3, nud3, "3"),
                (txtId4, nud4, "4")
            };

            // Validate input and get item IDs
            foreach (var (txtId, nud, itemName) in itemInputs)
            {
                if (!string.IsNullOrWhiteSpace(txtId.Text))
                {
                    if (nud.Value == 0) // Ensure quantity is not 0
                    {
                        MessageBox.Show($"Please enter a quantity for item {itemName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (int.TryParse(txtId.Text, out int id)) // Ensure valid integer ID
                    {
                        txnItems.Add(new Txnitem
                        {
                            TxnId = 0, // Not used rn
                            ItemId = id,
                            Quantity = (int)nud.Value,
                            ItemLocation = (int)cmbLocations.SelectedValue,
                            Notes = radLoss.Checked ? "Loss" : "Damaged"
                        });
                    }
                    else
                    {
                        MessageBox.Show($"Please enter a valid item ID for item {itemName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // If list is greater than 1 create return txn
            if (txnItems.Count > 0)
            {
                Txn newReturn = new Txn()
                {
                    EmployeeId = StaticHelpers.UserSession.CurrentUser.EmployeeId,
                    SiteIdfrom = cmbLocations.SelectedValue != null ? (int)cmbLocations.SelectedValue : 0,
                    SiteIdto = cmbLocations.SelectedValue != null ? (int)cmbLocations.SelectedValue : 0,
                    TxnStatus = "COMPLETE",
                    TxnType = radLoss.Checked ? "Loss" : "Damage",
                    ShipDate = DateTime.Now,
                    BarCode = "N/A",
                    CreatedDate = DateTime.Now,
                    EmergencyDelivery = 0,
                    DeliveryId = null,
                    Notes = txtReason.Text
                };

                string res = await StaticHelpers.DBOperations.CreateOrderWithAudit(newReturn, txnItems, "");

                if (res != "ok")
                {
                    MessageBox.Show(res, "Error Saving Txn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Txn saved now account for inventory
                    res = await StaticHelpers.DBOperations.ProcessLossOrDamage(newReturn, txnItems);

                    if (res != "ok")
                    {
                        MessageBox.Show(res, "Error Saving Inventory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Loss/Damage saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        StaticHelpers.UserSession.DamagedReturnProcessed = true; // Allows form to close if processing a return
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter at least one item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        //           FORM CLOSING
        //
        // Prevents form from closing if damaged return has not been processed
        private void Loss_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!StaticHelpers.UserSession.DamagedReturnProcessed)
            {
                // If damaged return has not been processed prevent form from closing
                DialogResult dia = MessageBox.Show("You are attempting to close without processing the return, this could cause errors. Are you sure you want to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dia == DialogResult.No)
                    e.Cancel = true;
            }
        }
    }
}
