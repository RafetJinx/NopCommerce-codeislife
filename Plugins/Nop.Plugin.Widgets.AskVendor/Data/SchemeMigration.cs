using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.Widgets.AskVendor.Data.Domain;

namespace Nop.Plugin.Widgets.AskVendor.Data;

[NopMigration("2023-03-25 10:10:10:6544156", "Ask Vendor Installation Migrate", MigrationProcessType.Installation)]
public class SchemeMigration : AutoReversingMigration
{
    public override void Up()
    {
        Create.TableFor<VendorQuestion>();
    }
}
