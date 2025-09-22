using Dice_and_Statistics;
namespace TestDiceAndConsole
{
    [TestClass]
    public class TestGames
    {
        [TestMethod]
        public void CreateGame_EmptyNamePlayer1_ShouldThrow()
        {
            Assert.ThrowsException<System.ArgumentException>(() => new Game("", "pino", 10));
        }
        [TestMethod]
        public void CreateGame_EmptyNamePlayer2_ShouldThrow()
        {
            Assert.ThrowsException<System.ArgumentException>(() => new Game("gigi", "", 10));
        }
        [TestMethod]
        public void CreateGame_EmptyNamePlayer1AndPlayer2_ShouldThrow()
        {
            Assert.ThrowsException<System.ArgumentException>(() => new Game("", "", 10));
        }
        [TestMethod]
        public void CreateGame_NullNamePlayer1_ShouldThrow()
        {
            Assert.ThrowsException<System.ArgumentException>(() => new Game(null, "pino",10));
        }
        [TestMethod]
        public void CreateGame_NullNamePlayer2_ShouldThrow()
        {
            Assert.ThrowsException<System.ArgumentException>(() => new Game("gigi", null,10));
        }
        [TestMethod]
        public void CreateGame_ValidNamePlayer1AndPlayer2_ShouldNotThrow()
        {
            new Game("gigi", "pino",10);
        }
        Game game= new Game("gigi", "pino", 10);
        [TestMethod]
        public void Play_10Times_ShouldNotThrow()
        {
            game.Play(10);
        }
        [TestMethod]
        public void Play_NegativeTimes_ShouldThrow()
        {
            Assert.ThrowsException<System.ArgumentException>(() => game.Play(-1));
        }
        [TestMethod]
        public void GetWinner_10Times_ShouldNotThrow()
        {
            game.Play(10);
            string winner=game.Winner;
        }

    }
}