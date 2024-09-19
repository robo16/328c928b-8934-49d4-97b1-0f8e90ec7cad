using LISMinimalApi;

var builder = WebApplication.CreateBuilder(args);

// Register services for DI
builder.Services.AddSingleton<InputParser>();
builder.Services.AddSingleton<LISFinder>();

var app = builder.Build();


app.MapPost("/calculate-lis", (string input, InputParser parser, LISFinder finder) =>
{
    try
    {
        var sequence = parser.Parse(input);
        var lis = string.Join(" ", finder.FindLongestIncreasingSubsequence(sequence));
        return Results.Ok(lis);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.Run();