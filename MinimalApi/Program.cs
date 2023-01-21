using MinimalApi.Extensions;

var builder = WebApplication.CreateBuilder ( args );
builder.RegisterServices ();

// Add services to the container.

var app = builder.Build ();

// Configure the HTTP request pipeline.

// Global exception handler
app.Use ( async ( ctx, next ) =>
{
  try
  {
    await next ();
  }
  catch ( Exception )
  {
    ctx.Response.StatusCode = 500;
    await ctx.Response.WriteAsync ( "Server error occured" );
  }
} );

app.UseHttpsRedirection ();

app.RegisterEndpointDefinitions ();

app.Run ();
