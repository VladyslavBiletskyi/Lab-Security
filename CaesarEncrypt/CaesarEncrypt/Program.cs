using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarEncrypt
{
    class Program
    {
        public static string ALPHABET = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-+_=()[]{}.,!? абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        static void Main(string[] args)
        {
            Controller();
        }
        public static void Controller()
        {
            
            char mode;
            string text; int key;
            while (true)
            {
                Console.WriteLine("###############################\nChoose encrypt, decrypt or exit (e/d/x)");
                mode = Console.ReadLine()[0];
                switch (mode)
                {
                    case 'e':
                        Console.WriteLine("Input your text");
                        text = Console.ReadLine();
                        Console.WriteLine("Input the key");
                        try
                        {
                            key = int.Parse(Console.ReadLine())%ALPHABET.Length;
                        }
                        catch
                        {
                            Console.WriteLine("Wrong parameter, try again");
                            continue;
                        }
                        Console.WriteLine("Your cryptogramm is:\n" + EncryptCaesar(text, key) + "\n###############\n");
                        break;
                    case 'd':
                        Console.WriteLine("Input your text");
                        text = Console.ReadLine();
                        Console.WriteLine("Input the key");
                        try
                        {
                            key = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Wrong parameter, try again");
                            continue;
                        }
                        Console.WriteLine("Your cryptogramm is:\n" + DecryptCaesar(text, key) + "\n###############\n");
                        break;
                    case 'x':
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Wrong parameter, try again");
                        break;
                }
            }
        }
        public static string EncryptCaesar(string text, int key)
        {
            StringBuilder ans = new StringBuilder();
            char letter = ' ';
            int index;
            foreach(char element in text)
            {
                letter = ((index = ALPHABET.IndexOf(element)) != -1) ? ALPHABET[Math.Abs((index + key) % ALPHABET.Length)] : element;
                ans.Append(letter);
            }
            return ans.ToString();
        }
        public static string DecryptCaesar(string text,int key)
        {
            StringBuilder ans = new StringBuilder();
            char letter = ' ';
            int index;
            foreach (char element in text)
            {
                letter = ((index = ALPHABET.IndexOf(element)) != -1) ? ALPHABET[Math.Abs(((index+ALPHABET.Length) - key) % ALPHABET.Length)] : element;
                ans.Append(letter);
            }
            return ans.ToString();
        }
    }
}
