using bookLibrary.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bookLibrary.Tests.EntitiesTests
{
    [TestClass]
    [TestCategory("Reader - Tests")]
    public class ReaderTests
    {
        private readonly Reader _readerEmailExists;
        private readonly Reader _readerEmailNotExists;

        public ReaderTests()
        {
            // TODO: alterar para uma consulta no FakeRepositorio
            _readerEmailExists = new Reader("Marllon Ramos", "87marllon@gmail.com", "123456");

            // TODO: alterar para uma consulta no FakeRepositorio
            _readerEmailNotExists = new Reader("", "", "");
        }
    
        [TestMethod]
        public void Should_return_true_if_email_exists()
        {
            Assert.AreEqual(true, _readerEmailExists.IsExist("87marllon@gmail.com"));
        }

        [TestMethod]
        public void Should_return_false_if_email_not_exists()
        {
            Assert.AreEqual(false, _readerEmailNotExists.IsExist("marllonramos@hotmail.com"));
        }
    }
}
