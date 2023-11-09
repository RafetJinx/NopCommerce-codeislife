using Nop.Plugin.Widgets.ProductInStock.Components;
using Nop.Services.Cms;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.ProductInStock
{
    internal class ProductInStockPlugin : BasePlugin, IWidgetPlugin
    {
        /// <summary>
        /// Make the widget visible.
        /// </summary>
        public bool HideInWidgetList => false;


        /// <summary>
        /// Defined the widget to be displayed.
        /// </summary>
        /// <param name="widgetZone"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Type GetWidgetViewComponent(string widgetZone)
        {
            return typeof(ProductInStockViewComponent);
        }

        /// <summary>
        /// Where will the widget be displayed?
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IList<string>> GetWidgetZonesAsync()
        {
            return await Task.FromResult(new List<string> { PublicWidgetZones.CategoryDetailsBeforeSubcategories });
        }
    }
}
