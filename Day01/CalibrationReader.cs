using FluentAssertions;
namespace AdventOfCode2023.Day01;

public class CalibrationReader
{
    public static int SumCalibrationValues(string[] inputs)
    {
        return inputs.Select(ParseCalibrationValue).Sum();
    }

    internal static int SumStringCalibrationValues(string[] lines)
    {
        return lines.Select(ParseStringCalibrationValues).Sum();
    }

    public static int ParseStringCalibrationValues(string input)
    {
        string normalizedInput = ReplaceStringNumbers(input);
        return ParseCalibrationValue(normalizedInput);
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

    private static string ReplaceStringNumbers(string input)
    {
        return input switch
        {
            _ when input.Length == 0 => string.Empty,
            _ when input.Length == 1 => input,
            _ when input.StartsWith("one") => "1" + ReplaceStringNumbers(input[1..]),
            _ when input.StartsWith("two") => "2" + ReplaceStringNumbers(input[1..]),
            _ when input.StartsWith("three") => "3" + ReplaceStringNumbers(input[1..]),
            _ when input.StartsWith("four") => "4" + ReplaceStringNumbers(input[1..]),
            _ when input.StartsWith("five") => "5" + ReplaceStringNumbers(input[1..]),
            _ when input.StartsWith("six") => "6" + ReplaceStringNumbers(input[1..]),
            _ when input.StartsWith("seven") => "7" + ReplaceStringNumbers(input[1..]),
            _ when input.StartsWith("eight") => "8" + ReplaceStringNumbers(input[1..]),
            _ when input.StartsWith("nine") => "9" + ReplaceStringNumbers(input[1..]),
            _ => input[0] + ReplaceStringNumbers(input[1..])
        };
    }

}