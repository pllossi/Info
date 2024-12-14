using TimeManagment;
namespace TimeMangagmentTests
{
    [TestClass]
    public class TimeTests
    {
        [TestMethod]
        public void TestConstructor_ValidTime()
        {
            var time = new Time(10, 30);
            Assert.AreEqual(10, time.Hours);
            Assert.AreEqual(30, time.Minutes);
        }

        [TestMethod]
        public void TestConstructor_InvalidHour()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Time(25, 0));
        }

        [TestMethod]
        public void TestConstructor_InvalidMinute()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Time(10, 60));
        }

        [TestMethod]
        public void TestAddHours_Increase()
        {
            var time = new Time(10, 30);
            time.AddHours(5);
            Assert.AreEqual(15, time.Hours);
            Assert.AreEqual(30, time.Minutes);
        }

        [TestMethod]
        public void TestAddHours_WrapAround()
        {
            var time = new Time(23, 30);
            time.AddHours(2);
            Assert.AreEqual(1, time.Hours);
            Assert.AreEqual(30, time.Minutes);
        }

        [TestMethod]
        public void IsAm_AspectedTrue()
        {
            var time = new Time(10,00);
            Assert.IsTrue(time.isAm());
        }
        
        [TestMethod]
        public void IsAm_AspectedFalse()
        {
            var time = new Time(19,00);
            Assert.IsFalse(time.isAm());
        }

        [TestMethod]
        public void TestAddMinutes_Increase()
        {
            var time = new Time(10, 30);
            time.AddMinutes(40);
            Assert.AreEqual(11, time.Hours);
            Assert.AreEqual(10, time.Minutes);
        }

        [TestMethod]
        public void TestAddMinutes_Negative()
        {
            var time = new Time(10, 30);
            time.AddMinutes(-50);
            Assert.AreEqual(9, time.Hours);
            Assert.AreEqual(40, time.Minutes);
        }

        [TestMethod]
        public void TestToString()
        {
            var time = new Time(9, 5);
            Assert.AreEqual("09:05", time.ToString());
        }

        [TestMethod]
        public void TestEquals_SameTime()
        {
            Time time1 = new Time(10, 30);
            Time time2 = new Time(10, 30);
            Assert.IsTrue(time1.Equals(time2));
        }

        [TestMethod]
        public void TestPeriodo()
        {
            Time time = new Time(14, 30);
            Assert.AreEqual("PM", time.Periodo);
        }

        [TestMethod]
        public void Test_Periodo_AspectedAm()
        {
            Time time = new Time(4, 30);
            Assert.AreEqual("AM", time.Periodo);
        }

        [TestMethod]
        public void Time_ToString()
        {
            Time time=new(14,30);
            Assert.AreEqual("14:30", time.ToString());
        }

        [TestMethod]
        public void Time_ToString_HoursOneDecimal()
        {
            Time time = new Time(4, 30);
            Assert.AreEqual("04:30",time.ToString());
        }
        [TestMethod]
        public void Time_ToString_MinutesOneDecimal()
        {
            Time time = new Time(14, 0);
            Assert.AreEqual("14:00",time.ToString());
        }


    }
}