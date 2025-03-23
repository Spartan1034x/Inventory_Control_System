using BullseyeDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullseyeDesktopApp.StaticHelpers
{
    public static class MiscHelper
    {

        // STATIC LISTS FOR COUNTRIES AND PROVINCES
        public static List<String> provCodes = new List<string>() { "AB", "BC", "MB", "NB", "NL", "NT", "NS", "NU", "ON", "PE", "QC", "SK", "YT", "US" };

        public static List<string> countries = new List<string>
                {
                    "United States", "Canada", "United Kingdom", "Germany", "France",
                    "Italy", "Spain", "Australia", "Japan", "China",
                    "India", "Brazil", "Mexico", "Russia", "South Korea",
                    "Netherlands", "Sweden", "Switzerland", "Argentina", "South Africa",
                    "Turkey", "Saudi Arabia", "United Arab Emirates", "Indonesia", "Thailand",
                    "Vietnam", "Malaysia", "Philippines", "Egypt", "Pakistan",
                    "Bangladesh", "Nigeria", "Colombia", "Poland", "Chile",
                    "Belgium", "Austria", "Denmark", "Norway", "Finland"
                };


        //        CALCULATE DELIVERY DATE
        //
        // Receives delivery day for that store, returns date of next delivery for that store or Now if bad data sent in
        public static DateTime CalculateDeliveryDate(string day)
        {
            // Returns default date if bad data sent
            if (String.IsNullOrEmpty(day))
                return DateTime.Now;

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
