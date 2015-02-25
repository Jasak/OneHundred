using CommonCode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameGenerator
{
    public class NGenerator : IProgram
    {
        Random random;

        private readonly string[] C = new string[] { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "r", "s", "t", "v", "w", "x", "y", "z" };
        private string[] V = new string[] { "a", "i", "e", "o", "u" };
        private string[] Ending = new string[] { "ith", "ton", "on", "field", "man" };

        private List<List<string[]>> Grammars;

        public NGenerator()
        {
            random = new Random(DateTime.Now.Millisecond);

            Grammars = new List<List<string[]>>() {
                new List<string[]>() { C, V, Ending },
                new List<string[]>() { C, V, C, V, Ending }
            };
        }

        public void Run()
        {
            ConsoleKeyInfo userInput;
            Console.Clear();
            Console.WriteLine("Hit Escape to stop. Anykey will continue generation.");
            do
            {
                Console.WriteLine(Generate());
                userInput = Console.ReadKey();
            }
            while (userInput.Key != ConsoleKey.Escape);
            
        }

        public string Generate()
        {
            StringBuilder nameBuilder = new StringBuilder();

            var grammar = PickRandom<List<string[]>>(Grammars);

            for (int i = 0; i < grammar.Count; i++)
            {
                if (i == 0)
                    nameBuilder.Append(PickRandom<string>(grammar[i]).ToUpper());
                else
                    nameBuilder.Append(PickRandom<string>(grammar[i]));
            }

            return nameBuilder.ToString();
        }

        private T PickRandom<T>(IEnumerable<T> array)
        {
            return array.ToArray()[random.Next(array.ToArray().Length)];
        }
    }
}
