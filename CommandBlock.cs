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
        TextBox textBox;

        protected CommandBlock()
        {
            // Designing the properties of the button
            BackColor = Color.MediumPurple;
            ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            Location = new System.Drawing.Point(232, 95);
            Name = "command";
            Size = new System.Drawing.Size(150, 46);
            TabIndex = 9;
            UseVisualStyleBackColor = false;
            Click += command_Click;

            // Designing the properties of the textBox
            textBox = new TextBox()
            {
                BackColor = Color.Lavender,
                Location = new System.Drawing.Point(Location.X + 100, Location.Y + 5), // This places the textBox where we want it in comparison to the commandblock
                Name = "textBox",
                Size = new System.Drawing.Size(33, 39),
                TabIndex = 10
            };
        }

        private void command_Click(object sender, EventArgs e)
        {

        }
    }

    public class TurnCommandBlock : CommandBlock
    {
        public TurnCommandBlock(LeftRight leftRightDirection)
        {
            Text = "Turn " + leftRightDirection;
        }
    }

    public class MoveCommandBlock : CommandBlock
    {
        public MoveCommandBlock(int moveAmount)
        {
            Text = "Move " + moveAmount;
        }
    }

    public class RepeatCommandBlock : CommandBlock
    {
        public RepeatCommandBlock(int repeatAmount)
        {
            Text = "Repeat " + repeatAmount;
        }
    }
}
