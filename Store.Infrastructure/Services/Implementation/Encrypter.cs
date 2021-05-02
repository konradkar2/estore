using System;
using System.Security.Cryptography;
using Store.Core.Extensions;

namespace Store.Infrastructure.Services
{
    public class Encrypter : IEncrypter
    {
        private static readonly int DerivedIterationCount = 10000;
        private static readonly int SaltSize = 40;
        public string GetSalt()
        {
            var random = new Random();
            var saltBytes = new Byte[SaltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        public string GetHash(string value, string salt)
        {
            if(salt.Empty()){
                throw new ArgumentException("Can not generate hash from an empty salt.", nameof(salt));
            }
            if(value.Empty()){
                throw new ArgumentException("Can not generate hash from an empty value.", nameof(value));
            }
            var pbkdf2 = new Rfc2898DeriveBytes(value,GetBytes(salt),DerivedIterationCount);
            return Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));

        }
        private static byte [] GetBytes(string value)
        {
            var bytes = new byte[value.Length*sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(),0,bytes,0,bytes.Length);

            return bytes;
        }
    }
}