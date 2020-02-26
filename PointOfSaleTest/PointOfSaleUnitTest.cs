using System;
using System.Collections.Generic;
using SalesStuffLibrary;
using Xunit;

namespace PointOfSaleTest
{
    public class PointOfSaleUnitTest
    {
        [Fact]
        public void TestForNegtiveUnitPrice()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new ProductInfo("A", "item", -1.25m, 3.00m, 3)
            );
        }

        [Fact]
        public void TestForNegtiveBulkPrice()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new ProductInfo("A", "item", 1.25m, -3.00m, 3)
            );
        }

        [Fact]
        public void TestForNegtiveBulkUnitQty()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new ProductInfo("A", "item", 1.25m, 3.00m, -3)
            );
        }

        [Fact]
        public void TestForNegtiveOrderQty()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new OrderItem("A", -3)
            );
        }

        [Fact]
        public void TestForProductNotExist()
        {
            var terminal = new PointOfSaleTerminal();
            // Set default pricing for Products
            Utils.SetDefaultPricing(terminal);

            Assert.Throws<KeyNotFoundException>(
                () => terminal.ScanProduct("Undefined")
            );
        }

        [Fact]
        public void TestForRandomScanAmount()
        {
            Console.WriteLine("### Point Of Sale Terminal Service UP ###");

            var terminal = new PointOfSaleTerminal();
            // Set default pricing for Products
            Utils.SetDefaultPricing(terminal);

            // Order 1
            terminal.ScanProduct("A");
            terminal.ScanProduct("B");
            terminal.ScanProduct("C");
            terminal.ScanProduct("D");
            terminal.ScanProduct("A");
            terminal.ScanProduct("B");
            terminal.ScanProduct("A");

            var total = terminal.CalculateTotal();

            Console.WriteLine($"Amount of Random Order: {total}");

            Assert.Equal(13.25m, total);
        }

        [Fact]
        public void TestForSequenceScanAmount()
        {
            Console.WriteLine("### Point Of Sale Terminal Service UP ###");

            var terminal = new PointOfSaleTerminal();
            // Set default pricing for Products
            Utils.SetDefaultPricing(terminal);

            // Sequence Order
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");

            var total = terminal.CalculateTotal();

            Console.WriteLine($"Amount of Random Order: {total}");

            Assert.Equal(6.0m, total);
        }

        [Fact]
        public void TestForNormalPriceAmount()
        {
            Console.WriteLine("### Point Of Sale Terminal Service UP ###");

            var terminal = new PointOfSaleTerminal();
            // Set default pricing for Products
            Utils.SetDefaultPricing(terminal);

            // Order without using BulkPrice
            terminal.ScanProduct("A");
            terminal.ScanProduct("B");
            terminal.ScanProduct("C");
            terminal.ScanProduct("D");

            var total = terminal.CalculateTotal();

            Console.WriteLine($"Amount of Random Order: {total}");

            Assert.Equal(7.25m, total);
        }

        [Fact]
        public void TestForAmountAfterPriceChange()
        {
            Console.WriteLine("### Point Of Sale Terminal Service UP ###");

            var terminal = new PointOfSaleTerminal();
            // Set default pricing for Products
            Utils.SetDefaultPricing(terminal);

            // Order without using BulkPrice
            terminal.ScanProduct("A");
            terminal.ScanProduct("B");
            terminal.ScanProduct("C");
            terminal.ScanProduct("D");

            // Change the price of Product 'B'
            terminal.SetPricing("B", "item", 5.00m, 0, 0);

            var total = terminal.CalculateTotal();

            Console.WriteLine($"Amount of Random Order: {total}");

            Assert.Equal(8.00m, total);
        }
    }
}
