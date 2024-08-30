using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using Api_ZserviceDesk.Controllers;

namespace Api_ZserviceDesk.Models
{
    public class CryptographyModel
    {
        public string Encrypt(string Password, string EncryptionKey)
        {

            byte[] clearBytes = Encoding.Unicode.GetBytes(Password);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        try
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        catch (Exception ex)
                        {
                            ExceptionTracking et = new ExceptionTracking();
                            et.status = ((System.Net.WebException)ex.InnerException) != null ? ((System.Net.WebException)ex.InnerException).Status.ToString() : null;
                            et.message = ex.Message;
                            et.exception_message = ex.InnerException != null ? ex.InnerException.Message : null;
                            et.exception_type = ex.Message;
                            et.StackTrace = ex.StackTrace;
                            new UtilityController().InsException(et);
                            return ex.Message;
                        }
                    }
                    Password = Convert.ToBase64String(ms.ToArray());
                    Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(Password));
                }
            }
            return Password;
        }
        public string Decrypt(string Password, string EncryptionKey)
        {
            Password = Encoding.UTF8.GetString(Convert.FromBase64String(Password));
            byte[] cipherBytes = Convert.FromBase64String(Password);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        try
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        catch (Exception ex)
                        {
                            ExceptionTracking et = new ExceptionTracking();
                            et.status = ((System.Net.WebException)ex.InnerException) != null ? ((System.Net.WebException)ex.InnerException).Status.ToString() : null;
                            et.message = ex.Message;
                            et.exception_message = ex.InnerException != null ? ex.InnerException.Message : null;
                            et.exception_type = ex.Message;
                            et.StackTrace = ex.StackTrace;
                            new UtilityController().InsException(et);
                            return ex.Message;
                        }

                    }
                    Password = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return Password;
        }
    }
}