using System;
using Onion_PersistanceLayer;
using Onion_ServiceLayer;
using Onion_DomainLayer;

using System.Collections.Generic;

namespace Onion_PresentationLayer
{

    /// <summary>
    /// Bucket order presentation
    /// </summary>
    public class BucketOrderPL
    {

        private readonly EnterPagePL enterPageView = new EnterPagePL();
        private readonly Action<int, Status> changeStatus;
        private readonly BucketOrderService BucketOrderController = new BucketOrderService();
        private readonly Func<IEnumerable<Order>> getOrders;
        private readonly Func<bool> isUserRole;
        private readonly Func<int> getFirstId;
        private readonly Func<int> getLastId;
        private readonly Func<Order, bool> isUserLogined;
        private readonly Func<int, Status> getStatusBefore;
        /// <summary>
        /// Default constructor
        /// </summary>
        public BucketOrderPL()
        {
            changeStatus += MockBucketOrderRepository.ChangeStatus;
            getOrders += BucketOrderController.getAllOrders;
            isUserRole += BucketOrderController.IsUserRole;
            isUserLogined += BucketOrderController.IsCurrentUserLogined;
            getFirstId += BucketOrderController.GetFirstId;
            getLastId += BucketOrderController.GetLastId;
            getStatusBefore += BucketOrderController.GetStatusBefore;

        }


        /// <summary>
        /// Write order and change status
        /// </summary>
        public void ChangeBucketOrderStatus()
        {
            Output();
            ChangeStatus();
            Output();
        }

        /// <summary>
        /// Write orders
        /// </summary>
        public void Output()
        {
            Console.Clear();  
            
            foreach (var i in getOrders())
            {
                if (isUserRole())
                {
                    if (isUserLogined(i))
                    {
                        OutputResult(i);
                    }
                }
                else
                {
                    OutputResult(i);
                }

                Console.WriteLine();
            }   
        }
        /// <summary>
        /// Writing orders
        /// </summary>
        /// <param name="i"><see cref="Order"/> value</param>

        public void OutputResult(Order i)
        {
            decimal price = 0;

            Console.WriteLine(i.Id + " " + i.Date + " " + i.Status + " " + i.User.Login);

            foreach (var j in i.Items)
            {
                if (!((j as ItemByNumber) is null))
                    Console.WriteLine(j.Id + " " + i.Date + " " + j.Name + " " + ((ItemByNumber)j).Number + " " + j.Price);
                else if (!((j as ItemByWeight) is null))
                    Console.WriteLine(j.Id + " " + i.Date + " " + j.Name + " " + ((ItemByWeight)j).Weight + " " + j.Price);

                price += j.TotalPrice;
            }
            Console.WriteLine("Total price = " + price);

            Console.WriteLine();
        }

        /// <summary>
        /// Changing orders status
        /// </summary>
        public void ChangeStatus()
        {
            string newStatus;
            Console.WriteLine("Choose order id to change (0 to cancel)");
            var result = Console.ReadLine();
            if (result.Equals("0")) {
                enterPageView.Output();
                enterPageView.Choise();
            }
            if (MockActiveUserRepository.WhoISLogged() == typeof(User))
            {
                Console.WriteLine((int)(Status.Cancelled_by_user) + " "+ Status.Cancelled_by_user);
            }
            else
            {
                Console.WriteLine("Accessible status: ");
                foreach (var s in (Status[])Enum.GetValues(typeof(Status)))
                {
                    if(s != Status.Cancelled_by_user)
                        Console.WriteLine((int)s + " " + s);
                }
            }
            Console.WriteLine("Enter new status id:");

            if (isUserRole())
            {

                newStatus = Console.ReadLine();
                
                if(!newStatus.Equals("2"))
                {
                    Console.WriteLine("Wrong choise");
                    ChangeStatus();
                }
            }
            else
            {
                newStatus = Console.ReadLine();


                if (newStatus.Equals("2"))
                {
                    Console.WriteLine("Wrong choise");
                    ChangeStatus();
                } 
                
            }

            
            if (Int32.TryParse(result, out int intId) && (intId == 0 || intId >= getFirstId() && intId <= getLastId()))
            {
                if (intId == 0)
                {
                    enterPageView.Output();
                    enterPageView.Choise();
                }

                if (Enum.TryParse(newStatus, out Status status))
                {
                    if (isUserRole())
                    {
                        if (getStatusBefore(intId) != Status.Recieved)
                        {
                            changeStatus(intId, status);
                            ChangeBucketOrderStatus();
                        }
                        else
                        {
                            Console.WriteLine("User can't change recieved status");
                        }
                    }
                    else
                    {
                        changeStatus(intId, status);
                        ChangeBucketOrderStatus();
                    }
                }
                else
                {
                    ChangeBucketOrderStatus();
                }
            }
            else
            {
                ChangeBucketOrderStatus();
            }
        }
    }
}
