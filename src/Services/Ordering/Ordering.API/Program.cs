using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices().AddInfrastructureServices(builder.Configuration).AddApiServices();




//_---------------------------------------------
var app = builder.Build();
//_---------------------------------------------




// Configure the HTTP request pipeline.


app.Run();
