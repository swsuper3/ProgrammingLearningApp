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
    // For using the Form, we used the following guides:
    // https://learn.microsoft.com/en-us/dotnet/desktop/winforms/how-to-create-a-windows-forms-application-from-the-command-line?view=netframeworkdesktop-4.8
    // https://learn.microsoft.com/en-us/visualstudio/ide/create-csharp-winform-visual-studio?view=vs-2022

    public class WindowsForm : Form
    {
        public WindowsForm()
        {
            InitializeComponent();
        }

        [STAThread]         // This specifies that our app is a single-threaded apartment
        public static void Main()
        {
            Initialize();
            System.Windows.Forms.Application.Run(new WindowsForm());
        }

        public static void Initialize()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
        }

        private ComboBox programSelecter;
        private Button metricsButton;
        private Button runButton;


        private void InitializeComponent()
        {
            #region Initializing Design Elements
            runButton = new Button()
            {
                Location = new System.Drawing.Point(170, 528),
                Name = "runButton",
                Size = new System.Drawing.Size(150, 46),
                TabIndex = 0,
                Text = "Run",  
                UseVisualStyleBackColor = true
            };
            runButton.Click += runButton_Click;

            metricsButton = new Button()
            {
                Location = new System.Drawing.Point(343, 528),
                Name = "metricsButton",
                Size = new System.Drawing.Size(150, 46),
                TabIndex = 3,
                Text = "Metrics",
                UseVisualStyleBackColor = true
            };
            metricsButton.Click += metricsButton_Click;


            programSelecter = new ComboBox()
            {
                FormattingEnabled = true,
                Location = new System.Drawing.Point(12, 27),
                Name = "comboBox1",
                Size = new System.Drawing.Size(242, 40),
                TabIndex = 2,
                Text = "Load program"
            };
            programSelecter.Items.AddRange(new object[] { "Basic", "Advanced", "Expert", "From file..." });
            programSelecter.SelectedIndexChanged += programSelecter_SelectedIndexChanged;
            #endregion

            SuspendLayout();

            // WindowsForm
            ClientSize = new System.Drawing.Size(921, 770);
            Controls.Add(metricsButton);
            Controls.Add(runButton);
            Controls.Add(programSelecter);
            Name = "Programming Learning App";
            Load += WindowsForm_Load;
            Text = "Programming Learning App";
            ResumeLayout(false);
        }

        #region Component Events
        private void metricsButton_Click(object sender, EventArgs e)
        {

        }

        private void runButton_Click(object sender, EventArgs e)
        {

        }

        private void programSelecter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void WindowsForm_Load(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
