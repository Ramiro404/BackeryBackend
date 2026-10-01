namespace BackeryBackend.DTOs
{
    public class OrderProductDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
    public class SaveOrderProductDto
    {
        public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Amount { get; set; }
}
}
