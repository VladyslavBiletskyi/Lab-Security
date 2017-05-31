using System;
using System.IO;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace DigitalSigner
{
    
    public partial class MainForm : Form
    {
        private RSAParameters rsaParams;
        private byte hash4Bit;
        bool MayIGo = false;
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fileStream = new FileStream(openFileDialog1.FileName, FileMode.Open))
                {
                    SHA1 sha = SHA1.Create();
                    byte[] hash = sha.ComputeHash(fileStream);
                    hash4Bit = (byte) (hash[hash.Length - 1] & 0b00001111);
                    hashBox.Text = hash4Bit + "";
                    MayIGo = true;
                }
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            if (!MayIGo)
            {
                MessageBox.Show("Choose file!");
                return;
            }           
            RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(1024);
            rsaParams = rsaProvider.ExportParameters(true);
            BigInteger E = new BigInteger(rsaParams.Exponent);
            BigInteger D = new BigInteger(rsaParams.D);
            BigInteger N = new BigInteger(rsaParams.Modulus);
            keysBox.Text = string.Format("E = {0}\nD = {1}\nN = {2}\n", E, D, N);
            var encode = rsaProvider.Encrypt(new byte[] {hash4Bit}, false);
            signatureBox.Text = new BigInteger(encode).ToString();
            using (FileStream stream = new FileStream(
                openFileDialog1.FileName.Replace(openFileDialog1.SafeFileName, "Sign"+openFileDialog1.SafeFileName), FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                rsaParams.D = null;
                rsaParams.Modulus = null;
                formatter.Serialize(stream, new Sign{
                    E = rsaParams.Exponent,
                    P = rsaParams.P,
                    Q = rsaParams.Q,
                    DQ = rsaParams.DQ,
                    DP = rsaParams.DP,
                    IQ = rsaParams.InverseQ,
                    Bytes = encode});
            }
        }

        private void CheckSignature_Click(object sender, EventArgs e)
        {
            Sign sign;
            byte[] crypto;
            if (checkFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            using (FileStream stream = new FileStream(checkFileDialog.FileName, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                
                try
                {
                    sign = (Sign) formatter.Deserialize(stream);
                }
                catch
                {
                    MessageBox.Show("Error!");
                    return;
                }
                rsaParams = new RSAParameters()
                {
                    Exponent = sign.E,
                    P = sign.P,
                    Q = sign.Q,
                    DQ = sign.DQ,
                    DP = sign.DP,
                    InverseQ = sign.IQ
                };
                crypto = sign.Bytes;
            }
            rsaParams.D = BigInteger.Parse(dBox.Text).ToByteArray();
            rsaParams.Modulus = BigInteger.Parse(nBox.Text).ToByteArray();
            RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider();
            try
            {
                rsaProvider.ImportParameters(rsaParams);
                byte[] array = new BigInteger(
                        rsaProvider.Decrypt(crypto, false))
                    .ToByteArray();
                decryptHashBox.Text = new BigInteger(array).ToString();
                resultBox.Text = (array[array.Length - 1] == hash4Bit).ToString();
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }
    }
    [Serializable]
    public class Sign
    {
        public byte[] E;
        public byte[] DQ;
        public byte[] DP;
        public byte[] Q;
        public byte[] P;
        public byte[] IQ = {0};
        public byte[] Bytes;
    }
}
