using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assigment2
{
    public static class ValidationHelper
    {
        //Capitalize Method 
        public static string Capitalize( string value)
        {
            
            char [] capitalazedString = value.ToCharArray();
            if (capitalazedString.Length >= 1)
            {
                if (char.IsLower(capitalazedString[0]))
                {
                    capitalazedString[0] = char.ToUpper(capitalazedString[0]);
                }
            }
            for (int i = 1; i < capitalazedString.Length; i++)
            {
                if (capitalazedString[i - 1] == ' ')
                {
                    if (char.IsLower(capitalazedString[i]))
                    {
                        capitalazedString[i] = char.ToUpper(capitalazedString[i]);
                    }
                }
            }
            return new string(capitalazedString);
        }




        // Method to validat and change postal code  
        public static bool IsValidPostalCode(ref string PostalCode)
        {
            if (string.IsNullOrWhiteSpace(PostalCode))
            {
                return false;
            }

            if (_canadianPostalCodePattern.IsMatch(PostalCode))
            {
                PostalCode = PostalCode.ToUpper();
                if (PostalCode.Length == 6)
                {
                    PostalCode.Insert(3, " ");

                }
             return true;

            }
            else
            {
                return false;
            }

        }
        // Method to validat and change province
        public static bool IsValidProvinceCode(ref string Province)
        {
            if (string.IsNullOrWhiteSpace(Province))
            {
                return false;
            }
            else
            {
                Province = Province.ToUpper();
                for (int i = 0; i < Checkprovinces.Length; i++)
                {
                    if (Checkprovinces[i] == Province)
                    {
                        return true;
                    }

                }

                return false;
            }

        }
        // Method to validat and change phone number
        public static bool IsValidPhoneNumber(ref string phoneNumber)
        {

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return false;
            }
            else
            {
                if (_canadianPhoneNumber.IsMatch(phoneNumber))
                {
                    return true;
                }
                
                    return false;

            }

        }
        // Method to validat email
        public static bool IsValidEmail(ref string email) 
        {

            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
            else
            {
                if (_validEmail.IsMatch(email))
                {
                    return true;
                }
                return false;

            }

        }

        // Regex 
        private static Regex _canadianPostalCodePattern = new Regex(@"^[A-Z]\d[A-Z] ?\d[A-Z]\d$", RegexOptions.IgnoreCase);
        private static string[] Checkprovinces = new string[] { "AB", "BC", "MB", "NB", "NL", "NT", "NS", "NU", "ON", "PE", "QS", "SK", "YT" };
        private static Regex _canadianPhoneNumber = new Regex(@"\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})");
        private static Regex _validEmail = new Regex (@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");


    }


}
