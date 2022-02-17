namespace MUSACA.ViewModels.Products
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.Product;

    public class ProductCreateInputModel
    {
        public string Id { get; set; }

        [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Name { get; set; }

        [MaxLength(2048, ErrorMessage = "Url is too long")]
        public string Picture { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        //[MaxLength(BarcodeMaxLength, ErrorMessage = "Too long Barcode")]
        //[RegularExpression(BarcodeLenght, ErrorMessage = "Barcode Must Be 12 digit Long")]
        //[StringLength(12, MinimumLength = 12 , ErrorMessage = "Barcode Must Be 12 digit Long")]
        public string Barcode { get; set; }
    }
}
