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
        if (input.Length == 0) return string.Empty;
        if (input.Length == 1) return input;

        if (input.StartsWith("one"))
        {
            return "1" + ReplaceStringNumbers(input[1..]);
        }
        if (input.StartsWith("two"))
        {
            return "2" + ReplaceStringNumbers(input[1..]);
        }
        if (input.StartsWith("three"))
        {
            return "3" + ReplaceStringNumbers(input[1..]);
        }
        if (input.StartsWith("four"))
        {
            return "4" + ReplaceStringNumbers(input[1..]);
        }
        if (input.StartsWith("five"))
        {
            return "5" + ReplaceStringNumbers(input[1..]);
        }
        if (input.StartsWith("six"))
        {
            return "6" + ReplaceStringNumbers(input[1..]);
        }
        if (input.StartsWith("seven"))
        {
            return "7" + ReplaceStringNumbers(input[1..]);
        }
        if (input.StartsWith("eight"))
        {
            return "8" + ReplaceStringNumbers(input[1..]);
        }
        if (input.StartsWith("nine"))
        {
            return "9" + ReplaceStringNumbers(input[1..]);
        }

        return input[0] + ReplaceStringNumbers(input[1..]);
    }

}