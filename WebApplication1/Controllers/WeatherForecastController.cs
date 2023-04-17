using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("[action]")]
        //[HttpGet("{id:int}")]
        //? num1 = 30159 & num2 = 2022
        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("{id:int}")]
        public WeatherForecast GetWeatherForecast(int id)
        {
            return new WeatherForecast
            {
                Date = DateTime.Now.AddDays(id),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };
        }

        [HttpGet("[action]")]
        public int SumNumbers(int num1, int num2)
        {
            return num1 + num2;
        }

        [HttpGet("[action]")]

        public string GetSymbols(string text)
        {
            return text.ToUpper();
        }

        [HttpGet("[action]")]

        public string FindSymbols(string text)
        {
            string alfavit = "abcdefghijklmnopqrstuvwxyz";
            string result = "";
            foreach(char a in alfavit)
            {
                if(!text.Contains(a))
                {
                    result += a;
                }
            }
            return result;
        }

        [HttpGet("[action]")]
        public string FindLostSymbols(string text)
        {
            string alfavit = "abcdefghijklmnopqrstuvwxyz";
            char[] chars = text.ToCharArray();
            int firstIndex = alfavit.IndexOf(chars[0]);
            int lastIndex = alfavit.LastIndexOf(chars[chars.Length-1]);
            string partOfRow = "";
            for(int i =firstIndex;i<lastIndex;i++)
            {
                if (!text.Contains(alfavit[i]))
                {
                    partOfRow+= alfavit[i];
                }
            }           
            return partOfRow;
        }
    }
}