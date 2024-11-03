using ProgrammingLearningApp;

namespace TestProject
{
    public class CharacterTests
    {
        [Theory]
        [InlineData(LeftRight.Left, 2, Direction.West)]
        [InlineData(LeftRight.Right, 2, Direction.West)]
        [InlineData(LeftRight.Left, 1, Direction.North)]
        [InlineData(LeftRight.Right, 3, Direction.North)]
        [InlineData(LeftRight.Left, 4, Direction.East)]
        [InlineData(LeftRight.Right, 4, Direction.East)]
        public void TurnTesting(LeftRight turnDirection, int amount, Direction expected)
        {
            //Arrange
            Character c = new Character();

            //Act
            c.Turn(turnDirection, amount);

            //Assert
            Assert.Equal(expected, c.ViewDirection);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(0)]
        [InlineData(99999)]
        public void Move_Character_East(int amountToMove)
        {
            //Arrange
            Character c = new Character();
            World world = new World(c);

            //Act
            world.MovePlayer(amountToMove);

            //Assert
            Assert.Equal(amountToMove, c.Position.x);
        }
    }
}