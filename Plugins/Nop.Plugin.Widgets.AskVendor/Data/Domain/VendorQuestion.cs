using Nop.Core;

namespace Nop.Plugin.Widgets.AskVendor.Data.Domain;

public class VendorQuestion : BaseEntity
{
    /*
        Notlar: 
            CustomerId
            VendorId
            ProductId
            Question
            CreatedUnUtc
    */

    public int CustomerId { get; set; }
    public int VendorId { get; set; }
    public int ProductId { get; set; }
    public string Question { get; set; }
    public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;
}
