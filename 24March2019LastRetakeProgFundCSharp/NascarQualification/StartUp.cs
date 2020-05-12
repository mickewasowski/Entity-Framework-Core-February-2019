using System;
using System.Collections.Generic;
using System.Linq;

namespace NascarQualification
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> racers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = tokens[0];

                switch (command)
                {
                    case "Box":
                        Box(racers, tokens);
                        break;
                    case "Accident":
                        Accident(racers, tokens);
                        break;
                    case "Race":
                        Race(racers, tokens);
                        break;
                    case "Overtake":
                        Overtake(racers, tokens);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ~ ",racers));
        }

        private static void Overtake(List<string> racers, string[] tokens)
        {
            string name = tokens[1];
            int positionsToMove = int.Parse(tokens[2]);


            if (racers.Contains(name))
            {
                int index = racers.IndexOf(name);
                int nextPosition = index - positionsToMove;

                if (nextPosition >= 0)
                {

                    racers.Insert(nextPosition, name);
                    racers.RemoveAt(index + 1);
                }
            }
        }

        private static void Race(List<string> racers, string[] tokens)
        {
            string name = tokens[1];

            if (!racers.Contains(name))
            {
                racers.Insert(racers.Count, name);
            }
        }

        private static void Accident(List<string> racers, string[] tokens)
        {
            string name = tokens[1];
            racers.Remove(name);
        }

        private static void Box(List<string> racers, string[] tokens)
        {
            string name = tokens[1];

            if (racers.Contains(name))
            {
               int index = racers.IndexOf(name);

                if (index != racers.Count)
                {
                    racers.Insert(index + 2, name);
                    racers.RemoveAt(index);
                }
            }
        }
    }
}
