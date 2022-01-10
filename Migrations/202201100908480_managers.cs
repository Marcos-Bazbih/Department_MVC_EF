namespace Department_MVC_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class managers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Seniority = c.Int(nullable: false),
                        NumberOfEmployees = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Managers");
        }
    }
}
