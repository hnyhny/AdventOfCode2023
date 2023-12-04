using FluentAssertions;
namespace AdventOfCode2023.Day01;

public class Day01
{
    public static int ParseStringCalibrationValue(string input)
    {
        string normalizedInput = ReplaceStringNumbers(input);
        return ParseCalibrationValue(normalizedInput);
    }

    public static int ParseCalibrationValue(string input)
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

        string numberString = input switch
        {
            _ when input.StartsWith("one") => "1",
            _ when input.StartsWith("two") => "2",
            _ when input.StartsWith("three") => "3",
            _ when input.StartsWith("four") => "4",
            _ when input.StartsWith("five") => "5",
            _ when input.StartsWith("six") => "6",
            _ when input.StartsWith("seven") => "7",
            _ when input.StartsWith("eight") => "8",
            _ when input.StartsWith("nine") => "9",
            _ => input[0].ToString()
        };

        return numberString + ReplaceStringNumbers(input[1..]);
    }

}