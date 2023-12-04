namespace AdventOfCode2023.Day04;

public class Card
{
    public int Value { get; init; }
    public Card(int[] WinningNumbers, int[] PlayerNumbers)
    {
        var numberOfPlayerWins = WinningNumbers.Intersect(PlayerNumbers).Count();
        Value = numberOfPlayerWins switch
        {
            0 => 0,
            _ => Math.PowerOfTwo(numberOfPlayerWins - 1),
        };
    }
}