using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InternationalSoftUniada
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var participantsByCountry = new Dictionary<string, Dictionary<string, int>>();

            while (input != "END")
            {
                string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string country = tokens[0];
                string personName = tokens[1];
                int points = int.Parse(tokens[2]);

                if (!participantsByCountry.ContainsKey(country))
                {
                    participantsByCountry.Add(country,new Dictionary<string, int>());
                    participantsByCountry[country].Add(personName, points);
                }
                else if (!participantsByCountry[country].ContainsKey(personName))
                {
                    participantsByCountry[country].Add(personName, points);
                }
                else
                {
                    int personPoints = participantsByCountry[country][personName];

                    participantsByCountry[country][personName] = personPoints + points;
                }

                input = Console.ReadLine();
            }

            StringBuilder sb = new StringBuilder();

            foreach (var p in participantsByCountry.OrderByDescending(x => x.Value.Values.Sum()))
            {
                int totalPoints = participantsByCountry[p.Key].Sum(x => x.Value);
                sb.AppendLine($"{p.Key}: {totalPoints}");

                foreach (var s in p.Value)
                {
                    sb.AppendLine($" -- {s.Key} -> {s.Value}");
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
