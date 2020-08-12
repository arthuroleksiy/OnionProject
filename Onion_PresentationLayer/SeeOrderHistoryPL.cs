using System;
using Onion_PresentationLayer;
using Onion_ServiceLayer;
using Onion_DomainLayer;

using System.Collections.Generic;

namespace Onion_PresentationLayer
{
    public class SeeOrderHistoryPL
    {
        private readonly EnterPagePL enterPageView = new EnterPagePL();
        private readonly SeeOrderHistoryService seeOrderHistoryBLL = new SeeOrderHistoryService();
        private readonly Func<IEnumerable<Order>> getOrders;
        private readonly Func<bool> isUserRole;
        private readonly Func<Order, bool> isUserLogined;
        /// <summary>
        /// Default construcyor
        /// </summary>
        public SeeOrderHistoryPL()
        {
            getOrders += seeOrderHistoryBLL.getAllOrders;
            isUserRole += seeOrderHistoryBLL.IsUserRole;
            isUserLogined += seeOrderHistoryBLL.IsCurrentUserLogined;
        }
        /// <summary>
        /// Output result order
        /// </summary>
        /// <param name="i"><see cref="Order"/></param>
        public void OutputUserData(Order i)
        {

            decimal price = 0;

            Console.WriteLine(i.Id + " " + i.Date + " " + i.Status + " " + i.User.Login);

            foreach (var j in i.Items)
            {
                if (j is ItemByNumber)
                    Console.WriteLine(j.Id + " " + j.Name + " " + ((ItemByNumber)j).Number + " " + j.Price);
                else if (j is ItemByWeight)
                    Console.WriteLine(j.Id + " " + j.Name + " " + ((ItemByWeight)j).Weight + " " + j.Price);

                price += j.Price;
            }
            Console.WriteLine();
            Console.WriteLine(price);
        }
        /// <summary>
        /// Input order
        /// </summary>
        public void InputOrder()
        {
            foreach (var i in getOrders())
            {
                if (isUserRole())
                {
                    if (isUserLogined(i))
                    {
                        OutputUserData(i);
                    }
                }
                else
                {
                    OutputUserData(i);
                }


            }

            Console.ReadKey();
            enterPageView.Output();
            enterPageView.Choise();
        }
    }
}

