using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework6.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        OrderService service;

        [TestMethod()]
        public void OrderServiceTest()
        {
            service = new OrderService();
            Assert.IsNotNull(service.orderList);
        }

        [TestMethod()]
        public void AddOrderTest1()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddOrder("111", "Jack");
            Order order1 = new Order("101", "Tom");
            Order order2 = new Order("111", "Jack");
            Assert.AreEqual(service.orderList[0],order1);
            Assert.AreEqual(service.orderList[1], order2);
            Assert.AreEqual(service.orderList.Count,2);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void AddOrderTest2()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddOrder("111", "Jack");

            //异常，订单号重复
            service.AddOrder("101", "Tim");
        }

        [TestMethod()]
        public void AddOrderTest3()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddOrder("111", "Jack");
            //无异常
            service.AddOrder("122", "Jack");
        }

        [TestMethod()]
        public void AddGoodsTest1()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddGoods("101", "milk", 30, 1);
            OrderDetails detail = new OrderDetails("milk", 30, 1);
            Assert.AreEqual(service.orderList[0].detailList[0], detail);
            Assert.AreEqual(service.orderList[0].detailList.Count,1);
            Assert.AreEqual(service.orderList[0].TotalPrice, 30);

            //商品相同，数量增加
            service.AddGoods("101", "milk", 30, 2);
            OrderDetails detail2 = new OrderDetails("milk", 30, 3);
            Assert.AreEqual(service.orderList[0].detailList[0],detail2);
            Assert.AreEqual(service.orderList[0].detailList.Count,1);
            Assert.AreEqual(service.orderList[0].TotalPrice, 90);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void AddGoodsTest2()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddGoods("101", "milk", 30, 1);

            //商品相同，数量增加，单价修改为原单价
            service.AddGoods("101", "milk", 15, 1);
            OrderDetails detail = new OrderDetails("milk", 30, 2);
            Assert.AreEqual(service.orderList[0].detailList[0], detail);
            Assert.AreEqual(service.orderList[0].TotalPrice, 60);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void AddGoodsTest3()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            //不存在订单
            service.AddGoods("100", "water", 5, 3);
        }

        [TestMethod()]
        public void DeleteOrderTest1()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddOrder("111", "Jack");
            service.DeleteOrder("101");
            Order order = new Order("111", "Jack");
            Assert.AreEqual(service.orderList[0], order);
            Assert.AreEqual(service.orderList.Count, 1);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void DeleteOrderTest2()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddOrder("111", "Jack");
            service.DeleteOrder("122");
        }

        [TestMethod()]
        public void DeleteGoodsTest1()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddGoods("101", "milk", 30, 1);
            service.AddGoods("101", "Cola", 14, 3);
            service.DeleteGoods("101", "milk");
            Assert.AreEqual(service.orderList[0].detailList.Count,1);
            Assert.AreEqual(service.orderList[0].TotalPrice, 42);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void DeleteGoodsTest2()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddGoods("101", "milk", 30, 1);
            service.DeleteGoods("101", "Cola");
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void DeleteGoodsTest3()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddGoods("101", "milk", 30, 1);
            service.DeleteGoods("100", "milk");
        }

        [TestMethod()]
        public void ModifyOrderTest1()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddOrder("111", "Jack");
            service.ModifyOrder("111", "177");
            service.ModifyOrder("101", "101", "Jim");
            Order order1 = new Order("101", "Jim");
            Order order2 = new Order("177", "Jack");
            Assert.AreEqual(service.orderList[0], order1);
            Assert.AreEqual(service.orderList[1], order2);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void ModifyOrderTest2()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddOrder("111", "Jack");
            service.ModifyOrder("122", "133");
        }

        [TestMethod()]
        public void ModifyGoodsTest1()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddGoods("101", "milk", 30, 1);
            service.AddGoods("101", "Cola", 14, 3);
            service.AddGoods("101", "Apple", 5, 4);
            service.ModifyGoods("101", "Cola", "Juice");
            service.ModifyGoods("101", "Apple", "Apple",6);
            service.ModifyGoods("101", "milk", "milk", 30, 2);
            OrderDetails detail1 = new OrderDetails("milk", 30, 2);
            OrderDetails detail2 = new OrderDetails("Juice", 14, 3);
            OrderDetails detail3 = new OrderDetails("Apple", 6, 4);
            Assert.AreEqual(service.orderList[0].detailList[0], detail1);
            Assert.AreEqual(service.orderList[0].detailList[1], detail2);
            Assert.AreEqual(service.orderList[0].detailList[2], detail3);
            Assert.AreEqual(service.orderList[0].TotalPrice, 126);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void ModifyGoodsTest2()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddGoods("101", "milk", 30, 1);
            service.ModifyGoods("101", "Cola", "Juice");
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void ModifyGoodsTest3()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddGoods("101", "milk", 30, 1);
            service.ModifyGoods("111", "milk", "water");
        }

        [TestMethod()]
        public void QueryAllOrderTest()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddOrder("111", "Jack");
            service.AddGoods("101", "milk", 30, 1);
            service.AddGoods("101", "water", 15, 3);
            service.AddGoods("111", "milk", 30, 4);
            service.AddGoods("111", "water", 15, 1);
            Order order1 = new Order("101", "Tom");
            order1.detailList.Add(new OrderDetails("milk", 30, 1));
            order1.detailList.Add(new OrderDetails("water", 15, 3));
            Order order2 = new Order("111", "Jack");
            order2.detailList.Add(new OrderDetails("milk", 30, 4));
            order2.detailList.Add(new OrderDetails("water", 15, 1));
            Assert.AreEqual(service.orderList[0], order1);
            Assert.AreEqual(service.orderList[1], order2);

            Order[] orders = service.QueryAllOrder();
            Assert.AreEqual(orders[0], order2);
            Assert.AreEqual(orders[1], order1);
        }

        [TestMethod()]
        public void QueryOrderByIdTest1()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddOrder("111", "Jack");
            service.AddGoods("101", "milk", 30, 1);
            service.AddGoods("101", "water", 15, 3);
            service.AddGoods("111", "milk", 30, 4);
            service.AddGoods("111", "water", 15, 1);
            Order order2 = new Order("111", "Jack");
            order2.detailList.Add(new OrderDetails("milk", 30, 4));
            order2.detailList.Add(new OrderDetails("water", 15, 1));
            Assert.AreEqual(service.orderList[1], order2);

            Order[] orders = service.QueryOrderById("111");
            Assert.AreEqual(orders[0], order2);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void QueryOrderByIdTest2()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddOrder("111", "Jack");
            service.AddGoods("101", "milk", 30, 1);
            service.AddGoods("101", "water", 15, 3);
            service.AddGoods("111", "milk", 30, 4);
            service.AddGoods("111", "water", 15, 1);
            Order[] orders = service.QueryOrderById("122");
        }

        [TestMethod()]
        public void QueryOrderByCustomerTest1()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddOrder("111", "Jack");
            service.AddOrder("122", "Jack");
            service.AddGoods("101", "milk", 30, 1);
            service.AddGoods("101", "water", 15, 3);
            service.AddGoods("111", "milk", 30, 4);
            service.AddGoods("111", "water", 15, 1);
            service.AddGoods("122", "milk", 30, 3);
            service.AddGoods("122", "water", 15, 4);

            Order order = new Order("111", "Jack");
            order.detailList.Add(new OrderDetails("milk", 30, 4));
            order.detailList.Add(new OrderDetails("water", 15, 1));
            Order order2 = new Order("122", "Jack");
            order2.detailList.Add(new OrderDetails("milk", 30, 3));
            order2.detailList.Add(new OrderDetails("water", 15, 4));
            Order[] orders = service.QueryOrderByCustomer("Jack");
            Assert.AreEqual(orders[0], order2);
            Assert.AreEqual(orders[1], order);
            Assert.AreEqual(orders.Length, 2);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void QueryOrderByCustomerTest2()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddOrder("111", "Jack");
            service.AddGoods("101", "milk", 30, 1);
            service.AddGoods("101", "water", 15, 3);
            service.AddGoods("111", "milk", 30, 4);
            service.AddGoods("111", "water", 15, 1);
            Order[] orders = service.QueryOrderByCustomer("Mary");
        }

        [TestMethod()]
        public void QueryOrderByGoodsTest1()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddOrder("111", "Jack");
            service.AddGoods("101", "milk", 30, 1);
            service.AddGoods("101", "water", 15, 3);
            service.AddGoods("111", "milk", 30, 4);
            service.AddGoods("111", "water", 15, 1);

            OrderService.Info info1 = new OrderService.Info
            {
                id = "101",
                customer = "Tom",
                totalPrice = 75,
                goodsName = "water",
                unitPrice = 15,
                count = 3
            };
            OrderService.Info info2 = new OrderService.Info
            {
                id = "111",
                customer = "Jack",
                totalPrice = 135,
                goodsName = "water",
                unitPrice = 15,
                count = 1
            };
            OrderService.Info[] infolist = service.QueryOrderByGoods("water");
            Assert.AreEqual(infolist[0], info2);
            Assert.AreEqual(infolist[1], info1);
            Assert.AreEqual(infolist.Length, 2);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void QueryOrderByGoodsTest2()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddOrder("111", "Jack");
            service.AddGoods("101", "milk", 30, 1);
            service.AddGoods("101", "water", 15, 3);
            service.AddGoods("111", "milk", 30, 4);
            service.AddGoods("111", "water", 15, 1);
            OrderService.Info[] infolist = service.QueryOrderByGoods("Cola");
        }

        [TestMethod()]
        public void QueryOrderByTotalPriceTest1()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddOrder("111", "Jack");
            service.AddOrder("122", "Mary");
            service.AddGoods("101", "milk", 30, 1);
            service.AddGoods("101", "water", 15, 3);
            service.AddGoods("111", "milk", 30, 4);
            service.AddGoods("111", "Juice", 14, 3);
            service.AddGoods("122", "Cola", 14, 4);
            service.AddGoods("122", "water", 15, 1);

            Order order1 = new Order("101", "Tom");
            order1.detailList.Add(new OrderDetails("milk", 30, 1));
            order1.detailList.Add(new OrderDetails("water", 15, 3));
            Order order2 = new Order("122", "Mary");
            order2.detailList.Add(new OrderDetails("Cola", 14, 4));
            order2.detailList.Add(new OrderDetails("water", 15, 1));
            Order[] orders = service.QueryOrderByTotalPrice(50, 100);
            Assert.AreEqual(orders[0], order1);
            Assert.AreEqual(orders[1], order2);
            Assert.AreEqual(orders.Length, 2);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void QueryOrderByTotalPriceTest2()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddOrder("111", "Jack");
            service.AddOrder("122", "Mary");
            service.AddGoods("101", "milk", 30, 1);
            service.AddGoods("101", "water", 15, 3);
            service.AddGoods("111", "milk", 30, 4);
            service.AddGoods("111", "Juice", 14, 3);
            service.AddGoods("122", "Cola", 14, 4);
            service.AddGoods("122", "water", 15, 1);
            Order[] orders = service.QueryOrderByTotalPrice(10, 40);
        }

        [TestMethod()]
        public void SortTest1()
        {
            service = new OrderService();
            service.AddOrder("122", "Mary");
            service.AddOrder("101", "Tom");
            service.AddOrder("111", "Jack");
            service.AddGoods("122", "Cola", 14, 4);
            service.AddGoods("122", "water", 15, 1);
            service.AddGoods("101", "milk", 30, 1);
            service.AddGoods("101", "water", 15, 3);
            service.AddGoods("111", "milk", 30, 4);
            service.AddGoods("111", "Juice", 14, 3);
            service.Sort();

            Order order1 = new Order("101", "Tom");
            order1.detailList.Add(new OrderDetails("milk", 30, 1));
            order1.detailList.Add(new OrderDetails("water", 15, 3));
            Order order2 = new Order("111", "Jack");
            order2.detailList.Add(new OrderDetails("Juice", 14, 3));
            order2.detailList.Add(new OrderDetails("milk", 30, 4));
            Order order3 = new Order("122", "Mary");
            order3.detailList.Add(new OrderDetails("Cola", 14, 4));
            order3.detailList.Add(new OrderDetails("water", 15, 1));
            Assert.AreEqual(service.orderList.Count, 3);
            Assert.AreEqual(service.orderList[0], order1);
            Assert.AreEqual(service.orderList[1], order2);
            Assert.AreEqual(service.orderList[2], order3);
        }

        [TestMethod()]
        public void SortTest2()
        {
            service = new OrderService();
            service.AddOrder("122", "Mary");
            service.AddOrder("101", "Tom");
            service.AddOrder("111", "Jack");
            service.AddGoods("122", "Cola", 14, 4);
            service.AddGoods("122", "water", 15, 1);
            service.AddGoods("101", "milk", 30, 1);
            service.AddGoods("101", "water", 15, 3);
            service.AddGoods("111", "milk", 30, 4);
            service.AddGoods("111", "Juice", 14, 3);
            service.Sort((a1,a2)=> string.Compare(a2.Id, a1.Id));

            Order order1 = new Order("101", "Tom");
            order1.detailList.Add(new OrderDetails("milk", 30, 1));
            order1.detailList.Add(new OrderDetails("water", 15, 3));
            Order order2 = new Order("111", "Jack");
            order2.detailList.Add(new OrderDetails("Juice", 14, 3));
            order2.detailList.Add(new OrderDetails("milk", 30, 4));
            Order order3 = new Order("122", "Mary");
            order3.detailList.Add(new OrderDetails("Cola", 14, 4));
            order3.detailList.Add(new OrderDetails("water", 15, 1));
            Assert.AreEqual(service.orderList.Count, 3);
            Assert.AreEqual(service.orderList[0], order3);
            Assert.AreEqual(service.orderList[1], order2);
            Assert.AreEqual(service.orderList[2], order1);
        }

        [TestMethod()]
        public void SortTest3()
        {
            service = new OrderService();
            service.AddOrder("122", "Mary");
            service.AddOrder("101", "Tom");
            service.AddOrder("111", "Jack");
            service.AddGoods("122", "Cola", 14, 4);
            service.AddGoods("122", "water", 15, 1);
            service.AddGoods("101", "milk", 30, 1);
            service.AddGoods("101", "water", 15, 3);
            service.AddGoods("111", "milk", 30, 4);
            service.AddGoods("111", "Juice", 14, 3);
            service.Sort((a1, a2) => string.Compare(a1.Customer, a2.Customer));

            Order order1 = new Order("101", "Tom");
            order1.detailList.Add(new OrderDetails("milk", 30, 1));
            order1.detailList.Add(new OrderDetails("water", 15, 3));
            Order order2 = new Order("111", "Jack");
            order2.detailList.Add(new OrderDetails("Juice", 14, 3));
            order2.detailList.Add(new OrderDetails("milk", 30, 4));
            Order order3 = new Order("122", "Mary");
            order3.detailList.Add(new OrderDetails("Cola", 14, 4));
            order3.detailList.Add(new OrderDetails("water", 15, 1));
            Assert.AreEqual(service.orderList.Count, 3);
            Assert.AreEqual(service.orderList[0], order2);
            Assert.AreEqual(service.orderList[1], order3);
            Assert.AreEqual(service.orderList[2], order1);
        }

        [TestMethod()]
        public void SortTest4()
        {
            service = new OrderService();
            service.AddOrder("122", "Mary");
            service.AddOrder("101", "Tom");
            service.AddOrder("111", "Jack");
            service.AddGoods("122", "Cola", 14, 4);
            service.AddGoods("122", "water", 15, 1);
            service.AddGoods("101", "milk", 30, 1);
            service.AddGoods("101", "water", 15, 3);
            service.AddGoods("111", "milk", 30, 4);
            service.AddGoods("111", "Juice", 14, 3);
            service.Sort((a1, a2) => (int)(a2.TotalPrice - a1.TotalPrice));

            Order order1 = new Order("101", "Tom");
            order1.detailList.Add(new OrderDetails("milk", 30, 1));
            order1.detailList.Add(new OrderDetails("water", 15, 3));
            Order order2 = new Order("111", "Jack");
            order2.detailList.Add(new OrderDetails("Juice", 14, 3));
            order2.detailList.Add(new OrderDetails("milk", 30, 4));
            Order order3 = new Order("122", "Mary");
            order3.detailList.Add(new OrderDetails("Cola", 14, 4));
            order3.detailList.Add(new OrderDetails("water", 15, 1));
            Assert.AreEqual(service.orderList.Count, 3);
            Assert.AreEqual(service.orderList[0], order2);
            Assert.AreEqual(service.orderList[1], order1);
            Assert.AreEqual(service.orderList[2], order3);
        }

        [TestMethod()]
        public void ExportTest()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddOrder("111", "Jack");
            service.AddOrder("122", "Mary");
            service.AddGoods("101", "milk", 30, 1);
            service.AddGoods("101", "water", 15, 3);
            service.AddGoods("111", "milk", 30, 4);
            service.AddGoods("111", "Juice", 14, 3);
            service.AddGoods("122", "Cola", 14, 4);
            service.AddGoods("122", "water", 15, 1);
            service.Export("order2.xml");
            string text1 = File.ReadAllText(@"..\..\orderXmlTest.xml");
            string text2 = File.ReadAllText("order2.xml");
            Assert.AreEqual(text1, text2);
            File.Delete("order2.xml");
        }

        [TestMethod()]
        public void ImportTest()
        {
            service = new OrderService();
            service.AddOrder("101", "Tom");
            service.AddOrder("111", "Jack");
            service.AddOrder("122", "Mary");
            service.AddGoods("101", "milk", 30, 1);
            service.AddGoods("101", "water", 15, 3);
            service.AddGoods("111", "milk", 30, 4);
            service.AddGoods("111", "Juice", 14, 3);
            service.AddGoods("122", "Cola", 14, 4);
            service.AddGoods("122", "water", 15, 1);
            Order[] orders = service.Import(@"..\..\orderXmlTest.xml");
            Assert.AreEqual(orders.Length, 3);
            Assert.AreEqual(orders[0], service.orderList[0]);
            Assert.AreEqual(orders[1], service.orderList[1]);
            Assert.AreEqual(orders[2], service.orderList[2]);
        }
    }
}