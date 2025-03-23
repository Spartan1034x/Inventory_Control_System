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
    public partial class OrderEdit : Form
    {

        Txn order = new Txn();

        public OrderEdit()
        {
            InitializeComponent();
        }

        private void OrderEdit_Load(object sender, EventArgs e)
        {
            order = UserSession.SelectedOrder ?? new Txn();
            PopulateInputs();
        }


        //           POPULATE INPUTS
        //
        //
        private void PopulateInputs()
        {
            txtOrderID.Text = order.TxnId.ToString();            // ID
            txtCreatedDate.Text = order.CreatedDate.ToString();  // Created Date
            txtBarcode.Text = order.BarCode;                     // Barcode
            txtDeliveryID.Text = String.IsNullOrEmpty(order.DeliveryId.ToString()) ? "N/A" : order.DeliveryId.ToString();    // Delivery ID


            // Set cmb binding source to TxnStatus table, then set display member to order status
            try
            {
                using (var context = new BullseyeContext())
                {
                    cmbStatus.DataSource = new BindingSource() { DataSource = context.Txnstatuses.ToList() };
                    SetCmbDisplay(cmbStatus, "StatusName", order.TxnStatus); // Status

                    cmbSiteTo.DataSource = new BindingSource() { DataSource = context.Sites.ToList() };
                    SetCmbDisplay(cmbSiteTo, "SiteName", order.SiteIdtoNavigation.SiteName); // Site To

                    cmbSiteFrom.DataSource = new BindingSource() { DataSource = context.Sites.ToList() };
                    SetCmbDisplay(cmbSiteFrom, "SiteName", order.SiteIdfromNavigation.SiteName); // Site From

                    cmbType.DataSource = new BindingSource() { DataSource = context.Txntypes.ToList() };
                    SetCmbDisplay(cmbType, "TxnType1", order.TxnType); // Type

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error (Cmb Population)");
            }

            dtpShip.Value = order.ShipDate; // Ship Date
            dtpShip.CustomFormat = "ddd MMMM d, yyyy"; // Ship Date Format

            chkEmergency.Checked = order.EmergencyDelivery == 1 ? true : false; // Emergency Delivery

        }


        // Sets cmb display member and selected value
        private void SetCmbDisplay(ComboBox cmb, string dis, string sel)
        {
            cmb.DisplayMember = dis;
            cmb.ValueMember = dis;
            cmb.SelectedValue = sel;
        }


        //            EXIT BUTTON
        //
        //
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //            CANCEL ORDER BUTTON
        //
        //
        private async void btnCancelOrder_Click(object sender, EventArgs e)
        {
            DialogResult dia = MessageBox.Show("Are you sure you want to cancel this order?", "Cancel Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dia == DialogResult.Yes)
            {
                using (var context = new BullseyeContext())
                {
                    // Call update order with txn
                    order.TxnStatus = "CANCELLED";

                    await DBOperations.UpdateOrderWithAudit(order, new List<Txnitem>());

                    // Move inventory from current location back to WH
                    await DBOperations.MoveInventory(order.Txnitems.ToList(), order);

                    this.Close();
                }
            }
        }



        //            SAVE BUTTON
        //
        //
        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Save all changes to order
            order.TxnStatus = cmbStatus.SelectedValue?.ToString();
            order.ShipDate = dtpShip.Value;
            order.SiteIdto = (cmbSiteTo.SelectedItem as Site).SiteId;
            order.TxnType = cmbType.SelectedValue?.ToString() ?? order.TxnType;
            order.BarCode = txtBarcode.Text;
            order.EmergencyDelivery = chkEmergency.Checked ? (sbyte)1 : (sbyte)0;
            if (int.TryParse(txtDeliveryID.Text, out int res))
            {
                order.DeliveryId = res;
            }

            string res2 = await DBOperations.UpdateOrderWithAudit(order, new List<Txnitem>());

            if (res2 == "ok")
                this.Close();
            else
            {
                MessageBox.Show(res2, "DB Error (Update Order)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //           KEY PRESS EVENTS
        //
        // Only allow digits
        private void txtDeliveryID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        //           COMBO BOX EVENTS
        //
        //
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedValue.ToString() == "CANCELLED")
            {
                MessageBox.Show("Cancel orders with button", "Order Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetCmbDisplay(cmbStatus, "StatusName", order.TxnStatus); // Status
            }
            else
            {
                btnCancelOrder.Enabled = true;
            }
        }
    }
}
