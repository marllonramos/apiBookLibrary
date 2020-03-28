using bookLibrary.Domain.Commands.CategoryCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace bookLibrary.Tests.CommandsTests
{
    [TestClass]
    [TestCategory("Category - Tests")]
    public class UpdateCategoryTests
    {
        [TestMethod]
        public void Should_return_invalid_if_id_is_invalid()
        {
            var command = new UpdateCategoryCommand()
            {
                Id = Guid.Empty,
                Name = "Ação"
            };

            command.Validate();
            Assert.IsTrue(command.Invalid);
        }

        [TestMethod]
        public void Should_return_invalid_if_name_is_invalid()
        {
            var command = new UpdateCategoryCommand()
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
            var command = new UpdateCategoryCommand()
            {
                Id = Guid.NewGuid(),
                Name = "Carlos Munoz"
            };

            command.Validate();


            Assert.IsTrue(command.Valid);
        }
    }
}
