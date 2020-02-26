﻿using System;
using System.Collections.Generic;

namespace SalesStuffLibrary
{
    public class Utils
    {

        public static void SetDefaultPricing(PointOfSaleTerminal terminal)
        {
            Console.WriteLine("Default Pricing:");
            // Set default pricing for Products
            foreach (int product in Enum.GetValues(typeof(Products)))
            {
                switch (product)
                {
                    case 1:
                        terminal.SetPricing("A", "item", 1.25m, 3.00m, 3);
                        break;
                    case 2:
                        terminal.SetPricing("B", "item", 4.25m, 0, 0);
                        break;
                    case 3:
                        terminal.SetPricing("C", "pack", 1.00m, 5.00m, 6);
                        break;
                    case 4:
                        terminal.SetPricing("D", "item", 0.75m, 0, 0);
                        break;
                    default:
                        break;
                }

            }
            Console.WriteLine();
        }

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

                return (bulkAmount + unitAmount);
            }
            else
            {
                return orderItem.OrderQty * productInfo.UnitPrice;
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

        public static void ProductExistCheck(String productCode, Dictionary<string, ProductInfo> priceMap)
        {
            
            if (!priceMap.ContainsKey(productCode))
            {
                throw new KeyNotFoundException("Product '" + productCode + "' is not exist in Price List");
            }
        }


        public Utils()
        {
        }
    }
}
