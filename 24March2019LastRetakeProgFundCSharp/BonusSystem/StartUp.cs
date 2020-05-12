using System;

namespace BonusSystem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int initialBonus = int.Parse(Console.ReadLine());

            double currTotalBonus = 0;
            int currAttendances = 0;

            for (int i = 0; i < studentsCount; i++)
            {
                int attendance = int.Parse(Console.ReadLine());

                double totalScore = (5.00 + initialBonus * 1.00) * attendance / lecturesCount;

                double totalBonus = Math.Round(totalScore);


                if (currTotalBonus < totalBonus)
                {
                    currTotalBonus = totalBonus;
                    currAttendances = attendance;
                }
            }

            Console.WriteLine($"The maximum bonus score for this course is {currTotalBonus}.The student has attended {currAttendances} lectures.");
        }
    }
}
