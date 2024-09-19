using LISMinimalApi;

var builder = WebApplication.CreateBuilder(args);

// Register services for DI
builder.Services.AddSingleton<InputParser>();
builder.Services.AddSingleton<LISFinder>();

// Add logging services
builder.Services.AddLogging();

// Add services for Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable middleware for Swagger UI and OpenAPI documentation
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "LIS API V1");
        c.RoutePrefix = string.Empty;  // Set Swagger UI at the app's root
    });
}

// Global exception handling middleware
app.Use(async (context, next) =>
{
    try
    {
        await next.Invoke();
    }
    catch (Exception ex)
    {
        // Log the exception
        var logger = context.RequestServices.GetService<ILogger<LISFinder>>();
        logger?.LogError(ex, "An error occurred while processing the request");

        // Create a custom error response
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(new
        {
            error = "An unexpected error occurred.",
            details = ex.Message // Optionally include the exception message
        });
    }
});

app.MapPost("/calculate-lis", (string input, InputParser parser, LISFinder finder, ILogger<LISFinder> logger) =>
{
    logger.LogInformation("Received input: {Input}", input);
    try
    {
        var sequence = parser.Parse(input);
        logger.LogInformation("Parsed sequence: {Sequence}", string.Join(", ", sequence));
        
        var lis = string.Join(" ", finder.FindLongestIncreasingSubsequence(sequence));
        logger.LogInformation("Calculated LIS: {LIS}", string.Join(", ", lis));
        
        return Results.Ok(lis);
    }
    catch (ArgumentException ex)
    {
        logger.LogError(ex, "Error occurred while processing input");
        return Results.BadRequest(new { error = ex.Message });
    }
});

app.Run();