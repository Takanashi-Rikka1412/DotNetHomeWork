/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Data.Entity;

namespace OrderApi
{
    public class OrderService  //订单服务
    {
        //添加新订单
        public int AddOrder(string id, string customer)
        {
            using (var db = new OrderContext())
            {
                var order = new Order()
                { OrderID = id, Customer = customer, TotalPrice = 0 };
                order.Details = new List<OrderDetails>();
                try
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                    return db.Orders.ToList().IndexOf(order);
                }
                catch (Exception e)
                {
                    throw new Exception("添加失败：" + e.Message);
                }
            }

        }

        //在订单中增加商品
        public void AddGoods(string id, string name, float unitPrice, int count)
        {
            using (var db = new OrderContext())
            {
                var order = db.Orders.FirstOrDefault(o => o.OrderID == id);
                var detail = new OrderDetails()
                { DetailID = id + name, Name = name, UnitPrice = unitPrice, Count = count, OrderID = id };

                if (order != null)
                {
                    order.TotalPrice += unitPrice * count;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("不存在该订单！");
                }
                try
                {
                    db.Entry(detail).State = EntityState.Added;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("添加失败：" + e.Message);
                }

            }
        }

        //删除订单
        public void DeleteOrder(string id)
        {
            using (var db = new OrderContext())
            {
                var order = db.Orders.Include("Details")
                    .FirstOrDefault(o => o.OrderID == id);
                if (order != null)
                {
                    foreach (var d in db.Details)
                    {
                        if (d.OrderID == id)
                            db.Details.Remove(d);
                    }
                    db.Orders.Remove(order);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("不存在该订单！");
                }
            }

        }

        //在订单中删除商品 
        public void DeleteGoods(string id, string name)
        {
            using (var db = new OrderContext())
            {
                var order = db.Orders.FirstOrDefault(o => o.OrderID == id);
                var detail = db.Details
                    .FirstOrDefault(d => d.Name == name && d.OrderID == id);
                if (order != null)
                {
                    order.TotalPrice -= detail.UnitPrice * detail.Count;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("不存在该订单！");
                }
                if (detail != null)
                {
                    db.Details.Remove(detail);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("不存在该商品！");
                }

            }

        }

        //修改订单号或客户
        public int ModifyOrder(string preId, string newId, string newCustomer = "")
        {
            if (preId == newId)
            {
                using (var db = new OrderContext())
                {
                    var order = db.Orders.Include("Details").FirstOrDefault(o => o.OrderID == preId);
                    if (order != null)
                    {
                        if (newCustomer != "")
                            order.Customer = newCustomer;
                        db.SaveChanges();
                        return db.Orders.ToList().IndexOf(order);
                    }
                    else
                    {
                        throw new Exception("不存在该订单");
                    }
                }
            }
            else
            {
                string customer;
                List<OrderDetails> detail;
                using (var db = new OrderContext())
                {
                    var order = db.Orders.Include("Details").FirstOrDefault(o => o.OrderID == preId);
                    customer = order.Customer;
                    detail = order.Details;
                }
                int i = AddOrder(newId, customer);
                foreach (OrderDetails d in detail)
                {
                    AddGoods(newId, d.Name, d.UnitPrice, d.Count);
                }
                DeleteOrder(preId);
                return i;
            }

        }

        //修改商品
        public void ModifyGoods(string id, string preName, string newName, float newUnitPrice = -1, int newCount = -1)
        {
            using (var db = new OrderContext())
            {
                var detail = db.Details.FirstOrDefault(d => d.OrderID == id && d.Name == preName);
                var order = db.Orders.FirstOrDefault(o => o.OrderID == id);
                if (detail != null && order != null)
                {
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

                    db.SaveChanges();
                }
                else if (order == null)
                {
                    throw new Exception("不存在该订单！");
                }
                else if (detail == null)
                {
                    throw new Exception("不存在该商品！");
                }

            }

        }

        //查询全部订单信息
        public Order[] QueryAllOrder()
        {
            using (var db = new OrderContext())
            {
                var orders = db.Orders.Include("Details");
                return orders.ToArray();
            }

        }

        //用订单号查询订单
        public Order[] QueryOrderById(string id)
        {
            using (var db = new OrderContext())
            {
                var orders = db.Orders.Include("Details")
                             .Where(o => o.OrderID == id)
                             .OrderByDescending(o => o.TotalPrice);
                if (!orders.Any())
                    throw new Exception("不存在此订单号");
                return orders.ToArray();
            }

        }

        //用客户查询订单
        public Order[] QueryOrderByCustomer(string customer)
        {
            using (var db = new OrderContext())
            {
                var orders = db.Orders.Include("Details")
                             .Where(o => o.Customer == customer)
                             .OrderByDescending(o => o.TotalPrice);
                if (!orders.Any())
                    throw new Exception("不存在该客户的订单");
                return orders.ToArray();
            }

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
            using (var db = new OrderContext())
            {
                foreach (OrderDetails d in db.Details.Include("Order"))
                {
                    if (d.Name != goodsName)
                        continue;
                    Info info = new Info
                    {
                        id = d.OrderID,
                        customer = d.Order.Customer,
                        totalPrice = d.Order.TotalPrice,
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
            using (var db = new OrderContext())
            {
                var orders = db.Orders.Include("Details")
                    .Where(o => (maxTotalPrice <= -1) ?
                             o.TotalPrice >= minTotalPrice
                             : o.TotalPrice >= minTotalPrice && o.TotalPrice <= maxTotalPrice)
                             .OrderByDescending(o => o.TotalPrice);
                if (!orders.Any())
                    throw new Exception("不存在该金额范围内的订单");

                return orders.ToArray();
            }


        }


        //将所有订单序列化为xml文件
        public void Export(string address)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (var db = new OrderContext())
            {
                using (FileStream fs = new FileStream(address, FileMode.Create))
                {
                    xmlSerializer.Serialize(fs, db.Orders.Include("Details").ToList());
                }
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
}
*/