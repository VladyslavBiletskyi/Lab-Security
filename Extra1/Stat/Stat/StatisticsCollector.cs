using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Stat
{
    class StatisticsCollector
    {
        private static Dictionary<char, double>[] Statistics { set; get; }
        private static string ALPHABET = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-+_=()[]{}.,!?абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        public StatisticsCollector()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream("Statistics.st", FileMode.OpenOrCreate);
            try
            {
                Statistics = (Dictionary < char, double> [])formatter.Deserialize(stream);
                stream.Close();
            }
            catch
            {
                Statistics = new Dictionary<char, double>[MainForm.Styles.Length];
                for (int i = 0; i < Statistics.Length; i++)
                {
                    Statistics[i] = new Dictionary<char, double>();
                    foreach (char element in ALPHABET)
                    {
                        Statistics[i].Add(element, 0);
                    }
                }
                stream.Close();
                SaveStat();
            }
        }
        public void SaveStat()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream("Statistics.st", FileMode.OpenOrCreate);
            formatter.Serialize(stream, Statistics);
            stream.Close();
        }
        public Dictionary<char, double> GetStat(int style)
        {
            return (style <= Statistics.Length) ? Statistics[style] : null;
        }
        public void ImproveStat(int style,string text)
        {
            Dictionary<char, int> counts = new Dictionary<char, int>();
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
                if (Statistics[style].ContainsKey(element.Key))
                {
                    if (Statistics[style][element.Key] != 0)
                    {
                        Statistics[style][element.Key] = (Statistics[style][element.Key] + (element.Value / (double)text.Length))/2.0;
                    }
                    else
                    {
                        Statistics[style][element.Key] = (element.Value / (double)text.Length);
                    }
                }
            }
            SaveStat();
        }

    }
}
