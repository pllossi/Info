using System;
using TrainStation;

namespace TestTrain
{
    [TestClass]
    public class TestTicket
    {

        [TestMethod]
        public void Ticket_WithInvalidTicketTrainNumber_ShouldThrow()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Ticket test = new Ticket(-1); });
        }

        [TestMethod]
        public void ValidateTicket_WithValidValues_UpdateValidateTime()
        {
            Ticket test = new Ticket(1);
            DateTime time = new DateTime(2008, 9, 23, 12, 30, 0);
            test.ValidateTicket(time);
            Assert.AreEqual(time, test.ValidateTime);
        }


    }
}
