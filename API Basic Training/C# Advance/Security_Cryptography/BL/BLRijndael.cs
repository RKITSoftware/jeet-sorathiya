using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Security_Cryptography.BL
{
    /// <summary>
    ///  Rijndael encryption and decryption.
    /// </summary>
    public class BLRijndael
    {
        /// <summary>
        /// Encrypts the input text using Rijndael algorithm.
        /// </summary>
        /// <param name="plainText">Text to be encrypted</param>
        /// <param name="key">Encryption key</param>
        /// <param name="iv">Initialization vector</param>
        /// <returns>Encrypted text as a Base64-encoded string</returns>

        public static string EncryptedByRijndael(string plainText, string key, string iv)
        {
            using (RijndaelManaged rijndael = new RijndaelManaged())
            {
                rijndael.Key = Encoding.UTF8.GetBytes(key);
                rijndael.Mode = CipherMode.CFB;
                rijndael.Padding = PaddingMode.PKCS7; // Use PKCS7 padding
                rijndael.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform encryptor = rijndael.CreateEncryptor(rijndael.Key, rijndael.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        /// <summary>
        /// Decrypts the input cipher text using Rijndael algorithm.
        /// </summary>
        /// <param name="cipherText">Cipher text as a Base64-encoded string</param>
        /// <param name="key">Decryption key</param>
        /// <param name="iv">Initialization vector</param>
        /// <returns>Decrypted text</returns>
        public static string DecryptByRijndael(string cipherText, string key, string iv)
        {
            using (RijndaelManaged rijndael = new RijndaelManaged())
            {
                rijndael.Key = Encoding.UTF8.GetBytes(key);
                rijndael.Mode = CipherMode.CFB;
                rijndael.Padding = PaddingMode.PKCS7; // Use PKCS7 padding
                rijndael.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform decryptor = rijndael.CreateDecryptor(rijndael.Key, rijndael.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        //public static string GenerateKey(int keySizeInBits)
        // {
        //     using (Aes aes = new AesCryptoServiceProvider())
        //     {
        //         aes.KeySize = keySizeInBits;
        //         aes.GenerateKey();
        //         return Convert.ToBase64String(aes.Key);
        //     }
        // }
    }
}
