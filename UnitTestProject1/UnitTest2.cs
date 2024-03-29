using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp2;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void AuthTest()
        {
            var page = new AuthPage();
            var capchapage = new Capcha();
            Assert.IsFalse(page.Auth("test", "test"));
            Assert.IsFalse(page.Auth(" ", " "));
        }
    }
}
