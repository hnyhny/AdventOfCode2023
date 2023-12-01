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
}
