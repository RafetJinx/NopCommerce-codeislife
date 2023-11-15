using Microsoft.AspNetCore.Mvc;
using Nop.Services.Catalog;
using Nop.Web.Factories;
using Nop.Web.Framework.Controllers;
using Nop.Web.Models.Catalog;

namespace Nop.Plugin.Widgets.ProductInStock.Controllers
{
    public class ProductStockController : BaseController
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ICatalogModelFactory _catalogModelFactory;

        public ProductStockController(
        IProductService productService,
        ICategoryService categoryService,
        ICatalogModelFactory catalogModelFactory)
        {
            _productService = productService;
            _categoryService = categoryService;
            _catalogModelFactory = catalogModelFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilteredCategoryProducts(int categoryId, string stockStatus, CatalogProductsCommand command)
        {
            // Getting category
            var category = await _categoryService.GetCategoryByIdAsync(categoryId);

            // Getting products
            var catalogProductsModel = await _catalogModelFactory.PrepareCategoryProductsModelAsync(category, command);

            var productOverviewModels = catalogProductsModel.Products;
            var productsToRemove = new List<ProductOverviewModel>();

            // Filtering products by stock status
            foreach (var productOverviewModel in productOverviewModels)
            {
                var product = await _productService.GetProductByIdAsync(productOverviewModel.Id);
                var stockQuantity = await _productService.GetTotalStockQuantityAsync(product);

                if ((stockStatus == "inStock" && stockQuantity <= 0) ||
                        (stockStatus == "outOfStock" && stockQuantity > 0))
                {
                    productsToRemove.Add(productOverviewModel);
                }
            }

            foreach (var product in productsToRemove)
            {
                productOverviewModels.Remove(product);
            }

            var filteredProductOverviewModels = productOverviewModels;

            var model = await _catalogModelFactory.PrepareCategoryProductsModelAsync(category, command);
            model.Products = filteredProductOverviewModels;

            return PartialView("_ProductsInGridOrLines", model);
        }
    }
}
