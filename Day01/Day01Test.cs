using FluentAssertions;
namespace AdventOfCode2023.Day01;
public class Day01Test
{
    [Theory]
    [InlineData("two1nine", 29)]
    [InlineData("eightwothree", 83)]
    [InlineData("abcone2threexyz", 13)]
    [InlineData("xtwone3four", 24)]
    [InlineData("4nineeightseven2", 42)]
    [InlineData("zoneight234", 14)]
    [InlineData("7pqrstsixteen", 76)]
    [InlineData("eighthree", 83)]
    public void GetCalibrationValuesWithStrings(string input, int expected)
    {
        Day01.ParseStringCalibrationValue(input).Should().Be(expected);
    }
}
