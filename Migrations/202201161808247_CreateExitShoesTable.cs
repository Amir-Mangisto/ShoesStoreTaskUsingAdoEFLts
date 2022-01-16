namespace ShoesStoreTaskUsingAdoEFLts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateExitShoesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExitShoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComapnyName = c.String(),
                        Gender = c.String(),
                        HasHeel = c.Boolean(nullable: false),
                        InStore = c.Boolean(nullable: false),
                        Size = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExitShoes");
        }
    }
}
