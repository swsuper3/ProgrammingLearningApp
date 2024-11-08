using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLearningApp
{
    public abstract class Exercise
    {
        public Exercise(string fileName)
        {
            List<string> lines = ReadFile(fileName);
            Parse(lines);
        }

        public List<string> ReadFile(string fileName)
        {
            List<string> lines = new List<string>();
            StreamReader sr = new StreamReader(fileName);
            string line = sr.ReadLine();

            while (line != null)
            {
                lines.Add(line);
                line = sr.ReadLine();
            }

            sr.Close();

            return lines;
        }

        protected abstract void Parse(List<string> lines);

    }
}
