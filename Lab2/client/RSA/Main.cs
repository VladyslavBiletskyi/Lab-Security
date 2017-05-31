using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RSA
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Logger.Init(richTextBox1);
        }
       
        string publicKeyXML = "";
   
        Http currentHttp = new Http();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                currentHttp = new Http();
                publicKeyXML = Encoding.UTF8.GetString(Convert.FromBase64String(currentHttp.HttpGETrequest("http://bpid-labas.tk/lab2/")));
                Logger.Log("Публичный ключ получен!");
                Logger.Log(publicKeyXML, false);
                button2.Enabled = true;
                button3.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Main_Load(object sender, EventArgs e)
        {
            //string t1 = "";
            //string t2 = "";
            // RSA.AssignNewKey(ref privateKeyXML, ref publicKeyXML);
            //t1 = Convert.ToBase64String(Encoding.UTF8.GetBytes(privateKeyXML));
            //t2 = Convert.ToBase64String(Encoding.UTF8.GetBytes(publicKeyXMl));
            //publicKeyXML = Encoding.UTF8.GetString(Convert.FromBase64String("PFJTQUtleVZhbHVlPg0KICA8TW9kdWx1cz5BS3NWblhndWFobjE1dndwWENCWVJDV0tPWDNjSFRnME82VU9RWFpYOXhVUkxHbEdSSFpFN1Z3enhyV2UzdlVzOVdIZGVWekhlcnVtZzdPdEtzbSsyZmY1a3RQNXRvV242TldIQ1pqemlESDlUV3NTb2xudVJzTzUwaHVRZWxoaHJGcVlTcmRtUzNsVC9VTHhHaDR1bWFkU05WRlZEQ0Y5Mnd0V3I0ZnZKRXhEPC9Nb2R1bHVzPg0KICA8RXhwb25lbnQ+QVFBQjwvRXhwb25lbnQ+DQo8L1JTQUtleVZhbHVlPg=="));
            //string testCrypt = RSA.Encrypt("Hello123", publicKeyXML);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cryptedData = RSA.Encrypt(textBox1.Text, publicKeyXML);
            Logger.Log("Данные для отправки: ");
            Logger.Log(cryptedData,false);
            Logger.Log("Отпрвка на сервер...");
            string response = currentHttp.HttpPOSTrequest("http://bpid-labas.tk/lab2/", "data=" + Uri.EscapeDataString(cryptedData));
            Logger.Log("Ответ от сервера: ");
            Logger.Log(response, false);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string decrypted = RSA.Encrypt(textBox2.Text, publicKeyXML);
            Logger.Log("Закриптованные данные: ");
            Logger.Log(decrypted,false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
}
