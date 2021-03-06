using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using OrderTracker.Models;
using System;

namespace OrderTracker.Tests
{
  [TestClass]
  public class OrderTest : IDisposable
  {
    public void Dispose()
    {
      Order.ClearAll();
    }
    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("TestTitle", "TestDescription", 1.99);
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }
    [TestMethod]
    public void GetProperties_ReturnsProperties_String_String_Double()
    {
      // Arrange
      string title = "New Order";
      string description = "Order Description";
      double price = 19.99;

      // Act
      Order newOrder = new Order(title, description, price);
      string resultTitle = newOrder.Title;
      string resultDescription = newOrder.Description;
      double resultPrice = newOrder.Price;
      DateTime resultDate = newOrder.Date;

      // Assert
      Assert.AreEqual(title, resultTitle);
      Assert.AreEqual(description, resultDescription);
      Assert.AreEqual(price, resultPrice);
      Assert.AreEqual(DateTime.Today, resultDate);
    }
    [TestMethod]
    public void SetProperties_SetProperties_String_String_Double()
    {
      // Arrange
      string title = "New Order";
      string description = "Order Description";
      double price = 19.99;
      Order newOrder = new Order(title, description, price);

      // Act
      string updatedTitle = "Newer Order";
      string updatedDescription = "New Order Description";
      double updatedPrice = 20.00;
      newOrder.Title = updatedTitle;
      newOrder.Description = updatedDescription;
      newOrder.Price = updatedPrice;
      string resultTitle = newOrder.Title;
      string resultDescription = newOrder.Description;
      double resultPrice = newOrder.Price;
      
      // Assert
      Assert.AreEqual(updatedTitle, resultTitle);
      Assert.AreEqual(updatedDescription, resultDescription);
      Assert.AreEqual(updatedPrice, resultPrice);
    }
    [TestMethod]
    public void GetAll_ReturnsEmptyList_OrderList()
    {
      // Arrange
      List<Order> newList = new List<Order> { };

      // Act
      List<Order> result = Order.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]
    public void GetAll_ReturnsOrders_OrderList()
    {
      //Arrange
      string title01 = "title1";
      string title02 = "title2";
      string description01 = "an order";
      string description02 = "another order";
      double price01 = 34.54;
      double price02 = 21.21;
      Order newOrder1 = new Order(title01, description01, price01);
      Order newOrder2 = new Order(title02, description02, price02);
      List<Order> newList = new List<Order> { newOrder1, newOrder2 };

      //Act
      List<Order> result = Order.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]
    public void Find_ReturnsCorrectOrder_Order()
    {
      //Arrange
      string title01 = "title1";
      string title02 = "title2";
      string description01 = "an order";
      string description02 = "another order";
      double price01 = 34.54;
      double price02 = 21.21;
      Order newOrder1 = new Order(title01, description01, price01);
      Order newOrder2 = new Order(title02, description02, price02);

      //Act
      Order result = Order.Find(2);

      //Assert
      Assert.AreEqual(newOrder2, result);
    }
  }
}