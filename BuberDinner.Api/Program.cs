using BuberDinner.Application;
using BuberDinner.Infra;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication();
    builder.Services.AddInfra(builder.Configuration);
    builder.Services.AddControllers();
}


var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
}

app.Run();
