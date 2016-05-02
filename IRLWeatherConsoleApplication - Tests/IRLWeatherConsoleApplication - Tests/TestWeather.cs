using System;

namespace IRLWeatherConsoleApplication___Tests
{
    public class Weather
    {
        //fields
            private int id;
            private String city;
            private String todaysCondition;
            private int maxTemp;
            private int minTemp;
            private String windDirection;
            private int windSpeed;
            private String tomorrowsCondition;
        
        //constructor
        public Weather(int id, string city, string todaysCondition, int maxTemp, int minTemp, string windDirection, int windSpeed, string tomorrowsCondition)
        {
                this.id = id;
                this.city = city;
                this.todaysCondition = todaysCondition;
                this.maxTemp = maxTemp;
                this.minTemp = minTemp;
                this.windDirection = windDirection;
                this.windSpeed = windSpeed;
                this.tomorrowsCondition = tomorrowsCondition;
        
        }
        public String City
        {
            get
            {
                return city;
            }
            set
            {
                // validate - filename must be specified
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("city must not be null or white space");
                }
                else
                {
                    city = value;
                }
            }
        }


        public string TodaysCondition
        {
            get
            {
                return todaysCondition;
            }
            set
            {
                // validate - filename must be specified
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("TodaysCondition must not be null or white space");
                }
                else
                {
                    todaysCondition = value;
                }
            }
        }

        public string TomorrowsCondition
        {
            get
            {
                return tomorrowsCondition;
            }
            set
            {
                // validate - filename must be specified
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("TomorrowCondition must not be null or white space");
                }
                else
                {
                    tomorrowsCondition = value;
                }
            }
        }

        public int MaxTemp
        {
            get
            {
                return maxTemp;
            }
            set
            //Validation
            {
                if ((maxTemp > -40) || (maxTemp < 40))
                {
                    this.MaxTemp = maxTemp;
                }
                else
                {
                    throw new ArgumentException("Temperature ranges from -40 to +40 Celcius");
                }
            }
        }

        public int MinTemp
        {
            get
            {
                return minTemp;
            }
            set
            //Validation
            {
                if ((minTemp > -40) || (minTemp < 40))
                {
                    this.MinTemp = minTemp;
                }
                else
                {
                    throw new ArgumentException("Temperature ranges from -40 to +40 Celcius");
                }
            }
        }
        public string WindDirection { get; set; }

        public int WindSpeed
        {
            get
            {
                return windSpeed;
            }
            set
            //Validation
            {
                if ((windSpeed > 0) || (windSpeed < 200))
                {
                    this.WindSpeed = windSpeed;
                }
                else
                {

                    throw new ArgumentException("Wind speed ranges from 0 to 200 km/h");
                }
            }
        }
 

        //Output message depending on the results of validation
        public override string ToString()
        {
                return "\nId : " + id +
                       "\nCity : " + city +
                       "\nTodaysWeather : " + todaysCondition +
                       "\nMaxTemp : " + maxTemp +
                       "\nMinTemp : " + minTemp +
                       "\nWindDirection : " + windDirection +
                       "\nWindSpeed : " + windSpeed +
                       "\nTomorrowsWeather : " + tomorrowsCondition;

        }

        //TEST CLASS
        class TestWeather
        {
            static void Main(string[] args)
            {
                {
                    //Console.Write("Enter Weather Id :");
                    //int id = Int32.Parse(Console.ReadLine());
                    Console.Write("Enter City : ");
                    String city = Console.ReadLine();

                    //Array to store weather
                    Weather[] weathers = {
                    new Weather(1, "Belfast", "Cloudy", 10, 1, "East", 5, "Rain" ),
                    new Weather(2, "Cork", "Drizzle", 13, 2, "North", 8, "Overcast" ),
                    new Weather(3, "Donnegal", "Fog", 7, -1, "Northwest", 9, "Snow" ),
                    new Weather(4, "Dublin", "Snow", 4, 0, "West", 7, "Fog" ),
                    new Weather(5, "Galway", "Rain", 5,  -2, "Southeast", 10, "Drizzle" ),
                    new Weather(6, "Limerick", "Overcast", 11, 3, "Northeast", 5, "Cloudy") };

                    //Iterates across the array to print details
                    foreach (Weather s in weathers)
                    {
                        string t = s.ToString();
                        Console.WriteLine(t);
                    }

                }
            }
        }
    }
}
