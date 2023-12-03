using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
    internal static class NumberAreaParser
    {
        private static readonly Regex NumbersRegex = new(@"(\d+)");

        public static NumberArea[] GetAreas(string[] input)
        {
            NumberArea[] FromRow(NumberArea[] areas, int index) =>
                areas.Select(na => na with
                {
                    Top = Math.Max(0, index - 1),
                    Bottom = Math.Min(index + 1, input.Length - 1)
                })
                .ToArray();

            return input.Select(GetAreas)
                .SelectMany(FromRow)
                .ToArray();
        }
        private static NumberArea[] GetAreas(string input)
        {
            return NumbersRegex.Matches(input).Select(m =>
                 new NumberArea
                    (
                        Value: Convert.ToInt32(m.Value),
                        Left: Math.Max(0, m.Index - 1),
                        Right: Math.Min(m.Index + m.Length, input.Length - 1)
                    )).ToArray();
        }
    }
}