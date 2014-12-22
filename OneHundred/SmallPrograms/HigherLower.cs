using CommonCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallPrograms
{
    public class HigherLower : IProgram
    {
        string piAsString;
        int currentPosition;

        public HigherLower()
        {
            Reset();
        }

        public void Run()
        {
            ConsoleKeyInfo userInput;
            bool isPlaying = true;

            do
            {
                for (; currentPosition <= piAsString.Length - 2; currentPosition++)
                {
                    DrawCurrentState();
                    userInput = Console.ReadKey();

                    if (CheckDecision(userInput.Key))
                    {
                        if(currentPosition == piAsString.Length - 2)
                        {
                            DrawVictory();
                            isPlaying = false;
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        if (userInput.Key == ConsoleKey.E)
                        {
                            isPlaying = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong!");
                            Reset();
                            Console.ReadKey();

                        }
                        break;
                    }
                }
            }
            while (isPlaying);
            
        }

        private void Reset()
        {
            piAsString = Math.PI.ToString();
            currentPosition = 2;
        }

        private void DrawCurrentState()
        {
            Console.Clear();
            Console.WriteLine("Next number will be higher - arrow up");
            Console.WriteLine("Next number will be lower - arrow down");
            Console.Write(piAsString.Substring(0, currentPosition + 1));
        }

        private bool CheckDecision(ConsoleKey key)
        {
            int currentNumber = Int32.Parse(piAsString[currentPosition].ToString());
            int nextNumber = Int32.Parse(piAsString[currentPosition + 1].ToString());

            return (currentNumber > nextNumber && key == ConsoleKey.DownArrow) || (currentNumber < nextNumber && key == ConsoleKey.UpArrow) || currentNumber == nextNumber;
        }

        private void DrawVictory()
        {
            Console.Clear();
            Console.WriteLine("Congratulations! You won!");
            Console.Write(piAsString);
        }
    }
}
