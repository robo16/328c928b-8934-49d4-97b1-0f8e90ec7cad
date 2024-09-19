using LISMinimalApi;
    
namespace LongestIncreasingSubsequence.Tests;

public class InputParserTests
{
    private readonly InputParser _inputParser;

    public InputParserTests()
    {
        _inputParser = new InputParser();
    }
    
    [Fact]
    public void Parse_InputWithExtraSpaces_ReturnsListOfInts()
    {
        // Arrange
        string input = " 10   22 9   33";

        // Act
        List<int> result = _inputParser.Parse(input);

        // Assert
        Assert.Equal(new List<int> { 10, 22, 9, 33 }, result);
    }
    
    [Fact]
    public void Parse_EmptyString_ThrowsArgumentException()
    {
        // Arrange
        string input = "";

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => _inputParser.Parse(input));
        Assert.Equal("Input string is null or empty.", exception.Message);
    }
    
    [Fact]
    public void Parse_WhitespaceString_ThrowsArgumentException()
    {
        // Arrange
        string input = "   ";

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => _inputParser.Parse(input));
        Assert.Equal("Input string is null or empty.", exception.Message);
    }

    [Fact]
    public void Parse_InvalidInput_ThrowsFormatException()
    {
        // Arrange
        string input = "10 22 invalid 33";

        // Act & Assert
        Assert.Throws<FormatException>(() => _inputParser.Parse(input));
    }

    [Fact]
    public void Parse_SingleElement_ReturnsSingleElementList()
    {
        // Arrange
        string input = "42";

        // Act
        var result = _inputParser.Parse(input);

        // Assert
        Assert.Equal(new List<int> { 42 }, result);
    }

    [Fact]
    public void Parse_NegativeNumbers_ReturnsListOfInts()
    {
        // Arrange
        string input = "-10 -5 0 5 10";

        // Act
        var result = _inputParser.Parse(input);

        // Assert
        Assert.Equal(new List<int> { -10, -5, 0, 5, 10 }, result);
    }

    [Fact]
    public void Parse_LargeNumbers_ReturnsListOfInts()
    {
        // Arrange
        string input = "100000000 200000000 300000000";

        // Act
        var result = _inputParser.Parse(input);

        // Assert
        Assert.Equal(new List<int> { 100000000, 200000000, 300000000 }, result);
    }

}