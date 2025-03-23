using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BullseyeDesktopApp.Models;
using Microsoft.EntityFrameworkCore;
using BullseyeDesktopApp.StaticHelpers;
using BullseyeDesktopApp.Models.DisplayObjects;

namespace BullseyeDesktopApp
{
    //                               ***** Orders Tab *****
    public partial class Main
    {

        List<Txn> orders;
        bool defaultOrdersLoad = true;

        //              EDIT ORDER BUTTON
        //
        //
        private void btnOrdersEdit_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                // Get selected order
                var selection = orders.Where(o => o.TxnId == (int)dgvOrders.SelectedRows[0].Cells[0].Value).FirstOrDefault();

                // If it is not null then open edit page
                if (selection != null)
                {
                    StaticHelpers.UserSession.SelectedOrder = selection;

                    OrderEdit frm = new OrderEdit();
                    frm.ShowDialog();

                    StaticHelpers.UserSession.SelectedOrder = null; // Resets selected order

                    RefreshOrders();
                }
            }
        }

        //              DELIVERY PORTAL CLICK
        //
        //
        private void btnOrdersDelivery_Click(object sender, EventArgs e)
        {
            Form form = new DeliveryPortal();
            form.ShowDialog();
            RefreshOrders();
        }


        //             FULFILL ORDER CLICK
        //
        //
        private void btnOrdersFulfil_Click(object sender, EventArgs e)
        {
            int posID = StaticHelpers.UserSession.CurrentUser.PositionId;

            // If selected order is not for users location confirm they want to continue
            string selectedLocation = dgvOrders.SelectedRows[0].Cells["Location"].Value.ToString();
            string usersLocation = StaticHelpers.UserSession.CurrentUser.Site.SiteName;
            
            if (selectedLocation != usersLocation && posID != 9999)
            {
                DialogResult dia = MessageBox.Show("This order is not for your location confirm continue?", "Fulfil Order?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dia != DialogResult.Yes)
                    return;
                
            }

            if (dgvOrders.SelectedRows.Count > 0 && (posID == 9999 || posID == 3 || posID == 5 || posID == 4)) // Only admin and warehouse man can fulfil
            {
                // Get selected order Txn type
                var selection = orders.Where(o => o.TxnId == (int)dgvOrders.SelectedRows[0].Cells[0].Value).FirstOrDefault();

                // If it is not null and is of status SUBMITTED then open receive page
                if (selection != null && selection.TxnStatus == "ASSEMBLING" )
                {
                    // Set selected order to Static order var
                    UserSession.SelectedOrder = selection;

                    // If order set open receive order page
                    if (UserSession.SelectedOrder != null)
                    {
                        OrderFulfil frm = new OrderFulfil();
                        frm.ShowDialog();
                        UserSession.SelectedOrder = null; // Resets selected order
                        RefreshOrders();
                    }
                    else
                    {
                        MessageBox.Show("Selected Order is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else // If not a submitted order display warning
                    MessageBox.Show("Order must be of status \"ASSEMBLING\" to be fulfilled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Please select an order to fulfil it, you may not have priviliges to perform this action", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //            FORMAT WEIGHT CELL
        //
        //
        private void dgvOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvOrders.Columns[e.ColumnIndex].Name == "Weight" && e.Value is decimal weight)
            {
                e.Value = $"{weight} kgs";
                e.FormattingApplied = true;
            }
        }

        //            DGV ORDERS SELECTION CHANGED
        //
        //
        // Enables received button if selected order is received or submitted
        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                string status = dgvOrders.SelectedRows[0].Cells["Status"].Value.ToString() ?? "";
                string type = dgvOrders.SelectedRows[0].Cells["Type"].Value.ToString() ?? "";
                int userID = StaticHelpers.UserSession.CurrentUser.PositionId;

                // Receive Button
                btnOrdersReceive.Enabled = (status == "SUBMITTED" || status == "RECEIVED") && ((userID == 9999 || userID == 3) || (type.ToLower() == "Online".ToLower() && (userID == 9999 || userID == 4)));

                // Fulfil Button
                btnOrdersFulfil.Enabled = (status == "ASSEMBLING") && ((userID == 9999 || userID == 3 || userID == 5) || (type.ToLower() == "Online".ToLower() && (userID == 9999 || userID == 4)));

                // Edit Button
                btnOrdersEdit.Enabled = (userID == 9999 && (status != "CANCELLED" && status != "COMPLETE" && status != "REJECTED"));
            }
        }


        //             RECEIVE ORDER BUTTON
        //
        //
        // Creates selected order from row selected, sets as static var then opens receive form
        private void btnOrdersReceive_Click(object sender, EventArgs e)
        {
            int posID = StaticHelpers.UserSession.CurrentUser.PositionId;

            // If selected order is not for users location confirm they want to continue
            string selectedLocation = dgvOrders.SelectedRows[0].Cells["Location"].Value.ToString();
            string usersLocation = StaticHelpers.UserSession.CurrentUser.Site.SiteName;

            if (selectedLocation != usersLocation && posID != 9999)
            {
                DialogResult dia = MessageBox.Show("This order is not for your location confirm continue?", "Fulfil Order?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dia != DialogResult.Yes)
                    return;

            }

            if (dgvOrders.SelectedRows.Count > 0 && (posID == 9999 || posID == 3 || posID == 4)) // Only admin and warehouse man can receive
            {
                // Get selected order Txn type
                var selection = orders.Where(o => o.TxnId == (int)dgvOrders.SelectedRows[0].Cells[0].Value).FirstOrDefault();

                // If it is not null and is of status SUBMITTED then open receive page
                if (selection != null && (selection.TxnStatus == "submitted".ToUpper() || selection.TxnStatus == "RECEIVED".ToUpper()))
                {
                    // Set selected order to Static order var
                    UserSession.SelectedOrder = selection;

                    // If order set open receive order page
                    if (UserSession.SelectedOrder != null)
                    {
                        OrderReceive frm = new OrderReceive();
                        frm.ShowDialog();
                        UserSession.SelectedOrder = null; // Resets selected order
                        RefreshOrders();
                    }
                    else
                    {
                        MessageBox.Show("Selected Order is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else // If not a submitted order display warning
                    MessageBox.Show("Order must be of status \"SUBMITTED\" to be Received", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Please select an order to receive it, you may not have privileges to perform this action", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        //             HELP BUTTON
        //
        //
        private void picHelpOrders_Click(object sender, EventArgs e)
        {
            MessageBox.Show("• Click on column header to order by that column\n\n• Use Combo Boxes to filter results in display\n\n" +
                "• Only 1 Standard order allowed per location per week, unlimited emergency orders\n\n\u2022" +
                " Double click an online order to confirm pickup", "Orders Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //             FILTER COLUMNS
        //
        //
        private string lastSortedColumn = string.Empty;
        private bool sortDescending = true;
        // Filter the results by that column
        private void dgvOrders_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Get the clicked column header text
            string columnName = dgvOrders.Columns[e.ColumnIndex].HeaderText;

            FilterColumns(columnName);

        }
        //
        // Function receives column header
        private void FilterColumns(string columnName)
        {
            // Determine sort direction, if same as last column clicked reverse direction
            if (columnName == lastSortedColumn)
            {
                sortDescending = !sortDescending;
            }

            // Save column clicked
            lastSortedColumn = columnName;

            // Retrieve the current displayed list, exit method if empty
            List<OrderDisplay> orderDisplayList = ((BindingSource)dgvOrders.DataSource).DataSource as List<OrderDisplay>;
            if (orderDisplayList == null || orderDisplayList.Count == 0)
                return;

            List<OrderDisplay> sorted = new List<OrderDisplay>();

            // For all columns sort based on flag
            if (columnName == "Status")
            {
                if (sortDescending)
                    sorted = orderDisplayList.OrderByDescending(o => o.Status == "SUBMITTED").ThenBy(o => o.Status).ToList();
                else
                    sorted = orderDisplayList.OrderBy(o => o.Status == "SUBMITTED").ThenByDescending(o => o.Status).ToList();
            }
            else if (columnName == "Location")
            {
                // Sort by user's location, then location
                if (sortDescending)
                {
                    sorted = orderDisplayList
                        .OrderByDescending(o => o.Location == UserSession.CurrentUser.Site.SiteName)
                        .ThenBy(o => o.Location)
                        .ToList();
                }
                else
                {
                    sorted = orderDisplayList
                        .OrderBy(o => o.Location == UserSession.CurrentUser.Site.SiteName)
                        .ThenByDescending(o => o.Location)
                        .ToList();
                }
            }
            else if (columnName == "Items")
            {
                if (sortDescending)
                    sorted = orderDisplayList.OrderByDescending(o => o.Items).ToList();
                else
                    sorted = orderDisplayList.OrderBy(o => o.Items).ToList();
            }
            else if (columnName == "Weight")
            {
                if (sortDescending)
                    sorted = orderDisplayList.OrderByDescending(o => o.Weight).ToList();
                else
                    sorted = orderDisplayList.OrderBy(o => o.Weight).ToList();
            }
            else if (columnName == "DeliveryDate")
            {
                if (sortDescending)
                    sorted = orderDisplayList.OrderByDescending(o => DateTime.ParseExact(o.DeliveryDate, "yyyy/MM/dd", null)).ToList();
                else
                    sorted = orderDisplayList.OrderBy(o => DateTime.ParseExact(o.DeliveryDate, "yyyy/MM/dd", null)).ToList();
            }
            else if (columnName == "OrderID")
            {
                if (sortDescending)
                    sorted = orderDisplayList.OrderByDescending(o => o.OrderID).ToList();
                else
                    sorted = orderDisplayList.OrderBy(o => o.OrderID).ToList();
            }
            else if (columnName == "Type")
            {
                if (sortDescending)
                    sorted = orderDisplayList.OrderByDescending(o => o.Type == "Emergency Order").ThenByDescending(o=>o.Type).ToList();
                else
                    sorted = orderDisplayList.OrderBy(o => o.Type == "Emergency Order").ThenBy(o=>o.Type).ToList();
            }



            dgvOrders.DataSource = new BindingSource() { DataSource = sorted };
        }

        //             REFRESH BUTTON
        //
        //
        private void btnOrdersRefresh_Click(object sender, EventArgs e)
        {
            if (defaultOrdersLoad)
            {
                PopulateCmbs(); // Set default values in cmbs first
            }
            RefreshOrders();
        }


        //                 POPULATE CMBS
        //
        //
        // Querys db sets datsource to list from db, sets display member and valuemember to display default values
        private void PopulateCmbs()
        {
            int userID = UserSession.CurrentUser.PositionId;

            try
            {
                using (var context = new BullseyeContext())
                {
                    // STATUS Cmb
                    BindingSource ts = new BindingSource()
                    {
                        DataSource = context.Txnstatuses.ToList()
                    };
                    cmbOrdersStatus.DataSource = ts;

                    // If user is warehouse worker defaults to assembling orders
                    if (userID == 5)
                        SetCmbMembers(cmbOrdersStatus, "StatusName", "StatusName", "ASSEMBLING");
                    else if (userID == 9999)
                        SetCmbMembers(cmbOrdersStatus, "StatusName", "StatusName", "All");
                    else
                        SetCmbMembers(cmbOrdersStatus, "StatusName", "StatusName", "SUBMITTED");
                    

                    // TYPES Cmb
                    BindingSource tt = new BindingSource()
                    {
                        DataSource = context.Txntypes.ToList()
                    };
                    cmbOrdersType.DataSource = tt;
                    SetCmbMembers(cmbOrdersType, "TxnType1", "TxnType1", "All");
                    

                    // LOCATION Cmb
                    BindingSource tl = new BindingSource()
                    {
                        DataSource = context.Sites.ToList()
                    };
                    cmbOrdersLocation.DataSource = tl;

                    // Get and sets to users location, or all if warehouse supervisor
                    Site userSite = context.Sites.Where(s=>s.SiteId == UserSession.CurrentUser.SiteId).FirstOrDefault() ?? new Site();

                    if (userID == 3 || userID == 9999 || userID == 5) // If warehouse supervisor, worker or admin show all locations
                        SetCmbMembers(cmbOrdersLocation, "SiteName", "SiteName", "All");
                    else
                        SetCmbMembers(cmbOrdersLocation, "SiteName", "SiteName", userSite.SiteName);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error");
            }
        }
        //
        // Sets cmb members
        private void SetCmbMembers(ComboBox cmb, string disMbr, string valMbr, string selVal)
        {
            cmb.DisplayMember = disMbr;
            cmb.ValueMember = valMbr;
            cmb.SelectedValue = selVal;
        }


        //            REFRESH ORDERS
        //
        // Default load loads user locations and submitted orders, else it refreshes users selected criteria
        private void RefreshOrders()
        {
            try
            {
                using (var context = new BullseyeContext())
                {
                    // Gets all orders with location, item list, and approritate item
                    orders = context.Txns.Include(o=>o.SiteIdfromNavigation).Include(o => o.SiteIdtoNavigation).Include(o=>o.Txnitems).ThenInclude(i=>i.Item).ToList(); // ORDERS SET HERE

                    defaultOrdersLoad = false;
                    string location = cmbOrdersLocation.SelectedValue.ToString();
                    string status = cmbOrdersStatus.SelectedValue.ToString();
                    string type = cmbOrdersType.SelectedValue.ToString();

                    // Make in memory list to query against, 
                    var filteredOrders = orders.AsQueryable(); // MAY HAVE TO CHANGE IF PERFORMANCE IS IMACTED

                    if (location != "All")
                    {
                        filteredOrders = filteredOrders.Where(o => o.SiteIdtoNavigation.SiteName == location);
                    }
                    if (status != "All")
                    {
                        filteredOrders = filteredOrders.Where(o => o.TxnStatus == status);
                    }
                    if (type != "All")
                    {
                        filteredOrders = filteredOrders.Where(o => o.TxnType == type);
                    }

                    orders = filteredOrders.ToList();

                    // Sets bindingsource datasource to created display list
                    BindingSource bs = new BindingSource() { DataSource = CreateOrderDisplayList(orders) };
                    dgvOrders.DataSource = bs;

                    // Formats dgvorders
                    dgvOrders.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvOrders.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvOrders.Columns["Location"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvOrders.Columns["DeliveryDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvOrders.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    defaultOrdersLoad = false; // So selected index cmb change only fires after first load

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error");
            }
        }


        //           CREATE DISPLAY OBJECT
        //
        // Receives a list of Txns and parses each one into a display object calculating the weight and total items for each order item
        private List<OrderDisplay> CreateOrderDisplayList(List<Txn> orders)
        {   
            // Return list
            List<OrderDisplay> orderDisplay = new List<OrderDisplay>();

            foreach (Txn o in orders)
            {
                // Required variables for display object from txn list sent in
                int id = o.TxnId;
                string loc = o.SiteIdtoNavigation.SiteName ?? "Unknown";
                string status = o.TxnStatus ?? "Unknown";
                string type = o.TxnType;
                List<Txnitem> items = (List<Txnitem>)o.Txnitems;
                string deliveryDate = o.ShipDate.ToString("yyyy/MM/dd");

                // Calculate total items and weight
                decimal weight = 0;
                int itemQuantity = 0;
                foreach (var item in items)
                {
                    itemQuantity += item.Quantity; // Add quantity to total
                    weight += (item.Quantity / item.Item.CaseSize) * item.Item.Weight; // Calculate weight of items and add to toal weight
                }

                // Add line item to display list
                orderDisplay.Add(new OrderDisplay() {OrderID = id, Location = loc, Status = status, Type = type, Items = itemQuantity, DeliveryDate = deliveryDate, Weight = weight });
            }

            return orderDisplay;
        }


        //           CREATE ORDER BUTTON
        //
        //
        private void btnOrdersCreate_Click(object sender, EventArgs e)
        {
            Form create = new OrderCreate();
            create.ShowDialog();
            RefreshOrders();
        }


        //             COMBOBOX SELECTION CHANGED
        //
        //
        private void cmbOrdersLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!defaultOrdersLoad) 
                RefreshOrders();
        }

        private void cmbOrdersType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!defaultOrdersLoad)
                RefreshOrders();
        }

        private void cmbOrdersStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!defaultOrdersLoad)
                RefreshOrders();
        }
    }
}
