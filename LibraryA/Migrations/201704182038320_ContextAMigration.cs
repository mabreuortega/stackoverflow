namespace LibraryA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContextAMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModelAs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ModelAs");
        }
    }
}
