using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLearningApp
{
    public abstract class Command
    {
    }

    public class MoveCommand : Command
    {
        int amountToMove;

        public MoveCommand(int amountToMove)
        {
            this.amountToMove = amountToMove;
        }
    }

    public class TurnCommand : Command
    {
        LeftRight turnDirection;

        public TurnCommand(LeftRight turnDirection)
        {
            this.turnDirection = turnDirection;
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
    }

    public enum LeftRight {
        Left,
        Right
    }

}
