using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.ProductInStock.Models;
using Nop.Services.Catalog;
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
            if (additionalData is CategoryModel categoryModel)
            {
                var categoryId = categoryModel.Id;

                var model = new StockViewModel
                {
                    categoryId = categoryId,
                };

                return await Task.FromResult(View("~/Plugins/Widgets.ProductInStock/Views/ProductInStock.cshtml", model));
            }


            return View("~/Plugins/Widgets.ProductInStock/Views/ProductInStock.cshtml", new StockViewModel
            {
                categoryId = 0,
            });
        }
    }
}
