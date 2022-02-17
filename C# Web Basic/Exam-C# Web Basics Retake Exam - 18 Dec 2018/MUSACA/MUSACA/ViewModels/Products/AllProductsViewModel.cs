using System.Collections.Generic;

namespace MUSACA.ViewModels.Products
{
    public class AllProductsViewModel
    {
        public ICollection<ProductViewModel> Products { get; set; }

        public decimal Total { get; set; }
    }
}
