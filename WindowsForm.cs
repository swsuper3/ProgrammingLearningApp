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
    // For using the Form, we used the following guide:
    // https://learn.microsoft.com/en-us/dotnet/desktop/winforms/how-to-create-a-windows-forms-application-from-the-command-line?view=netframeworkdesktop-4.8
    
    public class WindowsForm : Form
    {
        public Button runButton;

        public WindowsForm()
        {
            runButton = new Button()
            {
                Size = new System.Drawing.Size(40, 40),
                Location = new System.Drawing.Point(30, 30),
                Text = "Run"
            };
            this.Controls.Add(runButton);
            runButton.Click += new EventHandler(runButton_Click);
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Running...");
        }

        [STAThread]         // This specifies that our app is a single-threaded apartment
        public static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.Run();
        }
        
    }
}
