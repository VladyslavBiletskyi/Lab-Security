
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Analysis
{

    class CryptoAnalyzer
    {
        public bool IsSuccess = true;
        private const int TAKE_COUNT= 4;
        private static Dictionary<char, double>[] Statistics { set; get; }
        private static string ALPHABET = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-+_=()[]{}.,!?абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private static Dictionary<char, double> stat { set; get; }
        public CryptoAnalyzer()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream("Statistics.st", FileMode.OpenOrCreate);
            try
            {
                Statistics = (Dictionary<char, double>[])formatter.Deserialize(stream);
                stream.Close();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка! Отсутствуют данные для анализа");
                IsSuccess = false;
            }
        }
        private void GetStat(string text)
        {
            Dictionary<char, int> counts = new Dictionary<char, int>();
            stat=new Dictionary<char, double>();
            foreach (char element in ALPHABET)
            {
                stat.Add(element, 0);
            }
            foreach (char element in text)
            {
                if (counts.ContainsKey(element))
                {
                    counts[element]++;
                }
                else
                {
                    counts.Add(element, 1);
                }
            }
            foreach (var element in counts)
            {
                if (stat.ContainsKey(element.Key))
                {
                    stat[element.Key] = counts[element.Key] / (double)text.Length;
                }
            }
        }
        public int[] GetKeyVariants(string text)
        {
            List<int> variants = new List<int>();
            GetStat(text);
            List<KeyValuePair<char, double>> pairs_clear;
            int almostKey = 0;
            Dictionary<int, int> movings = new Dictionary<int, int>();
            List<KeyValuePair<char, double>> pairs_crypto = new List<KeyValuePair<char, double>>();
            foreach (var element in stat.OrderByDescending(x => x.Value).Take(TAKE_COUNT))
            {
                pairs_crypto.Add(element);
            }
            foreach (var style in Statistics)
            {
                pairs_clear = new List<KeyValuePair<char, double>>();
                foreach (var element in style.OrderByDescending(x => x.Value).Take(TAKE_COUNT))
                {
                    pairs_clear.Add(element);
                }               
                for (int i = 0; i < TAKE_COUNT; i++)
                {
                    for (int j = 0; j < TAKE_COUNT; j++)
                    {
                        almostKey = ALPHABET.IndexOf(pairs_clear[i].Key) - ALPHABET.IndexOf(pairs_crypto[j].Key);
                        if (movings.ContainsKey(almostKey))
                        {
                            movings[almostKey]++;
                        }
                        else
                        {
                            movings.Add(almostKey, 1);
                        }
                    }
                }
            }
            return movings.Keys.Where(x => movings[x] > 1).ToArray();
        }
    }
}
