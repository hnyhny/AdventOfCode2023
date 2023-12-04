namespace AdventOfCode2023.Day04;

public class PuzzleSolutionTest
{
    [Theory]
    [InlineData(@"Day04\sample.part01.txt", 13)]
    [InlineData(@"Day04\puzzle.txt", 26426)]

    public void TestPart01(string filepath, int expected)
    {
        var input = File.ReadAllLines(filepath);
        input.Select(CardParser.ParseCard)
             .Sum(c => c.Value)
             .Should().Be(expected);
    }
    [Theory]
    [InlineData(@"Day04\sample.part01.txt", 30)]
    [InlineData(@"Day04\puzzle.txt", 26426)]
    public void TestPart02(string filepath, int expected)
    {
        var input = File.ReadAllLines(filepath);
        var cards = input.Select(CardParser.ParseCard).ToArray();
        var cardAmount = cards.ToDictionary(c => c.Id, _ => 1);
        foreach (var card in cards)
        {
            foreach (var id in card.WinsCards)
            {
                cardAmount[id] += (cardAmount[card.Id]);
            }
        }
        cardAmount.Values.Sum().Should().Be(expected);
    }
}
