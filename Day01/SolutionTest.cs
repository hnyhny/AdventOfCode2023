using FluentAssertions;
namespace AdventOfCode2023.Day01;

public class SolutionTest
{
    [Theory]
    [InlineData(@"Day01\sample.part01.txt", 142)]
    [InlineData(@"Day01\puzzle.txt", 55971)]
    public void TestPart01(string filepath, int expected)
    {
        var input = File.ReadAllLines(filepath);
        input.Sum(Day01.ParseCalibrationValue).Should().Be(expected);
    }

    [Theory]
    [InlineData(@"Day01\sample.part02.txt", 281)]
    [InlineData(@"Day01\puzzle.txt", 54719)]
    public void TestPart02(string filepath, int expected)
    {
        var input = File.ReadAllLines(filepath);
        input.Sum(Day01.ParseStringCalibrationValue).Should().Be(expected);
    }
}
