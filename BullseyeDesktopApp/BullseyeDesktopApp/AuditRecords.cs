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
    public partial class AuditRecords : Form
    {
        public AuditRecords()
        {
            InitializeComponent();
        }

        private void AuditRecords_Load(object sender, EventArgs e)
        {
            populateDGV();
        }


        //            POPULATE DGV
        //
        //
        private void populateDGV()
        {
            try
            {
                using (var context = new Models.BullseyeContext())
                {
                    var audits = context.Txnaudits.OrderByDescending(a=>a.TxnAuditId).ToList();
                    txnauditBindingSource.DataSource = audits;
                    PopulateLabels();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error");
            }
        }


        //             EXIT BUTTON
        //
        //
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //            CELL MOUSE CLICK
        //
        //
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                PopulateLabels();
            }

        }

        private void PopulateLabels()
        {
            DataGridViewRow dataGridViewRow = dgvAudits.SelectedRows[0];

            Txnaudit audit = dataGridViewRow.DataBoundItem as Txnaudit ?? new Txnaudit();
            if (audit.TxnAuditId != 0)
            {
                lblTxnAuditID.Text = audit.TxnAuditId.ToString();
                lblDeliveryID.Text = audit?.DeliveryId.ToString();
                lblEmployeeID.Text = audit?.EmployeeId.ToString();
                lblSiteID.Text = audit?.SiteId.ToString();
                lblStaus.Text = audit?.Status.ToString();
                lblTxnDate.Text = audit?.TxnDate.ToString();
                lblTxnID.Text = audit?.TxnId.ToString();
                lblTxnType.Text = audit?.TxnType.ToString();
                lblCreateDate.Text = audit?.CreatedDate.ToString();

            }
        }
    }
}
