using System;
using NUnit.Framework;

namespace PassTask13{
    [TestFixture]
    public class CustomerTest{
        [Test]
        public void TestCheckValid(){
            Customer Dom = new Customer("1001","Dom","000000");
            Dom.DateEnd = new DateTime(2021,4,24,10,0,0);
            DateTime currentTime = new DateTime(2021,4,24,11,0,0);
            Dom.CheckValid(currentTime);
            Assert.AreEqual(false, Dom.ValidMembership);

            currentTime = new DateTime(2021,4,24,9,0,0);
            Dom.CheckValid(currentTime);
            Assert.AreEqual(true, Dom.ValidMembership);
        }
        [Test]
        public void TestTotalSpent(){
            Transaction newTrans = new Transaction(true);
            newTrans.TotalSpent = 600;
            Transaction newTrans1 = new Transaction(true);
            newTrans1.TotalSpent = 500;
            Customer Dom = new Customer("1001","Dom","000000");
            Dom.AddTransCust(newTrans);
            Dom.AddTransCust(newTrans1);
            Dom.UpdateTotalPurchases();
            Assert.AreEqual(1100, Dom.TotalPurchases);

            Transaction newTrans2 = new Transaction(true);
            newTrans2.TotalSpent = 300;
            Dom.AddTransCust(newTrans2);
            Dom.UpdateTotalPurchases();
            Assert.AreEqual(1400, Dom.TotalPurchases);
        }
        [Test]
        public void TestUpdatePoints(){
            Transaction newTrans = new Transaction(true);
            newTrans.TotalSpent = 600;
            Transaction newTrans1 = new Transaction(true);
            newTrans1.TotalSpent = 500;
            Customer Dom = new Customer("1001","Dom","000000");
            Dom.AddTransCust(newTrans);
            Dom.AddTransCust(newTrans1);
            Dom.UpdateTotalPurchases();
            Dom.UpdatePoints();
            Assert.AreEqual(550, Dom.TotalPoints);

            Transaction newTrans2 = new Transaction(true);
            newTrans2.TotalSpent = 300;
            Dom.AddTransCust(newTrans2);
            Dom.UpdateTotalPurchases();
            Dom.UpdatePoints();
            Assert.AreEqual(700, Dom.TotalPoints);
        }
    }
}