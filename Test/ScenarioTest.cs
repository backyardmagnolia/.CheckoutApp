using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NAB;

namespace Test
{
    [TestClass]
    public class ScenarioTest
    {
        [TestMethod]
        public void Test_Purchased_3ATV_1HDM_Success()
        {
            const double actualTotal = 249.00;

            var co = new CheckOut(RulesBuilder.Build());
            var items = ItemFactory.Create(new List<string> {"atv", "atv", "atv", "hdm"});
            foreach (var item in items)
            {
                co.Scan(item);
            }

            var expectedTotal = co.Total().Total;

            Assert.AreEqual(expectedTotal, actualTotal);
        }

        [TestMethod]
        public void Test_Purchased_2ATV_5NX9_Success()
        {
            const double actualTotal = 2718.95;

            var co = new CheckOut(RulesBuilder.Build());
            var items = ItemFactory.Create(new List<string> {"atv", "nx9", "nx9", "atv", "nx9", "nx9", "nx9"});
            foreach (var item in items)
            {
                co.Scan(item);
            }

            var expectedTotal = co.Total().Total;

            Assert.AreEqual(expectedTotal, actualTotal);
        }

        [TestMethod]
        public void Test_Purchased_1MBP_1HDM_1NX9_Success()
        {
            const double actualTotal = 1949.98;

            var co = new CheckOut(RulesBuilder.Build());
            var items = ItemFactory.Create(new List<string> {"mbp", "hdm", "nx9"});
            foreach (var item in items)
            {
                co.Scan(item);
            }

            var expectedTotal = co.Total().Total;

            Assert.AreEqual(expectedTotal, actualTotal);
        }

        [TestMethod]
        public void Test_Purchased_5ATV_2HDM_1MBP_Success()
        {
            const double actualTotal = 1867.99;

            var co = new CheckOut(RulesBuilder.Build());
            var items = ItemFactory.Create(new List<string> {"atv", "hdm", "atv", "hdm", "atv", "atv", "atv", "mbp"});
            foreach (var item in items)
            {
                co.Scan(item);
            }

            var expectedTotal = co.Total().Total;

            Assert.AreEqual(expectedTotal, actualTotal);
        }

        [TestMethod]
        public void Test_InvalidSkuCode_Success()
        {
            const double actualTotal = 109.50;

            var co = new CheckOut(RulesBuilder.Build());
            var items = ItemFactory.Create(new List<string> { "atv", "mmm", "345","$%#" });
            foreach (var item in items)
            {
                co.Scan(item);
            }

            var expectedTotal = co.Total().Total;

            Assert.AreEqual(expectedTotal, actualTotal);
        }

        [TestMethod]
        public void Test_Combination_ValidAndInvalidSkuCode_Success()
        {
            const double actualTotal = 0;

            var co = new CheckOut(RulesBuilder.Build());
            var items = ItemFactory.Create(new List<string> { "mmm", "R5g", "werewrewrew" });
            foreach (var item in items)
            {
                co.Scan(item);
            }

            var expectedTotal = co.Total().Total;

            Assert.AreEqual(expectedTotal, actualTotal);
        }

        [TestMethod]
        public void Test_NoPromotionRulesAppliedForPurchasedItems_Success()
        {
            const double actualTotal = 2059.48;

            var co = new CheckOut(RulesBuilder.Build());
            var items = ItemFactory.Create(new List<string> { "atv", "mbp", "nx9" });
            foreach (var item in items)
            {
                co.Scan(item);
            }

            var expectedTotal = co.Total().Total;

            Assert.AreEqual(expectedTotal, actualTotal);
        }

        [TestMethod]
        public void Test_NoPromotionRulesCreated_Success()
        {
            const double actualTotal = 2059.48;

            var co = new CheckOut(null);
            var items = ItemFactory.Create(new List<string> { "atv", "mbp", "nx9" });
            foreach (var item in items)
            {
                co.Scan(item);
            }

            var expectedTotal = co.Total().Total;

            Assert.AreEqual(expectedTotal, actualTotal);
        }

    }
}