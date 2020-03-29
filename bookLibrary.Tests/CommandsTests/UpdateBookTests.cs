using bookLibrary.Domain.Commands.BookCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace bookLibrary.Tests.CommandsTests
{
    [TestClass]
    [TestCategory("Book - Update Tests")]
    public class UpdateBookTests
    {
        UpdateBookCommand _invalidCommand;
        UpdateBookCommand _validCommand;

        public UpdateBookTests()
        {
            #region _invalidCommand
            _invalidCommand = new UpdateBookCommand();
            _invalidCommand.Id = Guid.Empty;
            _invalidCommand.Title = "";
            _invalidCommand.Description = "Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum";
            _invalidCommand.Status = 0;
            _invalidCommand.PublishingCompanyId = Guid.Empty;
            _invalidCommand.AuthorId = Guid.Empty;
            _invalidCommand.CategoryId = Guid.Empty;
            #endregion
            #region _validCommand
            _validCommand = new UpdateBookCommand();
            _validCommand.Id = Guid.Empty;
            _validCommand.Title = "Além do bem e do mal";
            _validCommand.Description = "Lorem ipsum Lorem ipsum Lorem ipsum";
            _validCommand.Status = 2;
            _validCommand.PublishingCompanyId = Guid.NewGuid();
            _validCommand.AuthorId = Guid.NewGuid();
            _validCommand.CategoryId = Guid.NewGuid();
            #endregion
        }

        [TestMethod]
        public void Should_return_invalid_if_invalid_command()
        {
            _invalidCommand.Validate();
            Assert.AreEqual(false, _invalidCommand.Valid);
        }

        [TestMethod]
        public void Should_return_valid_if_valid_command()
        {
            _validCommand.Validate();
            Assert.AreEqual(true, _validCommand.Valid);
        }
    }
}
