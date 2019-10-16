using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Projekt
{
    class Program
    {
        static string DLFile()
        {
            WebClient myWebClient = new WebClient();
            string fileName = null;
            Console.WriteLine("1. Do u want to download file from internet?[y/n] ");
            string Key = Console.ReadLine();
            if (Key == "y")
            {
                Console.WriteLine("Enter file adress: ");
                string Adress = Console.ReadLine();             
                try
                {
                    var uri = new Uri(Adress);
                    fileName = uri.Segments.Last();
                    myWebClient.DownloadFile(Adress, fileName);
                    Console.WriteLine("Downloaded file");
                    return fileName;
                }
                catch (System.UriFormatException)
                {
                    Console.WriteLine("download failed. url not found");
                }
                catch (System.Net.WebException)
                {
                    Console.WriteLine("download failed. url not found");
                }
            }
            else if (Key == "n")
            {
                string FileText;
                Console.WriteLine("Enter file name in the same directory: ");
                fileName = Console.ReadLine();
                try
                {
                    FileText = File.ReadAllText(fileName);
                    return fileName;
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Could not find file " + fileName);
                    return fileName;
                }
            }
            else
            {
                Console.WriteLine("Please type 'y' or 'n' only next time :)");
                return fileName;
            }
            return fileName;
        }
        static int CountLetters(string fileName)
        {
            Console.WriteLine("2. Count number of letters in the file.");
            if (fileName == null)
            {
                Console.WriteLine("You haven't selected file yet!! Do it now!");
                return 1;
            }
            string FileText;
            try
            {
                FileText = File.ReadAllText(fileName);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not find file " + fileName);
                return 1;
            }
            int i, len, vowel, cons;
            vowel = 0;
            cons = 0;
            len = FileText.Length;
            for (i = 0; i < len; i++)
            {
                if (FileText[i] == 'a' || FileText[i] == 'e' || FileText[i] == 'i' || FileText[i] == 'o' || FileText[i] == 'u' || FileText[i] == 'A' || FileText[i] == 'E' || FileText[i] == 'I' || FileText[i] == 'O' || FileText[i] == 'U')
                {
                    vowel++;
                }
                else if ((FileText[i] >= 'a' && FileText[i] <= 'z') || (FileText[i] >= 'A' && FileText[i] <= 'Z'))
                {
                    cons++;
                }
            }
            Console.Write("\nNumber of vowel in the file is : {0}\n", vowel);
            Console.Write("Number of consonant in the file is : {0}\n\n", cons);
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
        static int CountWords(string fileName)
        {
            Console.WriteLine("3. Count number of words in the file.");
            if (fileName == null)
            {
                Console.WriteLine("You haven't selected file yet!! Do it now!");
                return 1;
            }
            string FileText;
            try
            {
                FileText = File.ReadAllText(fileName);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not find file " + fileName);
                return 1;
            }
            string[] Words = FileText.Split(' ');
            int WordsQty = 0;
            foreach (string word in Words)
            {
                if (word.Length == 1) continue;
                WordsQty++;
            }
            Console.WriteLine("REMINDER: Single letters are not counted towards number of words!");
            Console.WriteLine("Number of words is: " + WordsQty);
            return 0;
        }
        static int CountPuncMarks(string fileName)
        {
            Console.WriteLine("4. Count number of punctuation marks in the file.");
            if (fileName == null)
            {
                Console.WriteLine("You haven't selected file yet!! Do it now!");
                return 1;
            }
            string FileText;
            try
            {
                FileText = File.ReadAllText(fileName);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not find file " + fileName);
                return 1;
            }

            int PuncMarksQty = 0;
            foreach (char c in FileText)
            {
                if (c == '?' || c == '.')
                {
                    PuncMarksQty++;
                }
            }
            Console.WriteLine("Count of punctuation marks in file: " + PuncMarksQty);
            return 0;
        }
        static int CountSentence(string fileName)
        {
            Console.WriteLine("5. Count number of sentences in the file.");
            if (fileName == null)
            {
                Console.WriteLine("You haven't selected file yet!! Do it now!");
                return 1;
            }
            string FileText;
            try
            {
                FileText = File.ReadAllText(fileName);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not find file "+fileName);
                return 1;
            }
            string[] Words = Regex.Split(FileText, @"[^\.\?]*[\.\?]");
            int SentenceQty = 0;
            foreach (string word in Words)
            {
                SentenceQty++;
            }
            Console.WriteLine("Number of sentences is: " + SentenceQty);
            return 0;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("TEXT ANALYZER");
            string fileName = null;
            while (true)
            {
                Console.WriteLine("\nMENU: \n1. Select file.\n2. Count number of letters in the file.\n3. Count number of words in the file.\n4. Count number of punctuation marks in the file.\n5. Count number of sentences in the file.\n6. Report about usage of letters (A-Z).\n7. Save statistics from points 2-5 to the file(statystki.txt)\n8. Exit and close application.\n");
                Console.Write("Choose option to execute: ");
                int MenuOpt;
                if (!int.TryParse(Console.ReadLine(), out MenuOpt))
                {
                    Console.WriteLine("Wrong format. Please choose number 1-8");
                    continue;
                }
                if (MenuOpt == 1)
                {
                   fileName = DLFile();
                }
                else if (MenuOpt == 2)
                {
                    if (CountLetters(fileName) == 1) continue;
                }
                else if (MenuOpt == 3)
                {
                    if (CountWords(fileName) == 1) continue;
                }
                else if (MenuOpt == 4)
                {
                    if (CountPuncMarks(fileName) == 1) continue;
                }
                else if (MenuOpt == 5)
                {
                    if (CountSentence(fileName) == 1) continue;
                }
                else if (MenuOpt == 6)
                {
                    Console.WriteLine("6. Report about usage of letters (A-Z).");
                    if (fileName == null)
                    {
                        Console.WriteLine("You haven't selected file yet!! Do it now!");
                        continue;
                    }
                    int[] c = new int[(int)char.MaxValue];
                    string FileText;
                    try
                    {
                        FileText = File.ReadAllText(fileName);
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("Could not find file " + fileName);
                        continue;
                    }
                    foreach (char t in FileText)
                    {
                        c[(int)t]++;
                    }
                    for (int i = 0; i < (int)char.MaxValue; i++)
                    {
                        if (c[i] > 0 &&
                            char.IsLetter((char)i))
                        {
                            Console.WriteLine("{0} : {1}",
                                (char)i,
                                c[i]);
                        }
                    }
                }
                else if (MenuOpt == 7)
                {
                    Console.WriteLine("7. Save statistics from points 2-5 to the file(statystki.txt)");
                    FileStream ostrm;
                    StreamWriter writer;
                    TextWriter oldOut = Console.Out;
                    try
                    {
                        ostrm = new FileStream("./statystyki.txt", FileMode.OpenOrCreate, FileAccess.Write);
                        writer = new StreamWriter(ostrm);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Cannot open statystyki.txt for writing");
                        Console.WriteLine(e.Message);
                        return;
                    }
                    Console.SetOut(writer);
                    CountLetters(fileName);
                    CountWords(fileName);
                    CountPuncMarks(fileName);
                    CountSentence(fileName);
                    Console.SetOut(oldOut);
                    writer.Close();
                    ostrm.Close();
                    Console.WriteLine("Saving to file done!");
                }
                else if (MenuOpt == 8)
                {
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                        Console.WriteLine("Deleted file: "+fileName);
                    }
                    if (File.Exists("statystyki.txt"))
                    {
                        File.Delete("statystyki.txt");
                        Console.WriteLine("Deleted file: statystyki.txt");
                    }
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
