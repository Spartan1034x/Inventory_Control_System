using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullseyeDesktopApp.StaticHelpers
{
    public static class MiscHelper
    {

        //        CALCULATE DELIVERY DATE
        //
        // Receives delivery day, returns date of next delivery for that store
        public static DateTime CalculateDeliveryDate(string day)
        {
            // Convert sent date into DayOfWeek object
            DayOfWeek deliveryDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), day, true);

            DateTime today = DateTime.Today;

            // Days to add to delivery date is delivery day of the week subrtact current day of the week add and mod 7
            int daysToAdd = ((int)deliveryDay - (int)today.DayOfWeek + 7) % 7;

            DateTime returnDate = today.AddDays(daysToAdd).AddHours(8);

            // If return date is before or today it goess next week
            if (returnDate <= DateTime.Now)
            {
                returnDate = returnDate.AddDays(7);
            }

            return returnDate;
        }
    }
}
