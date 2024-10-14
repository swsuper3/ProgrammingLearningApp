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
    }
}