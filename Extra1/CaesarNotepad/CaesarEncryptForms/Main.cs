using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaesarEncryptForms
{
    public partial class Main : Form
    {
        public static string ALPHABET = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-+_=()[]{}.,!?абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        public Main()
        {
            InitializeComponent();
            numericUpDown1.Maximum = ALPHABET.Length;
        }

        private void BeginButton_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0)
            {
                CryptoBox.Text = EncryptCaesar(PureTextBox.Text, (int)numericUpDown1.Value);
            }
        }
        public static string EncryptCaesar(string text, int key)
        {
            StringBuilder ans = new StringBuilder();
            char letter = ' ';
            int index;
            foreach (char element in text)
            {
                letter = ((index = ALPHABET.IndexOf(element)) != -1) ? ALPHABET[Math.Abs((index + key) % ALPHABET.Length)] : element;
                ans.Append(letter);
            }
            return ans.ToString();
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0)
            {
                CryptoBox.Text = DecryptCaesar(PureTextBox.Text, (int)numericUpDown1.Value);
            }
        }
        public static string DecryptCaesar(string text, int key)
        {
            StringBuilder ans = new StringBuilder();
            char letter = ' ';
            int index;
            foreach (char element in text)
            {
                letter = ((index = ALPHABET.IndexOf(element)) != -1) ? ALPHABET[Math.Abs(((index + ALPHABET.Length) - key) % ALPHABET.Length)] : element;
                ans.Append(letter);
            }
            return ans.ToString();
        }

    }
}
