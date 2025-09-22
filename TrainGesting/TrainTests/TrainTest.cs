using TrainGesting;

namespace TrainTests
{
    [TestClass]
    public class TrainTests
    {
        [TestMethod]
        public void TrainNumber_ShouldThrowException_WhenNegative()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                var train = new Train(-1, "StartStation", "EndStation", new DateAndTime(1, 1, 2024, 10, 0), null, null, new DateAndTime(1, 1, 2024, 12, 0));
            });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NameStartStation_ShouldThrowException_WhenEmpty()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var train = new Train(1, " ", "EndStation", new DateAndTime(1, 1, 2024, 10, 0), null, null, new DateAndTime(1, 1, 2024, 12, 0));
            });
        }

        [TestMethod]
        public void NameEndStation_ShouldThrowException_WhenEmpty()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var train = new Train(1, "StartStation", " ", new DateAndTime(1, 1, 2024, 10, 0), null, null, new DateAndTime(1, 1, 2024, 12, 0));
            });
        }

        [TestMethod]
        public void StartingRealTime_ShouldThrowException_WhenBeforeStaringTimeAspected()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var train = new Train(1, "StartStation", "EndStation", new DateAndTime(1, 1, 2024, 10, 0), new DateAndTime(1, 1, 2024, 9, 0), null, new DateAndTime(1, 1, 2024, 12, 0));
            });
        }

        [TestMethod]
        public void EndingRealTime_ShouldThrowException_WhenBeforeStartingRealTime()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var train = new Train(1, "StartStation", "EndStation", new DateAndTime(1, 1, 2024, 10, 0), new DateAndTime(1, 1, 2024, 10, 30), new DateAndTime(1, 1, 2024, 10, 0), new DateAndTime(1, 1, 2024, 12, 0));
            });
        }

        [TestMethod]
        public void ArrivingTimeAspected_ShouldThrowException_WhenBeforeStaringTimeAspected()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var train = new Train(1, "StartStation", "EndStation", new DateAndTime(1, 1, 2024, 10, 0), null, null, new DateAndTime(1, 1, 2024, 9, 0));
            });
        }

        [TestMethod]
        public void isLate_ShouldReturnTrue_WhenStartingRealTimeIsAfterStaringTimeAspected()
        {
            var train = new Train(1, "StartStation", "EndStation", new DateAndTime(1, 1, 2024, 10, 0), new DateAndTime(1, 1, 2024, 10, 30), null, new DateAndTime(1, 1, 2024, 12, 0));
            Assert.IsTrue(train.isLate());
        }

        [TestMethod]
        public void isLate_ShouldReturnFalse_WhenStartingRealTimeIsNotAfterStaringTimeAspected()
        {
            var train = new Train(1, "StartStation", "EndStation", new DateAndTime(1, 1, 2024, 10, 0), new DateAndTime(1, 1, 2024, 10, 0), null, new DateAndTime(1, 1, 2024, 12, 0));
            Assert.IsFalse(train.isLate());
        }

        [TestMethod]
        public void isLate_ShouldThrowException_WhenStartingRealTimeIsNull()
        {
            var train = new Train(1, "StartStation", "EndStation", new DateAndTime(1, 1, 2024, 10, 0), null, null, new DateAndTime(1, 1, 2024, 12, 0));
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                train.isLate();
            });
        }

        [TestMethod]
        public void Lateness_ShouldReturnCorrectMinutes_WhenTrainIsLate()
        {
            var train = new Train(1, "StartStation", "EndStation", new DateAndTime(1, 1, 2024, 10, 0), new DateAndTime(1, 1, 10, 30), null, new DateAndTime(1, 1, 2024, 12, 0));
            Assert.AreEqual(30, train.Lateness());
        }

        [TestMethod]
        public void Lateness_ShouldReturnZero_WhenTrainIsNotLate()
        {
            var train = new Train(1, "StartStation", "EndStation", new DateAndTime(1, 1, 2024, 10, 0), new DateAndTime(1, 1, 2024, 10, 0), null, new DateAndTime(1, 1, 2024, 12, 0));
            Assert.AreEqual(0, train.Lateness());
        }
    }
}
