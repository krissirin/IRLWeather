namespace IRLWeather.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Weathers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.Int(nullable: false),
                        todaysCondition = c.Int(nullable: false),
                        MaxTemp = c.Int(nullable: false),
                        MinTemp = c.Int(nullable: false),
                        WindDirection = c.Int(nullable: false),
                        WindSpeed = c.Int(nullable: false),
                        tomorrowsCondition = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Weathers");
        }
    }
}
