using System;
using System.Collections.Generic;

namespace StackAndQueue.Questions
{
    class Question3
    {
        internal void Init(string input)
        {
            Console.WriteLine("\n**************\t" + this.GetType().Name);

            foreach (var item in new PostfixNotationExpression().ConvertToPostfixNotation(input))
                Console.Write(item+" ");

        }
    }
    class PostfixNotationExpression
    {
        private readonly List<string> operators = new List<string> { "(", ")", "+", "-", "*", "/", "^" };

        private IEnumerable<string> Separate(string input)
        {
            int pos = 0;
            while (pos < input.Length)
            {
                string s = string.Empty + input[pos];
                if (!operators.Contains(input[pos].ToString()))
                {
                    if (!char.IsDigit(input[pos]))
                    {
                        if (char.IsLetter(input[pos]))
                            for (int i = pos + 1; i < input.Length &&
                                (char.IsLetter(input[i]) || char.IsDigit(input[i])); i++)
                                s += input[i];
                    }
                    else for (int i = pos + 1;
                            i < input.Length && (char.IsDigit(input[i]) || input[i] == ',' || input[i] == '.');
                            i++)
                            s += input[i];
                }
                yield return s;
                pos += s.Length;
            }
        }
        private byte GetPriority(string str) => str switch
        {
            "(" or ")" => 0,
            "+" or "-" => 1,
            "*" or "/" => 2,
            "^" => 3,
            _ => 4
        };

        public string[] ConvertToPostfixNotation(string input)
        {
            List<string> outputSeparated = new List<string>();
            Stack<string> stack = new Stack<string>();
            foreach (string c in Separate(input))
            {
                if (operators.Contains(c))
                {
                    if (stack.Count > 0 && !c.Equals("("))
                    {
                        if (c.Equals(")"))
                        {
                            string s = stack.Pop();
                            while (s != "(")
                            {
                                outputSeparated.Add(s);
                                s = stack.Pop();
                            }
                        }
                        else if (GetPriority(c) > GetPriority(stack.Peek()))
                            stack.Push(c);
                        else
                        {
                            while (stack.Count > 0 && GetPriority(c) <= GetPriority(stack.Peek()))
                                outputSeparated.Add(stack.Pop());
                            stack.Push(c);
                        }
                    }
                    else
                        stack.Push(c);
                }
                else
                    outputSeparated.Add(c);
            }
            if (stack.Count > 0)
                foreach (string c in stack)
                    outputSeparated.Add(c);

            return outputSeparated.ToArray();
        }
    }
}
