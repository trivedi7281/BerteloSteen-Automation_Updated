using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DARS.Automation_.Utilities
{
    public class EcryptDecrypt
    {

        public void EncodingData()
        {
            // Here i we take a Decoded password
            String Decodepassword = "";

            var passwordInBytes = Encoding.UTF8.GetBytes(Decodepassword);
            string encodedPassword = Convert.ToBase64String(passwordInBytes);
            Console.WriteLine("Encoded pssword is:" + encodedPassword);
        }


        public void DecodingData()
        {
            // Here i we take a Encoded password
            String Encodedpassword = "";

            var EncodedpasswordInBytes = Convert.FromBase64String(Encodedpassword);
            string decodedPassword = Encoding.UTF8.GetString(EncodedpasswordInBytes);
            Console.WriteLine("Decoded pssword is:" + decodedPassword);
        }


    }
}
