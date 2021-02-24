using System;
using System.Collections.Generic;
using System.Text;

namespace StackAndQueue.Questions
{
    class Question1
    {

        private Dictionary<string, int> BracketsCounter = new()
        {
            ["Parentheses"] = 0,
            ["Braces"] = 0,
            ["Brackets"] = 0,
            ["Chevrons"] = 0,
        };
        private static string GetBrecketName(char symbol) =>
           symbol.ToString() switch
           {
               "(" or ")" => "Parentheses",
               "{" or "}" => "Braces",
               "[" or "]" => "Brackets",
               "<" or ">" => "Chevrons",
               _ => null
           };

        private static bool IsOpenBrecket(char symbol) =>
           symbol.ToString() switch
           {
               "(" or "{" or "[" or "<" => true,
               _ => false
           };

        internal void Init(string input)
        {
            Console.WriteLine("\n**************\t" + this.GetType().Name);
            bool InputIsCorrect = true;

            foreach (char symbol in input)
            {
                var BacketName = GetBrecketName(symbol);
                if (BacketName != null)
                    if (BracketsCounter.TryGetValue(BacketName, out int value))
                        if (IsOpenBrecket(symbol))
                            BracketsCounter[BacketName]++;
                        else
                            BracketsCounter[BacketName]--;

                foreach (var item in BracketsCounter)
                    if (item.Value < 0)
                    {
                        InputIsCorrect = false;
                        break;
                    }
            }

            foreach (var item in BracketsCounter)
                if (item.Value != 0)
                {
                    InputIsCorrect = false;
                    break;
                }

            if (InputIsCorrect)
                Console.WriteLine("Transmitted string is correct.");
            else
                Console.WriteLine("String isn't correct!");
        }
    }
}
