using BullseyeDesktopApp.Models;
using BullseyeDesktopApp.Models.DisplayObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BullseyeDesktopApp
{
    //                               ***** INVENTORY TAB *****
    public partial class Main
    {
        bool defaultInventoryLoad = true;
        List<Inventory> Inventory = new List<Inventory>();


        //           POPULATE DGV
        //
        // Receives a list of inventory and creates a new display list
        private void PopulateInventoryDGV(List<Inventory> inv)
        {
            List<MainInventoryDisplay> InventoryDisplay = new List<MainInventoryDisplay>();

            // Create new display object for each Inventory item and add to list
            foreach (var item in inv)
            {
                InventoryDisplay.Add(new MainInventoryDisplay() { ID = item.ItemId, Description = item.Item.Description, Threshold = item.ReorderThreshold, NewThreshold = item.ReorderThreshold });
            }

            dgvInventory.DataSource = new BindingSource() { DataSource = InventoryDisplay };

            dgvInventory.AutoResizeColumns();
            dgvInventory.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            foreach (DataGridViewColumn column in dgvInventory.Columns)
            {
                if (column.HeaderText != "NewThreshold")
                    column.ReadOnly = true;
                else
                    column.ReadOnly = false;
            }
        }


        //           INITIAL POPULATION
        //
        //
        private void InitialInventoryPopulation()
        {
            if (defaultInventoryLoad)
            {
                QueryInventoryDB();
            }
        }


        //          QUERIES ALL INVENTORIES
        //
        //
        private void QueryInventoryDB()
        {
            try
            {
                using (var context = new BullseyeContext())
                {
                    Inventory = context.Inventories.Where(i => i.SiteId == StaticHelpers.UserSession.CurrentUser.SiteId).Include(i => i.Item).ToList(); // Sets Inventory to list in db, includes item object for users location

                    PopulateInventoryDGV(Inventory);

                    defaultInventoryLoad = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error");
            }
        }


        //            HELP BUTTON
        //
        //
        private void picHelpInventory_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\u2022Updated selected items reorder quantity then click update to change selected item\n\u2022Search any item", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //            SEARCH FUNCTION
        //
        //
        private void txtInventorySearch_TextChanged(object sender, EventArgs e)
        {
            string searchCriteria = txtInventorySearch.Text.ToLower(); // Search criteria

            // Create new temporay inv list and send it to populate ftn
            List<Inventory> tempList = Inventory.Where(i => i.Item.Description.ToLower().Contains(searchCriteria)).ToList();

            PopulateInventoryDGV(tempList);
        }


        //          UPDATE BUTTON
        //
        //
        private void btnInventoryUpdate_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count > 0)
            {
                MainInventoryDisplay? selectedItem = dgvInventory.SelectedRows[0].DataBoundItem as MainInventoryDisplay;

                if (selectedItem != null)
                {
                    int newThreshold = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells[3].Value);

                    // Find matching inventory item
                    Inventory item = Inventory.First(i => i.ItemId == selectedItem.ID);

                    // Update threshold
                    item.ReorderThreshold = newThreshold;

                    string res = StaticHelpers.DBOperations.UpdateInventoryThreshold(item); // Updates item

                    if (res != "ok")
                        MessageBox.Show(res, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        QueryInventoryDB();
                    }
                }
            }
        }
    }
}
