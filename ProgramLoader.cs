using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLearningApp
{
    public class ProgramLoader
    {
        /// <summary>
        /// This method creates and returns a program from the specified filename. By default it tries to find the file inside of the Programs folder.
        /// </summary>
        /// <param name="filename">file name including extension</param>
        /// <returns></returns>
        public Program CreateProgram(string filename, string path = "../../../Programs/")
        {
            return new Program(ReadFile(path+filename));
        }

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

            return lines;
        }
    }
}
