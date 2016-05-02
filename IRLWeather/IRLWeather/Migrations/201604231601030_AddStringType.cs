namespace IRLWeather.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStringType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Weathers", "City", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Weathers", "City", c => c.Int(nullable: false));
        }
    }
}
