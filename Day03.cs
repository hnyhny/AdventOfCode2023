using FluentAssertions;

namespace AdventOfCode2023;

public class Day03
{

    public static int Part02(string[] input)
    {
        var areas = NumberAreaParser.GetAreas(input);

        return input.SelectMany(CellParser.GetGearCells)
                    .Select(cell => GetGearNumberNeighbours(cell, areas))
                    .Where(n => n.Length == 2)
                    .Sum(n => n[0].Value * n[1].Value);
    }

    public static int Part01(string[] input)
    {
        var allNumbers = NumberAreaParser.GetAreas(input);
        var symbolPositions = input.SelectMany(CellParser.GetSymbolCells).ToArray();
        bool HasSymbolNeighbor(NumberArea na) => symbolPositions.Any(na.IsCoveringCell);

        return allNumbers.Where(HasSymbolNeighbor).Sum(na => na.Value);
    }

    private static NumberArea[] GetGearNumberNeighbours(Cell cell, NumberArea[] numberAreas)
    {
        return numberAreas.Where(na => na.IsCoveringCell(cell)).ToArray();
    }
}
