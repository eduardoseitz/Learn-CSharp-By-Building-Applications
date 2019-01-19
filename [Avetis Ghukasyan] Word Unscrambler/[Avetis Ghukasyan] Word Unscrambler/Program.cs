using System;
using System.Collections.Generic;
using System.IO;

namespace _Avetis_Ghukasyan__Word_Unscrambler
{
    class Program
    {
        #region Main Methods

        static void Main(string[] args)
        {
            // Load up wordlist
            string[] wordList = File.ReadAllLines("Wordlist.txt");
            string[] newList = null;
            string[] matchedList = null;

            // Loops application
            bool isLooping = true;
            do
            {
                Console.Clear();

                // Presentation
                Console.WriteLine("******************");
                Console.WriteLine(" WORD UNSCRAMBLER ");
                Console.WriteLine("******************");

                // User chooses input method
                Console.WriteLine("\nMatch words from [F]ile or [M]anually?");
                string choice = Console.ReadLine().ToLower();
                Console.WriteLine();

                // If new words will be manually entered
                if (choice.Equals("m") || choice.Equals("manual"))
                {

                }
                // If new words will be entered from file
                else if (choice.Equals("f") || choice.Equals("file"))
                {
                    Console.WriteLine("Enter The File Path: ");
                    string path = Console.ReadLine();

                    if (!File.Exists(path))
                        Console.WriteLine("\n!Invalid File Path!\n");
                    else
                    {
                        Console.WriteLine("\n!File loaded sucesfully!\n");

                        newList = File.ReadAllLines(path);
                        Array.Sort(newList);
                        matchedList = newList;
                    }
                }

                // If exists display matched list on screen
                if (matchedList != null) {
                    foreach (string match in matchedList)
                        Console.WriteLine("MATCH FOUND: {0}", match);
                }

                // Break the loop
                Console.WriteLine("\nDo you wish to continue?");
                if (Console.ReadLine().ToLower().Equals("no"))
                    isLooping = false;
            }
            while (isLooping);
        }

        #endregion

        #region Helper Methods
        

        #endregion
    }
}
