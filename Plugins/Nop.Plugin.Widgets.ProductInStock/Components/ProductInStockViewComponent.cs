using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.ProductInStock.Models;
using Nop.Services.Catalog;
using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Web.Framework.Components;
using Nop.Web.Models.Catalog;
using CategoryModel = Nop.Web.Models.Catalog.CategoryModel;

namespace Nop.Plugin.Widgets.ProductInStock.Components
{
    public class ProductInStockViewComponent : NopViewComponent
    {
        private readonly IProductService _productService;

        public ProductInStockViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
        {
            Console.WriteLine(additionalData.ToString());

            var allProducts = new List<ProductOverviewModel>();
            var productsInStock = new List<ProductOverviewModel>();
            var productsOutOfStock = new List<ProductOverviewModel>();

            if (additionalData is CategoryModel categoryModel)
            {
                var productOverviewModels = categoryModel.CatalogProductsModel.Products;
                allProducts.AddRange(productOverviewModels);

                foreach (var productOverview in productOverviewModels)
                {
                    var product = await _productService.GetProductByIdAsync(productOverview.Id);
                    var stockQuantity = await _productService.GetTotalStockQuantityAsync(product);

                    if (stockQuantity > 0)
                    {
                        productsInStock.Add(productOverview);
                    }
                    else
                    {
                        productsOutOfStock.Add(productOverview);
                    }
                }
            }

            var model = new StockViewModel
            {
                AllProducts = allProducts,
                ProductsInStock = productsInStock,
                ProductsOutOfStock = productsOutOfStock
            };

            return await Task.FromResult(View("~/Plugins/Widgets.ProductInStock/Views/ProductInStock.cshtml", model));
        }
    }
}
