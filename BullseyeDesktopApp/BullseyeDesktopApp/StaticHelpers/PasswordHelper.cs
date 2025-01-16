using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BullseyeDesktopApp.StaticHelpers
{
    public static class PasswordHelper
    {
        //Sent: String
        //Returned: String
        //Desc: Receives plain text password and returns hashed string
        public static string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);


        //Sent: String
        //Returned: Bool
        //Desc: Receives plain text password and hashed password from db and checks if they match
        public static bool VerifyPassword(string hashed, string passwordProvided) => BCrypt.Net.BCrypt.Verify(passwordProvided, hashed);


        //         PASSWORD GENERATOR
        //
        // Defines catagories
        private enum CharType
        {
            Lowercase,
            Uppercase,
            Digit,
            Special
        }
        // Constants for minimums
        private const int Length = 15;
        private const int MinUppercases = 1;
        private const int MinLowercases = 1;
        private const int MinDigits = 1;
        private const int MinSpecials = 1;
        // New dictionary for char types, stores values of Chartypes
        private static readonly Dictionary<CharType, string> _chars = new Dictionary<CharType, string>()
        {
            { CharType.Lowercase, "abcdefghijklmnopqrstuvwxyz" },
            { CharType.Uppercase, "ABCDEFGHIJKLMNOPQRSTUVWXYZ" },
            { CharType.Digit, "0123456789" },
            { CharType.Special, "!@#$%^&*()-_=+{}[]?<>.," }
        };
        // New dictionary for outstanding chars required to meet password minimums
        private static Dictionary<CharType, int> _outstandingChars = new Dictionary<CharType, int>();
        // Generate function 
        public static string Generate()
        {
            ResetOutstandings();
            var password = new StringBuilder();

            for (int i = 0; i < Length; i++)
            {
                if (_outstandingChars.Sum(x => x.Value) == Length - i)
                {
                    var outstanding = _outstandingChars.Where(x => x.Value > 0).Select(x => x.Key).ToArray();
                    password.Append(DrawChar(outstanding));
                }
                else
                {
                    password.Append(DrawChar());
                }
            }

            return password.ToString();
        }
        //Resets all required counts for seperate chars back to default in the outstanding char dictionary
        private static void ResetOutstandings()
        {
            _outstandingChars[CharType.Lowercase] = MinLowercases;
            _outstandingChars[CharType.Uppercase] = MinUppercases;
            _outstandingChars[CharType.Digit] = MinDigits;
            _outstandingChars[CharType.Special] = MinSpecials;
        }
        //Selects a random character from allowed types, and when all minimum requirements are met from any type
        private static char DrawChar(params CharType[] types)
        {
            var filteredChars = types.Length == 0 ? _chars : _chars.Where(x => types.Contains(x.Key));
            int length = filteredChars.Sum(x => x.Value.Length);

            int index = RandomNumberGenerator.GetInt32(length);
            int offset = 0;

            foreach (var item in filteredChars)
            {
                if (index < offset + item.Value.Length)
                {
                    DecreaseOutstanding(item.Key);
                    return item.Value[index - offset];
                }
                offset += item.Value.Length;
            }

            return default(char);
        }
        // Decrements the outstanding type when one is used
        private static void DecreaseOutstanding(CharType type)
        {
            if (_outstandingChars[type] > 0)
            {
                _outstandingChars[type]--;
            }
        }



    }
}
