using bookLibrary.Domain.Commands.ReaderCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace bookLibrary.Tests.CommandsTests
{
    [TestClass]
    [TestCategory("Reader - Update Tests")]
    public class UpdateReaderTests
    {
        private readonly UpdateReaderCommand _invalidCommand;
        private readonly UpdateReaderCommand _validCommand;

        public UpdateReaderTests()
        {
            #region _invalidCommand
            _invalidCommand = new UpdateReaderCommand();
            _invalidCommand.Id = Guid.NewGuid();
            _invalidCommand.Name = "Mr";
            //_invalidCommand.Email = "87marllon";
            _invalidCommand.Password = "123";
            #endregion
            #region _validCommand
            _validCommand = new UpdateReaderCommand();
            _validCommand.Id = Guid.NewGuid();
            _validCommand.Name = "Marllon Ramos";
            //_validCommand.Email = "87marllon@gmail.com";
            _validCommand.Password = "12345";
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