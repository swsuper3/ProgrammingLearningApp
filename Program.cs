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

        private void AddCommand(Command c)
        {
            commands.Add(c);
        }

        /// <summary>
        /// This method executes all commands in this program.
        /// </summary>
        /// <param name="character"></param>
        public void Execute(Character character)
        {
            foreach(Command c in commands)
            {
                c.Execute(character);
            }
        }

        public ProgramMetrics GetMetrics()
        {
            int noOfCommands = commands.Count;

            int noOfRepeats = 0;

            List<int> repeatNestingLevels = new List<int>();
            foreach(Command command in commands)
            {
                if(command is not RepeatCommand)
                {
                    continue;
                }

                RepeatCommand repeat = (RepeatCommand) command;
                noOfRepeats++;

                ProgramMetrics repeatMetrics = repeat.GetMetrics();

                noOfCommands += repeatMetrics.noOfCommands;
                noOfRepeats += repeatMetrics.noOfRepeats;
                repeatNestingLevels.Add(repeatMetrics.maxNestingLevel);
            }

            int maxNestingLevel = 0;

            if (noOfRepeats != 0) {
                maxNestingLevel = repeatNestingLevels.Max();
            }

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
                        command = terms[1] == "left"
                            ? new TurnCommand(turnDirection: LeftRight.Left)
                            : new TurnCommand(turnDirection: LeftRight.Right);
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

                AddCommand(command);
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
