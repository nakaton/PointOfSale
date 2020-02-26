using System;
using System.Collections.Generic;

namespace SalesStuffLibrary
{
    public class PointOfSaleTerminal
    {
        public Dictionary<string, ProductInfo> PriceMap { get; set; }
        public List<OrderItem> OrderList { get; set; }
        public decimal OrderAmount { get; set; }


        /*
         * Method: SetPricing
         * Description: Set pricing when termianl start
         * Return: void
         */
        public void SetPricing(ProductInfo productInfo)
        {
            if(productInfo.UnitPrice > 0)
            {
                this.PriceMap.Add(productInfo.ProductCode, productInfo);
            }
        }


        /*
         * Method: ScanProduct
         * Description: Add orderItem into OderList or increase the Qty when scan items
         * Return: void
         */
        public void ScanProduct(string productCode)
        {
            Utils.ProductExistCheck(productCode, this);

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
         * Method: ScanProduct
         * Description: Add orderItem into OderList or increase the Qty when scan items
         * Return: OrderAmount
         */
        public decimal CalculateTotal()
        {
            foreach(var orderItem in this.OrderList)
            {
                this.OrderAmount += Utils.CalculateItemAmount(orderItem, this.PriceMap[orderItem.ProductCode]);
            }

            return this.OrderAmount;
        }


        /*
         * Method: ClearForNewOrder
         * Description: Clear previous OrderList and OrderAmount, prepare for next Order come in.
         * Return: void
         */
        public void ClearForNewOrder()
        {
            this.OrderList = new List<OrderItem>();
            this.OrderAmount = 0;
        }


        public PointOfSaleTerminal(Dictionary<string, ProductInfo> priceMap, List<OrderItem> orderItems, decimal orderAmount)
        {
            this.PriceMap = priceMap;
            this.OrderList = orderItems;
            this.OrderAmount = orderAmount;
        }

        public PointOfSaleTerminal()
        {
            this.PriceMap = new Dictionary<string, ProductInfo>();
            this.OrderList = new List<OrderItem>();
            this.OrderAmount = 0;
        }
    }
}
