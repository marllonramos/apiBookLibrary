using bookLibrary.Domain.Commands.PublishingCompanyCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bookLibrary.Tests.CommandsTests
{
    [TestClass]
    [TestCategory("PublishingCompany - Tests")]
    public class CreatePublishingCompanyTests
    {
        [TestMethod]
        public void Should_return_invalid_if_invalid_commands()
        {
            var command = new CreatePublishingCompanyCommand()
            {
                Name = ""
            };

            command.Validate();

            Assert.IsTrue(command.Invalid);

        }

        [TestMethod]
        public void Should_return_valid_if_valid_commands()
        {
            var command = new CreatePublishingCompanyCommand()
            {
                Name = "Abril"
            };

            command.Validate();

            Assert.IsTrue(command.Valid);
        }
    }
}
