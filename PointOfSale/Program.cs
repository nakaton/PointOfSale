using System;
using SalesStuffLibrary;

namespace PointOfSale
{
    class Program
    {
        static void Main(string[] args)
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

            Console.WriteLine($"Amount of Order 'ABCDABA': ${terminal.CalculateTotal()}");

            //Prepare for next order
            terminal.ClearForNewOrder();

            // Order 2
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");
            terminal.ScanProduct("C");

            Console.WriteLine($"Amount of Order 'CCCCCCC': ${terminal.CalculateTotal()}");

            //Prepare for next order
            terminal.ClearForNewOrder();

            // Order 3
            terminal.ScanProduct("A");
            terminal.ScanProduct("B");
            terminal.ScanProduct("C");
            terminal.ScanProduct("D");

            Console.WriteLine($"Amount of Order 'ABCD': ${terminal.CalculateTotal()}");
        }
    }
}
