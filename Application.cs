using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLearningApp
{
    public class Application
    {
        ProgramLoader programLoader = new ProgramLoader();

        public Application()
        {
            programLoader = new ProgramLoader();
        }

        public void RunProgram(string filename)
        {
            Character character = new Character();
            Program program = programLoader.CreateProgram(filename);

            program.Execute(character);

            Console.WriteLine("End state "+character.Position+" facing "+character.ViewDirection);
        }
    }
}
