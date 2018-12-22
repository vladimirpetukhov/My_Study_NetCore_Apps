namespace MUSACA.Models
{
    public class Product
    {
        /*•	Has an Id – a GUID String or an Integer.
•	Has a Name – a string.
•	Has a Price – a decimal.
•	Has a Barcode – a 12-digit long integer.
•	Has a Picture – a string.
*/
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long Barcode { get; set; }
        public string Picture { get; set; }
    }
}
