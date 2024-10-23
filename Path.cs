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

        public Path()
        {
            cellsAlongPath = new List<Point>();
        }

        public void Update(Character character)
        {
            cellsAlongPath.Add(character.Position);
        }

    }
}
