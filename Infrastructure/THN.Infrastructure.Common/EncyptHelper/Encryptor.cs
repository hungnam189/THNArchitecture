using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace THN.Infrastructure.Common.EncyptHelper
{

    public interface IEncryptor
    {
        string GetSalt(string value);
        string GetHash(string value, string salt);
    }



    public class Encryptor : IEncryptor
    {
        private const int SALT_SIZE = 40;
        private const int Interations_Count = 100000;

        private byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }


        public string GetHash(string value, string salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(value, GetBytes(salt), Interations_Count);
            return Convert.ToBase64String(pbkdf2.GetBytes(SALT_SIZE));
        }

        public string GetSalt(string value)
        {
            var saltBytes = new byte[SALT_SIZE];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes); 
        }
    }
}
