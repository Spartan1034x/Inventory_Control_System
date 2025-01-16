using BullseyeDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullseyeDesktopApp.StaticHelpers
{
    public static class UserSession
    {
        //Static current user variable
        public static Employee? CurrentUser {  get; set; }

        //Static variable for selected user
        public static Employee? SelectedUser { get; set; }


        //String for username from current user variable
        public static String UserName { 
            get {  return CurrentUser.Username; }
            set { UserName = value; }
        }


        //String for user location, does db query to find location from currentuser
        public static String UserLocation
        {
            get
            {
                using (var context = new BullseyeContext())
                {
                    var location = context.Sites.Where(s => s.SiteId == StaticHelpers.UserSession.CurrentUser.SiteId).FirstOrDefault();
                    return location?.SiteName.ToString() ?? "";
                }
            }
            set { UserLocation = value; }
        }
   
    }
}
