namespace ProgrammingLearningApp
{
    public class Program
    {
        List<Command> commands;
        public List<Command> Commands { get => commands; }

        public Program(List<string> text)
        {
            this.commands = new List<Command>();
            ParseCommandList(text);
        }

        /// <summary>
        /// This method executes all commands in this program.
        /// </summary>
        /// <param name="character"></param>
        public void Execute(World world)
        {
            foreach(Command c in commands)
                c.Execute(world);
        }

        public ProgramMetrics GetMetrics()
        {
            //The number of commands starts at the amount of commands in the outer program. This number is increased by the commands contained in repeats.
            int noOfCommands = commands.Count;

            int noOfRepeats = 0;

            List<int> repeatNestingLevels = new List<int>();
            foreach(Command command in commands)
            {
                if(command is not RepeatCommand)
                    continue;

                RepeatCommand repeat = (RepeatCommand) command;
                noOfRepeats++;

                ProgramMetrics repeatMetrics = repeat.GetMetrics();

                noOfCommands += repeatMetrics.noOfCommands;
                noOfRepeats += repeatMetrics.noOfRepeats;
                repeatNestingLevels.Add(repeatMetrics.maxNestingLevel);
            }

            //The maximum nesting level is 0 if there are no repeats, otherwise it's the biggest nesting level from all repeats at this level.
            int maxNestingLevel = 0;

            if (noOfRepeats != 0)
                maxNestingLevel = repeatNestingLevels.Max();

            return new ProgramMetrics(noOfCommands, maxNestingLevel, noOfRepeats);
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
                        if (terms[1] == "left")
                            command = new TurnCommand(LeftRight.Left);
                        else if (terms[1] == "right")
                            command = new TurnCommand(LeftRight.Right);
                        else
                        {
                            throw new Exception("Unknown command: " + terms[0] + " " + terms[1]);
                        }
                        break;

                    case "Repeat":
                        int repeats = int.Parse(terms[1]);
                        List<string> commands = new List<string>();
                        for (int j = i + 1; j < text.Count && text[j].StartsWith("\t"); j++)
                        {
                            commands.Add(text[j].Remove(0, 1));
                            i++;
                        }
                        Program program = new Program(commands);
                        command = new RepeatCommand(program, repeats);
                        break;

                    default:
                        throw new Exception("Unknown command: " + terms[0] + " " + terms[1]);
                }

                commands.Add(command);
            }
        }

        public override string ToString()
        {
            List<string> commandStrings = new List<string>();
            foreach (Command c in commands)
            {
                commandStrings.Add(c.ToString());
            }

            return string.Join(", ", commandStrings);
        }
    }
}
