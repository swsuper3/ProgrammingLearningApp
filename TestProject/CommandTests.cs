using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammingLearningApp;

namespace TestProject
{
    public class CommandTests
    {
        [Fact]
        public void ValidCommand_HappyPath_ProgramParse()
        {
            //Arrange
            List<string> validCommands = new List<string>();
            validCommands.Add("Move 3");
            Program p;

            try
            {
                p = new Program(validCommands);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.Fail("No error was expected, but one was thrown: " + ex.Message);
            }
        }

        [Fact]
        public void InvalidCommand_NotTwoWords_ProgramParse()
        {
            //Arrange
            List<string> invalidCommand = new List<string>();
            invalidCommand.Add("Move3");
            Program p;

            //Act
            Action a = () => p = new Program(invalidCommand);

            //Assert
            Assert.Throws<IndexOutOfRangeException>(a);
        }

        [Fact]
        public void InvalidCommand_CommandNotRecognized_ProgramParse()
        {
            //Arrange
            List<string> invalidCommand = new List<string>();
            invalidCommand.Add("sdkljflksklff 2");
            Program p;

            //Act
            Action a = () => p = new Program(invalidCommand);

            //Assert
            Assert.Throws<Exception>(a);
        }
    }
}
