namespace AdventOfCode2023;

internal record NumberArea(int Value, int Left = 0, int Right = 0, int Top = 0, int Bottom = 0)
{
    internal bool IsCoveringCell(Cell cell)
    {
        var isCellBetweenLeftAndRight = Left <= cell.X && cell.X <= Right;
        var isCellBetweenTopAndBottom = Top <= cell.Y && cell.Y <= Bottom;

        return isCellBetweenLeftAndRight && isCellBetweenTopAndBottom;
    }
};