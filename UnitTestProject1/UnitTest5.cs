using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp2;

namespace UnitTestProject5
{
    [TestClass]
    public class UnitTest5
    {
        [TestMethod]
        public void CapchaTest()
        {
            var page = new Capcha();
            Assert.IsFalse(page.CheckCapcha_Click());
        }
    }
}
