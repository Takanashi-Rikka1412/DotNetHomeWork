using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace OrderApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController: ControllerBase
    {
        private readonly OrderContext orderDb;

        public OrderController(OrderContext context)
        {
            this.orderDb = context;
        }


        [HttpGet]
        public ActionResult<List<Order>> GetOrder(string id, string customer, float? minTotalPrice, float? maxTotalPrice)
        {
            IQueryable<Order> orders = orderDb.Orders.Include("Details");
            if(id != null)
                orders = orders.Where(o => o.OrderID.Contains(id));

            if(customer != null)
                orders = orders.Where(o => o.Customer.Contains(customer));
            
            if(minTotalPrice != null)
                orders = orders.Where(o => o.TotalPrice >= minTotalPrice);
            
            if(maxTotalPrice != null)
                orders = orders.Where(o => o.TotalPrice <= maxTotalPrice);

            return orders.ToList();
        }


        [HttpGet("{detailName}")]
        public ActionResult<List<OrderDetails>> GetDetail(string detailName)
        {
            IQueryable<OrderDetails> details = orderDb.Details.Where(d => d.Name == detailName);
            
            return details.ToList();
        }


        [HttpPost]
        public ActionResult<Order> AddOrder(Order order)
        {
            try
            {
                orderDb.Orders.Add(order);
                order.TotalPrice = 0;
                if(order.Details != null)
                {
                    foreach(var detail in order.Details)
                        order.TotalPrice += detail.UnitPrice*detail.Count;
                }
                orderDb.SaveChanges();
            }
            catch(Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return order;
        }


        [HttpPost("{id}")]
        public ActionResult<OrderDetails> AddDetail(string id, OrderDetails detail)
        {
            var order = orderDb.Orders.FirstOrDefault(o => o.OrderID == id);
            if (order == null)
                return BadRequest("不存在该订单！");

            detail.OrderID = id;

            try
            {
                orderDb.Details.Add(detail);
                order.TotalPrice += detail.UnitPrice * detail.Count;
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return detail;
        }


        [HttpPut("{id}")]
        public ActionResult UpdateOrder(string id, Order order)
        {
            if (id == order.OrderID)
            {
                var preOrder= orderDb.Orders.Include("Details").FirstOrDefault(o => o.OrderID == id);
                if (preOrder == null)
                    return BadRequest("不存在该订单！");

                try
                {
                    preOrder.Customer = order.Customer;
                    if(order.Details != null)
                    {
                        preOrder.Details = order.Details;
                        preOrder.TotalPrice = 0;
                        foreach(var detail in preOrder.Details)
                            preOrder.TotalPrice += detail.UnitPrice*detail.Count;
                    }
                    orderDb.SaveChanges();
                }
                catch (Exception e)
                {
                    return BadRequest(e.InnerException.Message);
                }

                return NoContent();
            }
            else
            {
                var preOrder = orderDb.Orders.Include("Details").FirstOrDefault(o => o.OrderID == id);
                if (preOrder == null)
                    return BadRequest("不存在该订单！");

                string customer = preOrder.Customer;
                List<OrderDetails> detail = preOrder.Details;

                try
                {
                    orderDb.Orders.Add(order);
                    order.TotalPrice = 0;
                    if(order.Details != null)
                    {
                        foreach(var d in order.Details)
                            order.TotalPrice += d.UnitPrice*d.Count;
                    }
                    foreach (var d in orderDb.Details)
                    {
                        if (d.OrderID == id)
                            orderDb.Details.Remove(d);
                    }
                    orderDb.Orders.Remove(preOrder);
                    orderDb.SaveChanges();
                }
                catch(Exception e)
                {
                    return BadRequest(e.InnerException.Message);
                }

                return NoContent();
            }
        }


        [HttpPut("{orderId}/{detailName}")]
        public ActionResult UpdateDetail(string orderId, string detailName, OrderDetails detail)
        {
            var order = orderDb.Orders.FirstOrDefault(o => o.OrderID == orderId);
            if(order == null)
                return BadRequest("不存在该订单！");
            var preDetail = orderDb.Details.FirstOrDefault(d => d.OrderID == orderId && d.Name == detailName);
            if(detail == null)
                return BadRequest("不存在该商品！");

            try
            {
                preDetail.Name = detail.Name;
                order.TotalPrice = order.TotalPrice - preDetail.UnitPrice*preDetail.Count
                 + detail.UnitPrice*detail.Count;
                preDetail.UnitPrice = detail.UnitPrice;
                preDetail.Count = detail.Count;
                orderDb.SaveChanges();
            }
            catch(Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult DeteleOrder(string id)
        {
            var order = orderDb.Orders.Include("Details")
                    .FirstOrDefault(o => o.OrderID == id);
            if (order == null)
                return BadRequest("不存在该订单！");
            
            try
            {
                foreach (var d in orderDb.Details)
                {
                    if (d.OrderID == id)
                        orderDb.Details.Remove(d);
                }
                orderDb.Orders.Remove(order);
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }

            return NoContent();
        }


        [HttpDelete("{orderId}/{detailName}")]
        public ActionResult DeteleOrder(string orderId,string detailName)
        {
            var order = orderDb.Orders.FirstOrDefault(o => o.OrderID == orderId);
            if (order == null)
                return BadRequest("不存在该订单！");
            
            var detail = orderDb.Details
                .FirstOrDefault(d => d.Name == detailName && d.OrderID == orderId);
            if (detail == null)
                return BadRequest("不存在该商品！");

            try
            {
                orderDb.Details.Remove(detail);
                order.TotalPrice -= detail.UnitPrice * detail.Count;
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }

            return NoContent();
        }
    }
}
