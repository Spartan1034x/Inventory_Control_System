using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullseyeDesktopApp.StaticHelpers
{
    public static class Hasher
    {
        //Sent: String
        //Returned: String
        //Desc: Receives plain text password and returns hashed string
        public static string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);


        //Sent: String
        //Returned: Bool
        //Desc: Receives plain text password and hashed password from db and checks if they match
        public static bool VerifyPassword(string hashed, string passwordProvided) => BCrypt.Net.BCrypt.Verify(passwordProvided, hashed);
    }
}
