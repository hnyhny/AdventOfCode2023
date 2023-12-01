using FluentAssertions;
namespace AdventOfCode2023.Day01;

public class CalibrationReader
{
    public static int SumCalibrationValues(string[] inputs)
    {
        return inputs.Select(ParseCalibrationValue).Sum();
    }

    private static int ParseCalibrationValue(string input)
    {
        /// The ascii number values of the characters 0 - 9 are 48 - 57
        /// https://simple.m.wikipedia.org/wiki/File:ASCII-Table-wide.svg    
        Func<char, bool> IsCharNumber = c => 48 <= c && c <= 57;
        Func<char, int> RemoveAsciiOffset = c => c - 48;

        var numbersInLine = input.Where(IsCharNumber).Select(RemoveAsciiOffset).ToArray();
        return numbersInLine.First() * 10 + numbersInLine.Last();
    }
}