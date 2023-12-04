namespace AdventOfCode2023.Day04;

public class PuzzleSolutionTest
{
    [Theory]
    [InlineData(@"Day04\sample.part01.txt", 13)]
    [InlineData(@"Day04\puzzle.txt", 26426)]
    public void TestPart01(string filepath, int expected)
    {
        var input = File.ReadAllLines(filepath);
        Day04.Part01(input).Should().Be(expected);
    }

    [Theory]
    [InlineData(@"Day04\sample.part01.txt", 30)]
    [InlineData(@"Day04\puzzle.txt", 6227972)]
    public void TestPart02(string filepath, int expected)
    {
        var input = File.ReadAllLines(filepath);
        Day04.Part02(input).Should().Be(expected);
    }
}
