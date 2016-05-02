// client for IRLWeather RESTful web service
// in-memory data on service
// 2 lookups : 1. Get all weathers 2. Get specified city 

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IRLWeather.Models
{
    class Program
    {
        static async Task GetsAsync()   // async methods return Task or Task<T>
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://irlweather2016.azurewebsites.net/");                             // base URL for API Controller i.e. RESTFul service

                    // Add an Accept header for JSON
                    client.DefaultRequestHeaders.
                        Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));         // or application/xml

                    // GET /Weathers/all
                    // get all weathers
                    HttpResponseMessage response = await client.GetAsync("/Weathers/all");          // async call, await suspends until task finished 
                    if (response.IsSuccessStatusCode)                                                         // 200.299
                    {
                        // read result 
                        var weathers = await response.Content.ReadAsAsync<IEnumerable<Weather>>();
                        foreach (var weather in weathers)
                        {
                            Console.WriteLine(weather);
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }

                    // Get weathers for a specified city to be returned (having same specified routing key)
                    // GET: /Weathers/city/Belfast
                    // GET: /Weathers/city/Cork
                    // GET: /Weathers/city/Donnegal
                    // GET: /Weathers/city/Dublin
                    // GET: /Weathers/city/Galway
                    // GET: /Weathers/city/Limerick
                    // GET: /Weathers/city/Waterford
                    response = await client.GetAsync("/Weathers/city/Dublin");
                    if (response.IsSuccessStatusCode)                                                         // 200.299
                    {
                        // read result 
                        var weathers = await response.Content.ReadAsAsync<IEnumerable<Weather>>();
                        foreach (var weather in weathers)
                        {
                            Console.WriteLine(weather);
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        // kick off
        static void Main(string[] args)
        {
            GetsAsync().Wait();
            Console.ReadLine();
        }
    }
}
