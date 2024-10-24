using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows;

namespace ProgrammingLearningApp
{
    public abstract class CommandBlock : Button
    {
        protected CommandBlock()
        {

        }

    }

    public class TurnCommandBlock : CommandBlock
    {

    }

    public class MoveCommandBlock : CommandBlock
    {

    }

    public class RepeatCommandBlock : CommandBlock
    {

    }
}
