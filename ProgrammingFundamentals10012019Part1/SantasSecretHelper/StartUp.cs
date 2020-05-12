using System;
using System.Text;
using System.Text.RegularExpressions;

namespace SantasSecretHelper
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int substractNum = int.Parse(Console.ReadLine());

            string message = Console.ReadLine();

            while (message != "end")
            {
                byte[] asciiBytes = Encoding.ASCII.GetBytes(message);

                string decripted = "";

                for (int i = 0; i < asciiBytes.Length; i++)
                {
                    char character = (char)(asciiBytes[i] - substractNum);

                    decripted += character;
                }
                //@([A-Z]{1}[a-z]+)[^@-\\!:>][a-z]+!([A-Z]{1})!    =>  @Kate^jfdvbkrjgb!G!
                //.+@([A-Z]{1}[a-z]+)[^@-\\!:>][a-z]+!([A-Z]{1})!   =>  Kzbfabfajh!$%jkvbkj@Kim^jkfk!G!
                //.+@([A-Z]{1}[a-z]+)[0-9]*[^@-\\!:>][a-z]+!([A-Z]{1})!  =>  768huehfvwkjv@Lana97958749ndgjhb!G!
                //.*@([A-Z]{1}[a-z]+)[0-9]*[^@-\\!:>][a-z]+!([A-Z]{1})!  =>  matches everything

                Regex first = new Regex(@".*@([A-Z]{1}[a-z]+)[0-9]*[^-@!:>]*[a-z]*!([A-Z]{1})!");

                Match matchFirst = first.Match(decripted);

                if (matchFirst.Success)
                {
                    string name = matchFirst.Groups[1].Value;
                    if (matchFirst.Groups[2].Value == "G")
                    {
                        Console.WriteLine($"{name}");
                    }
                    message = Console.ReadLine();
                    continue;
                }

                message = Console.ReadLine();
            }
        }
    }
}
