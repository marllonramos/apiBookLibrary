using bookLibrary.Domain.Commands.PublishingCompanyCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace bookLibrary.Tests.CommandsTests
{
    [TestClass]
    [TestCategory("PublishingCompany - Tests")]

    public class UpdatePublishingCompanyTests
    {
        [TestMethod]
        public void Should_return_invalid_if_id_is_invalid()
        {
            var command = new UpdatePublishingCompanyCommand()
            {
                Id = Guid.Empty,
                Name = "Abril"
            };

            command.Validate();
            Assert.IsTrue(command.Invalid);
        }

        [TestMethod]
        public void Should_return_invalid_if_name_is_invalid()
        {
            var command = new UpdatePublishingCompanyCommand()
            {
                Id = Guid.NewGuid(),
                Name = ""
            };

            command.Validate();
            Assert.IsTrue(command.Invalid);
        }

        [TestMethod]
        public void Should_return_invalid_if_valid_commands()
        {
            var command = new UpdatePublishingCompanyCommand()
            {
                Id = Guid.NewGuid(),
                Name = "Carlos Munoz"
            };

            command.Validate();


            Assert.IsTrue(command.Valid);
        }
    }
}
