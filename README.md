# Gleeman Effective Logger File and/or Console



## Logging to Console or File

#### Install packages
`dotnet` CLI
```
$ dotnet add package Gleeman.EffectiveLogger.ConsoleFile --version 2.0.0
```
#### Program.cs
```csharp
using Gleeman.EffectiveLogger.ConsoleFile.Configurations;
```
```csharp
builder.Services.AddEffectiveLogger(settings =>
{
    settings.WriteToFile = true;
    settings.WriteToConsole = true;
    settings.FilePath = "File path is here";
    settings.FileName = "File name is here";
});
```
#### OR

appsettings.json
```csharp
"LogSettings": {
  "WriteToConsole": true, // true or false
  "WriteToFile": true, // // true or false
  "FilePath": "File path is here",
  "FileName": "File name is here"
}
```
#### Program.cs
```csharp
using Gleeman.EffectiveLogger.ConsoleFile.Configurations;
```
```csharp
builder.Services.AddEffectiveLogger(builder.Configuration);
```
<hr>


### Controller
```csharp
 [ApiController]
 [Route("[controller]")]
 public class WeatherForecastController : ControllerBase
 {
     private static readonly string[] Summaries = new[]
     {
     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
 };

     private readonly IEffectiveLogger<WeatherForecastController> _logger;

     public WeatherForecastController(IEffectiveLogger<WeatherForecastController> logger)
     {
         _logger = logger;
     }

     [HttpGet(Name = "GetWeatherForecast")]
     public IEnumerable<WeatherForecast> Get()
     {

         _logger.Info($"{Request.Path} - {Request.Method} - Status: {Response.StatusCode}");

         return Enumerable.Range(1, 5).Select(index => new WeatherForecast
         {
             Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
             TemperatureC = Random.Shared.Next(-20, 55),
             Summary = Summaries[Random.Shared.Next(Summaries.Length)]
         })
         .ToArray();
     }
 }
```
### Console
![Console](https://github.com/oznakdn/EffectiveLoggerConsoleFile/assets/79724084/2ce6fad2-3b13-4f08-85fa-6f47f8f8a11b)
### File
![File](https://github.com/oznakdn/EffectiveLoggerConsoleFile/assets/79724084/c721a865-a899-487c-adf0-310d9e300dbc)



