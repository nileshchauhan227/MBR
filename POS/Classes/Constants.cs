using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace POS.Classes
{
    public class Constants
    {

        public const string encryptKey = "SilverAmreli";
        public class ConfigurationKey
        {
            public static readonly string BillPrintOption = "Bill Print Option";
            public static readonly string KOTPrintOption = "KOT Print Option";
            public static readonly string PrintBillwhileLoginwithnormaluser = "Print Bill while Login with normal user";
            public static readonly string GeneralDiscountValue = "General DiscountValue";
            public static readonly string BillSeries = "Bill Series";
            public static readonly string KOTDefaultPrinter = "KOT Default Printer";
            public static readonly string BillDefaultPrinter = "Bill Default Printer";
            public static readonly string Discount = "Discount";
            public static readonly string ManualDiscount = "Manual Discount";
            public static readonly string AutoLogin = "Auto Login";
            public static readonly string KOTCompulsary = "KOT Compulsary";
            public static readonly string AutoCutter = "Auto Cutter";
            public static readonly string ServiceTaxEnabled = "ServiceTaxEnabled";
            public static readonly string DiscountPercentage = "Discount Percentage";
            public static readonly string PrintMessage = "Print Message";
            public static readonly string ShopName = "ShopName";
            public static readonly string InvoiceName = "InvoiceName";
            public static readonly string Firm = "Firm";
            public static readonly string Add1 = "Add1";
            public static readonly string Add2 = "Add2";
            public static readonly string ServiceTaxPercentage = "ServiceTaxPercentage";
            public static readonly string GST_TIN = "GST_TIN";
            public static readonly string CST_TIN = "CST_TIN";
            public static readonly string GroupWiseKOTPrint = "Group Wise KOT Print";
            public static readonly string GSTTINDATE = "GSTTINDATE";
            public static readonly string CSTTINDATE = "CSTTINDATE";
            public static readonly string Email = "Email";
            public static readonly string Phone = "Phone";
            public static readonly string ActivationFromDate = "Activation From Date";
            public static readonly string ActivationToDate = "Activation To Date";
            public static readonly string ReportHeader = "ReportHeader";
            public static readonly string ManageInventory = "ManageInventory";
            public static readonly string DatabasePath = "DatabasePath";
            public static readonly string DatabaseBackupPath = "DatabaseBackupPath";
            
        }
    }
    public class Enumes
    {
        public enum FecthRecord : int
        {
            Previous = 1,
            Next = 2,
            Last = 3
        }
    }
    public static class Extensions
    {
        /// <summary>
        /// Gets the date time.
        /// </summary>
        /// <param name="strToConvertIntoDateTime">The string to convert into date time.</param>
        /// <returns></returns>
        public static DateTime GetDateTime(this string strToConvertIntoDateTime)
        {
            DateTime dtToReturn;
            if (!DateTime.TryParseExact(strToConvertIntoDateTime, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dtToReturn))
            {
                throw new Exception("Date is not in correct format");
            }
            else
            {
                return dtToReturn;
            }
        }

        public static string GetShortDateString(this DateTime dt)
        {
            return dt.ToString("dd/MM/yyyy");
        }
        public static string GetDecimalString(this decimal value)
        {
            return value.ToString("0.00");
        }
    }
    public static class Encrypt_Decrypt
    {
        /// <summary>
        /// Converting Existing String Into Encrpted Format
        /// </summary>
        /// <param name="Text">The Text of the record to update.</param>
        /// <param name="Key">The Key of the record to update.</param>
        /// <returns>Return String Representing Encrypted Text</returns>
        /// <remarks></remarks>
        public static string EncryptText(string Text, string Key)
        {
            return Encrypt(Text, Key);
        }

        /// <summary>
        /// Decrypts the text.
        /// </summary>
        /// <param name="Text">The text.</param>
        /// <param name="Key">The key.</param>
        /// <returns>String Representing Decrypted Text</returns>
        /// <remarks></remarks>
        public static string DecryptText(string Text, string Key)
        {
            return Decrypt(Text, Key);
        }

        /// <summary>
        /// Encrypts the specified STR text.
        /// </summary>
        /// <param name="strText">The STR text.</param>
        /// <param name="strEncrKey">The STR encr key.</param>
        /// <returns>String Representing Encrypted Text</returns>
        /// <remarks></remarks>
        private static string Encrypt(string strText, string strEncrKey)
        {
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byKey = System.Text.Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(strText);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }

        /// <summary>
        /// Decrypts the specified STR text.
        /// </summary>
        /// <param name="strText">The STR text.</param>
        /// <param name="sDecrKey">The s decr key.</param>
        /// <returns>Representing Decrypted Text</returns>
        /// <remarks></remarks>
        private static string Decrypt(string strText, string sDecrKey)
        {
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byte[] inputByteArray = new byte[strText.Length + 1];

            byKey = System.Text.Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(strText);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }
    }
}
