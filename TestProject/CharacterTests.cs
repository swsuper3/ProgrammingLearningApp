using ProgrammingLearningApp;

namespace TestProject
{
    public class CharacterTests
    {
        [Fact]
        public void TurnLeft_NorthToWest()
        {
            //Arrange
            Character c = new Character();

            //Act
            c.Turn(LeftRight.Left);
            c.Turn(LeftRight.Left);

            //Assert
            Assert.Equal(Direction.West, c.ViewDirection);
        }

        [Fact]
        public void TurnRight_WestToNorth()
        {
            //Arrange
            Character c = new Character();

            //Act
            c.Turn(LeftRight.Right);
            c.Turn(LeftRight.Right);
            c.Turn(LeftRight.Right);

            //Assert
            Assert.Equal(Direction.North, c.ViewDirection);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(0)]
        [InlineData(99999)]
        public void Move_Character_East(int amountToMove)
        {
            //Arrange
            Character c = new Character();

            //Act
            c.Move(amountToMove);

            //Assert
            Assert.Equal(amountToMove, c.Position.x);
        }
    }
}