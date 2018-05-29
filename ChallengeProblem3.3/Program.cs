using System;

namespace ChallengeProblem3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int result = CountTransmissionErrors(input);
            Console.WriteLine(result);
        }

        private static int CountTransmissionErrors(string sosString)
        {
            int errorCount = 0;

            for(int i=0; i< sosString.Length; i+=3)
            {
                char letter = sosString[i];
                int position = i % 3;
                switch(position)
                {
                    case 0:
                    case 2:
                        if (letter != 'S')
                            errorCount++;
                        break;
                    case 1:
                        if (letter != 'O')
                            errorCount++;
                        break;
                }
            }

            return errorCount;
        }
    }
}
