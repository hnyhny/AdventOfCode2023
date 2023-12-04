using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day04;

public class Day04
{
    private static readonly Regex Numbers = new(@"(\d+)");

    internal static int Part01(string[] input)
    {
        return input.Select(TrimInput)
            .Select(i => i.Split('|'))
            .Select(ParseCard)
            .Sum(c => c.Value);
    }

    private static string TrimInput(string input)
    {
        /// Input hat die Form Card 11: ....
        /// Uns interessiert alles nach dem Doppelpunkt.
        return input.Substring(input.IndexOf(':') + 1);
    }
    private static Card ParseCard(string[] input)
    {
        return new Card
        (
            WinningNumbers: ToIntArray(input[0]),
            PlayerNumbers: ToIntArray(input[1])
        );
    }
    private static int[] ToIntArray(string input)
    {
        return Numbers.Matches(input)
            .Select(m => Convert.ToInt32(m.Value))
            .ToArray();
    }
}
