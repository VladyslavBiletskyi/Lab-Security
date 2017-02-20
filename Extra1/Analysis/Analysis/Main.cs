using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analysis
{
    public partial class Main : Form
    {
        const int BORDER = 20;
        private static string ALPHABET = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-+_=()[]{}.,!?абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        public Main()
        {
            InitializeComponent();
        }

        private void BeginButton_Click(object sender, EventArgs e)
        {
            Analyse(CryptogrammBox.Text);
        }
        public void Analyse(string text)
        {
            CryptoAnalyzer analyser = new CryptoAnalyzer();
            if (!analyser.IsSuccess)
            {
                return;
            }
            int[] keys = analyser.GetKeyVariants(text);
            KeysBox.DataSource = keys;
        }
        public void MoveLetters(int key)
        {
            BrootedTextBox.Clear();
            foreach (char element in CryptogrammBox.Text)
            {
                if (ALPHABET.IndexOf(element) != -1)
                {
                    BrootedTextBox.Text += ALPHABET[(ALPHABET.IndexOf(element) + key + ALPHABET.Length)%ALPHABET.Length];
                }
                else
                {
                    BrootedTextBox.Text += element;
                }
            }
        }

        private void KeysBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (KeysBox.SelectedIndex != -1)
            {
                int key = (int)KeysBox.SelectedItem;
                SampleBox.Clear();
                int border = (CryptogrammBox.Text.Length > BORDER) ? BORDER : CryptogrammBox.Text.Length;
                for (int i = 0; i < border; i++)
                {
                    SampleBox.Text += (ALPHABET.IndexOf(CryptogrammBox.Text[i]) != -1) ?
                    ALPHABET[(ALPHABET.IndexOf(CryptogrammBox.Text[i]) + key + ALPHABET.Length) % ALPHABET.Length] : CryptogrammBox.Text[i];
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (KeysBox.SelectedIndex != -1)
            {
                MoveLetters((int)KeysBox.SelectedItem);
            }
        }
    }
}
