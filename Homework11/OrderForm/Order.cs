using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderForm
{
    [Serializable]
    public class Order //订单
    {
        public List<OrderDetails> Details { get; set; }

        [Key,Required]
        public string OrderID { get; set; }
        [Required]
        public string Customer { get; set; }

        private float totalPrice;
        [Required]
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

        /*
        public Order() { }
        public Order(string id, string customer)
        {
            DetailList = new List<OrderDetails>();
            OrderID = id;
            Customer = customer;
            TotalPrice = 0;
        }
        public Order(OrderDetails detail, string id, string customer)
        {
            DetailList = new List<OrderDetails>();
            DetailList.Add(detail);
            OrderID = id;
            Customer = customer;
            TotalPrice = detail.UnitPrice * detail.Count;
        }
        */
        public override bool Equals(object order)
        {
            if (order.GetType() == typeof(Order) && OrderID == ((Order)order).OrderID)
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
            return $"订单号：{OrderID}\t客户：{Customer}\t订单总额：{TotalPrice}";
        }

        

    }
}
