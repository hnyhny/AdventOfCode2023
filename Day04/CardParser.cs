using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day04;

internal static class CardParser
{
    private static readonly Regex Numbers = new(@"(\d+)");
    internal static Card ParseCard(string ini)
    {
        /// String Format: CARD XX: 12 12 12 ... | 12 14 53 ...
        /// Uns interessieren nur die Zahlen
        /// Alles vor der Pipe sind die WinningNumbers, alles danach PlayerNumbers

        var matches = Regex.Match(ini, @"(\d+):(.*)\| (.*)").Groups;
        var id = Convert.ToInt32(matches[1].Value);
        var winningNumbers = ToIntArray(matches[2].Value);
        var playerNumbers = ToIntArray(matches[3].Value);

        return new Card(
            id: id,
            winningNumbers: winningNumbers,
            playerNumbers: playerNumbers);
    }

    private static int[] ToIntArray(string input)
    {
        return Numbers.Matches(input)
            .Select(m => Convert.ToInt32(m.Value))
            .ToArray();
    }
}