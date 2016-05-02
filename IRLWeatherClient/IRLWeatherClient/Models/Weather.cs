using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Web;

namespace IRLWeatherClient.Models
{
    /// <summary>
    /// Define a class that will hold the detailed information for a weather.
    /// </summary>

    public enum Condition
    {
        [Display(Name = "Sunny")]
        Sunny,
        [Display(Name = "Cloudy")]
        Cloudy,
        [Display(Name = "Overcast")]
        Overcast,
        [Display(Name = "Rain")]
        Rain,
        [Display(Name = "Drizzle")]
        Drizzle,
        [Display(Name = "Fog")]
        Fog,
        [Display(Name = "Snow")]
        Snow
    }

    public enum WindDirection
    {
        North, South, East, West, Northeast, Southeast, Northwest, Southwest
    }

    public class Weather
    {
        //Key
        [Required]
        public int Id { get; set; }


        //City
        [Display(Name = "City")]
        public string City { get; set; }

        //Today's weather
        [Display(Name = "Today's weather")]
        public Condition todaysCondition { get; set; }

        //maximum temperature forecast for today
        [Display(Name = "Max temp")]
        [Range(-40, 40, ErrorMessage = "Temperature ranges from -40 to +40 Celcius")]
        public int MaxTemp { get; set; }

        //Minimum temperature forecast for today
        [Display(Name = "Min temp")]
        [Range(-40, 40, ErrorMessage = "Temperature ranges from -40 to +40 Celcius")]
        public int MinTemp { get; set; }

        //Wind direction
        [Display(Name = "Wind Direction")]
        public WindDirection WindDirection { get; set; }


        //Wind Speed
        [Display(Name = "Wind Speed")]
        [Range(0, 200, ErrorMessage = "Wind speed ranges from 0 to 200 km/h")]
        public int WindSpeed { get; set; }

        //Tomorrow's weather
        [Display(Name = "Tomorrow's weather")]
        public Condition tomorrowsCondition { get; set; }

    }
    /// <summary>
    /// Define an interface which contains the methods for the weather repository.
    /// </summary>
    public interface IWeatherRepository
    {
        Weather GetWeathers(Weather weather);
        IEnumerable<Weather> GetWeatherByCity(String city);
        Weather GetWeather(int id);
        //Weather PutWeather(int id, Weather weather);
        //Weather PostWeather(Weather weather);
        //Boolean DeleteWeather(int id);
    }
    /// <summary>
    /// Define a class based on the weather repository interface which contains the method implementations.
    /// </summary>
    public class WeatherRepository : IWeatherRepository
    {
        private string xmlFilename = null;
        private XDocument xmlDocument = null;

        /// <summary>
        /// Define the class constructor.
        /// </summary>
        public WeatherRepository()
        {
            try
            {
                // Determine the path to the weathers.xml file.
                xmlFilename = HttpContext.Current.Server.MapPath("~/app_data/weathers.xml");
                // Load the contents of the weathers.xml file into an XDocument object.
                xmlDocument = XDocument.Load(xmlFilename);
            }
            catch (Exception ex)
            {
                // Rethrow the exception.
                throw ex;
            }
        }

        /// <summary>
        /// Method to retrieve all of the weathers in the catalog.
        /// Defines the implementation of the non-specific GET method.
        /// </summary>
        public IEnumerable<Weather> GetWeatherByCity(String city)
        {
            try
            {
                // Return a list that contains the catalog of weather ids/titles.
                return (
                    // Query the catalog of weathers.
                    from weather in xmlDocument.Elements("Weather")
                        // Sort the catalog based on weather IDs.
                    orderby weather.Attribute("id").Value ascending
                    // Create a new instance of the detailed weather information class.
                    select new Weather
                    {
                        // Populate the class with data from each of the weather's elements.
                        City = weather.Element.
                        Id = weather.Value,
                        MaxTemp = weather.Element("author").Value,
                        MinTemp = weather.Element("title").Value,
                        WindDirection = weather.Element("genre").Value,
                        WindSpeed = Convert.ToDecimal(weather.Element("price").Value),
                        todaysCondition = Convert.ToDateTime(weather.Element("publish_date").Value),
                        tomorrowsCondition = weather.Element("description").Value
                    }).ToList();
            }
            catch (Exception ex)
            {
                // Rethrow the exception.
                throw ex;
            }
        }

        /// <summary>
        /// Method to retrieve a specific weather from the catalog.
        /// Defines the implementation of the ID-specific GET method.
        /// </summary>
        public weatherDetails Readweather(String id)
        {
            try
            {
                // Retrieve a specific weather from the catalog.
                return (
                    // Query the catalog of weathers.
                    from weather in xmlDocument.Elements("catalog").Elements("weather")
                        // Specify the specific weather ID to query.
                    where weather.Attribute("id").Value.Equals(id)
                    // Create a new instance of the detailed weather information class.
                    select new weatherDetails
                    {
                        // Populate the class with data from each of the weather's elements.
                        Id = weather.Attribute("id").Value,
                        Author = weather.Element("author").Value,
                        Title = weather.Element("title").Value,
                        Genre = weather.Element("genre").Value,
                        Price = Convert.ToDecimal(weather.Element("price").Value),
                        PublishDate = Convert.ToDateTime(weather.Element("publish_date").Value),
                        Description = weather.Element("description").Value
                    }).Single();
            }
            catch
            {
                // Return null to signify failure.
                return null;
            }
        }

        /// <summary>
        /// Populates a weather weatherDetails class with the data for a weather.
        /// </summary>
        private XElement[] FormatweatherData(weatherDetails weather)
        {
            XElement[] weatherInfo =
            {
                new XElement("author", weather.Author),
                new XElement("title", weather.Title),
                new XElement("genre", weather.Genre),
                new XElement("price", weather.Price.ToString()),
                new XElement("publish_date", weather.PublishDate.ToString()),
                new XElement("description", weather.Description)
            };
            return weatherInfo;
        }

    }
}