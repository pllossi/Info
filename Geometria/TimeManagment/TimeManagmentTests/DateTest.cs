using TimeManagment;
namespace TimeMangagmentTests
{
    [TestClass]
    public class DateTest()
    {
        [TestMethod]
        public void Date_IllegalYear_ShouldThrow()
        {
            Assert.ThrowsException<System.ArgumentException>(() => (new Date(12, -1000, 1)));
        }

        [TestMethod]
        public void Date_IllegalMonth_ShouldThrow()
        {
            Assert.ThrowsException<System.ArgumentException>(() => (new Date(12, 1000, -1)));
        }

        [TestMethod]
        public void Date_IllegalDay_ShouldThrow()
        {
            Assert.ThrowsException<System.ArgumentException>(() => (new Date(-12, 1000, 1)));
        }

        [TestMethod]
        public void IsLeap_AspectedTrue()
        {
            Date date = new Date(12, 2008, 1);
            Assert.IsTrue(date.isLeap());
        }
        [TestMethod]
        public void IsLeap_AspectedFalse()
        {
            Date date = new Date(12, 2023, 1);
            Assert.IsFalse(date.isLeap());
        }

        [TestMethod]
        public void AddDays_UpdatesCorrectly()
        {
            Date date = new Date(12, 2024, 1);
            date.AddDays(1);
            int exp = 13;
            int actual = date.Day;
            Assert.AreEqual(exp, actual);
        }

        [TestMethod]
        public void AddMonth_UpdatesCorrectly()
        {
            Date date = new Date(12, 2024, 1);
            date.AddMonth(1);
            int exp = 2;
            int actual = date.Month;
            Assert.AreEqual(exp, actual);
        }
        [TestMethod]
        public void AddYear_UpdatesCorrectly()
        {
            Date date = new Date(12, 2024, 1);
            date.AddYears(1);
            int exp = 2025;
            int actual = date.Year;
            Assert.AreEqual(exp, actual);
        }

        [TestMethod]
        public void Date_ToString_OnMonth()
        {
            Date date= new Date(12,2024,1);
            Assert.AreEqual("12/01/2024", date.ToString());
        }

        [TestMethod]
        public void Date_ToString_OneDecimalOnDay()
        {
            Date date = new Date(2, 2024, 01);
            Assert.AreEqual("02/01/2024", date.ToString());
        }
    }
}
