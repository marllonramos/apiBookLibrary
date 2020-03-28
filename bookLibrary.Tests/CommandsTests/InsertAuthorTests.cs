using bookLibrary.Domain.Commands.AuthorCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bookLibrary.Tests.CommandsTests
{
    [TestClass]
    [TestCategory("Author - Tests")]
    public class InsertAuthorTests
    {
        [TestMethod]
        public void Should_return_invalid_if_invalid_commands()
        {
            var command = new CreateAuthorCommand()
            {
                Name = ""
            };

            command.Validate();

            Assert.IsTrue(command.Invalid);
        }

        [TestMethod]
        public void Should_return_invalid_if_valid_commands()
        {
            var command = new CreateAuthorCommand()
            {
                Name = "Laerte Silva"
            };

            command.Validate();


            Assert.IsTrue(command.Valid);
        } 
    }
}
