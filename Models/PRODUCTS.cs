namespace SievePOS.Models
{
    public class PRODUCTS
    {
        public int ID { get; set; }
        public string? BAR_CODE { get; set; }
        public string? PRODUCT_NAME { get; set; }
        public decimal LAST_PRATE { get; set; }
        public decimal AVG_RATE { get; set; }
        public decimal MRP_RATE { get; set; }
        public decimal STOCK_QTY { get; set; }

    }
}
