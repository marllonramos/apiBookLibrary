using bookLibrary.Domain.Commands.ReaderCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bookLibrary.Tests.CommandsTests
{
    [TestClass]
    [TestCategory("Reader - Tests")]
    public class InsertReaderTests
    {
        private readonly CreateReaderCommand _invalidCommand;
        private readonly CreateReaderCommand _validCommand;

        public InsertReaderTests()
        {
            #region _invalidCommand
            _invalidCommand = new CreateReaderCommand();
            _invalidCommand.Name = "Ma";
            _invalidCommand.Email = "87marllon";
            _invalidCommand.Password = "123";
            _invalidCommand.ConfirmPassword = "321";
            #endregion
            #region _validCommand
            _validCommand = new CreateReaderCommand();
            _validCommand.Name = "Marllon Ramos";
            _validCommand.Email = "87marllon@gmail.com";
            _validCommand.Password = "12345";
            _validCommand.ConfirmPassword = "12345";
            #endregion
        }

        [TestMethod]
        public void Should_return_invalid_if_invalid_commands()
        {
            _invalidCommand.Validate();
            Assert.AreEqual(false, _invalidCommand.Valid);
        }

        [TestMethod]
        public void Should_return_valid_if_valid_commands()
        {
            _validCommand.Validate();
            Assert.AreEqual(true, _validCommand.Valid);
        }
    }
}
