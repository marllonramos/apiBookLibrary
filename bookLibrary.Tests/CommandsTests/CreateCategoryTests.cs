using bookLibrary.Domain.Commands.CategoryCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bookLibrary.Tests.CommandsTests
{
    [TestClass]
    [TestCategory("Category - Tests")]
    public class CreateCategoryTests
    {
        [TestMethod]
        public void Should_return_invalid_if_invalid_commands()
        {
            var command = new CreateCategoryCommand()
            {
                Name = ""
            };

            command.Validate();

            Assert.IsTrue(command.Invalid);
        }

        [TestMethod]
        public void Should_return_valid_if_valid_commands()
        {
            var command = new CreateCategoryCommand()
            {
                Name = "Suspense"
            };

            command.Validate();

            Assert.IsTrue(command.Valid);
        }
    }
}
