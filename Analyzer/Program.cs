using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Projekt
{
    class Program
    {
        static void DLFile()
        {
            Console.WriteLine("1. Download file from internet.");
            string remoteUri = "https://s3.zylowski.net/public/input/";
            string fileName = "3.txt";
            WebClient myWebClient = new WebClient();
            string myStringWebResource = remoteUri + fileName;
            Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, myStringWebResource);
            myWebClient.DownloadFile(myStringWebResource, fileName);
            Console.WriteLine("Successfully Downloaded File \"{0}\" from \"{1}\"", fileName, myStringWebResource);
        }
        static int CountLetters()
        {
            Console.WriteLine("2. Count number of letters in the file.");
            string FileText;
            try
            {
                FileText = File.ReadAllText("3.txt");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not find file 3.txt");
                return 1;
            }

            int LettersQty = 0;
            foreach (char c in FileText)
            {
                if (!char.IsWhiteSpace(c) && char.IsLetter(c))
                {
                    LettersQty++;
                }
            }
            Console.WriteLine("Count of letters in file: " + LettersQty);
            return 0;
        }
        
        
        
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
                    DLFile();
                }
                else if (MenuOpt == 2)
                {
                    if (CountLetters() == 1) continue;
                }
                else if (MenuOpt == 3)
                {
                 
                }
                else if (MenuOpt == 4)
                {
                 
                }
                else if (MenuOpt == 5)
                {
                 
                }
                else if (MenuOpt == 6)
                {
                    Console.WriteLine("6. Report about usage of letters (A-Z).");
                    
                }
                else if (MenuOpt == 7)
                {
                }
                else if (MenuOpt == 8)
                {
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
