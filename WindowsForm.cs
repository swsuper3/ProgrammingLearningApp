using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows;
using System.Diagnostics;

namespace ProgrammingLearningApp
{
    // For creating the Form, we used the following guides:
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

        private List<CommandBlock> commandBlocks = new List<CommandBlock>();
        private ComboBox programSelecter;
        private Button metricsButton;
        private FlowLayoutPanel gridDisplay;
        private TableLayoutPanel grid;
        private TextBox output;
        private Button turnCommand;
        private Button moveCommand;
        private Button repeatCommand;
        private ListBox Program;
        private TreeView treeView1;
        private Button runButton;


        private void InitializeComponent()
        {
            runButton = new Button();
            metricsButton = new Button();
            programSelecter = new ComboBox();
            gridDisplay = new FlowLayoutPanel();
            grid = new TableLayoutPanel();
            output = new TextBox();
            turnCommand = new Button();
            moveCommand = new Button();
            repeatCommand = new Button();
            Program = new ListBox();
            treeView1 = new TreeView();
            gridDisplay.SuspendLayout();
            SuspendLayout();
            // 
            // runButton
            // 
            runButton.BackColor = Color.ForestGreen;
            runButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            runButton.Location = new System.Drawing.Point(219, 508);
            runButton.Name = "runButton";
            runButton.Size = new System.Drawing.Size(122, 52);
            runButton.TabIndex = 1;
            runButton.Text = "Run";
            runButton.UseVisualStyleBackColor = false;
            runButton.Click += runButton_Click;
            // 
            // metricsButton
            // 
            metricsButton.BackColor = Color.DodgerBlue;
            metricsButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            metricsButton.Location = new System.Drawing.Point(348, 508);
            metricsButton.Name = "metricsButton";
            metricsButton.Size = new System.Drawing.Size(122, 52);
            metricsButton.TabIndex = 0;
            metricsButton.Text = "Metrics";
            metricsButton.UseVisualStyleBackColor = false;
            metricsButton.Click += metricsButton_Click;
            // 
            // programSelecter
            // 
            programSelecter.Items.AddRange(new object[] { "Basic", "Advanced", "Expert", "From file..." });
            programSelecter.Location = new System.Drawing.Point(12, 27);
            programSelecter.Name = "programSelecter";
            programSelecter.Size = new System.Drawing.Size(200, 40);
            programSelecter.TabIndex = 2;
            programSelecter.Text = "Load program";
            programSelecter.SelectedIndexChanged += programSelecter_SelectedIndexChanged;
            // 
            // gridDisplay
            // 
            gridDisplay.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            gridDisplay.Controls.Add(grid);
            gridDisplay.Location = new System.Drawing.Point(689, 82);
            gridDisplay.Name = "gridDisplay";
            gridDisplay.Size = new System.Drawing.Size(414, 421);
            gridDisplay.TabIndex = 3;
            // 
            // grid
            // 
            grid.ColumnCount = 4;
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            grid.Location = new System.Drawing.Point(3, 3);
            grid.Name = "grid";
            grid.RowCount = 4;
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            grid.Size = new System.Drawing.Size(386, 279);
            grid.TabIndex = 0;
            grid.Paint += grid_Paint;
            // 
            // output
            // 
            output.ForeColor = Color.Gainsboro;
            output.Location = new System.Drawing.Point(219, 566);
            output.Name = "output";
            output.PlaceholderText = "<output>";
            output.ReadOnly = true;
            output.Size = new System.Drawing.Size(400, 39);
            output.TabIndex = 4;
            output.TextChanged += textBox1_TextChanged;
            // 
            // turnCommand
            // 
            turnCommand.BackColor = Color.Goldenrod;
            turnCommand.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            turnCommand.Location = new System.Drawing.Point(220, 20);
            turnCommand.Name = "turnCommand";
            turnCommand.Size = new System.Drawing.Size(122, 52);
            turnCommand.TabIndex = 5;
            turnCommand.Text = "Turn";
            turnCommand.UseVisualStyleBackColor = false;
            turnCommand.Click += turnCommand_Click;
            // 
            // moveCommand
            // 
            moveCommand.BackColor = Color.Goldenrod;
            moveCommand.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            moveCommand.Location = new System.Drawing.Point(348, 20);
            moveCommand.Name = "moveCommand";
            moveCommand.Size = new System.Drawing.Size(122, 52);
            moveCommand.TabIndex = 6;
            moveCommand.Text = "Move";
            moveCommand.UseVisualStyleBackColor = false;
            moveCommand.Click += moveCommand_Click;
            // 
            // repeatCommand
            // 
            repeatCommand.BackColor = Color.Goldenrod;
            repeatCommand.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            repeatCommand.Location = new System.Drawing.Point(476, 20);
            repeatCommand.Name = "repeatCommand";
            repeatCommand.Size = new System.Drawing.Size(122, 52);
            repeatCommand.TabIndex = 7;
            repeatCommand.Text = "Repeat";
            repeatCommand.UseVisualStyleBackColor = false;
            repeatCommand.Click += repeatCommand_Click;
            // 
            // Program
            // 
            Program.ForeColor = System.Drawing.SystemColors.Window;
            Program.FormattingEnabled = true;
            Program.ItemHeight = 32;
            Program.Location = new System.Drawing.Point(219, 82);
            Program.Name = "Program";
            Program.Size = new System.Drawing.Size(464, 420);
            Program.TabIndex = 8;
            Program.SelectedIndexChanged += program_SelectedIndexChanged;
            // 
            // treeView1
            // 
            treeView1.Location = new System.Drawing.Point(243, 128);
            treeView1.Name = "treeView1";
            treeView1.Size = new System.Drawing.Size(242, 194);
            treeView1.TabIndex = 9;
            // 
            // WindowsForm
            // 
            ClientSize = new System.Drawing.Size(1115, 770);
            Controls.Add(treeView1);
            Controls.Add(Program);
            Controls.Add(repeatCommand);
            Controls.Add(moveCommand);
            Controls.Add(turnCommand);
            Controls.Add(output);
            Controls.Add(gridDisplay);
            Controls.Add(metricsButton);
            Controls.Add(runButton);
            Controls.Add(programSelecter);
            Name = "WindowsForm";
            Text = "Programming Learning App";
            Load += WindowsForm_Load;
            gridDisplay.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private void AddTurnCommand(LeftRight leftRightDirection)
        {
            TurnCommandBlock turnCommandBlock = new TurnCommandBlock(leftRightDirection);
            commandBlocks.Add(turnCommandBlock);
            this.Controls.Add(turnCommandBlock);
            this.turnCommandBlock.Click += new System.EventHandler(th)
        }

        private void AddMoveCommand(int moveAmount)
        {
            MoveCommandBlock moveCommandBlock = new MoveCommandBlock(moveAmount);
            commandBlocks.Add(moveCommandBlock);
        }

        private void AddRepeatCommand(int repeatAmount)
        {
            RepeatCommandBlock repeatCommandBlock = new RepeatCommandBlock(repeatAmount);
            commandBlocks.Add(repeatCommandBlock);
        }

        private void metricsButton_Click(object sender, EventArgs e)
        {

        }

        private void runButton_Click(object sender, EventArgs e)
        {
            InitializeComponent();
        }

        private void programSelecter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void WindowsForm_Load(object sender, EventArgs e)
        {

        }

        private void grid_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void turnCommand_Click(object sender, EventArgs e)
        {
            AddTurnCommand(LeftRight.Left);
        }

        private void moveCommand_Click(object sender, EventArgs e)
        {
            AddMoveCommand(4);
        }

        private void repeatCommand_Click(object sender, EventArgs e)
        {
            AddRepeatCommand(3);
        }

        private void command_Click(object sender, EventArgs e)
        {

        }

        private void program_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
