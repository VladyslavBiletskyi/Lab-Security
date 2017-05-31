using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace RSA
{
    class RSA
    {
        public static string Sign(string rawText, string decryptedXmlPkey)
        {
            SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
            byte[] buffer = Encoding.ASCII.GetBytes(rawText);
            buffer = cryptoTransformSHA1.ComputeHash(buffer);
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.FromXmlString(decryptedXmlPkey);
            RSAPKCS1SignatureFormatter RSAFormatter = new RSAPKCS1SignatureFormatter(RSA);
            RSAFormatter.SetHashAlgorithm("SHA1");
            byte[] SignedHash = RSAFormatter.CreateSignature(buffer);
            return Convert.ToBase64String(SignedHash);
        }
        public static string Encrypt(string rawText, string pubKeyXml)
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(1024);
            RSAParameters RParams = new RSAParameters();
            XDocument Doc = XDocument.Parse(pubKeyXml);
            XElement RSAKey = Doc.Element("RSAKeyValue");
            RParams.Modulus = parseBytesFromXML(RSAKey, "Modulus", true);
            RParams.Exponent = parseBytesFromXML(RSAKey, "Exponent",true);
            RSA.ImportParameters(RParams);           
           
            return Convert.ToBase64String(RSA.Encrypt(Encoding.UTF8.GetBytes(rawText), false));
           
        }
       
        public static string Decrypt(string crypted, string privateKey)
        {
            try
            {
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(1024);
                RSAParameters RParams = new RSAParameters();
                XDocument Doc = XDocument.Parse(privateKey);
                XElement RSAKey = Doc.Element("RSAKeyValue");

                RParams.Modulus = parseBytesFromXML(RSAKey, "Modulus",true);
                RParams.Exponent = parseBytesFromXML(RSAKey, "Exponent");
                RParams.P = parseBytesFromXML(RSAKey, "P", true);
                RParams.Q = parseBytesFromXML(RSAKey, "Q", true);
                RParams.DP = parseBytesFromXML(RSAKey, "DP", true);
                RParams.DQ = parseBytesFromXML(RSAKey, "DQ", true);
                RParams.InverseQ = parseBytesFromXML(RSAKey, "InverseQ", true);
                RParams.D = parseBytesFromXML(RSAKey, "D");

                RSA.ImportParameters(RParams);
                return Encoding.UTF8.GetString(RSA.Decrypt(Convert.FromBase64String(crypted), false));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
           
              

        }
        public static void CreateNewKeysPair(ref string privateKey, ref string publicKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);
            string tempKey = rsa.ToXmlString(true);
            privateKey = tempKey;
            tempKey = rsa.ToXmlString(false);
            publicKey = tempKey;
        }

        public static string iterateBytes(byte[] input)
        {
            StringBuilder output = new StringBuilder();
            output.Append(string.Format("[{0}]", input.Length));
            output.Append(" {" + input[0].ToString());
            for (int i = 1; i < input.Length; i++)
            {
                output.Append(" " + input[i].ToString());
            }
            output.Append("}");
            return output.ToString();
        }
        private static byte[] parseBytesFromXML(XElement RSAKey, string name, bool skipZeroByte = false)
        {
            try
            {
                byte[] temp = Convert.FromBase64String(RSAKey.Element(name).Value.ToString());
                return skipZeroByte ? (temp[0] == 0 ? temp.Skip(1).ToArray() : temp) : temp;
            }
            catch (Exception ex)
            {
                throw new Exception("Error from parseBytesFromXML: " + ex.Message);
            }
        }



        //StringBuilder SB = new StringBuilder();
        //SB.AppendLine("-----------------------------------");
        //SB.AppendLine("privateKey, size:" + RSA.KeySize.ToString());
        //SB.AppendLine("Modulus: " + iterateBytes(RParams.Modulus));
        //SB.AppendLine("Exponent: " + iterateBytes(RParams.Exponent));
        //SB.AppendLine("P: " + iterateBytes(RParams.P));
        //SB.AppendLine("Q: " + iterateBytes(RParams.Q));
        //SB.AppendLine("DP: " + iterateBytes(RParams.DP));
        //SB.AppendLine("DQ: " + iterateBytes(RParams.DQ));
        //SB.AppendLine("InverseQ: " + iterateBytes(RParams.InverseQ));
        //SB.AppendLine("D: " + iterateBytes(RParams.D));
        //SB.AppendLine("-----------------------------------");
        //string gg = SB.ToString();

    }
}
