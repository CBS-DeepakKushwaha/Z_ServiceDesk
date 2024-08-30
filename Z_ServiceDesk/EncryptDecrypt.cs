using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;

namespace Z_ServiceDesk.Controllers
{
    public class EncryptDecrypt
    {
        //Same encryp/decrypt key is used in API to transfer data in encrypted format
        #region Common Encrypt/Decrypt
        static string encrypyDecrypyKey = "zx@#$57D342f";
        public string Encrypt(string Message)
        {
            try
            {
                byte[] Results;
                System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

                // Step 1. We hash the passphrase using MD5
                // We use the MD5 hash generator as the result is a 128 bit byte array
                // which is a valid length for the TripleDES encoder we use below

                MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(encrypyDecrypyKey));

                // Step 2. Create a new TripleDESCryptoServiceProvider object
                TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

                // Step 3. Setup the encoder
                TDESAlgorithm.Key = TDESKey;
                TDESAlgorithm.Mode = CipherMode.ECB;
                TDESAlgorithm.Padding = PaddingMode.PKCS7;

                // Step 4. Convert the input string to a byte[]
                byte[] DataToEncrypt = UTF8.GetBytes(Message);

                // Step 5. Attempt to encrypt the string
                try
                {
                    ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                    Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
                }
                finally
                {
                    // Clear the TripleDes and Hashprovider services of any sensitive information
                    TDESAlgorithm.Clear();
                    HashProvider.Clear();
                }

                // Step 6. Return the encrypted string as a base64 encoded string
                return Convert.ToBase64String(Results);
            }
            catch (Exception ex)
            {
                //ErrorHandler.LogError(ex);
                return "";
            }
        }
        public string Decrypt(string Message)
        {
            try
            {
                if (!string.IsNullOrEmpty(Message) && (Message.StartsWith("sk=") || Message.StartsWith("cd=") || Message.StartsWith("rb=")))
                {
                    return "";
                }

                byte[] Results;
                System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

                // Step 1. We hash the passphrase using MD5
                // We use the MD5 hash generator as the result is a 128 bit byte array
                // which is a valid length for the TripleDES encoder we use below

                MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(encrypyDecrypyKey));

                // Step 2. Create a new TripleDESCryptoServiceProvider object
                TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

                // Step 3. Setup the decoder
                TDESAlgorithm.Key = TDESKey;
                TDESAlgorithm.Mode = CipherMode.ECB;
                TDESAlgorithm.Padding = PaddingMode.PKCS7;

                // Step 4. Convert the input string to a byte[]
                Message = Message.Replace(' ', '+');
                Message = Message.Replace('-', '+');
                Message = Message.Replace('_', '/');

                byte[] DataToDecrypt = Convert.FromBase64String(Message);

                // Step 5. Attempt to decrypt the string
                try
                {
                    ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                    Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
                }
                finally
                {
                    // Clear the TripleDes and Hashprovider services of any sensitive information
                    TDESAlgorithm.Clear();
                    HashProvider.Clear();
                }

                // Step 6. Return the decrypted string in UTF8 format
                return UTF8.GetString(Results);
            }
            catch (Exception ex)
            {
                //ErrorHandler.LogError(ex, Message);
                return "";
            }

        }
        #endregion

        #region Encryption/decryption of URL
        private const string Url_ENCRYPTION_KEY = "s_jd$G9M0";
        private readonly static byte[] URL_SALT = Encoding.ASCII.GetBytes(Url_ENCRYPTION_KEY.Length.ToString());

        public static string EncryptUrl(string inputText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(inputText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    inputText = Convert.ToBase64String(ms.ToArray());
                    inputText = inputText.Replace("=", "-") + "76";

                    ////////if (Regex.Matches(inputText, "-").Count == 1)
                    ////////{
                    ////////    inputText = inputText.Replace("-", "=");
                    ////////}
                }
            }
            return inputText;


        }

        public static string DecryptUrl(string inputText)
        {
            try
            {
                inputText = inputText.Replace("76", "").Replace("-","=");
                string EncryptionKey = "MAKV2SPBNI99212";
                inputText = inputText.Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(inputText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        inputText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }


              
                return inputText;


            }
            catch (Exception ex)
            {
                //ErrorHandler.LogError(ex);
            }
            return "";
        }

        public static string[] GetDecryptUrlValues(string encryptedUrlstring)
        {
            if (!string.IsNullOrEmpty(encryptedUrlstring))
            {
                string strdecrypt = DecryptUrl(encryptedUrlstring);
                if (!string.IsNullOrEmpty(strdecrypt))
                {
                    return strdecrypt.Split(';');
                }
            }

            return null;
        }

        #endregion
    }
}