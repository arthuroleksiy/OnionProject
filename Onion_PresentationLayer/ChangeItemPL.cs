using System;
using System.Collections.Generic;
using Onion_PresentationLayer;
using Onion_ServiceLayer;
using Onion_DomainLayer;


namespace Onion_PresentationLayer
{

    /// <summary>
    /// Change item presentation
    /// </summary>
    public class ChangeItemPL
    {
        

        private readonly ChangeItemService changeItemController = new ChangeItemService();
        private readonly EnterPagePL enterPagePL = new EnterPagePL();
        private readonly static Dictionary<ItemType, Action<int, string>> dictReports = new Dictionary<ItemType, Action<int, string>>();

        private Func<string, bool> isItemType; 
        private Func<string, bool> isCorrectId; 
        private Func<string, int> parseId;
        private Func<string, ItemType> getItemByValue;
        private Func<int, IEnumerable<IItem>> getItemById;


        private readonly IEnumerable<IItem> wholeList;
        /// <summary>
        /// Default constructor
        /// </summary>
        public ChangeItemPL()
        {
            wholeList = changeItemController.GetItems();
            dictReports.Add(ItemType.Name, new Action<int, string>(changeItemController.ChangeName));
            dictReports.Add(ItemType.Description, new Action<int, string>(changeItemController.ChangeDescription));
            dictReports.Add(ItemType.Price, new Action<int, string>(changeItemController.ChangePrice));
            dictReports.Add(ItemType.Category, new Action<int, string>(changeItemController.ChangeCategory));
            
        }

        /// <summary>
        /// Writing items
        /// </summary>
        public void ChangeItemMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Id  Name  Price  Category  Description");
            Console.WriteLine();
            foreach (var i in wholeList)
            {
                Console.WriteLine(i.Id + " " + i.Name + " " + i.Price + " " + i.Category + " " + i.Description);
            }
            ChangeValue();
        }

        /// <summary>
        /// Change item menu
        /// </summary>
        public void ChangeValue()
        {
            string id = "";
            int resultId;
            string field = "";
            string j = "";
            isItemType += changeItemController.IsItemType;

            parseId += changeItemController.ParseId;

            isCorrectId += changeItemController.IsCorrectId;
            getItemByValue += changeItemController.GetItemValue;
            getItemById += changeItemController.GetItemById;
            Console.WriteLine();
            Console.WriteLine("Choose id of user's field that you want to change(0 to cancel):");
            id = Console.ReadLine();
            if (id.Equals("0"))
                enterPagePL.ChangeView();

            Console.WriteLine();
            Console.WriteLine("Choose field that you want to change(0 to cancel):");
            field = Console.ReadLine();
            
            if (field.Equals("0"))
                enterPagePL.ChangeView();

            Console.WriteLine();
            Console.WriteLine("Enter new value:");
            j = Console.ReadLine();


            if (isItemType(field) && isCorrectId(id))
            {
                resultId = parseId(id);
                dictReports[getItemByValue(field)](resultId, j);

                var result = getItemById(resultId);
                Console.WriteLine();
                Console.WriteLine("Changed value");

                Console.WriteLine();
                Console.WriteLine("Id  Name  Price  Category  Description");
                Console.WriteLine();
                foreach (var i in result)
                {
                    Console.WriteLine(i.Id + " " + i.Name + " " + i.Price + " " + i.Category+ " " + i.Description);
                }
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("Wrong data");
            }


            ChangeValue();
         }
    }
}
