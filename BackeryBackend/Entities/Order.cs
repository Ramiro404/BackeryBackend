namespace BackeryBackend.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CretedAt { get; set; }
        public decimal Total { get; set; }
        public int CustomerId {  get; set; }
    }
}
