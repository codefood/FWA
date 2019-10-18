using FWA.Data.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FWA.WebApi.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RoundingTest()
        {
            var ratingService = new RatingService(null);
            Assert.AreEqual(ratingService.Round(2.91m), 3.0m);
            Assert.AreEqual(ratingService.Round(3.249m), 3.0m);
            Assert.AreEqual(ratingService.Round(3.25m), 3.5m);
            Assert.AreEqual(ratingService.Round(3.6m), 3.5m);
            Assert.AreEqual(ratingService.Round(3.75m), 4.0m);
        }
    }
}
