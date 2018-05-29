using System;
using System.Collections.Generic;

namespace _3._2Studio
{
    class Program
    {
        static void Main(string[] args)
        {
            string hardCodedInput = "This is a test string";
            Dictionary<char, int> characterCount = GetCharacterCount(hardCodedInput);
            PrintDictionary(characterCount);
            Console.ReadLine();
        }

        private static Dictionary<char, int> GetCharacterCount(string input)
        {
            Dictionary<char, int> characterCount = new Dictionary<char, int>();
            foreach(char letter in input)
            {
                if (!characterCount.ContainsKey(letter))
                {
                    characterCount.Add(letter, 1);
                }
                else
                {
                    characterCount[letter]++;
                }
            } 

            return characterCount;
        }

        private static void PrintDictionary(Dictionary<char, int> dictToPrint)
        {
            foreach(KeyValuePair<char, int> item in dictToPrint)
            {
                string outString = $"{item.Key}: {item.Value}";
                Console.WriteLine(outString);
            }
        }
    }
}
