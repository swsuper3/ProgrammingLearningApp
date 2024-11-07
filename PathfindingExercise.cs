using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLearningApp
{
    public class PathfindingExercise : Exercise
    {
        int gridWidth;
        int gridHeight;
        List<Point> obstacles;

        public int GridWidth { get { return gridWidth; } }
        public int GridHeight { get { return gridHeight; } }
        public List<Point> Obstacles { get { return obstacles; } }

        public PathfindingExercise(string fileName) : base(fileName) { }

        protected override void Parse(List<string> lines)
        {
            gridWidth = lines.Max(x => x.Length);
            gridHeight = lines.Count;
            obstacles = new List<Point>();

            for(int i = 0; i < gridWidth; i++)
            {
                for(int j = 0; j < gridHeight; j++)
                {
                    switch (lines[j][i])
                    {
                        case '+':
                            obstacles.Add(new Point(i, j));
                            break;
                    }
                }
            }
        }
    }
}
