/* Bongani Lefaso Mabizela
 * 2016074458
 * CSIS 2614 Project 6 - SesothoAndEnglish*/
using libDictionary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SesothoAndEnglish
{
    class Program
    {
        static void Main(string[] args)
        {
            libDictionary.Dictionary dictionary = new libDictionary.Dictionary();
            
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Menu(dictionary, args);
        }//Main(string[] args)

        private static void Menu(Dictionary dictionary, string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("\t1. List of words in English alphabetical order");
            Console.WriteLine("\t2. List of words in Sesotho alphabetical order");
            Console.WriteLine("\t3. Translate");
            Console.WriteLine("\tX. Exit");
            Console.WriteLine();
            Console.Write("\tEnter option: ");
            char option = Console.ReadKey().KeyChar.ToString().ToUpper()[0];

            switch (option)
            {
                case '1': List(dictionary, Languages.English); Main(args); break;
                case '2': List(dictionary, Languages.Sesotho); Main(args); break;
                case '3': Translate(dictionary); Main(args); break;
                case 'X': Environment.Exit(0); break;

                default: Main(args); break;

            }//switch option
            Console.Clear();
        }//Menu(Dictionary dictionary, string[] args)

        private static void List(Dictionary dictionary, Languages language)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\tList of words in " + language + " alphabetical order\n");
            //Sort the words in the dictionary
            //dictionary.Sort(language);
            dictionary.SelectionSort(language);
            //List all words
            foreach (string[] words in dictionary)
                Console.WriteLine("\t" + words[0].PadRight(20) + words[1]);
            Console.WriteLine();
            Console.Write("\tPress any key to return to the menu ..."); Console.ReadKey();
            Console.Clear();
        } //List

        private static void Translate(Dictionary dictionary)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\tTranslation of a word\n");
            //Get word from user
            Console.Write("\tEnglish or Sesotho : ");
            string word = Console.ReadLine();
            //Display word and its translation
            if (dictionary.Contains(word))
            {
                Console.WriteLine("\tSesotho: " + dictionary[word][0]);
                Console.WriteLine("\tEnglish: " + dictionary[word][1]);
            }
            else
                Console.WriteLine("\tThe dictionary does not contain the word '" + word + "'.");
            Console.WriteLine();
            
            //int i = dictionary.BinarySearch(word);
            //if (i != -1)
            //{
            //    Console.WriteLine("\tSesotho: " + dictionary[i][0]);
            //    Console.WriteLine("\tEnglish: " + dictionary[i][1]);
            //}
            //else
            //    Console.WriteLine("\tThe dictionary does not contain the word '" + word + "'.");
            //Console.WriteLine();
            Console.Write("\tPress any key to return to the menu ..."); Console.ReadKey();
            Console.Clear();
        } //Translate
    }//class Program

    public static class Extension
    {
        public static int BinarySearch(this Dictionary dictionary, string word, int[] limits = null)
        {
            List<string[]> words = (List<string[]>)dictionary.lstWords;
            int lower = 0;
            int upper = words.Count;

            if (limits != null)
            {
                lower = limits[0];
                upper = limits[1];
            }//if (limits != null)

            int mid = (upper + lower) / 2;

            if (lower <= upper)
            {
                string w = words[mid][0];
                if (word.CompareTo(w) < 0)
                {
                    return BinarySearch(dictionary, word, new int[] { lower, mid });

                }//if (word.CompareTo(w) < 0)
                else
                {
                    if (word.CompareTo(w) > 0)
                    {
                        return BinarySearch(dictionary, word, new int[] { mid, upper });
                    }//if (word.CompareTo(w) > 0)
                    else
                    {
                        return mid;
                    }//else
                }//else
            }//(lower <= upper)
            else
            {
                return -1;
            }//else
        }//Recursive BinarySearch
    }//class Extension
}//namespace
