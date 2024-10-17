using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLearningApp
{
    public class ProgramMetrics
    {
        public int noOfCommands {  get; private set; }
        public int maxNestingLevel { get; private set; }
        public int noOfRepeats { get; private set; }

        public ProgramMetrics(int noOfCommands, int maxNestingLevel, int noOfRepeats)
        {
            this.noOfCommands = noOfCommands;
            this.maxNestingLevel = maxNestingLevel;
            this.noOfRepeats = noOfRepeats;
        }

        public override string ToString()
        {
            List<string> strings = new List<string>();
            strings.Add("Number of commands: "+noOfCommands);
            strings.Add("Maximum nesting level: "+maxNestingLevel);
            strings.Add("Number of repeat commands: "+noOfRepeats);

            return string.Join(", ", strings);
        }
    }
}
