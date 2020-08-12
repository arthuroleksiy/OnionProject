using System;
using System.Collections.Generic;
using System.Text;
using Onion_ServiceLayer;
using Onion_DomainLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Onion_Tests
{
    [TestClass]
    public class AddItemBLLTests
    {


        AddItemService addItemBLL = new AddItemService();
        


        [DataRow("0")]
        [DataRow("1")]
        [DataRow("2")]
        [TestMethod]
        public void ParseChoise_IsCorrect(string input)
        {
            
            var result = addItemBLL.ParseChoise(input, out int res);
            Assert.AreEqual(true,result);
        }



        [DataRow("0")]
        [DataRow("1")]
        [DataRow("2")]
        [TestMethod]
        public void IsIntResult_IsCorrect(string input)
        {

            var result = addItemBLL.IsIntResult(input, out int res);
            Assert.AreEqual(true, result);
        }

        [DataRow("0,00")]
        [DataRow("1,00")]
        [DataRow("2,00")]
        [TestMethod]
        public void IsDoubleResult_IsCorrect(string input)
        {


            var result = addItemBLL.IsDoubleResult(input, out double res);
            Assert.AreEqual(true, result);
        }
        /*
        public bool IsCategoryType(string input, out Category outValue)
        {

            if (!Enum.TryParse(input, out outValue))
            {
                return false;
            }

            return true;
        }*/

        [DataRow("Bakery")]
        [DataRow("Fruits_and_Vegetables")]
        [DataRow("Milk_products")]
        [TestMethod]
        public void IsCategoryType_IsCorrect(string input)
        {

            var result = addItemBLL.IsCategoryType(input, out Category res);
            Assert.AreEqual(true, result);
        }




        [DataRow("23")]
        [DataRow("23,50")]
        [DataRow("26,9999999")]
        [TestMethod]
        public void IsPrice_IsCorrect(string input)
        {


            var result = addItemBLL.IsPriceCorrect(input, out decimal res);
            Assert.AreEqual(true, result);
        }

    }
}
