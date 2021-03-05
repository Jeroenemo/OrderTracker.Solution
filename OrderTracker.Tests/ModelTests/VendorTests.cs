using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderTracker.Models;
using System.Collections.Generic;
using System;

namespace OrderTracker.Models
{
  [TestClass]
  public class VendorTests : IDisposable
  {
    public void Dispose()
    {
      Vendor.ClearAll();
    }
    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      Vendor newVendor = new Vendor("test vendor");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }
    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "test vendor";
      Vendor newVendor = new Vendor(name);

      //Act
      string result = newVendor.Name;

      //Assert
      Assert.AreEqual(name, result);
    }
    [TestMethod]
    public void GetId_ReturnsVendorId_Int()
    {
      //Arrange
      string name = "test vendor";
      Vendor newVendor = new Vendor(name);

      //Act
      int result = newVendor.Id;

      //Assert
      Assert.AreEqual(1, result);
    }
    [TestMethod]
    public void GetAll_ReturnsAllVendorObjects_VendorList()
    {
      //Arrange
      string name01 = "Paul Hollywood";
      string name02 = "Guy Fieri";
      Vendor newVendor01 = new Vendor(name01);
      Vendor newVendor02 = new Vendor(name02);
      List<Vendor> newList = new List<Vendor> { newVendor01, newVendor02 };

      //Act
      List<Vendor> result = Vendor.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]
    public void Find_ReturnCorrectVendor_Vendor()
    {
      //Arrange
      string name01 = "Paul Hollywood";
      string name02 = "Guy Fieri";
      Vendor newVendor01 = new Vendor(name01);
      Vendor newVendor02 = new Vendor(name02);

      //Act
      Vendor result = Vendor.Find(1);

      //Assert
      Assert.AreEqual(newVendor01, result);
    }
    [TestMethod]
    public void AddOrder_AssociatesOrderWithVendor_OrderList()
    {
      //Arrange
      string title = "New Order";
      string description = "Order Description";
      double price = 19.99;
      Order newOrder = new Order(title, description, price);
      List<Order> newList = new List<Order> { newOrder };
      string name = "David Chang";
      Vendor newVendor = new Vendor(name);
      newVendor.AddOrder(newOrder);

      //Act
      List<Order> result = newVendor.Orders;

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
  }
}