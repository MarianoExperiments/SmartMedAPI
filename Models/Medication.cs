namespace smartMedRestApi.Models
{
    public class Medication
    {
        public int id { get; set; }

        public string? Name { get; set; }

        public int Quantity { get; set; }
        
        public DateTimeOffset Creation_Date { get; set; }
    }
}