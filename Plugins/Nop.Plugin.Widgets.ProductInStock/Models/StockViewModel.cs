using Nop.Web.Models.Catalog;

namespace Nop.Plugin.Widgets.ProductInStock.Models
{
    public class StockViewModel
    {
        public required IList<ProductOverviewModel> AllProducts { get; set; }
        public required IList<ProductOverviewModel> ProductsInStock { get; set; }
        public required IList<ProductOverviewModel> ProductsOutOfStock { get; set; }
    }
}
