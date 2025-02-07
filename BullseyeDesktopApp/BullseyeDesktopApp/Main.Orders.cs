using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullseyeDesktopApp
{
    //                               ***** Orders Tab *****
    public partial class Main
    {

        //             REFRESH BUTTON
        //
        //
        private void btnOrdersRefresh_Click(object sender, EventArgs e)
        {

        }


        //           CREATE ORDER BUTTON
        //
        //
        private void btnOrdersCreate_Click(object sender, EventArgs e)
        {
            Form create = new CreateOrder();
            create.ShowDialog();
        }
    }
}
