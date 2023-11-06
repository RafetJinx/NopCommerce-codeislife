using Nop.Plugin.Widgets.AskVendor.Components;
using Nop.Services.Cms;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.AskVendor
{
    public class AskVendorPlugin : BasePlugin, IWidgetPlugin
    {
        /// <summary>
        /// Widget listesinde widget'ın görünüp görünmeyeceğini belirler.
        /// false -> görünür, true -> görünmez
        /// </summary>
        public bool HideInWidgetList => false;

        /// <summary>
        /// Hangi widget gösterilecek?
        /// </summary>
        /// <param name="widgetZone"></param>
        /// <returns></returns>
        public Type GetWidgetViewComponent(string widgetZone)
        {
            return typeof(AskVendorViewComponent);
        }

        /// <summary>
        /// Widget Nerede gösterilecek?
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IList<string>> GetWidgetZonesAsync()
        {
            var widgetZones = new List<string> { PublicWidgetZones.ProductDetailsInsideOverviewButtonsAfter };

            return await Task.FromResult(widgetZones);
        }
    }
}
