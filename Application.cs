using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        /// <summary>
        /// This method creates a program from the file, runs it and prints its effects to the console.
        /// </summary>
        /// <param name="filename"></param>
        public void RunProgram(string filename)
        {
            Character character = new Character();
            Program program = programLoader.CreateProgram(filename);
            Path path = new Path(character);
            character.Attach(path);

            program.Execute(character);

            Console.WriteLine(program);
            Console.WriteLine("End state "+character.Position+" facing "+character.ViewDirection);

            foreach(Point p in path.CellsAlongPath)
            {
                Debug.WriteLine(p.ToString());
            }
        }

        /// <summary>
        /// This method gets the hardcoded program, runs it and prints its effects to the console.
        /// </summary>
        /// <param name="filename"></param>
        public void RunProgram(int hardcodedNr)
        {
            Character character = new Character();
            Program program = programLoader.CreateProgram(hardcodedNr);

            program.Execute(character);

            Console.WriteLine(program);
            Console.WriteLine("End state " + character.Position + " facing " + character.ViewDirection);
        }

        /// <summary>
        /// This method creates a program from the file and prints its metrics to the console.
        /// </summary>
        /// <param name="filename"></param>
        public void ShowMetrics(string filename)
        {
            Program program = programLoader.CreateProgram(filename);

            Console.WriteLine(program.GetMetrics());
        }

        /// <summary>
        /// This method gets the hardcoded program and prints its metrics to the console.
        /// </summary>
        /// <param name="filename"></param>
        public void ShowMetrics(int hardcodedNr)
        {
            Program program = programLoader.CreateProgram(hardcodedNr);

            Console.WriteLine(program.GetMetrics());
        }
    }
}
