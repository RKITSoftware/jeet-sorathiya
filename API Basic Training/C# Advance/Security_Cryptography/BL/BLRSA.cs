using System;
using System.Security.Cryptography;
using System.Text;

namespace Security_Cryptography.BL
{
    /// <summary>
    /// RSA encryption and decryption.
    /// </summary>
    public class BLRSA
    {
        private static RSACryptoServiceProvider _objRsa = new RSACryptoServiceProvider();

        /// <summary>
        /// Encrypts the input data using RSA.
        /// </summary>
        /// <param name="data">Input data to be encrypted</param>
        /// <returns>Encrypted data as a Base64-encoded string</returns>
        public static string EncryptedByRSA(string data)
        {
            // Convert input data to bytes
            byte[] bytes = Encoding.UTF8.GetBytes(data);

            // Encrypt the bytes using RSA
            byte[] encryptedBytes = _objRsa.Encrypt(bytes, true);

            // Convert the encrypted bytes to a Base64-encoded string
            return Convert.ToBase64String(encryptedBytes);
        }

        /// <summary>
        /// Decrypts the input data using RSA.
        /// </summary>
        /// <param name="data">Encrypted data as a Base64-encoded string</param>
        /// <returns>Decrypted data as a UTF-8 encoded string</returns>
        public static string DecryptByRSA(string data)
        {
            // Convert Base64-encoded string to bytes
            byte[] bytes = Convert.FromBase64String(data);

            // Decrypt the bytes using RSA
            byte[] decryptedBytes = _objRsa.Decrypt(bytes, true);

            // Convert the decrypted bytes to a UTF-8 encoded string
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
