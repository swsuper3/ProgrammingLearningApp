using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLearningApp
{
    public class Path : IMyObserver<Character>
    {
        List<Point> cellsAlongPath;
        public List<Point> CellsAlongPath { get { return cellsAlongPath; } }

        public Path(Character c)
        {
            cellsAlongPath = new List<Point>();
            cellsAlongPath.Add(c.Position);
        }

        public void Update(Character character)
        {
            cellsAlongPath.Add(character.Position);
        }

    }
}
