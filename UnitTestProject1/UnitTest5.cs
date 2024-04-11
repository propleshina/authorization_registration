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
            Assert.IsFalse(page.Checking("lflf","lflfrfvre"));
            Assert.IsFalse(page.Checking("lflf", ""));
            Assert.IsFalse(page.Checking("lflf", "LFLF"));
            Assert.IsTrue(page.Checking("LFLF", "LFLF"));
        }
    }
}
