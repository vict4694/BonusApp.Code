﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BonusApp;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Order order;
        // 59 init
        //[testinitialize]
        //public void initializetest()
        //{
        //    order = new order();
        //    order.addproduct(new product
        //    {
        //        name = "mælk",
        //        value = 10.0
        //    });
        //    order.addproduct(new product
        //    {
        //        name = "smør",
        //        value = 15.0
        //    });
        //    order.addproduct(new product
        //    {
        //        name = "pålæg",
        //        value = 20.0
        //    });
        //}

        // 61
        [TestInitialize]
        public void InitializeTest()
        {
            order = new Order();
            order.AddProduct(new Product
            {
                Name = "Mælk",
                Value = 10.0,
                AvailableFrom = new DateTime(2018, 3, 1),
                AvailableTo = new DateTime(2018, 3, 5)
            });
            order.AddProduct(new Product
            {
                Name = "Smør",
                Value = 15.0,
                AvailableFrom = new DateTime(2018, 3, 3),
                AvailableTo = new DateTime(2018, 3, 4)
            });
            order.AddProduct(new Product
            {
                Name = "Pålæg",
                Value = 20.0,
                AvailableFrom = new DateTime(2018, 3, 4),
                AvailableTo = new DateTime(2018, 3, 7)
            });
        }

        [TestMethod]
        public void TenPercent_Test()
        {
            Assert.AreEqual(4.5, Bonuses.TenPercent(45.0));
            Assert.AreEqual(40.0, Bonuses.TenPercent(400.0));
        }
        [TestMethod]
        public void FlatTwoIfAMountMoreThanFive_Test()
        {
            Assert.AreEqual(2.0, Bonuses.FlatTwoIfAmountMoreThanFive(10.0));
            Assert.AreEqual(0.0, Bonuses.FlatTwoIfAmountMoreThanFive(4.0));
        }
        [TestMethod]
        public void GetValueOfProducts_Test()
        {
            Assert.AreEqual(45.0, order.GetValueOfProducts());
        }
        [TestMethod]
        public void GetBonus_Test()
        {
            order.Bonus = Bonuses.TenPercent;
            Assert.AreEqual(4.5, order.GetBonus());

            order.Bonus = Bonuses.FlatTwoIfAmountMoreThanFive;
            Assert.AreEqual(2.0, order.GetBonus());
        }
        [TestMethod]
        public void GetTotalPrice_Test()
        {
            order.Bonus = Bonuses.TenPercent;
            Assert.AreEqual(40.5, order.GetTotalPrice());

            order.Bonus = Bonuses.FlatTwoIfAmountMoreThanFive;
            Assert.AreEqual(43.0, order.GetTotalPrice());
        }
        [TestMethod]
        public void GetBonusAnonymous_Test()
        {
            order.Bonus =  delegate (double arg)
            {
                return arg / 10.0;
            };
        Assert.AreEqual(4.5, order.GetBonus());

            order.Bonus = delegate (double amount)
            { 
            return amount > 5.0 ? 2.0 : 0.0;
            };
        Assert.AreEqual(2.0, order.GetBonus());
        }

        [TestMethod]
        public void GetBonusLambda_Test()
        {
            order.Bonus =  arg => arg / 10.0;

            Assert.AreEqual(4.5, order.GetBonus());

            order.Bonus = amount => amount > 5.0 ? 2.0 : 0.0; // <- Change to lambda expressionx
            Assert.AreEqual(2.0, order.GetBonus());
        }

        // ex61
        [TestMethod]
        public void GetValueOfProductsByDate_Test()
        {
            Assert.AreEqual(0.0, order.GetValueOfProducts(new DateTime(2018, 2, 28)));
            Assert.AreEqual(10.0, order.GetValueOfProducts(new DateTime(2018, 3, 2)));
            Assert.AreEqual(20.0, order.GetValueOfProducts(new DateTime(2018, 3, 3)));
            Assert.AreEqual(45.0, order.GetValueOfProducts(new DateTime(2018, 3, 4)));
        }


    }

}
