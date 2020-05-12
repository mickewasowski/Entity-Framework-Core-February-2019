using System;
using System.Collections.Generic;
using System.Linq;

namespace SantasGifts
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<int> houses = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();

            int position = 0;

            for (int i = 0; i < num; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = tokens[0];
                int steps = int.Parse(tokens[1]);

                switch (command)
                {
                    case "Forward":
                       //ForwardCommand(houses, steps,position);
                        if (ForwardCommand(houses, steps, position) == 1)
                        {
                            position += steps;
                        }
                        break;
                    case "Back":
                        //BackCommand(houses, steps, position);
                        if (BackCommand(houses, steps, position) == 1)
                        {
                            position -= steps;
                        }
                        break;
                    case "Swap":
                        int first = int.Parse(tokens[1]);
                        int second = int.Parse(tokens[2]);
                        SwapCommand(houses, first, second);
                        break;
                    case "Gift":
                        int index = int.Parse(tokens[1]);
                        int houseNum = int.Parse(tokens[2]);

                        //GiftCommand(houses,index, houseNum);
                        if (GiftCommand(houses, index, houseNum) == 1)
                        {
                            position = houses.IndexOf(houseNum);
                        }
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"Position: {position}");
            Console.WriteLine(string.Join(", ",houses));
        }

        private static int GiftCommand(List<int> houses, int index, int houseNum)
        {
            if (index > houses.Count || index < 0)
            {
                return 0;
            }
            houses.Insert(index, houseNum);
            return 1;
        }

        private static void SwapCommand(List<int> houses, int first, int second)
        {
            if (houses.Contains(first) && houses.Contains(second))
            {
                int house1 = houses.IndexOf(first);
                int house2 = houses.IndexOf(second);

                houses.Insert(house1, second);
                houses.RemoveAt(house1 + 1);

                houses.Insert(house2, first);
                houses.RemoveAt(house2 + 1);
            }
            else
            {
                return;
            }   
        }

        private static int BackCommand(List<int> houses, int steps, int position)
        {
            if (position - steps < 0)
            {
                return 0;
            }

            houses.RemoveAt(position - steps);
            return 1;
        }

        private static int ForwardCommand(List<int> houses, int steps,int position)
        {
            if (position + steps > houses.Count - 1)
            {
                return 0;
            }

            houses.RemoveAt(position + steps);
            return 1;
        }
    }
}
