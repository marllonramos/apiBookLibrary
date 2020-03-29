using bookLibrary.Domain.Commands.AuthorCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace bookLibrary.Tests.CommandsTests
{
    [TestClass]
    [TestCategory("Author - Tests")]
    public class UpdateAuthorTests
    {
        [TestMethod]
        public void Should_return_invalid_if_id_is_invalid()
        {
            var command = new UpdateAuthorCommand()
            {
                Id = Guid.Empty,                
                Name = "Laercio Silva"
            };

            command.Validate();
            Assert.IsTrue(command.Invalid);
        }

        [TestMethod]
        public void Should_return_invalid_if_name_is_invalid()
        {
            var command = new UpdateAuthorCommand()
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
            var command = new UpdateAuthorCommand()
            {
                Id = Guid.NewGuid(),
                Name = "Carlos Munoz"
            };

            command.Validate();


            Assert.IsTrue(command.Valid);
        }
    }
}
