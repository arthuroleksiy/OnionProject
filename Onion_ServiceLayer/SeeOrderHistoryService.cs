using System;
using System.Collections.Generic;
using System.Text;
using Onion_DomainLayer;
using Onion_PersistanceLayer;


namespace Onion_ServiceLayer
{
    /// <summary>
    /// See order history class with business logic
    /// </summary>
    public class SeeOrderHistoryService
    {
        /// <summary>
        /// Gets all orders
        /// </summary>
        /// <returns>Collection of <see cref="Order"/></returns>
        /// <exception cref="NullReferenceException">Throws if orders are empty</exception>
        public IEnumerable<Order> getAllOrders()
        {
            NullReferenceException ex = new NullReferenceException("Orders");

            if (MockOrderHistoryRepository.Orders == null)
                throw ex;

            return MockOrderHistoryRepository.Orders;
        }
        /// <summary>
        /// Check if current user good for order
        /// </summary>
        /// <returns>bool value</returns>
        public bool IsUserRole()
        {
            return MockActiveUserRepository.WhoISLogged() == typeof(User);
        }
        /// <summary>
        /// Check if current user is signed in
        /// </summary>
        /// <param name="order"><see cref="Order"/> value</param>
        /// <returns>bool value</returns>
        /// <exception cref="NullReferenceException">Throws if order is null</exception>

        public bool IsCurrentUserLogined(Order order)
        {

            NullReferenceException ex = new NullReferenceException("Order is null");
            if (order == null)
                throw ex;

            return order.User.Login == MockActiveUserRepository.Login;
        }
    }
}
