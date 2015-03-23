using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a string of several words divided by spaces");
            string StringLine = Console.ReadLine();
            StringLine = StringLine.TrimStart().TrimEnd(); //Cut-off spaces in the beginning and in the end
            string[] Words = StringLine.Split(); //array of separated words
            int LW = Words.Length;
            char[] Arr = new char[LW];
            int[] Numarr = new int[LW];
            //string[] Vovel = new string[LW];
            char[] Vovels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            for (int i = 0; i < LW; i++)
            {
                Arr = Words[i].ToLower().ToCharArray();    //every word parsed to char array
                for (int j = 0; j < Words[i].Length; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        if (Arr[j] == Vovels[k])
                        {
                            Numarr[i]++; 
                        }
                    }
                }
            }
           
           
            for (int i = 0; i < LW; i++)
            {            
                for (int j = 0; j < LW-1; j++)
                    if (Numarr[j] < Numarr[j+1])
                    {                              ////Поиск минимального элемента
                        int z = Numarr[j];
                        Numarr[j] = Numarr[j + 1];
                        Numarr[j + 1] = z;
                        string St = Words[j];
                        Words[j] = Words[j + 1];
                        Words[j + 1] = St;
                    }
                
            }
            for (int i = 0; i < LW; i++)
            {
                Console.WriteLine(Numarr[i] + " " + Words[i]);

            }
            Console.ReadLine();
        }
    }
}
