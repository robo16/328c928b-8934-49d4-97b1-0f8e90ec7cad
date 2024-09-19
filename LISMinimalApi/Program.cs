using LISMinimalApi;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapPost("/calculate-lis", (string input) =>
{
    var parser = new InputParser();
    var finder = new LISFinder();
   
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