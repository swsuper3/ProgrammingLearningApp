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
using System.Security;
using System.IO;
using Microsoft.Win32;

namespace ProgrammingLearningApp
{
    // For creating the Form, we used the following guides:
    // https://learn.microsoft.com/en-us/dotnet/desktop/winforms/how-to-create-a-windows-forms-application-from-the-command-line?view=netframeworkdesktop-4.8
    // https://learn.microsoft.com/en-us/visualstudio/ide/create-csharp-winform-visual-studio?view=vs-2022
    // https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-open-files-using-the-openfiledialog-component?view=netframeworkdesktop-4.8

    public class WindowsForm : Form
    {
        World world;
        Path path;
        Random random;
        Exercise currentExercise;
        private ComboBox exerciseSelector;
        System.Windows.Forms.OpenFileDialog openFileDialog;

        public WindowsForm()
        {
            InitializeComponent();
            world = new World();
            random = new Random();
            openFileDialog = new System.Windows.Forms.OpenFileDialog()
            {
                FileName = "Select a text file",
                Filter = "Text files (*.txt)|*.txt",
                Title = "Open text file"
            };
            path = new Path(world.Character);
            world.Attach(path);
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
        private TextBox output;
        private Button turnCommand;
        private Button moveCommand;
        private Button repeatCommand;
        private Button runButton;
        private Panel gridPanel;
        private Label title;
        private TextBox textBox1;


        private void InitializeComponent()
        {
            runButton = new Button();
            metricsButton = new Button();
            programSelecter = new ComboBox();
            output = new TextBox();
            turnCommand = new Button();
            moveCommand = new Button();
            repeatCommand = new Button();
            textBox1 = new TextBox();
            gridPanel = new Panel();
            title = new Label();
            exerciseSelector = new ComboBox();
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
            // output
            // 
            output.ForeColor = Color.Gainsboro;
            output.Location = new System.Drawing.Point(219, 566);
            output.Multiline = true;
            output.Name = "output";
            output.PlaceholderText = "<output>";
            output.ReadOnly = true;
            output.Size = new System.Drawing.Size(884, 167);
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
            // textBox1
            // 
            textBox1.AcceptsTab = true;
            textBox1.Location = new System.Drawing.Point(220, 85);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "<Start programming here!>";
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Size = new System.Drawing.Size(463, 417);
            textBox1.TabIndex = 11;
            // 
            // gridPanel
            // 
            gridPanel.AutoScroll = true;
            gridPanel.AutoScrollMinSize = new System.Drawing.Size(828, 834);
            gridPanel.AutoSize = true;
            gridPanel.BackColor = System.Drawing.SystemColors.Window;
            gridPanel.Location = new System.Drawing.Point(689, 85);
            gridPanel.Name = "gridPanel";
            gridPanel.Size = new System.Drawing.Size(414, 417);
            gridPanel.TabIndex = 12;
            gridPanel.Paint += gridPanel_Paint;
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Segoe UI Black", 13.875F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, GraphicsUnit.Point);
            title.ForeColor = Color.DarkSlateGray;
            title.Location = new System.Drawing.Point(218, 17);
            title.Name = "title";
            title.Size = new System.Drawing.Size(527, 50);
            title.TabIndex = 13;
            title.Text = "Programming Learning App";
            title.Click += label1_Click_1;
            // 
            // exerciseSelector
            // 
            exerciseSelector.FormattingEnabled = true;
            exerciseSelector.Items.AddRange(new object[] { "Free play", "From file..." });
            exerciseSelector.Location = new System.Drawing.Point(12, 566);
            exerciseSelector.Name = "exerciseSelector";
            exerciseSelector.Size = new System.Drawing.Size(151, 28);
            exerciseSelector.TabIndex = 14;
            exerciseSelector.Text = "Select exercise";
            exerciseSelector.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // WindowsForm
            // 
            ClientSize = new System.Drawing.Size(1115, 770);
            Controls.Add(exerciseSelector);
            Controls.Add(title);
            Controls.Add(gridPanel);
            Controls.Add(textBox1);
            Controls.Add(output);
            Controls.Add(metricsButton);
            Controls.Add(runButton);
            Controls.Add(programSelecter);
            Name = "WindowsForm";
            Text = "Programming Learning App";
            Load += WindowsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void metricsButton_Click(object sender, EventArgs e)
        {
            // Parse the text from the textBox into a list
            string[] programText = textBox1.Text.Split("\r\n");
            List<string> programList = new List<string>();

            for (int i = 0; i < programText.Length; i++)
                programList.Add(programText[i]);

            // Attempt to get the metrics from the program
            try
            {
                Program program = new Program(programList);
                output.Text = program.GetMetrics().ToString();
            }
            catch
            {
                output.Text = "Invalid program. Please check your syntax and try again.";
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            Reset();

            // Parse the text from the textBox into a list
            string[] programText = textBox1.Text.Split("\r\n");
            List<string> programList = new List<string>();

            for (int i = 0; i < programText.Length; i++)
                programList.Add(programText[i]);

            // Attempt to execute the program
            Path path = new Path(world.Character);
            world.Attach(path);

            try
            {
                Program program = new Program(programList);
                program.Execute(world);
                output.Text = program + ". End state: " + world.Character.Position + " facing " + world.Character.ViewDirection;
            }
            catch (Exception exception)
            {
                output.Text = "Invalid program. Please check your syntax and try again.";
                Debug.WriteLine(exception.Message);
            }

            gridPanel.Invalidate();
        }

        private void programSelecter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fileName = "../../../Programs/empty.txt";

            if (programSelecter.SelectedIndex == 0)      // Basic
                fileName = "../../../Programs/basic" + random.Next(1, 4) + ".txt";

            else if (programSelecter.SelectedIndex == 1) // Advanced
                fileName = "../../../Programs/advanced" + random.Next(1, 4) + ".txt";

            else if (programSelecter.SelectedIndex == 2) // Expert
                fileName = "../../../Programs/expert" + random.Next(1, 4) + ".txt";

            else if (programSelecter.SelectedIndex == 3) // Load FromFile
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    fileName = openFileDialog.FileName;

            var sr = new StreamReader(fileName);
            textBox1.Text = sr.ReadToEnd();
        }

        private void WindowsForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void turnCommand_Click(object sender, EventArgs e)
        {
        }

        private void moveCommand_Click(object sender, EventArgs e)
        {
        }

        private void repeatCommand_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void gridPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Image image = Image.FromFile("../../../pacman.png");


            graphics.TranslateTransform(gridPanel.AutoScrollPosition.X, gridPanel.AutoScrollPosition.Y);
            Pen blackPen = new Pen(Brushes.Black);
            Pen redPen = new Pen(Brushes.Red, 3f);
            Pen purplePen = new Pen(Brushes.Purple, 8f);
            Brush orangeBrush = Brushes.OrangeRed;
            Brush darkOrangeBrush = Brushes.Chocolate;
            Brush greenBrush = Brushes.Green;

            List<Point> playerPath = path.CellsAlongPath;

            int boxWidth = 50;
            int boxHeight = 50;

            int minX = 0;
            int maxX = 9;
            int minY = 0;
            int maxY = 9;

            if (playerPath.Count > 1)
            {
                minX = Math.Min(minX, playerPath.Min(p => p.x));
                minY = Math.Min(minY, playerPath.Min(p => p.y));
                maxX = Math.Max(maxX, playerPath.Max(p => p.x));
                maxY = Math.Max(maxY, playerPath.Max(p => p.y));
            }


            int gridWidth = maxX - minX + 1;
            int gridHeight = maxY - minY + 1;

            gridPanel.AutoScrollMinSize = new System.Drawing.Size(gridWidth * boxWidth, gridHeight * boxHeight);


            //Drawing obstacles: the grid edges with dark orange, the walls with oange, to provide a small distinction
            foreach (KeyValuePair<Point, ObstacleType> obstacle in world.Obstacles)
            {
                if (obstacle.Value == ObstacleType.Wall)
                    graphics.FillRectangle(orangeBrush, new Rectangle(obstacle.Key.x * boxWidth, obstacle.Key.y * boxHeight, boxWidth, boxHeight));
                else
                    graphics.FillRectangle(darkOrangeBrush, new Rectangle(obstacle.Key.x * boxWidth, obstacle.Key.y * boxHeight, boxWidth, boxHeight));
            }

            //Drawing goal & checking for completion
            if (currentExercise != null)
            {
                PathfindingExercise pathExercise = (PathfindingExercise)currentExercise;
                graphics.FillRectangle(greenBrush, new Rectangle(pathExercise.Goal.x * boxWidth, pathExercise.Goal.y * boxHeight, boxWidth, boxHeight));

                if(pathExercise.Goal == world.Character.Position)
                {
                    Form popUp = new Form();
                    popUp.Text = "you r did it";
                    PictureBox pic = new PictureBox();
                    pic.ImageLocation = "https://static.wikia.nocookie.net/nintendo/images/6/60/Pikachu_%28Cap%29.png/revision/latest/scale-to-width/360?cb=20230203112812&path-prefix=en";
                    pic.Size = popUp.ClientSize;
                    popUp.Controls.Add(pic);
                    popUp.Show();
                }
            }

            //Draw grid
            for (int i = 0; i < gridWidth; i++)
            {
                for (int j = 0; j < gridHeight; j++)
                {
                    graphics.DrawRectangle(blackPen, new Rectangle(i * boxWidth, j * boxHeight, boxWidth, boxHeight));
                }
            }

            //Draw origin
            graphics.DrawRectangle(redPen, new Rectangle(-minX * boxWidth, -minY * boxHeight, boxWidth, boxHeight));

            //Draw path
            if (playerPath.Count > 1)
            {
                graphics.DrawLines(purplePen, ParsePoints(playerPath, boxWidth, boxHeight, minX, minY));
            }


            //Draw player
            switch (world.Character.ViewDirection)
            {
                case Direction.West:
                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case Direction.North:
                    image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
                case Direction.South:
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
            }

            Point characterPosition = world.Character.Position;
            graphics.DrawImage(image, new Rectangle((characterPosition.x - minX) * boxWidth, (characterPosition.y - minY) * boxHeight, boxWidth, boxHeight));
        }

        PointF[] ParsePoints(List<Point> points, int boxWidth, int boxHeight, int minX, int minY)
        {
            List<PointF> output = new List<PointF>();

            foreach (Point point in points)
            {
                output.Add(new PointF((point.x + 0.5f - minX) * boxWidth, (point.y + 0.5f - minY) * boxHeight));
            }

            return output.ToArray();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (exerciseSelector.SelectedIndex == 0) // Basic
            {
                currentExercise = null;
            }

            else if (exerciseSelector.SelectedIndex == 1) // Load FromFile 
            {
                string fileName = "../../../Programs/empty.txt";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    fileName = openFileDialog.FileName;

                currentExercise = new PathfindingExercise(fileName);
            }

            Reset();
        }

        void Reset()
        {
            this.world = new World();
            this.path = new Path(world.Character);
            world.Attach(this.path);

            if (currentExercise != null)
            {
                PathfindingExercise pathExercise = (PathfindingExercise)currentExercise;
                world.SetBounds(pathExercise.GridWidth, pathExercise.GridHeight);
                foreach (Point p in pathExercise.Obstacles)
                {
                    world.AddObstacle(p, ObstacleType.Wall);
                }
            }

            Refresh();
        }
    }
}
