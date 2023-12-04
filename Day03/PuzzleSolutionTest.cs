using FluentAssertions;

namespace AdventOfCode2023.Day03;

public class PuzzleSolutionTest
{
    [Theory]
    [InlineData(@"Day03\sample.part01.txt", 4361)]
    [InlineData(@"Day03\puzzle.txt", 539590)]
    public void TestPart01(string filepath, int expected)
    {
        var input = File.ReadAllLines(filepath);
        Day03.Part01(input).Should().Be(expected);
    }
    [Theory]
    [InlineData(@"Day03\sample.part01.txt", 467835)]
    [InlineData(@"Day03\puzzle.txt", 80703636)]
    public void TestPart02(string filepath, int expected)
    {
        var input = File.ReadAllLines(filepath);
        Day03.Part02(input).Should().Be(expected);
    }
}
