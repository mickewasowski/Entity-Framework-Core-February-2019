using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EmojiSumator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            int[] emojiCode = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            string emojiWord = "";

            for (int i = 0; i < emojiCode.Length; i++)
            {
                char character = (char)emojiCode[i];
                emojiWord += character;
            }

            List<string> foundEmojis = new List<string>();

            Regex reg = new Regex(@"\s:[a-z]{4,}:[^a-zA-Z0-9_-]\s*?|\,\.\!\?");

            MatchCollection matches = reg.Matches(message);

            StringBuilder sb = new StringBuilder();

            int totalEmojiPower = 0;

            foreach (Match m in matches)
            {
                string word = m.ToString();

                word = word.Substring(1, word.Length - 1);
                word = word.Substring(0, word.Length - 1);

                foundEmojis.Add(word);

                word = word.Substring(1, word.Length - 1);
                word = word.Substring(0, word.Length - 1);

                for (int i = 0; i < word.Length; i++)
                {
                    int currPower = (int)word[i];
                    totalEmojiPower += currPower;
                }
            }

            foreach (var m in foundEmojis)
            {
                string word = m;
                word = word.Substring(1, word.Length - 1);
                word = word.Substring(0, word.Length - 1);

                if (word == emojiWord)
                {
                    totalEmojiPower *= 2;
                    break; // ???
                }
            }

            if (foundEmojis.Count != 0)
            {
                Console.Write("Emojis found: ");
                Console.WriteLine(string.Join(", ", foundEmojis));
            }
            Console.WriteLine($"Total Emoji Power: {totalEmojiPower}");
        }
    }
}
