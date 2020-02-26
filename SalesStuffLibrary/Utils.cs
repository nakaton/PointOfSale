using System;
using System.Collections.Generic;

namespace SalesStuffLibrary
{
    public class Utils
    {
        /*
         * Method: CalculateItemAmount
         * Description: Calculate the Amount of orderItem (Separated by bulk amount and unit amount)
         * Return: OrderItemAmount
         */
        public static Decimal CalculateItemAmount(OrderItem orderItem, ProductInfo productInfo)
        {
            
            var bulkAmount = 0.0m;
            var unitAmount = 0.0m;

            if (productInfo.BulkUnitQty > 0)
            {
                // Amount for Bulk sales
                bulkAmount = (orderItem.OrderQty / productInfo.BulkUnitQty) * productInfo.BulkPrice;
                // Amount for Unit sales
                unitAmount = (orderItem.OrderQty % productInfo.BulkUnitQty) * productInfo.UnitPrice;
            }
            else
            {
                return orderItem.OrderQty * productInfo.UnitPrice;
            }

            return (bulkAmount + unitAmount);
        }

        public static void SetDefaultPricing(PointOfSaleTerminal terminal)
        {
            // Set default pricing for Products
            foreach (int product in Enum.GetValues(typeof(Products)))
            {
                ProductInfo productInfo = null;
                switch (product)
                {
                    case 1:
                        productInfo = new ProductInfo("A", "item", 1.25m, 3.00m, 3);
                        break;
                    case 2:
                        productInfo = new ProductInfo("B", "item", 4.25m, 0, 0);
                        break;
                    case 3:
                        productInfo = new ProductInfo("C", "pack", 1.00m, 5.00m, 6);
                        break;
                    case 4:
                        productInfo = new ProductInfo("D", "item", 0.75m, 0, 0);
                        break;
                    default:
                        break;
                }
                Console.WriteLine(productInfo.ToString());

                terminal.SetPricing(productInfo);
            }
        }

        public static void DecimalArgumentOutOfRangeCheck(decimal argument, string name)
        {
            if (argument < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(argument), name + " must be positive");
            }
        }

        public static void IntArgumentOutOfRangeCheck(int argument, string name)
        {
            if (argument < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(argument), name + " must be positive");
            }
        }

        public static void ProductExistCheck(String productCode, PointOfSaleTerminal terminal)
        {
            
            if (terminal.PriceMap.ContainsKey(productCode))
            {
                throw new KeyNotFoundException("Product " + productCode + " is not exist in Price List");
            }
        }


        public Utils()
        {
        }
    }
}
