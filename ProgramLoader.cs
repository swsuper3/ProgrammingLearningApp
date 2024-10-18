using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLearningApp
{
    public class ProgramLoader
    {
        // These programs are hard-coded, so they do not get loaded in from a file, but are already defined.
        private List<Program> hardcodedPrograms;

        public ProgramLoader()
        {
            hardcodedPrograms = new List<Program>()
            {
                new Program(new List<string>() {"Move 3", "Turn left", "Move 2", "Turn left", "Move 9"}),                          // 0 (beginner)
                new Program(new List<string>() {"Turn right", "Turn right", "Move 5", "Turn left", "Move 2"}),                     // 1 (beginner)
                new Program(new List<string>() {"Move 3", "Turn left", "Repeat 5", "\tMove 2", "\tTurn right", "Move 4"}),         // 2 (advanced)
                new Program(new List<string>() {"Move 5", "Repeat 8", "\tTurn left", "Move 3", "Repeat 5", "\tTurn right"}),       // 3 (advanced)
                new Program(new List<string>() {"Repeat 2", "\tRepeat 3", "\t\tTurn right", "\t\tMove 2", "Move 1"}),              // 4 (expert)
                new Program(new List<string>() {"Turn right", "Repeat 3", "\tMove 5", "\tTurn left", "\tRepeat 1", "\t\tMove 2"})  // 5 (expert)
            };
        }

        /// <summary>
        /// This method creates and returns a program from the specified filename. By default it tries to find the file inside of the Programs folder.
        /// </summary>
        /// <param name="filename">file name including extension</param>
        /// <returns></returns>
        public Program CreateProgram(string filename, string path = "../../../Programs/") => new Program(ReadFile(path+filename));

        /// <summary>
        /// This method returns one of the hardcoded programs, specified by the number.
        /// </summary>
        public Program CreateProgram(int hardcodedNr) => hardcodedPrograms[hardcodedNr];

        /// <summary>
        /// This methods simply reads a file and puts each line into a list.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public List<string> ReadFile(string filename)
        {
            List<string> lines = new List<string>();
            StreamReader sr = new StreamReader(filename);
            string line = sr.ReadLine();

            while (line != null)
            {
                lines.Add(line);
                line = sr.ReadLine();
            }

            sr.Close();

            return lines;
        }
    }
}
