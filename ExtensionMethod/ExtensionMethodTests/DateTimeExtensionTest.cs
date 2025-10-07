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
            var date = new DateTime(2024, 3, 21);
            var result = date.GetSeason();
            Assert.AreEqual(Season.Spring, result);
        }

        [TestMethod]
        public void GetSeason_ReturnsSummer_OnSummerSolstice()
        {
            var date = new DateTime(2024, 6, 21);
            var result = date.GetSeason();
            Assert.AreEqual(Season.Summer, result);
        }

        [TestMethod]
        public void GetSeason_ReturnsAutumn_OnAutumnEquinox()
        {
            var date = new DateTime(2024, 9, 21);
            var result = date.GetSeason();
            Assert.AreEqual(Season.Autumn, result);
        }

        [TestMethod]
        public void GetSeason_ReturnsWinter_OnWinterSolstice()
        {
            var date = new DateTime(2024, 12, 21);
            var result = date.GetSeason();
            Assert.AreEqual(Season.Winter, result);
        }

        [TestMethod]
        public void GetSeason_ReturnsWinter_BeforeSpringEquinox()
        {
            var date = new DateTime(2024, 3, 20);
            var result = date.GetSeason();
            Assert.AreEqual(Season.Winter, result);
        }

        [TestMethod]
        public void IsSummer_ReturnsTrue_OnSummerSolstice()
        {
            var date = new DateTime(2024, 6, 21);
            Assert.IsTrue(date.IsSummer());
        }

        [TestMethod]
        public void IsSummer_ReturnsFalse_OnSpringEquinox()
        {
            var date = new DateTime(2024, 3, 21);
            Assert.IsFalse(date.IsSummer());
        }

        [TestMethod]
        public void DaysUtilNextSeason_FromSpringEquinox()
        {
            var date = new DateTime(2024, 3, 21);
            var days = date.DaysUtilNextSeason();
            Assert.AreEqual((new DateTime(2024, 6, 21) - date).Days, days);
        }

        [TestMethod]
        public void DaysUtilNextSeason_FromWinterSolstice()
        {
            var date = new DateTime(2024, 12, 21);
            var days = date.DaysUtilNextSeason();
            Assert.AreEqual((new DateTime(2025, 3, 21) - date).Days, days);
        }

        [TestMethod]
        public void DaysUtilNextSeason_FromLastDayOfWinter()
        {
            var date = new DateTime(2024, 3, 20);
            var days = date.DaysUtilNextSeason();
            Assert.AreEqual((new DateTime(2024, 3, 21) - date).Days, days);
        }
    }
}
