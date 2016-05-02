// IRLWeatherContext - name of database

using System.Data.Entity;

namespace IRLWeather.Models
{
    public class IRLWeatherContext : DbContext
    {   
        public IRLWeatherContext() : base("name=IRLWeatherContext")
        {
            Database.SetInitializer<IRLWeatherContext>(new DropCreateDatabaseIfModelChanges<IRLWeatherContext>());
        }
        public DbSet<IRLWeather.Models.Weather> Weathers { get; set; }
    }
}
