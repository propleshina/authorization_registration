using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp2;

namespace UnitTestProject4
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void AuthTestDeleted()
        {
            var page = new AuthPage();
            Assert.IsFalse(page.Auth("Kar@gmai.com", "6QF1WB"));
            Assert.IsFalse(page.Auth("Victoria@gmai.com", "9mlPQJ"));
        }
    }
}
