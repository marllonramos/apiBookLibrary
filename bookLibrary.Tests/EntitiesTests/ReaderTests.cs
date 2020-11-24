using bookLibrary.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            _readerEmailExists = new Reader("Marllon Ramos", "87marllon@gmail.com", "123456", Guid.Parse("6B9632FC-9EB6-454D-82B3-B801C4AFB837"));

            // TODO: alterar para uma consulta no FakeRepositorio
            _readerEmailNotExists = new Reader("", "", "", Guid.Empty);
        }
    
        [TestMethod]
        public void Should_return_true_if_email_exists()
        {
            //Assert.AreEqual(true, _readerEmailExists.IsExist("87marllon@gmail.com"));
        }

        [TestMethod]
        public void Should_return_false_if_email_not_exists()
        {
            //Assert.AreEqual(false, _readerEmailNotExists.IsExist("marllonramos@hotmail.com"));
        }
    }
}
