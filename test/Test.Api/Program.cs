using Gleeman.EffectiveLogger.ConsoleFile.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddConsoleFileLog(settings =>
{
    settings.WriteToFile = true;
    settings.WriteToConsole = true;
    settings.FilePath = "File path is here";
    settings.FileName = "File name is here";
});

//builder.Services.AddEffectiveLogger(builder.Configuration);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
