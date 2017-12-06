/**   
 * Author     :       Nick Bruno
 */


using System;
using System.Security.Cryptography;

namespace Util
{
    public static class hashPassword
    {
        public static void hashPass(string pass, out string salt, out string hashedPass)
        {
            salt = generateSalt(16);
            hashedPass = hashPass(pass, salt);
        }

        public static string hashPass(string pass, string salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes = new byte[pass.Length + salt.Length];

            int i = 0;
            foreach (char c in pass)
                plainTextWithSaltBytes[i++] = (byte)c;
            foreach (char c in salt)
                plainTextWithSaltBytes[i++] = (byte)c;

            byte[] hashed = algorithm.ComputeHash(plainTextWithSaltBytes);
            string hashedPass = "";
            foreach (byte b in hashed)
                hashedPass += b.ToString("X2");
            return hashedPass;
        }

        private static string generateSalt(int size)
        {
            Random rand = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string s = "";
            for (int i = 0; i < size; i++)
                s += chars[rand.Next(chars.Length)];
            return s;
        }
    }
}
