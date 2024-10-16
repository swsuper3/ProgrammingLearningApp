using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLearningApp
{
    public class ProgramLoader
    {
        public Program CreateProgram(string filename)
        {
            return new Program(ReadFile(filename));
        }

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

            return lines;
        }
    }
}
