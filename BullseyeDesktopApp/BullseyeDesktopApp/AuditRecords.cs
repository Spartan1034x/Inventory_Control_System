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
                    var audits = context.Txnaudits.ToList();
                    txnauditBindingSource.DataSource = audits;
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
    }
}
