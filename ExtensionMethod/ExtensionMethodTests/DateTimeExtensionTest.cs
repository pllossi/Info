using System;
using ExtensionMethod;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtensionMethod;

namespace ExtensionMethodTests
{
    [TestClass]
    public class DateTimeExtensionsTests
    {
        [TestMethod]
        public void GetSeason_ReturnsSpring_OnSpringEquinox()
        {
            DateTime date = new DateTime(2024, 3, 21);
            Season  result = date.GetSeason();
            Assert.AreEqual(Season.SPRING, result);
        }

        [TestMethod]
        public void GetSeason_ReturnsSummer_OnSummerSolstice()
        {
            DateTime date = new DateTime(2024, 6, 21);
            Season result = date.GetSeason();
            Assert.AreEqual(Season.SUMMER, result);
        }

        [TestMethod]
        public void GetSeason_ReturnsAutumn_OnAutumnEquinox()
        {
            DateTime date = new DateTime(2024, 9, 21);
            Season result = date.GetSeason();
            Assert.AreEqual(Season.AUTUMN, result);
        }

        [TestMethod]
        public void GetSeason_ReturnsWinter_OnWinterSolstice()
        {
            DateTime date = new DateTime(2024, 12, 21);
            Season result = date.GetSeason();
            Assert.AreEqual(Season.WINTER, result);
        }

        [TestMethod]
        public void GetSeason_ReturnsWinter_BeforeSpringEquinox()
        {
            DateTime date = new DateTime(2024, 3, 20);
            Season result = date.GetSeason();
            Assert.AreEqual(Season.WINTER, result);
        }

        [TestMethod]
        public void IsSummer_ReturnsTrue_OnSummerSolstice()
        {
            DateTime date = new DateTime(2024, 6, 21);
            Assert.IsTrue(date.IsSummer());
        }

        [TestMethod]
        public void IsSummer_ReturnsFalse_OnSpringEquinox()
        {
            DateTime date = new DateTime(2024, 3, 21);
            Assert.IsFalse(date.IsSummer());
        }

        [TestMethod]
        public void DaysUtilNextSeason_FromSpringEquinox()
        {
            DateTime date = new DateTime(2024, 3, 21);
            int days = date.DaysUtilNextSeason();
            Assert.AreEqual((new DateTime(2024, 6, 21) - date).Days, days);
        }

        [TestMethod]
        public void DaysUtilNextSeason_FromWinterSolstice()
        {
            DateTime date = new DateTime(2024, 12, 21);
            int days = date.DaysUtilNextSeason();
            Assert.AreEqual((new DateTime(2025, 3, 21) - date).Days, days);
        }

        [TestMethod]
        public void DaysUtilNextSeason_FromLastDayOfWinter()
        {
            DateTime date = new DateTime(2024, 3, 20);
            int days = date.DaysUtilNextSeason();
            Assert.AreEqual((new DateTime(2024, 3, 21) - date).Days, days);
        }
    }
}
