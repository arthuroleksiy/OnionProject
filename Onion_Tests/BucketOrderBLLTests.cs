using Microsoft.VisualStudio.TestTools.UnitTesting;
using Onion_ServiceLayer;
using Onion_DomainLayer;
using System.Linq;
using Onion_PersistanceLayer;
using System.Collections.Generic;
using System;

namespace Onion_Tests
{
    [TestClass]
    public class BucketOrderBLLTests
    {
        private readonly BucketOrderService bucketOrderBLL;

        public BucketOrderBLLTests()
        {

            bucketOrderBLL = new BucketOrderService();
        }


        [TestMethod]
        public void GetFirstId_IsCorrect()
        {
            int actual = bucketOrderBLL.GetFirstId();
            int expected = 3;

            Assert.AreEqual(expected, actual);
            
        }
        [TestMethod]
        [DataRow(19)]
        public void GetStatusBefore_IsCorrectly(int intId)
        {
            var expected = Status.New; 
            var actual = bucketOrderBLL.GetStatusBefore(intId);
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void GetLastId_IsCorrect()
        {
            int actual = bucketOrderBLL.GetLastId();
            int expected = 3;

            Assert.AreEqual(expected, actual);
        }

       

        public IEnumerable<Order> getAllOrders()
        {
            NullReferenceException ex = new NullReferenceException("Orders");

            if (MockOrderHistoryRepository.Orders == null)
                throw ex;

            return MockOrderHistoryRepository.Orders;
        }
        /*
        public bool IsUserRole()
        {
            return MockActiveUserRepository.WhoISLogged() == typeof(User);
        }*/
        
        [TestMethod]
        public void IsCurrentUserLogined_ResturnsTrue()
        {
            var order = new Order(1, Status.Finished, new List<IItem> { MockBucketOrderRepository.ChangeItemById<int>(1, 2), MockBucketOrderRepository.ChangeItemById<double>(4, 3.0) },
                new DateTime(2020, 01, 12, 12, 12, 12), MockRegisteredUserRepository.GetUserById(2));

            MockActiveUserRepository.Login = "petro79";
            var result = bucketOrderBLL.IsCurrentUserLogined(order);
            Assert.AreEqual(true, result);
        }

        /*
        [TestMethod]
        public void ChangeStatus_IsStatusChanged()
        {
            BucketOrderService bucketOrderBLL = new BucketOrderService();
            var before = MockBucketOrderRepository.Orders.Where(i => i.Id.Equals(3)).Select(i => i.Status).First();
            var expected = Status.Payment_required;
            bucketOrderBLL.ChangeStatus(3, Status.Payment_required);
            //Thread.Sleep(500);
            var actual = MockBucketOrderRepository.Orders.Where(i => i.Id.Equals(3)).Select(i => i.Status).First();
           // bucketOrderBLL.ChangeStatus(3, before);
            Assert.AreEqual(expected, actual);
        }*/
    }
}
