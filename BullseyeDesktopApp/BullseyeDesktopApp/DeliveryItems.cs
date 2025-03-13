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
using BullseyeDesktopApp.Models.DisplayObjects;

namespace BullseyeDesktopApp
{
    public partial class DeliveryItems : Form
    {
        Delivery delivery = new Delivery();
        List<DeliveryItemDisplay> deliveryItems = new List<DeliveryItemDisplay>();

        public DeliveryItems()
        {
            InitializeComponent();
        }

        private void DeliveryItems_Load(object sender, EventArgs e)
        {
            delivery = UserSession.SelectedDelivery ?? new Delivery();
            PopulateLabels();
            PopulateDGV();
        }


        //             POPULATE DGV
        //
        //
        private void PopulateDGV()
        {
            CreateDisplayItems();

            dgvItems.DataSource = new BindingSource() { DataSource = deliveryItems };

            dgvItems.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dgvItems.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvItems.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Make all cols read only except for "Confirmed"
            foreach (DataGridViewColumn col in dgvItems.Columns)
            {
                if (col.Name != "Confirmed")
                {
                    col.ReadOnly = true;
                }
            }
        }



        //             CREATE DISPLAY ITEMS
        //
        //
        private void CreateDisplayItems()
        {
            foreach (var txn in delivery.Txns) // Txns included in deliveries from db
            {
                foreach (var item in txn.Txnitems) // TxnItems included in txns from db
                {
                    DeliveryItemDisplay temp = new DeliveryItemDisplay();
                    temp.ID = item.ItemId;
                    temp.Name = item.Item.Name;
                    temp.Quantity = item.Quantity;
                    temp.Confirmed = true;

                    deliveryItems.Add(temp);
                }
            }
        }
        


        //             POPULATE LBLS
        //
        //
        private void PopulateLabels()
        {
            lblDate.Text = delivery.DeliveryDate.ToString("ddd MMMM d, yyyy");
            lblID.Text = delivery.DeliveryId.ToString();
        }


        //             CLOSE BUTTON
        //
        //
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
