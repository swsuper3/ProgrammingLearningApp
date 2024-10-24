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

        private void InitializeComponent()
        {
            button1 = new Button();
            comboBox1 = new ComboBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(170, 528);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(150, 46);
            button1.TabIndex = 0;
            button1.Text = "Run";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Basic", "Advanced", "Expert", "From file..." });
            comboBox1.Location = new System.Drawing.Point(12, 27);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(242, 40);
            comboBox1.TabIndex = 2;
            comboBox1.Text = "Load program";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(343, 528);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(150, 46);
            button2.TabIndex = 3;
            button2.Text = "Metrics";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // WindowsForm
            // 
            ClientSize = new System.Drawing.Size(921, 770);
            Controls.Add(button2);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Name = "WindowsForm";
            Load += WindowsForm_Load;
            ResumeLayout(false);
        }

        public static void Initialize()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private TextBox textBox1;
        private MenuStrip menuStrip1;
        private ComboBox comboBox1;
        private Button button2;
        private Button button1;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void WindowsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
