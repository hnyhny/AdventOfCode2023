using FluentAssertions;

namespace AdventOfCode2023.Day02;

public class PuzzleSolutionTest
{
    [Theory]
    [InlineData(@"Day02\sample.part01.txt", 8)]
    [InlineData(@"Day02\puzzle.txt", 2406)]
    public void TestPart01(string filepath, int expected)
    {
        var input = File.ReadAllLines(filepath);
        Day02.SumPossibleGameIds(input).Should().Be(expected);
    }

    [Theory]
    [InlineData(@"Day02\sample.part02.txt", 2286)]
    [InlineData(@"Day02\puzzle.txt", 78375)]

    public void TestPart02PuzzleData(string filepath, int expected)
    {
        var input = File.ReadAllLines(filepath);
        Day02.SumGamePowers(input).Should().Be(expected);
    }
}
