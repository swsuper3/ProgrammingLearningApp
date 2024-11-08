using ProgrammingLearningApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = ProgrammingLearningApp.Point;

namespace TestProject
{
    public class ExerciseTests
    {
        //For these tests we use a mock exercise class; this class has a definition for ReadFile with absolutely no logic. This way, we can seperately test the Parse() method.


        [Fact]
        public void OneByOneGrid_PathfindingEx()
        {
            //Arrange
            MockExercise exercise = new MockExercise("");
            Point expectedDimensions = new Point(1, 1);
            List<string> grid = new List<string>();
            grid.Add("x");

            //Act
            exercise.Parse(grid);
            Point actualDimensions = new Point(exercise.GridWidth, exercise.GridHeight);

            //Assert
            Assert.Equal(expectedDimensions, actualDimensions);
        }

        [Fact]
        public void TallerThanWide_PathfindingEx()
        {
            //Arrange
            MockExercise exercise = new MockExercise("");
            Point expectedDimensions = new Point(2, 3);
            List<string> grid = new List<string>
            {
                "++",
                "++",
                "++"
            };

            //Act
            exercise.Parse(grid);
            Point actualDimensions = new Point(exercise.GridWidth, exercise.GridHeight);

            //Assert
            Assert.Equal(expectedDimensions, actualDimensions);
        }

        [Fact]
        public void WiderThanTall_PathfindingEx()
        {
            //Arrange
            MockExercise exercise = new MockExercise("");
            Point expectedDimensions = new Point(5, 3);
            List<string> grid = new List<string>
            {
                "+++++",
                "+++++",
                "+++++"
            };

            //Act
            exercise.Parse(grid);
            Point actualDimensions = new Point(exercise.GridWidth, exercise.GridHeight);

            //Assert
            Assert.Equal(expectedDimensions, actualDimensions);
        }

    }
}
