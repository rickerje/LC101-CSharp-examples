using System;

namespace ChallengeProblem3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            string result = ReduceString(inputString);
            Console.WriteLine(result);
        }

        private static string ReduceString(string inputString)
        {
            string stringToReduce = inputString;
            string reducedString = string.Empty;
            bool didMakeChange;

            do
            {
                didMakeChange = false;
                for (int i = 0; i < stringToReduce.Length; i++)
                {
                    if (i >= stringToReduce.Length - 1)
                    {
                        break;
                    }

                    char letter = stringToReduce[i];
                    char nextLetter = stringToReduce[i + 1];

                    if (letter.Equals(nextLetter))
                    {
                        i++;
                        didMakeChange = true;
                    }
                    else if (!letter.Equals(nextLetter))
                    {
                        reducedString += letter;
                    }
                }

                stringToReduce = reducedString;
            } while (didMakeChange);

            return reducedString;
        }
    }

    

}
