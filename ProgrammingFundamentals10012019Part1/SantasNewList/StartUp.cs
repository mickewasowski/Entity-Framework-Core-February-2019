using System;
using System.Linq;
using System.Collections.Generic;

namespace SantasNewList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, int> children = new Dictionary<string, int>();

            Dictionary<string, int> presents = new Dictionary<string, int>();

            while (input != "END")
            {
                string[] tokens = input.Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (tokens[0] == "Remove")
                {
                    children.Remove(tokens[1]);
                    input = Console.ReadLine();
                    continue;
                }

                string childName = tokens[0];
                string presentType = tokens[1];
                int amount = int.Parse(tokens[2]);

                if (!children.ContainsKey(childName))
                {
                    children.Add(childName, amount);
                }
                else
                {
                    children[childName] += amount;
                }

                if (!presents.ContainsKey(presentType))
                {
                    presents.Add(presentType, amount);
                }
                else
                {
                    presents[presentType] += amount;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Children:");
            foreach (var c in children.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{c.Key} -> {c.Value}");
            }

            Console.WriteLine("Presents:");
            foreach (var p in presents)
            {
                Console.WriteLine($"{p.Key} -> {p.Value}");
            }
        }
    }
}
