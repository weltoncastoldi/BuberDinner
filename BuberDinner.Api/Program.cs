using BuberDinner.Api.Filters;
using BuberDinner.Application;
using BuberDinner.Infra;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication();
    builder.Services.AddInfra(builder.Configuration);
    builder.Services.AddControllers(opt => opt.Filters.Add<ErrorHandlingFilterAttribute>());
}


var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseHttpsRedirection();
    app.MapControllers();
}

app.Run();
