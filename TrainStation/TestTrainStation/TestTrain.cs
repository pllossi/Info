using TrainStation;
namespace TestTrainLib
{
    [TestClass]
    public class TestTrain
    {
        [TestMethod]
        public void Train_WithInvalidTrainNumber_ShouldThrow()
        {
            DateTime h1 = new DateTime(2022, 12, 12, 12, 12, 12);
            DateTime h2 = new DateTime(2022, 12, 13, 13, 13, 13);
            DateTime h3 = new DateTime(2022, 12, 16, 16, 16, 16);
            DateTime h4 = new DateTime(2022, 12, 17, 17, 17, 17);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Train test = new Train(-1, "Roma", "Milano", h1, h3, h2, h4); });
        }

        [TestMethod]
        public void Train_WithInvalidStartAndEndStationName_ShouldThrow()
        {
            DateTime h1 = new DateTime(2022, 12, 12, 12, 12, 12);
            DateTime h2 = new DateTime(2022, 12, 13, 13, 13, 13);
            DateTime h3 = new DateTime(2022, 12, 16, 16, 16, 16);
            DateTime h4 = new DateTime(2022, 12, 17, 17, 17, 17);
            Assert.ThrowsException<ArgumentNullException>(() => { Train test = new Train(100, "", "Milano", h1, h3, h2, h4); });
            Assert.ThrowsException<ArgumentNullException>(() => { Train test = new Train(100, "Roma", "", h1, h3, h2, h4); });
        }

        [TestMethod]
        public void Train_WithInvalidExEnd_ShouldThrow()
        {
            DateTime h1 = new DateTime(2022, 12, 12, 12, 12, 12);
            DateTime h2 = new DateTime(2022, 12, 13, 13, 13, 13);
            DateTime h3 = new DateTime(2022, 12, 11, 16, 16, 16);
            DateTime h4 = new DateTime(2022, 12, 17, 17, 17, 17);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Train test = new Train(100, "Roma", "Milano", h1, h3, h2, h4); });
        }

        [TestMethod]
        public void Train_WithInvalidAcEnd_ShouldThrow()
        {
            DateTime h1 = new DateTime(2022, 12, 12, 12, 12, 12);
            DateTime h2 = new DateTime(2022, 12, 13, 13, 13, 13);
            DateTime h3 = new DateTime(2022, 12, 16, 16, 16, 16);
            DateTime h4 = new DateTime(2022, 12, 11, 11, 11, 11);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Train test = new Train(100, "Roma", "Milano", h1, h3, h2, h4); });
        }

        [TestMethod]
        public void DelayInMinute_WithValidValues_IsCorrect()
        {
            DateTime h1 = new DateTime(2022, 12, 12, 12, 12, 12);
            DateTime h2 = new DateTime(2022, 12, 13, 13, 13, 13);
            DateTime h3 = new DateTime(2022, 12, 17, 16, 16, 16);
            DateTime h4 = new DateTime(2022, 12, 17, 17, 17, 17);
            Train test = new Train(100, "Roma", "Milano", h1, h3, h2, h4);
            Assert.AreEqual(61, test.delayInMinutes());
        }
    }
}