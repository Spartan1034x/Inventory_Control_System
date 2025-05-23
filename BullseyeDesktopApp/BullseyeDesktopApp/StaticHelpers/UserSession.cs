﻿using BullseyeDesktopApp.Models;
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

        // Selected order for warehouse manager
        public static Txn? SelectedOrder { get; set; }

        // Selected Location for admin CRUD
        public static Site? SelectedLocation { get; set; }

        // Selected Delivery for item confirmation
        public static Delivery? SelectedDelivery { get; set; }

        // Selected Supplier
        public static Supplier? SelectedSupplier { get; set; }

        // Bool for processing damaged return items
        public static bool DamagedReturnProcessed = true;

        // Selected SiteId for return txn
        public static int SelectedReturnSiteId { get; set; }

        // Bool for add or edit item page
        public static bool AddItem { get; set; }


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

        // Path to current users Pictures folder
        private static string rootDirectory = Application.StartupPath;
        public static string PictureDirectoryPath = Path.Combine(rootDirectory, "Pictures");
   
    }
}
