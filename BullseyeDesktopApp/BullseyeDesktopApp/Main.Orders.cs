using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BullseyeDesktopApp.Models;
using Microsoft.EntityFrameworkCore;
using BullseyeDesktopApp.StaticHelpers;

namespace BullseyeDesktopApp
{
    //                               ***** Orders Tab *****
    public partial class Main
    {

        List<Txn> orders;
        bool defaultLoad = true;


        //             HELP BUTTON
        //
        //
        private void picHelpOrders_Click(object sender, EventArgs e)
        {
            MessageBox.Show("•Click on column header to order by that column\n•Use Combo Boxes to filter results in display\n" +
                "•Only 1 Standard order allowed per location per week, unlimited emergency orders", "Orders Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            dgvOrders.DataSource = new BindingSource() { DataSource = sorted };
        }

        //             REFRESH BUTTON
        //
        //
        private void btnOrdersRefresh_Click(object sender, EventArgs e)
        {
            if (defaultLoad)
            {
                PopulateCmbs(); // Set default values in cmbs first
            }
            RefreshOrders();
        }


        //                 POPULATE CMBS
        //
        //
        private void PopulateCmbs()
        {
            try
            {
                using (var context = new BullseyeContext())
                {
                   
                    // Querys db sets datsource to list from db, sets display member and valuemember to display default values
                    // If warehouse supervisor sets to all locations

                    // Status Cmb
                    BindingSource ts = new BindingSource()
                    {
                        DataSource = context.Txnstatuses.ToList()
                    };
                    cmbOrdersStatus.DataSource = ts;
                    SetCmbMembers(cmbOrdersStatus, "StatusName", "StatusName", "SUBMITTED");
                    
                    // Types Cmb
                    BindingSource tt = new BindingSource()
                    {
                        DataSource = context.Txntypes.ToList()
                    };
                    cmbOrdersType.DataSource = tt;
                    SetCmbMembers(cmbOrdersType, "TxnType1", "TxnType1", "All");
                    
                    // Location Cmb
                    BindingSource tl = new BindingSource()
                    {
                        DataSource = context.Sites.ToList()
                    };
                    cmbOrdersLocation.DataSource = tl;
                    // Get users location
                    Site userSite = context.Sites.Where(s=>s.SiteId == UserSession.CurrentUser.SiteId).FirstOrDefault() ?? new Site();

                    if (UserSession.CurrentUser.PositionId == 3) // If warehouse supervisor show all locations
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
        //
        private void RefreshOrders()
        {
            try
            {
                using (var context = new BullseyeContext())
                {
                    // Gets all orders with location, item list, and approritate item
                    orders = context.Txns.Include(o => o.SiteIdtoNavigation).Include(o=>o.Txnitems).ThenInclude(i=>i.Item).ToList();

                    // Set to defaults if first Refresh, Non warehouse managers see there location first by default
                    if (defaultLoad && UserSession.CurrentUser.PositionId != 3)
                    {
                        // Filter orders based on users location, open store orders
                        orders = orders.Where(o => o.SiteIdto == UserSession.CurrentUser.SiteId).Where(o=>o.TxnStatus == "SUBMITTED").ToList();
                        defaultLoad = false;
                    }
                    // Non first load and warehouse managers see user input (inputs set by default in populate cmbs methods for first load for warehouse manager)
                    else
                    {
                        defaultLoad = false;
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

                    }

                    // Sets bindingsource datasource to created display list
                    BindingSource bs = new BindingSource() { DataSource = CreateOrderDisplayList(orders) };
                    dgvOrders.DataSource = bs;

                    // Formats dgvorders
                    dgvOrders.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvOrders.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvOrders.Columns["Location"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvOrders.Columns["DeliveryDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvOrders.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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
                string loc = o.SiteIdtoNavigation.SiteName ?? "Unknown";
                string status = o.TxnStatus ?? "Unknown";
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
                orderDisplay.Add(new OrderDisplay() { Location = loc, Status = status, Items = itemQuantity, DeliveryDate = deliveryDate, Weight = weight });
            }

            return orderDisplay;
        }


        //           CREATE ORDER BUTTON
        //
        //
        private void btnOrdersCreate_Click(object sender, EventArgs e)
        {
            Form create = new CreateOrder();
            create.ShowDialog();
        }


        //             COMBOBOX SELECTION CHANGED
        //
        //
        private void cmbOrdersLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!defaultLoad) 
                RefreshOrders();
        }

        private void cmbOrdersType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!defaultLoad)
                RefreshOrders();
        }

        private void cmbOrdersStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!defaultLoad)
                RefreshOrders();
        }
    }
}
