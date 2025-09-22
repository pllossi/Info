using Dice_and_Statistics;
namespace TestDiceAndConsole
{
    [TestClass]
    public class PlayerTests
    {
        Player player;
        [TestMethod]
        public void TestName()
        {
            player = new Player("gigi");
            Assert.AreEqual("gigi", player.Name);
        }
        [TestMethod]
        public void TestNameEmpty()
        {
            Assert.ThrowsException<System.ArgumentException>(() => new Player(""));
        }
        [TestMethod]
        public void TestNameNull()
        {
            Assert.ThrowsException<System.ArgumentException>(() => new Player(null));
        }
        [TestMethod]
        public void TestNameSpace()
        {
            Assert.ThrowsException<System.ArgumentException>(() => new Player(" "));
        }
        [TestMethod]
        public void TestThrowDice()
        {
            player = new Player("gigi");
            player.ThrowDice(10);
            Assert.AreEqual(10, player.Score.Length);
        }

        [TestMethod]
        public void TestThrowDiceNegative()
        {
            player = new Player("gigi");
            Assert.ThrowsException<System.ArgumentException>(() => player.ThrowDice(-1));
        }
        [TestMethod]
        public void TestThrowDiceOneTime()
        {
            player = new Player("gigi");
            player.ThrowDice();
            Assert.AreEqual(1, player.Score.Length);
        }
    }
}
