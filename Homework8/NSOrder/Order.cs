using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace NSOrder
{
    [Serializable]
    public class Order //订单
    {
        public List<OrderDetails> detailList;
        public string Id { get; set; }
        public string Customer { get; set; }

        private float totalPrice;
        public float TotalPrice
        {
            get => totalPrice;
            set
            {
                if (value < 0)
                {
                    totalPrice = 0;
                    throw new Exception("错误！总价不能为负数！");
                }
                else
                    totalPrice = value;
            }
        }


        public Order() { }
        public Order(string id, string customer)
        {
            detailList = new List<OrderDetails>();
            Id = id;
            Customer = customer;
            TotalPrice = 0;
        }
        public Order(OrderDetails detail, string id, string customer)
        {
            detailList = new List<OrderDetails>();
            detailList.Add(detail);
            Id = id;
            Customer = customer;
            TotalPrice = detail.UnitPrice * detail.Count;
        }

        public override bool Equals(object order)
        {
            if (order.GetType() == typeof(Order) && Id == ((Order)order).Id)
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"订单号：{Id}\t客户：{Customer}\t订单总额：{TotalPrice}";
        }

    }

    [Serializable]
    public class OrderDetails  //订单明细
    {
        public string Name { get; set; }

        private float unitPrice;
        public float UnitPrice
        {
            get => unitPrice;
            set
            {
                if (value < 0)
                {
                    unitPrice = 0;
                    throw new Exception("错误！单价不能为负数！");
                }
                else
                    unitPrice = value;
            }
        }

        private int count;
        public int Count
        {
            get => count;
            set
            {
                if (value <= 0)
                {
                    count = 1;
                    throw new Exception("错误！数量应该为正数！");
                }
                else
                    count = value;
            }
        }



        public OrderDetails() { }
        public OrderDetails(string name, float unitPrice, int count = 1)
        {
            Name = name;
            Count = count;
            UnitPrice = unitPrice;
        }

        public override bool Equals(object detail)
        {
            if (detail.GetType() == typeof(OrderDetails) && Name == ((OrderDetails)detail).Name)
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"商品名称：{Name}\t单价：{UnitPrice}\t数量：{Count}";
        }
    }

    public class OrderService  //订单服务
    {
        public List<Order> orderList;

        public OrderService()
        {
            orderList = new List<Order>();
        }

        //添加新订单
        public void AddOrder(string id, string customer)
        {
            Order order = new Order(id, customer);
            var orders = from o in orderList
                         where o.Equals(order)
                         select o;
            if (orders.Any())
                throw new Exception("不可添加重复订单！");
            else if (id == String.Empty || customer == String.Empty)
                throw new Exception("订单号和客户名不能为空！");
            else
                orderList.Add(order);
        }

        //在订单中增加商品
        public void AddGoods(string id, string name, float unitPrice, int count)
        {

            var orders = from o in orderList
                         where o.Id.Equals(id)
                         select o;
            if (!orders.Any())
                throw new Exception("不存在该订单！");

            Order order = orders.FirstOrDefault();
            OrderDetails detail = new OrderDetails(name, unitPrice, count);
            var details = from d in order.detailList
                          where d.Equals(detail)
                          select d;
            if (!details.Any())
                order.detailList.Add(detail);
            else
            {
                detail = details.FirstOrDefault();
                detail.Count += count;
            }
            order.TotalPrice += unitPrice * count;

            if (detail.UnitPrice != unitPrice)
                throw new Exception("单价与先前不同，已修改为原单价！");
        }

        //删除订单
        public void DeleteOrder(string id)
        {
            var orders = from o in orderList
                         where o.Id.Equals(id)
                         select o;
            if (!orders.Any())
                throw new Exception("不存在该订单！");
            else
                orderList.Remove(orders.FirstOrDefault());
        }

        //在订单中删除商品 
        public void DeleteGoods(string id, string name)
        {
            var orders = from o in orderList
                         where o.Id.Equals(id)
                         select o;
            if (!orders.Any())
                throw new Exception("不存在该订单！");


            Order order = orders.FirstOrDefault();
            var details = from d in order.detailList
                          where d.Name.Equals(name)
                          select d;
            if (!details.Any())
                throw new Exception("不存在该商品！");

            OrderDetails detail = details.FirstOrDefault();
            order.TotalPrice -= detail.UnitPrice * detail.Count;
            order.detailList.Remove(detail);

        }

        //修改订单号或客户
        public void ModifyOrder(string preId, string newId, string newCustomer = "")
        {
            var orders = from o in orderList
                         where o.Id.Equals(preId)
                         select o;
            if (!orders.Any())
                throw new Exception("不存在该订单");
            else
            {
                Order order = orders.FirstOrDefault();
                order.Id = newId;
                if (newCustomer != "")
                    order.Customer = newCustomer;
            }
        }

        //修改商品
        public void ModifyGoods(string id, string preName, string newName, float newUnitPrice = -1, int newCount = -1)
        {
            var orders = from o in orderList
                         where o.Id.Equals(id)
                         select o;
            if (!orders.Any())
                throw new Exception("不存在该订单！");


            Order order = orders.FirstOrDefault();
            var details = from d in order.detailList
                          where d.Name.Equals(preName)
                          select d;
            if (!details.Any())
                throw new Exception("不存在该商品！");

            OrderDetails detail = details.FirstOrDefault();
            detail.Name = newName;
            if (newUnitPrice >= 0)
            {
                order.TotalPrice = order.TotalPrice + (newUnitPrice - detail.UnitPrice) * detail.Count;
                detail.UnitPrice = newUnitPrice;
            }
            if (newCount > 0)
            {
                order.TotalPrice = order.TotalPrice + detail.UnitPrice * (newCount - detail.Count);
                detail.Count = newCount;
            }
        }

        //查询全部订单信息
        public Order[] QueryAllOrder()
        {
            var orders = from o in orderList
                         orderby o.TotalPrice descending
                         select o;
            return orders.ToArray();
        }

        //用订单号查询订单
        public Order[] QueryOrderById(string id)
        {
            var orders = from o in orderList
                         where o.Id.Equals(id)
                         orderby o.TotalPrice descending
                         select o;
            if (!orders.Any())
                throw new Exception("不存在此订单号");


            return orders.ToArray();

        }

        //用客户查询订单
        public Order[] QueryOrderByCustomer(string customer)
        {
            var orders = from o in orderList
                         where o.Customer.Equals(customer)
                         orderby o.TotalPrice descending
                         select o;
            if (!orders.Any())
                throw new Exception("不存在该客户的订单");

            return orders.ToArray();
        }

        public struct Info
        {
            public string id;
            public string customer;
            public float totalPrice;
            public string goodsName;
            public float unitPrice;
            public int count;
            public override string ToString()
            {
                return $"订单号：{id}\t客户：{customer}\t订单总额：{totalPrice}\t商品名称：{goodsName}\t单价：{unitPrice}\t数量：{count}";
            }
        }
        //用商品查询订单详情
        public Info[] QueryOrderByGoods(string goodsName)
        {
            List<Info> infoList = new List<Info>();

            foreach (Order order in orderList)
            {
                var details = from d in order.detailList
                              where d.Name.Equals(goodsName)
                              select d;

                foreach (OrderDetails d in details)
                {
                    Info info = new Info
                    {
                        id = order.Id,
                        customer = order.Customer,
                        totalPrice = order.TotalPrice,
                        goodsName = d.Name,
                        unitPrice = d.UnitPrice,
                        count = d.Count
                    };
                    infoList.Add(info);
                }
            }
            if (infoList.Count == 0)
                throw new Exception("不存在该商品");
            infoList.Sort((d1, d2) => (int)(d2.totalPrice - d1.totalPrice));
            return infoList.ToArray();
        }

        //用订单金额范围查询订单
        public Order[] QueryOrderByTotalPrice(float minTotalPrice, float maxTotalPrice = -1)
        {
            var orders = from o in orderList
                         where (maxTotalPrice <= -1) ?
                         o.TotalPrice >= minTotalPrice
                         : o.TotalPrice >= minTotalPrice && o.TotalPrice <= maxTotalPrice
                         orderby o.TotalPrice descending
                         select o;

            if (!orders.Any())
                throw new Exception("不存在该金额范围内的订单");

            return orders.ToArray();
        }


        //对订单排序
        public void Sort(Comparison<Order> comparison = null)
        {
            if (comparison == null)
                orderList.Sort((o1, o2) => string.Compare(o1.Id, o2.Id));
            else
                orderList.Sort(comparison);
            foreach (Order o in orderList)
            {
                o.detailList.Sort((d1, d2) => string.Compare(d1.Name, d2.Name));
            }
        }

        //对商品排序
        public void Sort(string id, Comparison<OrderDetails> comparison = null)
        {
            int index = orderList.IndexOf(new Order(id, ""));
            if (comparison == null)
                orderList[index].detailList.Sort((d1, d2) => string.Compare(d1.Name, d2.Name));
            else
                orderList[index].detailList.Sort(comparison);
        }


        //将所有订单序列化为xml文件
        public void Export(string address)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(address, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, orderList);
            }
        }

        //将xml文件反序列化载入订单
        public Order[] Import(string address)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            List<Order> orders;
            using (FileStream fs = new FileStream(address, FileMode.Open))
            {
                orders = (List<Order>)xmlSerializer.Deserialize(fs);
            }
            return orders.ToArray();
        }
    }


    public class Programm
    {
        public static void Show(Order[] order)
        {
            Console.WriteLine("---------------------------------------------------------------");
            foreach (Order o in order)
            {
                Console.WriteLine("订单号：" + o.Id + "，客户：" + o.Customer + "，总价：" + o.TotalPrice);
                Console.WriteLine("商品名\t单价\t数量");
                foreach (OrderDetails d in o.detailList)
                {
                    Console.WriteLine(d.Name + "\t" + d.UnitPrice + "\t" + d.Count);
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("\n\n\n");
        }
        public static void Show(OrderService.Info[] order)
        {
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("订单号\t客户\t总价\t商品名\t单价\t数量");
            foreach (OrderService.Info o in order)
            {
                Console.WriteLine(o.id + "\t" + o.customer + "\t" + o.totalPrice + "\t" + o.goodsName + "\t" + o.unitPrice + "\t" + o.count);
            }
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("\n\n\n");
        }
        static void mMain(string[] args)
        {

            Console.WriteLine("创建空订单服务");
            OrderService service = new OrderService();
            Console.WriteLine("向订单服务中添加新订单（101,Tom）");
            service.AddOrder("101", "Tom");
            Console.WriteLine("向订单服务中添加新订单（111,Jack）");
            service.AddOrder("111", "Jack");
            //异常，订单号重复
            Console.WriteLine("向订单服务中添加新订单（101,Tim）");
            try { service.AddOrder("101", "Tim"); } catch (Exception e) { Console.WriteLine(e.Message); }
            //无异常
            Console.WriteLine("向订单服务中添加新订单（122,Jack）");
            try { service.AddOrder("122", "Jack"); } catch (Exception e) { Console.WriteLine(e.Message); }


            Console.WriteLine("\n\n向订单101中加入商品（101,milk,30,1）");
            service.AddGoods("101", "milk", 30, 1);
            //商品相同，数量增加
            Console.WriteLine("向订单101中加入商品（101,milk,30,2）");
            service.AddGoods("101", "milk", 30, 2);
            //商品相同，数量增加，单价修改为原单价
            Console.WriteLine("向订单101中加入商品（101,milk,15,1）");
            try { service.AddGoods("101", "milk", 15, 1); } catch (Exception e) { Console.WriteLine(e.Message); }
            //不存在订单
            Console.WriteLine("向订单100中加入商品（100,water,5,3）");
            try { service.AddGoods("100", "water", 5, 3); } catch (Exception e) { Console.WriteLine(e.Message); }


            Console.WriteLine("\n\n现加入各种订单和商品");
            service.AddOrder("133", "Tim");
            service.AddOrder("144", "John");
            service.AddOrder("155", "???");
            service.AddGoods("101", "water", 5, 5);
            service.AddGoods("101", "apple", 3, 7);
            service.AddGoods("101", "orange", 2, 6);
            service.AddGoods("111", "apple", 3, 4);
            service.AddGoods("111", "orange", 2, 2);
            service.AddGoods("111", "Cola", 5, 16);
            service.AddGoods("122", "orange", 2, 6);
            service.AddGoods("122", "apple", 3, 5);
            service.AddGoods("122", "water", 5, 2);
            service.AddGoods("133", "orange", 2, 3);
            service.AddGoods("133", "water", 5, 5);
            service.AddGoods("144", "apple", 3, 14);
            service.AddGoods("155", "?????", 1, 1);


            Show(service.QueryAllOrder());

            Console.WriteLine("删除订单（155）");
            service.DeleteOrder("155");
            Console.WriteLine("删除订单（166）");
            try { service.DeleteOrder("166"); } catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("删除商品（101,milk）");
            service.DeleteGoods("101", "milk");
            Console.WriteLine("删除商品（101,Cola）");
            try { service.DeleteGoods("101", "Cola"); } catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine("删除商品（100,apple）");
            try { service.DeleteGoods("100", "apple"); } catch (Exception e) { Console.WriteLine(e.Message); }


            Console.WriteLine("\n\n删除后");
            Show(service.QueryAllOrder());
            Console.WriteLine("排序后");
            service.Sort((a1, a2) => (int)(a2.TotalPrice - a1.TotalPrice));
            Show(service.orderList.ToArray());


            Console.WriteLine("修改订单号（144,177）");
            service.ModifyOrder("144", "177");
            Console.WriteLine("修改订单客户（101,101,Jim）");
            service.ModifyOrder("101", "101", "Jim");
            Console.WriteLine("修改商品（111,Cola,Juice）");
            service.ModifyGoods("111", "Cola", "Juice");
            Console.WriteLine("\n\n修改后");
            Show(service.QueryAllOrder());


            Console.WriteLine("订单号查找（177）");
            Show(service.QueryOrderById("177"));
            Console.WriteLine("客户查找（Jack）");
            Show(service.QueryOrderByCustomer("Jack"));
            Console.WriteLine("商品查找（apple）");
            Show(service.QueryOrderByGoods("apple"));
            Console.WriteLine("订单金额范围查找（40,60）");
            Show(service.QueryOrderByTotalPrice(40, 60));


            Console.WriteLine("将所有订单序列化为xml文件");
            service.Export("order.xml");
            Console.WriteLine(File.ReadAllText("order.xml"));
            Console.WriteLine("\n\n将xml文件反序列化载入订单");
            Show(service.Import("order.xml"));



        }
    }

}
