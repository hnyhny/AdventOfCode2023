namespace AdventOfCode2023.Day04;

public class CardParserTest
{
    [Theory]
    [InlineData(@"Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 1, 4, 8)]
    [InlineData(@"Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 2, 2, 2)]
    [InlineData(@"Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", 3, 2, 2)]
    [InlineData(@"Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", 4, 1, 1)]
    [InlineData(@"Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", 5, 0, 0)]
    [InlineData(@"Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", 6, 0, 0)]
    public void TestParseCard(string input, int id, int matchingNumbers, int expectedValue)
    {
        var card = CardParser.ParseCard(input);

        card.Id.Should().Be(id);
        card.WinningNumbersCount.Should().Be(matchingNumbers);
        card.Value.Should().Be(expectedValue);

    }
}