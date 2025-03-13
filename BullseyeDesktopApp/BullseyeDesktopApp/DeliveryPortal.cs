using BullseyeDesktopApp.Models;
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
using BullseyeDesktopApp.Models.DisplayObjects;

namespace BullseyeDesktopApp
{
    public partial class DeliveryPortal : Form
    {
        private Bitmap? signatureBit;
        private Byte[]? signature;
        private bool isDrawing = false;
        private Point lastPoint = Point.Empty;
        private List<int> txnIDs = new List<int>();
        private List<Delivery> deliveries = new List<Delivery>(); // Includes list of txns, and list of txnitems for each txn, and an item for each txnitem list
        private bool itemsConfirmed = false;

        public DeliveryPortal()
        {
            InitializeComponent();
        }

        private void DeliveryPortal_Load(object sender, EventArgs e)
        {
            InitializeSignatureBlock();
            PopulateLabels();
            DeliveryDBCall();
            PopulateDGV();
        }


        //           POPULATE DGV
        //
        //
        private void PopulateDGV()
        {
            List<Delivery> filteredDeliveries = new List<Delivery>();

            if (radPickup.Checked)
            {
                filteredDeliveries = deliveries.Where(d => d.Enroute == false).ToList();
            }
            else if (radDelivering.Checked)
            {
                filteredDeliveries = deliveries.Where(d => d.Enroute == true && d.Delivered == false).ToList();
            }
            else if (radAccept.Checked)
            {
                filteredDeliveries = deliveries.Where(d => d.Delivered == true && d.Accepted == false).ToList();
            }
            else if (radHistory.Checked)
            {
                filteredDeliveries = deliveries.Where(d => d.Accepted == true).ToList();
            }

            List<DeliveryDisplay> deliveryDisplays = new List<DeliveryDisplay>();

            foreach (var del in filteredDeliveries)
            {
                // Dtermine ordere total weight and items
                decimal totalWeight = 0;
                int totalItems = 0;
                foreach (var txn in del.Txns)
                {
                    foreach (var item in txn.Txnitems)
                    {
                        totalWeight += item.Quantity * item.Item.Weight;
                        totalItems += item.Quantity;
                    }
                }

                // Create new display object with weight and total items
                DeliveryDisplay newDisplay = new DeliveryDisplay()
                {
                    DeliveryId = del.DeliveryId,
                    DeliveryDate = del.DeliveryDate,
                    VehicleType = del.VehicleType,
                    Weight = totalWeight,
                    TotalCases = totalItems,
                    Notes = del.Notes,
                    Delivered = del.Delivered

                };

                deliveryDisplays.Add(newDisplay);
            }

            dgvDeliveries.DataSource = new BindingSource() { DataSource = deliveryDisplays };

            // Format the Delivery Date column
            dgvDeliveries.Columns["DeliveryDate"].DefaultCellStyle.Format = "ddd MMMM d, yyyy";

            dgvDeliveries.Columns["DeliveryId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dgvDeliveries.Columns["DeliveryId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }


        //           DELIVERY DB CALL
        //
        //
        private void DeliveryDBCall()
        {
            try
            {
                using (var context = new BullseyeContext())
                {
                    deliveries = context.Deliveries.Include(d => d.Txns).ThenInclude(t => t.Txnitems).ThenInclude(ti => ti.Item).ToList(); // Include list of txns, and list of txnitems for each txn, and an item for each txnitem list

                    deliveries = deliveries.OrderByDescending(d => d.DeliveryDate).ToList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error");
            }
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

        }


        //           EXIT BUTTON
        //
        //    
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //           SIGNATURE PICTURE BOX
        //
        //
        private void InitializeSignatureBlock()
        {
            signatureBit = new Bitmap(picSignature.Width, picSignature.Height);
            picSignature.Image = signatureBit;
        }

        //          SIGNATURE EVENTS
        private void picSignature_MouseDown(object sender, MouseEventArgs e)
        {
            StartDrawing(e);
        }

        private void picSignature_MouseMove(object sender, MouseEventArgs e)
        {
            DrawSignature(e);
        }

        private void picSignature_MouseUp(object sender, MouseEventArgs e)
        {
            StopDrawing();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            InitializeSignatureBlock();
            picHelp.Invalidate();
        }

        //         SIGNATURE METHODS
        private void StartDrawing(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                lastPoint = new Point(e.X, e.Y);
            }
        }

        private void DrawSignature(MouseEventArgs e)
        {
            if (isDrawing)
            {
                using (Graphics g = Graphics.FromImage(signatureBit))
                {
                    g.DrawLine(new Pen(Color.Black, 2), lastPoint, new Point(e.X, e.Y));
                    lastPoint = new Point(e.X, e.Y);
                    picSignature.Image = signatureBit;
                }
            }
        }

        private void StopDrawing()
        {
            isDrawing = false;
        }

        //          SAVE SIGNATURE
        private void SaveSignature()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Null checked in confirm button

                signatureBit?.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                signature = ms.ToArray();
                signatureBit?.Dispose();
            }
        }

        //          CHECK SIGNATURE BLOCK
        private bool IsBitmapEmpty()
        {
            if (signatureBit == null)
                return true;

            for (int x = 0; x < signatureBit.Width; x++)
            {
                for (int y = 0; y < signatureBit.Height; y++)
                {
                    Color pixelColor = signatureBit.GetPixel(x, y);

                    // If any pixel is NOT white or transparent it has been signed
                    if (pixelColor.ToArgb() != Color.White.ToArgb() && pixelColor.A != 0)
                    {
                        return false;
                    }
                }
            }
            return true; // All pixels are white or transparent meaning it's empty
        }


        //           RADIO BUTTONS
        //
        //
        private void radPickup_CheckedChanged(object sender, EventArgs e)
        {
            PopulateDGV();
            ButtonChange();
        }
        private void radDelivered_CheckedChanged(object sender, EventArgs e)
        {
            PopulateDGV();
            ButtonChange();
        }

        private void radDelivering_CheckedChanged(object sender, EventArgs e)
        {
            PopulateDGV();
            ButtonChange();
        }

        private void radAccept_CheckedChanged(object sender, EventArgs e)
        {
            PopulateDGV();
            ButtonChange();


        }

        private void ButtonChange()
        {
            btnConfirm.Text = radAccept.Checked ? "&Accept" : "&Confirm";
            btnConfirm.Enabled = !radHistory.Checked;
        }


        //           CONFIRM BUTTON (WH pickup and store drop off)
        //
        //
        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            // If items werent confirmed exit ftn
            if (!itemsConfirmed)
            {
                itemsConfirmed = ConfirmItems();
                if (!itemsConfirmed)
                {
                    MessageBox.Show("Items need to be verified to confirm order!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Ensure delivery has been signed for
            if (IsBitmapEmpty())
            {
                MessageBox.Show("Please sign for delivery", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get selected delivery
            DeliveryDisplay selectedDeliveryDisplay = (DeliveryDisplay)dgvDeliveries.CurrentRow.DataBoundItem;
            Delivery selectedDelivery = deliveries.Where(d => d.DeliveryId == selectedDeliveryDisplay.DeliveryId).First();

            // Dtermine ordere total weight and items
            decimal totalWeight = 0;
            int totalItems = 0;
            foreach (var txn in selectedDelivery.Txns)
            {
                foreach (var item in txn.Txnitems)
                {
                    totalWeight += item.Quantity * item.Item.Weight;
                    totalItems += item.Quantity;
                }
            }

            // Save signature
            SaveSignature();

            // Update delivery with signature, and bools to track delivery
            selectedDelivery.Signature = signature;

            if (radPickup.Checked) // If pickup has been confirmed enroute is true
            {
                selectedDelivery.Enroute = true;
            }
            else if (radDelivering.Checked) // If delivering is confirmed delivered is true
            {
                selectedDelivery.Delivered = true;
            }
            else if (radAccept.Checked) // If accepted is confirmed accepted is true
            {
                selectedDelivery.Accepted = true;
            }

            
            var context = new BullseyeContext();

            try
            {
                context.Deliveries.Update(selectedDelivery);
                await context.SaveChangesAsync();

                string status = radPickup.Checked ? "IN TRANSIT" : radDelivering.Checked ? "DELIVERED" : "COMPLETE";

                await UpdateTxnAndInventory(context, selectedDelivery, status);

                MessageBox.Show("Delivery Confirmed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopulateDGV();
                InitializeSignatureBlock();
                picHelp.Invalidate();
                itemsConfirmed = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException, "DB Error");
            }
            finally
            {
                context.Dispose();
            }

            } // End of Confirm Button Click Event


        //         UPDATE TXN AND INVENTORY
        //
        //
        private async Task UpdateTxnAndInventory(BullseyeContext context, Delivery selectedDelivery, string status)
        {
            foreach (var txn in selectedDelivery.Txns)
            {
                // Update each txn to status
                txn.TxnStatus = status;

                string txnRes = await StaticHelpers.DBOperations.UpdateOrderWithAudit(txn, new List<Txnitem>()); // Just updates the order not the txnItems

                if (txnRes != "ok")
                {
                    MessageBox.Show(txnRes, "DB Error (UpdateOrderWithAudit)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Call move inventory to update inventory locations
                string res = await StaticHelpers.DBOperations.MoveInventory(txn.Txnitems.ToList(), txn);

                if (res != "ok")
                {
                    MessageBox.Show(res, "DB Error (Move Inventory)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //              OPEN DELIVERY ITEMS FORM
        //
        //
        private bool ConfirmItems()
        {
            if (dgvDeliveries.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a delivery", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Get selected delivery
            DeliveryDisplay selectedDeliveryDisplay = (DeliveryDisplay)dgvDeliveries.CurrentRow.DataBoundItem;
            Delivery selectedDelivery = deliveries.Where(d => d.DeliveryId == selectedDeliveryDisplay.DeliveryId).First();

            // Set static var for selected delivery
            StaticHelpers.UserSession.SelectedDelivery = selectedDelivery;

            // Open delivery items form
            DeliveryItems frm = new DeliveryItems();
            frm.ShowDialog();
            UserSession.SelectedDelivery = null;

            // If ok return true else false
            if (frm.DialogResult == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //              DGV SELECTION CHANGED
        //
        // Only allows user to confirm delivery if date is today
        private void dgvDeliveries_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDeliveries.SelectedRows.Count > 0)
            {
                DeliveryDisplay tempDelivery = (DeliveryDisplay)dgvDeliveries.SelectedRows[0].DataBoundItem;

                DateTime deliveryDate = tempDelivery.DeliveryDate.Date; // Removes time
                DateTime today = DateTime.Now.Date; // Removes time from today

                btnConfirm.Enabled = deliveryDate == today;
            }
        }


        //              HELP BUTTON
        //
        //
        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\u2022Please sign for delivery by using the mouse to draw in the box provided \n\n" +
                "\u2022If you need to clear your signature, click the clear button. \n\n" +
                "\u2022Once you have signed, click the confirm button to confirm the delivery. \n\n" +
                "\u2022Can only confirm pick up and drop off of orders that are current day. \n\n" +
                "\u2022Ensure total items for delivery match amount loaded on truck. \n\n" +
                "\u2022Or if unloading the truck ensure total items match amount unloaded, by signing you are confirming the amount", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
