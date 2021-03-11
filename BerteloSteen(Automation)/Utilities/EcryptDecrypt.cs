using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DARS.Automation_.Utilities
{
    public class EncryptDecrypt
    {
        

        public string EncodingData(string decodedPassword)
        {
            Info information = new Info();
            var passwordInBytes = Encoding.UTF8.GetBytes(decodedPassword);
            string encodedPassword = Convert.ToBase64String(passwordInBytes);
            return encodedPassword;
        }


        public string DecodingData(string encodedPassword)
        {
            var EncodedpasswordInBytes = Convert.FromBase64String(encodedPassword);
            string decodedPassword = Encoding.UTF8.GetString(EncodedpasswordInBytes);
            return decodedPassword;
        }


    }
}
