namespace AdventOfCode2023.Day04;

public record Card
{
    public int Id { get; init; }
    public int[] WinsCards => Enumerable.Range(Id + 1, WinningNumbersCount).ToArray();
    public int WinningNumbersCount { get; init; }
    public int Value { get; init; }
    public Card(int id, int[] winningNumbers, int[] playerNumbers)
    {
        Id = id;
        WinningNumbersCount = winningNumbers.Intersect(playerNumbers).Count();
        Value = WinningNumbersCount switch
        {
            0 => 0,
            _ => Math.PowerOfTwo(WinningNumbersCount - 1),
        };
    }
}