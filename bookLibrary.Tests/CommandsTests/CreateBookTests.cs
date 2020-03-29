using bookLibrary.Domain.Commands.BookCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace bookLibrary.Tests.CommandsTests
{
    [TestClass]
    [TestCategory("Book - Create Tests")]
    public class CreateBookTests
    {
        CreateBookCommand _invalidCommand;
        CreateBookCommand _validCommand;
        
        public CreateBookTests()
        {
            #region _invalidCommand
            _invalidCommand = new CreateBookCommand();
            _invalidCommand.Title = "";
            _invalidCommand.Description = "Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum";
            _invalidCommand.PublishingCompanyId = Guid.Empty;
            _invalidCommand.AuthorId = Guid.Empty;
            _invalidCommand.CategoryId = Guid.Empty;
            #endregion
            #region _validCommand
            _validCommand = new CreateBookCommand();
            _validCommand.Title = "O morro dos ventos uivantes";
            _validCommand.Description = "Lorem ipsum Lorem ipsum Lorem ipsum";
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
