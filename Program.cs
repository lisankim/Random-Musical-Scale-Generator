using RMSG.Classes;
using System;

namespace RMSG
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuSelection();
        }
        private static void MenuSelection()
        {
            Scale s = new Scale();
            int menuSelection = 0;
            while (menuSelection != 5)
            {
                Console.WriteLine("");
                Console.WriteLine("Welcome to Musical Scale Generator! Please make a selection: ");
                Console.WriteLine("1. List all the musical scales!");
                Console.WriteLine("2. Mix the list and show me a list of shuffled musical scales!");
                Console.WriteLine("3. Give me a random scale of the day!");
                Console.WriteLine("4. Show me the scales I've already practiced.");
                Console.WriteLine("5. Exit");

                if (!int.TryParse(Console.ReadLine(), out menuSelection))
                {
                    Console.WriteLine("Invalid input. Please enter only a number.");

                }
                else if (menuSelection == 1)
                {

                    for (int i = 0; i < s.Scales.Count; i++)
                    {
                        Console.WriteLine(s.Scales[i]);
                    }
                }

                else if (menuSelection == 2)
                {

                    //printing the mixed list of scales
                    s.Shuffle();
                    for (int i = 0; i < s.Scales.Count; i++)
                    {
                        Console.WriteLine(s.Scales[i]);
                    }
                }
                else if (menuSelection == 3)
                {
                    string scale = s.GetRandomScale();
                    Console.WriteLine("Scale of the day: " + scale);
                    s.ScaleLog($"{DateTime.Now} Scale of the day: {scale}");
                }

                else if (menuSelection == 4)
                {
                    if (s.usedList.Count == 0)
                    {
                        Console.WriteLine("There are none in this list. Please press 3 to get a random scale of the day!");
                    }
                    else
                    {
                        for (int i = 0; i < s.usedList.Count; i++)
                        {
                            Console.WriteLine(s.usedList[i]);
                        }
                    }
                }
                else if (menuSelection == 5)
                {
                    Console.WriteLine("Goodbye!");

                }

            }
        }

    }
}
