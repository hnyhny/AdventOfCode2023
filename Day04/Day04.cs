namespace AdventOfCode2023.Day04;

public class Day04
{
    public static int Part01(string[] input)
    {
        return input.Select(CardParser.ParseCard)
                    .Sum(c => c.Value);
    }
    public static int Part02(string[] input)
    {
        var cards = input.Select(CardParser.ParseCard).ToArray();
        var cardCounter = cards.Aggregate(new CardCounter(cards), (counter, card) => counter.AddWinnersFor(card));
        return cardCounter.GetCount();
    }
}
