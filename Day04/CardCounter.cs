namespace AdventOfCode2023.Day04;

public class CardCounter
{
    private readonly IDictionary<int, int> AmountById = new Dictionary<int, int>();
    public CardCounter(IEnumerable<Card> cards)
    {
        AmountById = cards.ToDictionary(c => c.Id, _ => 1);
    }
    public int GetCount()
    {
        return AmountById.Values.Sum();
    }
    public CardCounter AddWinnersFor(Card card)
    {
        foreach (var winner in card.WinsCards)
        {
            AmountById[winner] += AmountById[card.Id];
        }
        return this;
    }
}
