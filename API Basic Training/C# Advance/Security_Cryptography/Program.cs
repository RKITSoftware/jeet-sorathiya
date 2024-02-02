using Security_Cryptography.BL;
using System;

namespace Security_Cryptography
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Input : ");
            string data = Console.ReadLine();

            // Encrypt and decrypt using AES
            string encriptData = BLAES.EncryptedByAES(data);
            Console.WriteLine($"{data} after Encrypted By AES : {encriptData} ");
            Console.WriteLine($"{encriptData} after Decrypted By AES : {BLAES.DecryptByAES(encriptData)}");

            Console.WriteLine();

            // Encrypt and decrypt using RSA
            encriptData = BLRSA.EncryptedByRSA(data);
            Console.WriteLine($"{data} after Encrypted By RSA : {encriptData} ");
            Console.WriteLine($"{encriptData} after Decrypted By RSA : {BLRSA.DecryptByRSA(encriptData)}");

            // Rijndael key and IV for encryption and decryption
            string generatedKey = "0123456789ABCDEF0123456789ABCDEF";//BLRijndael.GenerateKey(keySizeInBits);
            string iv = "0123456789ABCDEF";

            // Encrypt and decrypt using Rijndael
            encriptData = BLRijndael.EncryptedByRijndael(data, generatedKey, iv);
            Console.WriteLine($"{data} after Encrypted By Rijndael : {encriptData} ");
            Console.WriteLine($"{encriptData} after Decrypted By Rijndael : {BLRijndael.DecryptByRijndael(encriptData, generatedKey, iv)}");

        }
    }
}
