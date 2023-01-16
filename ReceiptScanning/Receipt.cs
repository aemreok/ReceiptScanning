namespace ReceiptScanning
{
    partial class Program
    {
        public class Receipt
        {
            public string description { get; set; }
            public string locale { get; set; }
            public BoundingPoly boundingPoly { get; set; }
            public int basedPointY { get; set; }
        }
    }
}
