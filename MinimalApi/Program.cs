using MinimalApi.Extensions;

var builder = WebApplication.CreateBuilder ( args );
builder.RegisterServices ();

// Add services to the container.

var app = builder.Build ();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection ();

app.RegisterEndpointDefinitions ();

app.Run ();
