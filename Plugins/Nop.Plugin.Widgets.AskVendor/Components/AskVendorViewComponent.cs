using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Nop.Web.Models.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.AskVendor.Components
{
    public class AskVendorViewComponent : NopViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
        {
            if (additionalData is not ProductDetailsModel)
                return Content("");

            var model = (ProductDetailsModel)additionalData;

            if (model.VendorModel.Id <= 0)
                return Content("");

            return await Task.FromResult(View("~/Plugins/Widgets.AskVendor/Views/AskVendor.cshtml"));
        }
    }
}
