using System;
using System.Collections.Generic;

namespace SalesStuffLibrary
{
    public class PointOfSaleTerminal
    {
        public Dictionary<string, ProductInfo> PriceMap { get; set; }
        public List<OrderItem> OrderList { get; set; }


        /*
         * Method: SetPricing
         * Description: Set pricing when termianl start
         * Return: void
         */
        public void SetPricing(String productCode, String unit, Decimal unitPrice, Decimal bulkPrice, Int16 bulkUnitQty)
        {
            if(unitPrice > 0)
            {
                ProductInfo productInfo = new ProductInfo(productCode, unit, unitPrice, bulkPrice, bulkUnitQty);
                Console.WriteLine(productInfo.ToString());

                // Remove inactive price and add in new price
                this.PriceMap.Remove(productCode);
                this.PriceMap.Add(productCode, productInfo);
            }
        }


        /*
         * Method: ScanProduct
         * Description: Add orderItem into OderList or increase the Qty when scan items
         * Return: void
         */
        public void ScanProduct(string productCode)
        {
            // Check scanned product is exist or not
            Utils.isProductExist(productCode, this.PriceMap);

            // Check whether item already contained in Order List
            bool isContained = false;

            foreach(OrderItem orderItem in this.OrderList)
            {
                if (orderItem.ProductCode == productCode)
                {
                    isContained = true;
                    orderItem.OrderQty += 1;
                }
            }

            if (!isContained)
            {
                this.OrderList.Add(new OrderItem(productCode, 1));
            }
        }


        /*
         * Method: CalculateTotal
         * Description: Calculate the check out Order Amount
         * Return: OrderAmount
         */
        public decimal CalculateTotal()
        {
            decimal orderAmount = 0.0m;

            foreach(var orderItem in this.OrderList)
            {
                orderAmount += Utils.CalculateItemAmount(orderItem, this.PriceMap[orderItem.ProductCode]);
            }

            return orderAmount;
        }


        /*
         * Method: ClearForNewOrder
         * Description: Clear previous OrderList, prepare for next Order come in.
         * Return: void
         */
        public void ClearForNewOrder()
        {
            this.OrderList = new List<OrderItem>();
        }


        public PointOfSaleTerminal(Dictionary<string, ProductInfo> priceMap, List<OrderItem> orderItems)
        {
            this.PriceMap = priceMap;
            this.OrderList = orderItems;
        }

        public PointOfSaleTerminal()
        {
            this.PriceMap = new Dictionary<string, ProductInfo>();
            this.OrderList = new List<OrderItem>();
        }
    }
}
