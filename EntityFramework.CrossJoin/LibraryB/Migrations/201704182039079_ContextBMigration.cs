namespace LibraryB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContextBMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModelBs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ModelBs");
        }
    }
}
