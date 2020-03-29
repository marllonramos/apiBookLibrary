using bookLibrary.Domain.Commands.ReaderCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bookLibrary.Tests.CommandsTests
{
    [TestClass]
    [TestCategory("Reader - Create Tests")]
    public class CreateReaderTests
    {
        private readonly CreateReaderCommand _invalidCommand;
        private readonly CreateReaderCommand _validCommand;

        private readonly CreateReaderCommand _invalidEmailCommand;
        private readonly CreateReaderCommand _validEmailCommand;
        private readonly CreateReaderCommand _passwordDifferentConfirmPasswordCommand;

        public CreateReaderTests()
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

            #region _invalidEmailCommand
            _invalidEmailCommand = new CreateReaderCommand();
            _invalidEmailCommand.Name = "Marllon Ramos";
            _invalidEmailCommand.Email = "87ma";
            _invalidEmailCommand.Password = "123456";
            _invalidEmailCommand.ConfirmPassword = "123456";
            #endregion
            #region _validEmailCommand
            _validEmailCommand = new CreateReaderCommand();
            _validEmailCommand.Name = "Marllon";
            _validEmailCommand.Email = "87marllon@gmail.com";
            _validEmailCommand.Password = "12345";
            _validEmailCommand.ConfirmPassword = "12345";
            #endregion

            #region _passwordDifferentConfirmPasswordCommand
            _passwordDifferentConfirmPasswordCommand = new CreateReaderCommand();
            _passwordDifferentConfirmPasswordCommand.Name = "Marllon";
            _passwordDifferentConfirmPasswordCommand.Email = "87marllon@gmail.com";
            _passwordDifferentConfirmPasswordCommand.Password = "12345";
            _passwordDifferentConfirmPasswordCommand.ConfirmPassword = "54321";
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

        [TestMethod]
        public void Should_return_invalid_if_email_is_invalid()
        {
            _invalidEmailCommand.Validate();
            Assert.AreEqual(false, _invalidEmailCommand.Valid);
        }

        [TestMethod]
        public void Should_return_valid_if_email_is_valid()
        {
            _validEmailCommand.Validate();
            Assert.AreEqual(true, _validEmailCommand.Valid);
        }

        [TestMethod]
        public void Should_return_invalid_if_password_different_confirm_password()
        {
            _passwordDifferentConfirmPasswordCommand.Validate();
            Assert.AreEqual(false, _passwordDifferentConfirmPasswordCommand.Valid);
        }
    }
}
