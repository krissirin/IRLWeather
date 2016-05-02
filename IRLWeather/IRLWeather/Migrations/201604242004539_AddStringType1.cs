namespace IRLWeather.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStringType1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Weathers", "todaysCondition", c => c.String());
            AlterColumn("dbo.Weathers", "WindDirection", c => c.String());
            AlterColumn("dbo.Weathers", "tomorrowsCondition", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Weathers", "tomorrowsCondition", c => c.Int(nullable: false));
            AlterColumn("dbo.Weathers", "WindDirection", c => c.Int(nullable: false));
            AlterColumn("dbo.Weathers", "todaysCondition", c => c.Int(nullable: false));
        }
    }
}
