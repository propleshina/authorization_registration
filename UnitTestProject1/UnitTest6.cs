using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp2;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest6
    {
        [TestMethod]
        public void RegistrationTest()
        {
            var page = new Registration();
            Assert.IsFalse(page.RegistrationCheck("", "fio", "fio", "fio", "Администратор", "88005553344", 
                "https://strana-rosatom.ru/wp-content/uploads/2022/04/tjulen2.jpg", "М"));
            Assert.IsFalse(page.RegistrationCheck("kkk", "fio", "fio", "fio", "Администратор", "880053344", 
                "https://strana-rosatom.ru/wp-content/uploads/2022/04/tjulen2.jpg", "Ж"));
            Assert.IsFalse(page.RegistrationCheck("Иван Иванов", "fio", "fio", "fio", "Администратор", "8800ф553344", 
                "https://strana-rosatom.ru/wp-content/uploads/2022/04/tjulen2.jpg", "М"));
            Assert.IsFalse(page.RegistrationCheck("abj", "fio", "fio", "fio", "", "88005553344", 
                "https://strana-rosatom.ru/wp-content/uploads/2022/04/tjulen2.jpg", "М"));
            Assert.IsFalse(page.RegistrationCheck("123", "fio", "fio", "fio", "Администратор", "88005553344", 
                "https://strana-rosatom.ru/wp-content/uploads/2022/04/tjulen2.jpg", ""));
            Assert.IsFalse(page.RegistrationCheck("фио", "fio", "dkfl", "fio", "Администратор", "88005553344", 
                "https://strana-rosatom.ru/wp-content/uploads/2022/04/tjulen2.jpg", "М"));
            Assert.IsTrue(page.RegistrationCheck("фио", "fio", "fio", "fio", "Администратор", "88005553344",
    "https://strana-rosatom.ru/wp-content/uploads/2022/04/tjulen2.jpg", "М"));
        }
    }
}
