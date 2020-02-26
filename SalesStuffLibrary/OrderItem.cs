using System;

namespace SalesStuffLibrary
{
    public class OrderItem
    {
        public string ProductCode { get; set; }
        public int OrderQty { get; set; }

        public OrderItem(string productCode, int orderQty)
        {
            Utils.IntArgumentOutOfRangeCheck(orderQty, "OrderQty");

            this.ProductCode = productCode;
            this.OrderQty = orderQty;
        }
    }
}
