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
            string[] wordList = null;
            if (File.Exists("Wordlist.txt"))
            {
                wordList = File.ReadAllLines("Wordlist.txt");
            }
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
                    Console.WriteLine("Type words separated by commas [,]:");
                    string input = Console.ReadLine();
                    newList = FormatInput(input, ',', false);
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
                    }
                }

                // Gets words that matched
                matchedList = MatchList(wordList, newList, true);

                // If exists display matched list on screen
                if (matchedList.Equals(null))
                {
                    Console.WriteLine("!No words matched!");
                }
                else
                {
                    PrintList(matchedList);

                    Console.WriteLine("Do you wish to write the results to a file?");
                    if (Console.ReadLine().ToLower().Equals("yes"))
                    {
                        Console.Write("File Name: ");
                        string path = Console.ReadLine();
                        File.WriteAllLines(path, matchedList);
                        Console.WriteLine("Results written successfully!");
                        Console.WriteLine();
                    }
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

        // Turns user input into a list
        static string[] FormatInput(string input, char separator, bool allowSpaces)
        {
            List<string> output = new List<string>();
            string newWord = string.Empty;
            
            // Format input
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Equals(','))
                {
                    output.Add(newWord);
                    newWord = string.Empty;
                }
                else if ((allowSpaces == true) || (allowSpaces == false && !input[i].Equals(' ')))
                {
                    newWord += input[i];
                }
            }

            output.Add(newWord);
            return output.ToArray();
        }

        // Check if lists matches
        static string[] MatchList(string[] wordList, string[] newList, bool suffle)
        {
            Array.Sort(wordList);
            Array.Sort(newList);

            List<string> newWords = new List<string>(newList);
            List<string> matches = new List<String>();
            
            // Suffle words and adds new ones
            //if (suffle)
            //{
            //    foreach (string word in newList)
            //    {
            //        char[] newWord = word.ToCharArray();
            //        for (int letter = 0;  letter < word.Length; letter++)
            //        {
            //            for (int pos = 0; pos < word.Length; pos++)
            //            {
            //                newWord[pos] = word[letter];
            //                newWord[letter] = word[pos];

            //                if (!newWord.Equals(word))
            //                    newWords.Add(newWord.ToString());
            //            }
            //        }
            //    }
            //}

            // Loop through wordlist and add verify if words match
            foreach (string newWord in newList)
            {
                foreach (string word in wordList)
                {
                    if (newWord.ToLower().Equals(word.ToLower()))
                    {
                        matches.Add(word);
                        Console.WriteLine("Match Found: {0}", word);
                    }
                }
            }

            return matches.ToArray();
        }

        // Print word list
        static void PrintList(string[] list)
        {
            Console.WriteLine("\n[Matches]\n");

            foreach (string word in list)
            {
                Console.Write("{0};", word);
            }

            Console.WriteLine("\n");
        }

        #endregion
    }
}
