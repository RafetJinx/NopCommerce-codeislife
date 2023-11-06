using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;
using Nop.Data.Mapping.Builders;

namespace Nop.Plugin.Widgets.AskVendor.Data.Domain.Builders;

public class VendorQuestionBuilder : NopEntityBuilder<VendorQuestion>
{
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
             .WithColumn(nameof(VendorQuestion.CustomerId)).AsInt32().ForeignKey<Customer>()
             .WithColumn(nameof(VendorQuestion.VendorId)).AsInt32().ForeignKey<Vendor>()
             .WithColumn(nameof(VendorQuestion.ProductId)).AsInt32().ForeignKey<Product>()
             .WithColumn(nameof(VendorQuestion.Question)).AsString().NotNullable()
             .WithColumn(nameof(VendorQuestion.CreatedOnUtc)).AsDateTime2().NotNullable();
    }
}
