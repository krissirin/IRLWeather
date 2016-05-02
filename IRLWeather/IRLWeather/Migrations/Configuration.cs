namespace IRLWeather.Migrations
{
    using System.Data.Entity.Migrations;
    using IRLWeather.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<IRLWeatherContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        // populate in-memory collections with some test data
        protected override void Seed(IRLWeatherContext context)
        {
        context.Weathers.AddOrUpdate(new Models.Weather[] {
            new Weather() { Id = 1, City = "Belfast", todaysCondition = "Cloudy", MaxTemp = 10, MinTemp = 1, WindDirection = "East", WindSpeed = 5, tomorrowsCondition = "Rain"},
            new Weather() { Id = 2, City = "Cork", todaysCondition = "Drizzle", MaxTemp = 13, MinTemp = 2, WindDirection = "North", WindSpeed = 8, tomorrowsCondition = "Overcast"},
            new Weather() { Id = 3, City = "Donnegal", todaysCondition = "Fog", MaxTemp = 7, MinTemp = -1, WindDirection = "Northwest", WindSpeed = 9, tomorrowsCondition ="Snow"},
            new Weather() { Id = 4, City = "Dublin", todaysCondition = "Snow", MaxTemp = 4, MinTemp = 0, WindDirection = "West", WindSpeed = 7, tomorrowsCondition = "Fog"},
            new Weather() { Id = 5, City = "Galway", todaysCondition = "Rain", MaxTemp = 5, MinTemp = -2, WindDirection = "Southeast", WindSpeed = 10, tomorrowsCondition = "Drizzle"},
            new Weather() { Id = 6, City = "Limerick", todaysCondition = "Overcast", MaxTemp = 10, MinTemp = 1, WindDirection = "South", WindSpeed = 6, tomorrowsCondition = "Cloudy"},
            new Weather() { Id = 7, City = "Waterford", todaysCondition = "Sunny", MaxTemp = 11, MinTemp = 3, WindDirection = "Northeast", WindSpeed = 5, tomorrowsCondition = "Cloudy"}
        });
        }
    }
}
