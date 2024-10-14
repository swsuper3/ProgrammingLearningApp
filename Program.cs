using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLearningApp
{
    public class Program
    {
        List<Command> commands;

        public void AddCommand(Command c)
        {
            commands.Add(c);
        }
    }
}
