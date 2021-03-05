using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using OrderTracker.Models;
using System;

namespace OrderTracker.Tests
{
  [TestClass]
  public class OrderTest
  {
    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("TestTitle", "TestDescription", 1.99);
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }
    [TestMethod]
    public void GetProperties_ReturnsProperties_String_String_Double()
    {
      string title = "New Order";
      string description = "Order Description";
      double price = 19.99;

      Order newOrder = new Order(title, description, price);
      string resultTitle = newOrder.Title;
      string resultDescription = newOrder.Description;
      double resultPrice = newOrder.Price;
      
      Assert.AreEqual(title, resultTitle);
      Assert.AreEqual(description, resultDescription);
      Assert.AreEqual(price, resultPrice);
    }
  }
}