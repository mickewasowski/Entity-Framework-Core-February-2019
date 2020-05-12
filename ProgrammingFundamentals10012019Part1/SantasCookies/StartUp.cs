using System;

namespace SantasCookies
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int amountBatches = int.Parse(Console.ReadLine());
            int totalBoxes = 0;

            for (int i = 0; i < amountBatches; i++)
            {
                int flourAmount = int.Parse(Console.ReadLine());
                int sugarAmount = int.Parse(Console.ReadLine());
                int cocoaAmount = int.Parse(Console.ReadLine());

                decimal flourCups = GetFlourCups(flourAmount);
                decimal sugarSpoons = GetSugarSpoons(sugarAmount);
                decimal cocoaSpoons = GetCocoaSpoons(cocoaAmount);

                if (flourCups <= 0 || sugarSpoons <= 0 || cocoaSpoons <= 0)
                {
                    Console.WriteLine("Ingredients are not enough for a box of cookies.");
                }
                else
                {
                    decimal minimum = GetMinimumAmount(flourCups, sugarSpoons, cocoaSpoons);

                    decimal totalCookiesPerBake = Math.Floor((140 + 10 + 20) * minimum / 25);

                    int boxesPerBake = (int)totalCookiesPerBake / 5;
                    Console.WriteLine($"Boxes of cookies: {boxesPerBake}");

                    totalBoxes += boxesPerBake;
                }
            }

            Console.WriteLine($"Total boxes: {totalBoxes}");
        }

        private static decimal GetMinimumAmount(decimal flourCups, decimal sugarSpoons, decimal cocoaSpoons)
        {
            decimal result = 0;

            decimal currMin = Math.Min(flourCups, sugarSpoons);

            result = Math.Min(currMin, cocoaSpoons);

            return result;
        }

        private static int GetCocoaSpoons(int cocoaAmount)
        {
            int result = cocoaAmount / 10;

            return result;
        }

        private static int GetSugarSpoons(int sugarAmount)
        {
            int result = sugarAmount / 20;

            return result;
        }

        private static int GetFlourCups(int flourAmount)
        {
            int result = flourAmount / 140;

            return result;
        }
    }
}
