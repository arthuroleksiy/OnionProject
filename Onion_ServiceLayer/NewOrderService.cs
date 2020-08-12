using System;
using System.Collections.Generic;
using Onion_DomainLayer;
using Onion_PersistanceLayer;


namespace Onion_ServiceLayer
{
    /// <summary>
    /// New order class with business logic
    /// </summary>
    public class NewOrderService
    {
        /// <summary>
        /// Controller that contains business logic for new order
        /// </summary>
        NewOrderService newOrderController = new NewOrderService();

        /// <summary>
        /// Controller for bucket order
        /// </summary>
        BucketOrderService bucketOrderController = new BucketOrderService();

        /// <summary>
        /// Gets required data from order
        /// </summary>
        /// <returns>Data for order</returns>
        public (int, DateTime, Type) GetDataForOrder()
        {
            int id = MockBucketOrderRepository.GetLastId() + 1;

            DateTime date = DateTime.Now;
            var returnType = MockActiveUserRepository.WhoISLogged();

            return (id, date, returnType);
        }

        /// <summary>
        /// Forms new order
        /// </summary>
        /// <param name="order"></param>
        /// <param name="items">Collection of <see cref="IItem"/></param>
        public void FormOrder(Order order, List<IItem> items)
        {

            order.Id = newOrderController.GetDataForOrder().Item1;
            order.Date = newOrderController.GetDataForOrder().Item2;

            if (typeof(Administrator) == newOrderController.GetDataForOrder().Item3)
            {
                order.User = (MockActiveUserRepository.CurrentUser as Administrator);
            }
            else if (typeof(User) == newOrderController.GetDataForOrder().Item3)
            {
                order.User = (MockActiveUserRepository.CurrentUser as User);
            }

            order.Items = items;
            order.Status = Status.New;
            MockBucketOrderRepository.AddOrderByParameters(order);
        }
        /// <summary>
        /// Gets total price for item
        /// </summary>
        /// <param name="items">Collection of <see cref="IItem"/></param>
        /// <returns>Final summary</returns>
        public decimal CountTotalResult(List<IItem> items)
        {
            if (items is null)
                throw new ArgumentNullException("items");

            decimal finalSum = 0;
            foreach (var i in items)
            {
                finalSum += i.TotalPrice;
            }

            return finalSum;
        }
        /// <summary>
        /// Gets items of chosen <see cref="Category"/>
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Collection of <see cref="IItem"/></returns>
        public IEnumerable<IItem> ChosenCategory(Category category)
        {
            foreach (var i in MockAssortementRepsotory.Assortement)
            {
                if (i.Category == category)
                {
                    yield return i;
                }
            }

        }


    }
}
