using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEC
{
    public partial class Form1 : Form
    {
        int[] initialPermutation = new int[] {
            57,  49,  41,  33,  25,  17,   9,  1,
            59,  51,  43,  35,  27,  19,  11,  3,
            61,  53,  45,  37,  29,  21,  13,  5,
            63,  55,  47,  39,  31,  23,  15,  7,
            56,  48,  40,  32,  24,  16,   8,  0,
            58,  50,  42,  34,  26,  18,  10,  2,
            60,  52,  44,  36,  28,  20,  12,  4,
            62,  54,  46,  38,  30,  22,  14,  6
        }; // chek

        int[] finalPermutation = new int[]
        {
            39,  7,   47,  15,  55,  23,  63,  31,
            38,  6,   46,  14,  54,  22,  62,  30,
            37,  5,   45,  13,  53,  21,  61,  29,
            36,  4,   44,  12,  52,  20,  60,  28,
            35,  3,   43,  11,  51,  19,  59,  27,
            34,  2,   42,  10,  50,  18,  58,  26,
            33,  1,   41,   9,  49,  17,  57,  25,
            32,  0,   40,   8,  48,  16,  56,  24
        };   // chek

        int[] E = new int[]
        {
            31,   0,   1,   2,   3,   4,
             3,   4,   5,   6,   7,   8,
             7,   8,   9,  10,  11,  12,
            11,  12,  13,  14,  15,  16,
            15,  16,  17,  18,  19,  20,
            19,  20,  21,  22,  23,  24,
            23,  24,  25,  26,  27,  28,
            27,  28,  29,  30,  31,  0
        };                  // chek

        int[][,] S = new int[8][,];

        int[] P = new int[]
        {
            15,  6 ,  19,  20,  28,  11,  27,  16,
            0 ,  14,  22,  25,  4 ,  17,  30,  9 ,
            1 ,  7 ,  23,  13,  31,  26,  2 ,  8 ,
            18,  12,  29,  5 ,  21,  10,  3 ,  24
        };                  // chek

        int[] C = new int[]
        {
            56,  48,  40,  32,  24,  16,  8,   0,   57,  49,  41,  33,  25,  17,
             9,   1,  58,  50,  42,  34,  26,  18,  10,  2,   59,  51,  43,  35
        };                  // chek

        int[] D = new int[]
        {
            62,  54,  46,  38,  30,  22,  14,  6,   61,  53,  45,  37,  29,  21,
            13,  5,   60,  52,  44,  36,  28,  20,  12,   4,  27,  19,  11,  3
        };                  // chek

        int[] shift = new int[]
        {
            1,   1,   2,   2,   2,  2,   2,   2,   1,   2,   2 ,  2,   2,   2,   2,   1
        };              // chek

        int[] K = new int[]
        {
            13,  16,  10,  23,  0,   4,   2,   27,  14,  5,   20,  9,  22,  18,  11,  3,
            25,  7,   15,  6,   26,  19,  12,  1,   40,  51,  30,  36,  46,  54,  29,  39,
            50,  44,  32,  47,  43,  48,  38,  55,  33,  52,  45,  41,  49,  35,  28,  31
        };                  // chek

        Encoding enc = new UTF8Encoding(true, false);
        public Form1()
        {
            InitializeComponent();
            S[0] = new int[,]
            {
                { 14,  4, 13,  1,  2, 15,  11,   8,   3,  10,   6,  12,   5,   9,   0,   7 },
                { 0,  15,  7,  4, 14,  2,  13,   1,  10,   6,  12,  11,   9,   5,   3,   8 },
                { 4,   1, 14,  8, 13,  6,   2,  11,  15,  12,   9,   7,   3,  10,   5,   0 },
                { 15, 12,  8,  2,  4,  9,   1,   7,   5,  11,   3,  14,  10,   0,   6,   13}
            };
            S[1] = new int[,]
            {
                { 15,  1,   8,   14,  6,   11,  3,   4,   9,   7 ,  2  , 13 , 12  ,0 ,  5 ,  10 },
                { 3,   13,  4,   7,   15 , 2   ,8  , 14,  12 , 0 ,  1,   10,  6 ,  9 ,  11 , 5 },
                { 0 ,  14 , 7 ,  11,  10 , 4,   13 , 1,   5  , 8  , 12 , 6  , 9  , 3 ,  2 ,  15 },
                { 13  ,8  , 10  ,1 ,  3 ,  15 , 4 ,  2 ,  11 , 6  , 7  , 12  ,0 ,  5 ,  14,  9 }
            };
            S[2] = new int[,]
            {
                { 10,  0,   9,   14,  6,   3,   15,  5,   1,   13,  12,  7,   11,  4,   2,   8 },
                { 13,  7,   0,   9,   3,   4,   6,   10,  2 ,  8,   5,   14,  12,  11,  15,  1 },
                { 13,  6,   4,   9,   8,   15,  3,   0,   11,  1,   2,   12,  5,   10,  14,  7 },
                { 1,   10,  13,  0,   6,   9,   8,   7,   4,   15,  14,  3,   11,  5,   2,   12 }
            };
            S[3] = new int[,]
            {
                { 7,   13,  14,  3,   0,   6,   9,   10,  1,   2,   8,   5,   11,  12,  4,   15 },
                { 13,  8,   11,  5,   6,   15,  0,   3,   4,   7,   2,   12,  1,   10,  14,  9 },
                { 10,  6,   9,   0,   12,  11,  7,   13,  15,  1,   3,   14,  5,   2,   8,   4 },
                { 3,   15,  0,   6,   10,  1,   13,  8,   9,   4 ,  5 ,  11,  12,  7,   2,   14 }
            };
            S[4] = new int[,]
            {
                { 2,   12,  4,   1,   7,   10,  11,  6,   8,   5,   3,   15,  13,  0,   14,  9 },
                { 14,  11,  2,   12,  4,   7,   13,  1,   5,   0,   15,  10,  3,   9,   8,   6 },
                { 4,   2,   1,   11,  10,  13,  7,   8,   15,  9,   12,  5,   6,   3,   0,   14 },
                { 11,  8,   12,  7,   1,   14,  2,   13,  6,   15,  0,   9,   10,  4,   5,   3 }
            };
            S[5] = new int[,]
            {
                {12,  1,   10,  15,  9,   2,   6,   8,   0,   13,  3,   4,   14,  7,   5,   11 },
                {10,  15,  4,   2,   7,   12,  9,   5,   6,   1,   13,  14,  0,   11,  3,   8 },
                {9,   14,  15,  5,   2,   8,   12,  3,   7,   0,   4,   10,  1,   13,  11,  6 },
                {4,   3,   2,   12,  9,   5,   15,  10,  11,  14,  1,   7,   6,   0,   8,   13 }
            };
            S[6] = new int[,]
            {
                { 4,   11,  2,   14,  15,  0,   8,   13,  3,   12,  9,   7,   5,   10,  6,   1 },
                { 13,  0,   11,  7,   4,   9,   1,   10,  14,  3,   5,   12,  2,   15,  8,   6 },
                { 1,   4,   11,  13,  12,  3,   7,   14,  10,  15,  6,   8,   0,   5,   9,   2 },
                { 6,   11,  13,  8,   1,   4,   10,  7,   9,   5,   0,   15,  14,  2,   3,   12 }
            };
            S[7] = new int[,]
            {
                { 13,  2,   8,   4,   6,   15,  11,  1,   10,  9,   3,   14,  5,   0,   12,  7 },
                { 1,   15,  13,  8,   10,  3,   7,   4,   12,  5,   6,   11,  0,   14,  9,   2 },
                { 7,   11,  4,   1,   9,   12,  14,  2,   0,   6,   10,  13,  15,  3,   5,   8 },
                { 2,   1,   14,  7,   4,   10,  8,   13,  15,  12,  9,   0,   3,   5,   6,   11 }
            };
        }
        private MyBitArray InitialPermutation(MyBitArray sourceData)
        {
            MyBitArray encryptedData = new MyBitArray(64);
            for (int i = 0; i < 64; i++)
            {
                encryptedData[i] = sourceData[initialPermutation[i]];
            }
            return encryptedData;
        }

        private MyBitArray FinalPermutation(MyBitArray sourceData)
        {
            MyBitArray encryptedData = new MyBitArray(64);
            for (int i = 0; i < 64; i++)
            {
                encryptedData[i] = sourceData[finalPermutation[i]];
            }
            return encryptedData;
        }

        private MyBitArray PPermutation( MyBitArray B_32)
        {
            MyBitArray pPermutation = new MyBitArray(32);
            // Перестановка P
            for (int i = 0; i < 32; i++)
            {
                pPermutation[i] = B_32[P[i]];
            }
            return pPermutation;
        }
        private MyBitArray CycleFeistel(MyBitArray sourceData, MyBitArray key, int numberOfCycle)
        {
            MyBitArray encryptedData = new MyBitArray(64);

            MyBitArray R = new MyBitArray(32);
            MyBitArray L = new MyBitArray(32);
            MyBitArray rExpanded;
            MyBitArray k;
            MyBitArray[] B = new MyBitArray[8];
            MyBitArray B_32;
            MyBitArray pPermutation;


            // разделение на 2 блока
            for (int i = 0; i < 32; i++)
            {
                L[i] = sourceData[i];
                R[i] = sourceData[32 + i];
            }

            // расширение правой части
            rExpanded = ExtendHalf(R);

            // 48-битный ключ
            k = GenerateKey(key, numberOfCycle);

            // разбитие расширеной правой части на 8 блоков по 6 бит
            MyBitArray Xored = new MyBitArray(48);
            for (int i = 0; i < 48; i++)
            {
                Xored[i] = rExpanded[i] ^ k[i];
            }

            for (int i = 0; i < 8; i++)
            {
                B[i] = new MyBitArray(6);
                for (int j = 0; j < 6; j++)
                {
                    B[i][j] = Xored[(i * 6) + j]; 
                }
                
            }
           

            // получение B` из таблици Значение функции  f(R[i-1], k[i]) (32 бит)
            int B_before_P = 0;
            for (int i = 0; i < 8; i++)
            {
                byte[] a;
                byte[] b;

                MyBitArray temp = new MyBitArray(new bool[] { B[i][0], B[i][5] });
                a = temp.GetBytesArray();
                temp = new MyBitArray(new bool[] { B[i][1], B[i][2], B[i][3], B[i][4] });
                b = temp.GetBytesArray();

                B_before_P = B_before_P | (S[i][a[0], b[0]] << (32 - ((i + 1) * 4)));
            }

            B_32 = new MyBitArray(new int[] { B_before_P });

            pPermutation = PPermutation(B_32);

            for (int i = 0; i < 32; i++)
            {
                encryptedData[i] = R[i];
                encryptedData[32 + i] = L[i] ^ pPermutation[i];
            }

            return encryptedData;

        }

        private MyBitArray BackCycleFeistel(MyBitArray sourceData, MyBitArray key, int numberOfCycle)
        {
            MyBitArray encryptedData = new MyBitArray(64);

            MyBitArray R = new MyBitArray(32);
            MyBitArray L = new MyBitArray(32);
            MyBitArray lExpanded;
            MyBitArray k;
            MyBitArray[] B = new MyBitArray[8];
            MyBitArray B_32;
            MyBitArray pPermutation;


            // разделение на 2 блока
            for (int i = 0; i < 32; i++)
            {
                L[i] = sourceData[i];
                R[i] = sourceData[32 + i];
            }

            // расширение правой части
            lExpanded = ExtendHalf(L);


            // 48-битный ключ
            k = GenerateKey(key, numberOfCycle);

            // разбитие расширеной правой части на 8 блоков по 6 бит
            byte[] kek = new byte[8];
            MyBitArray Xored = new MyBitArray(48);
            for (int i = 0; i < 48; i++)
            {
                Xored[i] = lExpanded[i] ^ k[i];
            }

            for (int i = 0; i < 8; i++)
            {
                B[i] = new MyBitArray(6);
                for (int j = 0; j < 6; j++)
                {
                    B[i][j] = Xored[(i * 6) + j];
                }

            }


            // получение B` из таблици Значение функции  f(R[i-1], k[i]) (32 бит)
            int B_before_P = 0;
            for (int i = 0; i < 8; i++)
            {
                byte[] a;
                byte[] b;

                MyBitArray temp = new MyBitArray(new bool[] { B[i][0], B[i][5] });
                a = temp.GetBytesArray();
                temp = new MyBitArray(new bool[] { B[i][1], B[i][2], B[i][3], B[i][4] });
                b = temp.GetBytesArray();

                B_before_P = B_before_P | (S[i][a[0], b[0]] << (32 - ((i + 1) * 4)));
            }

            B_32 = new MyBitArray(new int[] { B_before_P });

            pPermutation = PPermutation(B_32);

            for (int i = 0; i < 32; i++)
            {
                encryptedData[32 + i] = L[i];
                encryptedData[i] = R[i] ^ pPermutation[i];
            }


            return encryptedData;

        }

        private MyBitArray ExtendHalf(MyBitArray half)
        {
            MyBitArray res = new MyBitArray(48);
            for (int i = 0; i < 48; i++)
            {
                res[i] = half[E[i]];
            }
            return res;
        }

        public MyBitArray Encrypt(MyBitArray sourceData, MyBitArray key)
        {
            if (sourceData.Length != 64)
            {
                throw new Exception("Размер блока не 64 бита");
            }

            // начальная перестановка
            sourceData = InitialPermutation(sourceData);

            // 16 циклов сети Фейстеля
            for (int numberOfCycle = 0; numberOfCycle < 16; numberOfCycle++)
            {
                sourceData = CycleFeistel(sourceData, key, numberOfCycle);
            }

            // финальная перестановка
            sourceData = FinalPermutation(sourceData);

            return sourceData;
        }

        public MyBitArray Decrypt(MyBitArray sourceData, MyBitArray key)
        {
            if (sourceData.Length != 64)
            {
                throw new Exception("Размер блока не 64 бита");
            }

            // начальная перестановка
            sourceData = InitialPermutation(sourceData);

            // 16 циклов сети Фейстеля
            for (int numberOfCycle = 15; numberOfCycle >= 0; numberOfCycle--)
            {
                sourceData = BackCycleFeistel(sourceData, key, numberOfCycle);
            }

            // финальная перестановка
            sourceData = FinalPermutation(sourceData);

            return sourceData;
        }

        private MyBitArray GenerateKey(MyBitArray sourceKey, int iter)
        {
            MyBitArray key = new MyBitArray(48);
            MyBitArray permutatedKey = new MyBitArray(56);
            MyBitArray permutatedKeyC = new MyBitArray(28);
            MyBitArray permutatedKeyD = new MyBitArray(28);
            MyBitArray permutatedKeyCShifted = new MyBitArray(28);
            MyBitArray permutatedKeyDShifted = new MyBitArray(28);


            for (int i = 0; i < 28; i++)
            {
                permutatedKeyC[i] = sourceKey[C[i]];
                permutatedKeyD[i] = sourceKey[D[i]];
            }

            int iterShift = 0;
            MyBitArray t = new MyBitArray(56);
            for(int i = 0; i < 28; i++)
            {
                t[i] = permutatedKeyC[i];
                t[i + 28] = permutatedKeyD[i];
            }
            byte[] te = t.GetBytesArray();

            for (int i = 0; i <= iter; i++)
            {
                iterShift += shift[i];
            }

            for (int i = 0; i < 28; i++)
            {
                permutatedKeyCShifted[(i - iterShift + 28) % 28] = permutatedKeyC[i];
                permutatedKeyDShifted[(i - iterShift + 28) % 28] = permutatedKeyD[i];
            }

            for (int i = 0; i < 28; i++)
            {
                t[i] = permutatedKeyCShifted[i];
                t[i + 28] = permutatedKeyDShifted[i];
            }
            te = t.GetBytesArray();

            for (int i = 0; i < 28; i++)
            {
                permutatedKey[i] = permutatedKeyCShifted[i];
                permutatedKey[28 + i] = permutatedKeyDShifted[i];
            }

            for (int i = 0; i < 48; i++)
            {
                key[i] = permutatedKey[K[i]];
            }

            return key;
        }


        private MyBitArray ExtentKey(MyBitArray sourceKey)
        {
            MyBitArray key = new MyBitArray(64);

            int index = 0;
            int counter = 0;
            for (int i = 0; i < 64; i++)
            {
                if ((i + 1) % 8 == 0)
                {
                    if (counter % 2 == 0)
                    {
                        key[i] = true;
                    }
                    counter = 0;
                    continue;
                }
                counter = (sourceKey[index]) ? counter + 1 : counter;
                key[i] = sourceKey[index];
                index++;
            }

            return key;
        }

        private List<MyBitArray> SplitData(string data)
        {
            List<MyBitArray> splitedData = new List<MyBitArray>(data.Length / 4);
            
            for(int i = 0; i < data.Length; i += 8)
            {
                string sub;
                byte[] b;
                if (data.Length < i+8)
                {

                    sub = data.Substring(i, data.Length - i);
                    b = new byte[8];
                    byte[] b1 = enc.GetBytes(sub);
                    for (int j = 0; j < b1.Length; j++)
                    {
                        b[b.Length - 1 - j] = b1[b1.Length - 1 - j];
                    }

                }
                else
                {
                    sub = data.Substring(i, 8);
                    b = enc.GetBytes(sub);
                }
                
                splitedData.Add(new MyBitArray(b));
            }


            return splitedData;
        }
   
        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            textBoxRes.Clear();

            List<MyBitArray> encryptedData = new List<MyBitArray>(textBoxSource.Text.Length / 4);

       
            MyBitArray key;
            List<byte> bKey = new List<byte>(7);
            bKey.AddRange(enc.GetBytes(textBoxKey.Text));
            byte[] Bkey = new byte[7];
            
            for(int i = 0; i < bKey.Count && i < 7; i++)
            {
                Bkey[i] = bKey[i];
            }
            
            key = new MyBitArray(Bkey);

            string tempKeyOut = string.Empty;
            for (int i =0; i < bKey.Count; i++)
            {
                tempKeyOut += bKey[i];
            }
            textBoxRes.Text += "ключ шифрования в байтах: " + tempKeyOut + Environment.NewLine;

            key = ExtentKey(key);

            List<MyBitArray> data = SplitData(textBoxSource.Text);

            // шифрование
            foreach (var element in data)
            {
                 encryptedData.Add(Encrypt(element, key));
            }


            // вывод
             StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();

            for (int i = 0; i < encryptedData.Count; i++)
            {
                byte[] text = encryptedData[i].GetBytesArray();
                char[] textChar = enc.GetChars(text);
                for (int j = 0; j < text.Length; j++)
                {
                    sb.Append(text[j] + " ");
                }
                sb2.Append(textChar);
            }
            textBoxRes.Text += sb + Environment.NewLine;
            textBoxRes.Text += sb2 + Environment.NewLine;
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            textBoxRes.Text = "";

            string[] subs = textBoxSource.Text.Split(' ');
            List<byte> dataB = new List<byte>(subs.Length);
            for(int i = 0; i < subs.Length; i++)
            {
                dataB.Add(Byte.Parse(subs[i]));
            }

            List<MyBitArray> decryptedData = new List<MyBitArray>(textBoxSource.Text.Length / 4);
            MyBitArray key;
            List<byte> bKey = new List<byte>(7);
            bKey.AddRange(enc.GetBytes(textBoxKey.Text));
            byte[] Bkey = new byte[7];

            for (int i = 0; i < bKey.Count && i < 7; i++)
            {
                Bkey[i] = bKey[i];
            }

            key = new MyBitArray(Bkey);

            key = ExtentKey(key);

            List<MyBitArray> data = new List<MyBitArray>(dataB.Count / 8);

            for (int i = 0; i < dataB.Count; i += 8)
            {
                data.Add(new MyBitArray(new byte[] { dataB[i], dataB[i + 1], dataB[i + 2], dataB[i + 3], dataB[i + 4], dataB[i + 5], dataB[i + 6], dataB[i + 7] }));
            }

            foreach (var element in data)
            {
                decryptedData.Add(Decrypt(element, key));
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < decryptedData.Count; i++)
            {
                byte[] text = decryptedData[i].GetBytesArray();

                List<char> arr =  new List<char>(enc.GetChars(text));
                arr.RemoveAll(new Predicate<char>( c => c.Equals('\0') ));

                sb.Append(arr.ToArray());

            }
            textBoxRes.Text += sb + Environment.NewLine;

        }
    }
}
