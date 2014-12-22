using CommonCode;
using NameGenerator;
using SmallPrograms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProgramLuncher
{
    class ProgramLuncher
    {
        static void Main(string[] args)
        {
            //TODO: move this to some program luncher which will be run by this static main method.
            // this below sucks balls
 
            List<System.Type> knownProgramTypes = new List<Type>() {
                typeof(NGenerator),
                typeof(HigherLower)
            };
            ProgramEnumerator programEnumerator = new ProgramEnumerator(knownProgramTypes);
            ConsoleKeyInfo userInput;

            PrintList(programEnumerator);
            do
            {
                Console.WriteLine("Select program or type 'e' to exit.");
                userInput = Console.ReadKey();

                int selectedProgram;
                if(Int32.TryParse(userInput.KeyChar.ToString(), out selectedProgram))
                {
                    if(selectedProgram < programEnumerator.Count())
                    {
                        IProgram programToRun = programEnumerator[selectedProgram].CreateNewInstance();

                        programToRun.Run();

                        Console.Clear();
                        Console.WriteLine(programEnumerator[selectedProgram].Name + " exitted.");
                        PrintList(programEnumerator);
                    }
                    else
                    {
                        Console.WriteLine("Index out of range.");
                    }
                }
            }
            while(userInput.Key != ConsoleKey.E);
            
        }

        static void PrintList(ProgramEnumerator programsEnumeration)
        {
            int i = 0;
            Console.WriteLine("Available programs list:");
            foreach (ProgramDescription desc in programsEnumeration)
            {
                Console.WriteLine(i.ToString() + ". " + desc.Name + " (" + desc.Type.ToString() + ")");
                i++;
            }
        }
    }
}
