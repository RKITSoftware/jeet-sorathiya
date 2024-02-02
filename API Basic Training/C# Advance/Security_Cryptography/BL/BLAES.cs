using System;
using System.Security.Cryptography;
using System.Text;

namespace Security_Cryptography.BL
{
    /// <summary>
    /// AES encryption and decryption.
    /// </summary>
    public class BLAES
    {
        private static AesCryptoServiceProvider _objAes = new AesCryptoServiceProvider();

        /// <summary>
        /// Encrypts the input data using AES.
        /// </summary>
        /// <param name="data">Input data to be encrypted</param>
        /// <returns>Encrypted data as a Base64-encoded string</returns>
        public static string EncryptedByAES(string data)
        {
            // Convert input data to bytes
            byte[] bytes = Encoding.UTF8.GetBytes(data);

            using (ICryptoTransform encript = _objAes.CreateEncryptor())
            {
                // Encrypt the bytes using AES
                byte[] encriptedBytes = encript.TransformFinalBlock(bytes, 0, bytes.Length);

                // Convert the encrypted bytes to a Base64-encoded string
                return Convert.ToBase64String(encriptedBytes);
            }
        }

        /// <summary>
        /// Decrypts the input data using AES.
        /// </summary>
        /// <param name="data">Encrypted data as a Base64-encoded string</param>
        /// <returns>Decrypted data as a UTF-8 encoded string</returns>
        public static string DecryptByAES(string data)
        {
            // Convert Base64-encoded string to bytes
            byte[] bytes = Convert.FromBase64String(data);

            using (ICryptoTransform decript = _objAes.CreateDecryptor())
            {
                // Decrypt the bytes using AES
                byte[] decriptBytes = decript.TransformFinalBlock(bytes, 0, bytes.Length);

                // Convert the decrypted bytes to a UTF-8 encoded string
                return Encoding.UTF8.GetString(decriptBytes);
            }
        }
    }
}

