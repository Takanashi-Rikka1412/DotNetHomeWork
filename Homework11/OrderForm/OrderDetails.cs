using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrderForm
{
    [Serializable]
    public class OrderDetails  //订单明细
    {
        [Key,Required]
        public string DetailID { get; set; }
        [Required]
        public string Name { get; set; }

        private float unitPrice;
        [Required]
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
        [Required]
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


        public string OrderID { get; set; }
        [ForeignKey("OrderID")]
        [XmlIgnore]
        public Order Order { get; set; }

        

        /*
        public OrderDetails() { }
        public OrderDetails(string name, float unitPrice, int count = 1)
        {
            Name = name;
            Count = count;
            UnitPrice = unitPrice;
        }
        */
        
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

}
