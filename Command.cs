using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLearningApp
{
    public abstract class Command
    {
        public abstract void Execute(World world);
    }

    public class MoveCommand : Command
    {
        int amountToMove;

        public MoveCommand(int amountToMove)
        {
            this.amountToMove = amountToMove;
        }

        /// <summary>
        /// This method calls the Move method of the character.
        /// </summary>
        /// <param name="character"></param>
        public override void Execute(World world)
        {
            world.MovePlayer(amountToMove);
        }

        public override string ToString()
        {
            return "Move " + amountToMove;
        }
    }

    public class TurnCommand : Command
    {
        LeftRight turnDirection;

        public TurnCommand(LeftRight turnDirection)
        {
            this.turnDirection = turnDirection;
        }

        /// <summary>
        /// This method calls the Turn method of the character.
        /// </summary>
        /// <param name="character"></param>
        public override void Execute(World world)
        {
            world.TurnPlayer(turnDirection);
        }

        public override string ToString()
        {
            return "Turn " + turnDirection;
        }
    }

    public class RepeatCommand : Command
    {
        Program programToRepeat;
        int amountOfRepeats;

        public RepeatCommand(Program program, int repeats)
        {
            programToRepeat = program;
            amountOfRepeats = repeats;
        }

        /// <summary>
        /// This method executes the program to repeat the amound of times necessary.
        /// </summary>
        /// <param name="character"></param>
        public override void Execute(World world)
        {
            for (int i = 0; i < amountOfRepeats; i++)
            {
                programToRepeat.Execute(world);
            }
        }

        /// <summary>
        /// This method passes the metrics from the Repeat's inner program. One exception: the maxNestingLevel is incremented to show that the inner program was nested.
        /// </summary>
        /// <returns></returns>
        public ProgramMetrics GetMetrics()
        {
            ProgramMetrics innerProgram = programToRepeat.GetMetrics();

            return new ProgramMetrics(innerProgram.noOfCommands, innerProgram.maxNestingLevel + 1, innerProgram.noOfRepeats);
        }

        public override string ToString()
        {
            List<string> programStrings = new List<string>();
            for(int i = 0; i < amountOfRepeats; i++)
            {
                programStrings.Add(programToRepeat.ToString());
            }

            return string.Join(", ", programStrings);
        }
    }

    public enum LeftRight {
        Left,
        Right
    }

}
