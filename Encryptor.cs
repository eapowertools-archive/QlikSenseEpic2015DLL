using System;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace Aes_Example
{
    class AESEncrypter
    {
        private SecureString AESKey { get; set; }

        public AESEncrypter(string aesKey)
        {
            foreach (char c in aesKey)
            {
                AESKey.AppendChar(c);
            }
        }

        public string EncryptString(string stringToEncrypt)
        {
            byte[] encrypted;
            using (Aes myAes = Aes.Create())
            {
                // Encrypt the string to an array of bytes.
                encrypted = EncryptStringToBytes_Aes(stringToEncrypt, Encoding.UTF8.GetBytes(AESKey.ToString()), myAes.IV);
            }

            return encrypted.ToString();
        }

        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key,
            byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key
                    , aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt
                        , encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(
                            csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }
    }
}