using System;
using System.Security.Cryptography;

namespace myLibrary
{
    public class Hash
    {
        public const int SALT_SIZE = 32;
        public const int HASH_SIZE = 32;
        public const int ITERATION_COUNT = 100000;

        // Generates a hash given the password & the salt. Returns the hashed password. 
        public static string HashGenerator(string password, string salt)
        {
            byte[] slt = Convert.FromBase64String(salt);
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, slt, ITERATION_COUNT);
            byte[] hashedPwd = pbkdf2.GetBytes(HASH_SIZE);
            return Convert.ToBase64String(hashedPwd);
        }

        // Returns salt. 
        public static string SaltGenerator()
        {
            RNGCryptoServiceProvider generator = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_SIZE];
            generator.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }
    }
}
