// IRLWeather model class - Weather information for a city comprises the following:

using System.ComponentModel.DataAnnotations;

namespace IRLWeather.Models
{
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
            public string todaysCondition { get; set; }

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
            public string WindDirection { get; set; }

            //Wind Speed
            [Display(Name = "Wind Speed")]
            [Range(0, 200, ErrorMessage = "Wind speed ranges from 0 to 200 km/h")]
            public int WindSpeed { get; set; }

            //Tomorrow's weather
            [Display(Name = "Tomorrow's weather")]
            public string tomorrowsCondition { get; set; }

    }
}