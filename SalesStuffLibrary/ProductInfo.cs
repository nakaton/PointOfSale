using System;
namespace SalesStuffLibrary
{
    public class ProductInfo
    {
        public String ProductCode { get; set; }
        public String Unit { get; set; }
        public Decimal UnitPrice { get; set; }
        public Decimal BulkPrice { get; set; }
        public Int16 BulkUnitQty { get; set; }

        public ProductInfo(String productCode, String unit, Decimal unitPrice, Decimal bulkPrice, Int16 bulkUnitQty)
        {
            Utils.DecimalArgumentOutOfRangeCheck(unitPrice, "UnitPrice");
            Utils.DecimalArgumentOutOfRangeCheck(bulkPrice, "BulkPrice");
            Utils.IntArgumentOutOfRangeCheck(bulkUnitQty, "BulkUnitQty");

            this.ProductCode = productCode;
            this.Unit = unit;
            this.UnitPrice = unitPrice;
            this.BulkPrice = bulkPrice;
            this.BulkUnitQty = bulkUnitQty;
        }

        public override string ToString()
        {
            return this.ProductCode + " | " +
                this.UnitPrice.ToString() + " for " + this.Unit + " | " +
                this.BulkPrice.ToString() + " for " + this.BulkUnitQty.ToString()
                + " " + this.Unit + " | ";

        }
    }
}
