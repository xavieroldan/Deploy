using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace LoginDeploy1.Tools
{
    public class PasswordHelper
    {
       private static int rounds = 5; //number of iterations to secure the password

        //public static string Base64Encode(string password)
        //{
        //    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(password);
        //    return System.Convert.ToBase64String(plainTextBytes);
        //}
        //public static string Base64Decode(string base64EncodedData)
        //{
        //    var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        //    return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        //}

        public static string Base64Encode(string password,string user)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(String.Concat(user,password));
            var text = System.Convert.ToBase64String(plainTextBytes);

            for (int i = 0; i < rounds; i++)
            {
                plainTextBytes = System.Text.Encoding.UTF8.GetBytes(String.Concat(user, text));
                text = System.Convert.ToBase64String(plainTextBytes);
            }

            return text;
        }

        public static string Base64Decode(string passEncoded, string user)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(passEncoded);
            var text = System.Text.Encoding.UTF8.GetString(base64EncodedBytes).Remove(0, user.Length);

            for (int i = 0; i < rounds; i++)
            {
                base64EncodedBytes = System.Convert.FromBase64String(text);
                text = System.Text.Encoding.UTF8.GetString(base64EncodedBytes).Remove(0, user.Length);
            }

            return text;
        }
    }
}
