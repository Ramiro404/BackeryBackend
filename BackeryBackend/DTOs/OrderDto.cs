namespace BackeryBackend.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Total { get; set; }
        public int CustomerId { get; set; }
    }
    public class SaveOrderDto
    {
    public DateTime CreatedAt { get; set; }
    public decimal Total { get; set; }
    public int CustomerId { get; set; }
    }
}
