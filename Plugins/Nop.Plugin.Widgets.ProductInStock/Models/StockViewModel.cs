using Nop.Web.Framework.UI.Paging;
using Nop.Web.Models.Catalog;

namespace Nop.Plugin.Widgets.ProductInStock.Models
{
    public partial record class StockViewModel : BasePageableModel
    {
        public required int categoryId;
    }
}
