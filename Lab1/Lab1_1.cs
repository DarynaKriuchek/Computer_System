using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text="";
            double len=0.0;
            double entropy = 0.0;
            Console.OutputEncoding = Encoding.UTF8;
            string path = "";
            Console.WriteLine("Enter number of needed file:\n 1-esenin.txt;\n 2 - bayka.txt;\n 3-cryptography.txt");
            int file_number = 0;
            file_number = Int32.Parse(Console.ReadLine());
            switch (file_number)
            {
                case 1:
                     path = @"C:\Computer system\Lab1_1\Lyrics\esenin.txt";
                    break;
                case 2:
                     path = @"C:\Computer system\Lab1_1\Lyrics\bayka.txt";
                    break;
                case 3:
                     path = @"C:\Computer system\Lab1_1\Lyrics\cryptography.txt";
                    break;
                default:
                    path = @"C:\Computer system\Lab1_1\Lyrics\esenin.txt";
                    break;

            }

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
            {
             
               text = sr.ReadToEnd();

            }
            len = text.Length;
            Dictionary<char, int> result = new Dictionary<char, int>();
            foreach (char symbol in text)
            {
                if (result.ContainsKey(symbol))
                    result[symbol]++;
                else
                    result[symbol] = 1;
            }
            foreach(  KeyValuePair<char , int> keyValuePair in result)
            {
                entropy += (keyValuePair.Value / len) * Math.Log(len/keyValuePair.Value, 2);

                Console.WriteLine("Symbol = {0}, Frequency = {1},",
                            keyValuePair.Key, keyValuePair.Value);
            }
            double fileinfo = entropy * len / 8;
            Console.WriteLine("Entropy in bit :{0},\nquantity of info in byte :{1}", entropy, fileinfo);
            FileInfo file = new FileInfo(path);
            Console.WriteLine("File name: " + file.Name + "\n File size byte: " + file.Length);
        }
    }
}
