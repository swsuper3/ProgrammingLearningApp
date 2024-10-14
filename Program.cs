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

        public Program(List<string> text)
        {
            this.commands = new List<Command>();
            ParseCommandList(text);
        }

        private void AddCommand(Command c)
        {
            commands.Add(c);
        }

        /// <summary>
        /// This method reads all the commands from a textfile and puts them in the program.
        /// </summary>
        private void ParseCommandList (List<string> text)
        {
            Command command;
            string[] terms;

            for (int i = 0; i < text.Count; i++)
            {
                terms = text[i].Split(' ');

                switch (terms[0])
                {
                    case "Move":
                        command = new MoveCommand(amountToMove: int.Parse(terms[1]));
                        break;

                    case "Turn":
                        command = terms[1] == "left"
                            ? new TurnCommand(turnDirection: LeftRight.Left)
                            : new TurnCommand(turnDirection: LeftRight.Right);
                        break;

                    case "Repeat":
                        int repeats = int.Parse(terms[1]);
                        List<string> commands = new List<string>();
                        for (int j = i; j < text.Count && text[j].StartsWith("\t"); j++)
                            commands.Add(text[j].Remove(0, 2));
                        Program program = new Program(commands);
                        command = new RepeatCommand(program, repeats);
                        break;

                    default:
                        throw new Exception("Unknown command.");
                }

                AddCommand(command);
            }
        }
    }
}
