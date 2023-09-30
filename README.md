# Gleeman Effective Logger File and/or Console


# How To Use?

### Logging to Console or File
#### Install packages
`dotnet` CLI
```
> dotnet add package Gleeman.EffectiveLogger.ConsoleFile --version 2.0.0
```
#### Program.cs
```charp
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
```charp
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
![Console](https://github.com/oznakdn/EffectiveLoggerConsoleFile/assets/79724084/838b53d0-8ac0-4a78-9db8-6e78414943a8)
### File
![File](https://github.com/oznakdn/EffectiveLoggerConsoleFile/assets/79724084/f1096c94-cc4e-4bd5-ba31-b5acf46d2f81)


