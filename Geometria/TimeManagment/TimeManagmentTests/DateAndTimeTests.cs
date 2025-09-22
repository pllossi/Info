using System.Security.Cryptography.X509Certificates;
using TimeManagment;

namespace TimeMangagmentTests
{
    [TestClass]
    public class DateAndTimeTests()
    {
        [TestMethod]
        public void DateAndTimeTests_NegativeDay_ShouldThrow()
        {
            Assert.ThrowsException<System.ArgumentException>(() => new DateAndTime(-1, 3, 2008, 6, 30));
        }
        [TestMethod]
        public void DateAndTimeTests_NegativeMonth_ShouldThrow()
        {
            Assert.ThrowsException<System.ArgumentException>(() => new DateAndTime(1, -3, 2008, 6, 30));
        }
        [TestMethod]
        public void DateAndTimeTests_NegativeYear_ShouldThrow()
        {
            Assert.ThrowsException<System.ArgumentException>(() => new DateAndTime(1, 3, -2008, 6, 30));
        }
        [TestMethod]
        public void DateAndTimeTests_NegativeHours_ShouldThrow()
        {
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new DateAndTime(1, 3, 2008, -6, 30));
        }
        [TestMethod]
        public void DateAndTimeTests_NegativeMinutes_ShouldThrow()
        {
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new DateAndTime(1, 3, 2008, 6, -30));
        }

        DateAndTime data = new DateAndTime(1, 3, 2008, 6, 30);

        [TestMethod]
        public void DateAndTime_CorrectsCorrectly_ToString()
        {
            string ex = "01/03/2008,06:30";
            Assert.AreEqual(ex, data.ToString());
        }

        [TestMethod]
        public void AddDays_CorrectValue_ToString()
        {
            data.AddDays(1);
            Assert.AreEqual("02/03/2008,06:30", data.ToString());
        }
        [TestMethod]
        public void AddMonth_CorrectValue_ToString()
        {
            data.AddMonths(1);
            Assert.AreEqual("01/04/2008,06:30", data.ToString());
        }
        [TestMethod]
        public void AddYear_CorrectValue_ToString()
        {
            data.AddYears(1);
            Assert.AreEqual("01/03/2009,06:30", data.ToString());
        }

    }
}