namespace BackeryBackend.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UnitAvailable { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }

    public class SaveProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UnitAvailable { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
