using FluentAssertions;
namespace AdventOfCode2023.Day01;

public class CalibrationReaderTest
{
    [Fact]
    public void SumPart01SampleDataShouldReturn142()
    {
        var lines = new[] {
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet"
        };

        CalibrationReader.SumCalibrationValues(lines).Should().Be(142);
    }

    [Fact]
    public void SumPart01PuzzleInputShouldReturn55971()
    {
        var input = File.ReadAllLines(@"inputs\day01.txt");
        CalibrationReader.SumCalibrationValues(input).Should().Be(55971);
    }

    [Fact]
    public void SumPart02SampleDatatShouldReturn()
    {
        var lines = new[]
        {
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen"
        };
        CalibrationReader.SumStringCalibrationValues(lines).Should().Be(281);
    }
    [Fact]
    public void SumPart02PuzzleInputShouldReturn55971()
    {
        var input = File.ReadAllLines(@"inputs\day01.txt");
        CalibrationReader.SumStringCalibrationValues(input).Should().Be(54663);

    }
    [Theory]
    [InlineData("two1nine", 29)]
    [InlineData("eightwothree", 83)]
    [InlineData("abcone2threexyz", 13)]
    [InlineData("xtwone3four", 24)]
    [InlineData("4nineeightseven2", 42)]
    [InlineData("zoneight234", 14)]
    [InlineData("7pqrstsixteen", 76)]
    [InlineData("eighthree", 83)]
    [InlineData("sevennine", 79)]

    public void GetCalibrationValuesWithStrings(string input, int expected)
    {
        CalibrationReader.ParseStringCalibrationValues(input).Should().Be(expected);
    }
}
