using FluentAssertions;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day03
{
    internal static class CellParser
    {

        private static readonly Regex SymbolsRegex = new(@"[^\d.]");
        private static readonly Regex GearsRegex = new(@"\*");
        public static Cell[] GetGearCells(string input, int rowIndex)
        {
            return input.Select((character, columnIndex) => CreateCell(character, columnIndex, rowIndex))
                    .Where(cell => GearsRegex.IsMatch(cell.Character))
                    .ToArray();
        }
        public static Cell[] GetSymbolCells(string input, int rowIndex)
        {
            return input.Select((character, columnIndex) => CreateCell(character, columnIndex, rowIndex))
                     .Where(cell => SymbolsRegex.IsMatch(cell.Character))
                     .ToArray();
        }
        private static Cell CreateCell(char c, int index, int rowIndex)
        {
            return new(index, rowIndex, c.ToString());
        }
    }
}