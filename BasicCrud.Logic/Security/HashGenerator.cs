using System;
using System.Security.Cryptography;

namespace BasicCrud.Logic.Security
{
    public class HashGenerator
    {
        public byte[] GenerateFromPassword(string password)
        {
            // Generate Salt
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            // Generate Hash with generated salt.
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return hashBytes;
        }

        public bool CheckHashWithPassword(byte[] hash, string password)
        {
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hash, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] generatedHash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
                if (hash[i + 16] != generatedHash[i])
                    return false;
            return true;
        }
    }
}
