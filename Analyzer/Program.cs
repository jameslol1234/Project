using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TEXT ANALYZER");
            while (true)
            {
                Console.WriteLine("\nMENU: \n1. Download file from internet.\n2. Count number of letters in the file.\n3. Count number of words in the file.\n4. Count number of punctuation marks in the file.\n5. Count number of sentences in the file.\n6. Report about usage of letters (A-Z).\n7. Save statistics from points 2-5 to the file(statystki.txt)\n8. Exit and close application.\n");
                Console.Write("Choose option to execute: ");
                int MenuOpt;
                if (!int.TryParse(Console.ReadLine(), out MenuOpt))
                {
                    Console.WriteLine("Wrong format. Please choose number 1-8");
                    continue;
                }
                if (MenuOpt == 1)
                {
                    Console.WriteLine("1. Download file from internet.");
                    Console.WriteLine("add some code here...");
                    continue;
                }
                else if (MenuOpt == 2)
                {
                    Console.WriteLine("2. Count number of letters in the file.");
                    Console.WriteLine("add some code here...");
                }
                else if (MenuOpt == 3)
                {
                    Console.WriteLine("3. Count number of words in the file.");
                    Console.WriteLine("add some code here...");
                }
                else if (MenuOpt == 4)
                {
                    Console.WriteLine("4. Count number of punctuation marks in the file.");
                    Console.WriteLine("add some code here...");
                }
                else if (MenuOpt == 5)
                {
                    Console.WriteLine("5. Count number of sentences in the file.");
                    Console.WriteLine("add some code here...");
                }
                else if (MenuOpt == 6)
                {
                    Console.WriteLine("6. Report about usage of letters (A-Z).");
                    Console.WriteLine("add some code here...");
                }
                else if (MenuOpt == 7)
                {
                    Console.WriteLine("7. Save statistics from points 2-5 to the file(statystki.txt)");
                    Console.WriteLine("add some code here...");
                }
                else if (MenuOpt == 8)
                {
                    Console.WriteLine("Exiting the program...");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong option!\nPlease select correct option(1-8)");
                    continue;
                }
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}
