using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLearningApp
{
    public class MockExercise : PathfindingExercise
    {
        public MockExercise(string input) : base(input)
        {

        }

        public override List<string> ReadFile(string fileName)
        {
            return fileName.Split(';').ToList();
        }
    }
}
