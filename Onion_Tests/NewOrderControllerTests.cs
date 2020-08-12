using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onion_PersistanceLayer;
using Onion_DomainLayer;
using System;
using System.Collections.Generic;
using Onion_Tests.Comparers;
using Onion_ServiceLayer;

namespace Onion_Tests
{
   [TestClass]
    public class NewOrderControllerTests
    {

        

        private readonly IItemComparer itemComparer = new IItemComparer();

        public IEnumerable<Order> Orders = new List<Order>
            {
                new Order(1,Status.Finished, new List<IItem> {MockOrderHistoryRepository.ChangeItemById<int>(1, 2), MockOrderHistoryRepository.ChangeItemById<double>(4, 3.0) },
                new DateTime(2020,01,12,12,12,12), MockRegisteredUserRepository.GetUserById(2)),

                new Order(2,Status.Cancelled_by_user, new List<IItem> { MockOrderHistoryRepository.ChangeItemById<double>(3, 2.0), MockOrderHistoryRepository.ChangeItemById<int>(15, 3) },
                new DateTime(2020,01,12,12,12,12), MockRegisteredUserRepository.GetUserById(3))
            };

        public NewOrderControllerTests()
        {

        }
        /*
        [TestMethod]
        public void CountTotalResult_ReturnCorrectSum()
        {
            NewOrderBLL _newOrderController = new NewOrderBLL();
            var testedValue = new List<IItem> {
                new ItemByWeight(7, 1.00, "Potato", "", 10.0m, 10.0m, Category.Fruits_and_Vegetables),
                new ItemByNumber(8, 2, "Milk", "", 23.0m, 46.0m, Category.Milk_products) };

            decimal res = _newOrderController.CountTotalResult(testedValue);
            decimal expectedValue = 56.0m;
            Assert.AreEqual(res, expectedValue);
        }*/
        /*
        [TestMethod]
        public void GetDataForOrder_ReturnCorrectData()
        {


            NewOrderBLL _newOrderController = new NewOrderBLL();
            (int, DateTime, Type) expected = _newOrderController.GetDataForOrder();
            expected.Item3 = typeof(Guest);
            var res = (5, DateTime.Today, (new Guest()).GetType());
            Assert.AreEqual(res.Item1, expected.Item1);
            Assert.AreEqual(res.Item2.ToShortDateString(), expected.Item2.ToShortDateString());
            Assert.AreEqual(res.Item3, expected.Item3);

        }*/
        
        /*
        [TestMethod]
        public void ChosenCategory_ReturnCorrectData()
        {

            NewOrderBLL _newOrderController = new NewOrderBLL();
            IEnumerable<IItem> expectedValues = new List<IItem>
            {
            new ItemByNumber(25,1,"Mr.Muscle", "", 65.0m,65.0m, Category.Household_Goods),
            new ItemByNumber(26,1,"Fairy", "", 45.50m,45.50m, Category.Household_Goods),
            new ItemByNumber(27,1,"Colgate", "", 50.0m,50.0m, Category.Household_Goods),
            new ItemByNumber(28,1,"Tide", "", 80.0m,80.0m, Category.Household_Goods)
            };

            var actualValues = _newOrderController.ChosenCategory(Category.Household_Goods);

            Assert.IsTrue(expectedValues.SequenceEqual(actualValues, itemComparer), "Result is not as expected");

        }*/
    }
}
