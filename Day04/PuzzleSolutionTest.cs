namespace AdventOfCode2023.Day04;

public class PuzzleSolutionTest
{
    [Theory]
    [InlineData(@"Day04\sample.part01.txt", 13)]
    [InlineData(@"Day04\puzzle.txt", 26426)]

    public void TestPart01(string filepath, int expected)
    {
        var input = File.ReadAllLines(filepath);
        Day04.Part01(input).Should().Be(expected);
    }
}
public class CardTest
{
    public static IEnumerable<object[]> CardTestData = new[]
    {
       new object[] { new[] { 1, 2, 3 }, new[] { 1 }, 1 },
       new object[] { new[] { 1, 2, 3 }, new[] { 1, 2 }, 2 },
       new object[] { new[] { 1, 2, 3 }, new[] { 1, 2, 3}, 4 },

    };
    [Theory]
    [MemberData(nameof(CardTestData))]
    public void Foo(int[] winnerNumbers, int[] playerNumbers, int expected)
    {
        var card = new Card(winnerNumbers, playerNumbers);
        card.Value.Should().Be(expected);
    }
}