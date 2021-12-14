namespace FastFood.Services.DTO.Items
{
    public class CreateItemsDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
