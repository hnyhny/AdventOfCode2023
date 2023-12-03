using FluentAssertions;
using System.Text.RegularExpressions;

namespace AdventOfCode2023;

public class Day03Test
{
    [Fact]
    public void TestPart01PuzzleData()
    {
        var input = File.ReadAllLines(@"inputs\day03.txt");
        Day03.Part01(input).Should().Be(539590);
    }
    [Fact]
    public void TestPart01SampleData()
    {
        var input = new[]
        {
        "467..114..",
        "...*......",
        "..35..633.",
        "......#...",
        "617*......",
        ".....+.58.",
        "..592.....",
        "......755.",
        "...$.*....",
        ".664.598..",
        };

        Day03.Part01(input).Should().Be(4361);
    }
}

internal class NumberAreaBuilde
{

}
public class Day03
{
    public static int Part01(string[] input)
    {
        var allNumbers = GetAreas(input);
        var symbolPositions = GetSymbolPositions(input);

        bool HasSymbolNeighbor(NumberArea na) => symbolPositions.Any(na.IsCoveringCell);

        return allNumbers.Where(HasSymbolNeighbor).Sum(na => na.Value);
    }

    private static Cell[] GetSymbolPositions(string[] input)
    {
        return input.SelectMany(GetSymbolIndexes).ToArray();
    }

    private static bool IsSymbol(char c) => Regex.IsMatch(c.ToString(), @"[^\d.]");

    private static IEnumerable<Cell> GetSymbolIndexes(string row, int rowIndex)
    {
        return row.Select((c, i) => (c, i))
                .Where(t => IsSymbol(t.c))
                .Select(t => t.i)
                .Select(columnNumber => new Cell(columnNumber, rowIndex)); ;
    }
    private static IEnumerable<NumberArea> GetAreas(string[] input)
    {
        return input.SelectMany((s, i) => GetArea(s, i, input.Length));

    }
    private static IEnumerable<NumberArea> GetArea(string input, int rowIndex, int maxRows)
    {
        var maxColumns = input.Length;
        return Regex.Matches(input, @"(\d+)")
            .Select(m => new NumberArea
                (
                    Value: Convert.ToInt32(m.Value),
                    Left: Math.Max(0, m.Index - 1),
                    Right: Math.Min(m.Index + m.Length, maxColumns - 1),
                    Top: Math.Max(0, rowIndex - 1),
                    Bottom: Math.Min(rowIndex + 1, maxRows - 1)
                )).ToArray();
    }
}

internal record Cell(int X, int Y);

internal record NumberArea(int Value, int Left, int Right, int Top, int Bottom)
{
    internal bool IsCoveringCell(Cell cell)
    {
        var isCellBetweenLeftAndRight = Left <= cell.X && cell.X <= Right;
        var isCellBetweenTopAndBottom = Top <= cell.Y && cell.Y <= Bottom;

        return isCellBetweenLeftAndRight && isCellBetweenTopAndBottom;
    }
};