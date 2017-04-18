namespace LibraryB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinorChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ModelBs", "Date", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ModelBs", "Date", c => c.DateTime(nullable: false));
        }
    }
}
