using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLearningApp
{
    public abstract class Command
    {
        public abstract void Execute(Character character);
    }

    public class MoveCommand : Command
    {
        int amountToMove;

        public MoveCommand(int amountToMove)
        {
            this.amountToMove = amountToMove;
        }

        public override void Execute(Character character)
        {
            character.Move(amountToMove);
        }
    }

    public class TurnCommand : Command
    {
        LeftRight turnDirection;

        public TurnCommand(LeftRight turnDirection)
        {
            this.turnDirection = turnDirection;
        }

        public override void Execute(Character character)
        {
            character.Turn(turnDirection);
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

        public override void Execute(Character character)
        {
            for (int i = 0; i < amountOfRepeats; i++)
            {
                programToRepeat.Execute(character);
            }
        }
    }

    public enum LeftRight {
        Left,
        Right
    }

}
