using FluentAssertions;

namespace AdventOfCode2023;

public class Day03Test
{
    private readonly string[] input =
        [
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
        ];
    private readonly string[] puzzleInput = File.ReadAllLines(@"inputs\day03.txt");

    public void TestPart01Puzzle()
    {
        Day03.Part01(puzzleInput).Should().Be(539590);
    }

    [Fact]
    public void TestPart01Sample()
    {

        Day03.Part01(input).Should().Be(4361);
    }

    [Fact]
    public void TestPart02Puzzle()
    {
        Day03.Part02(puzzleInput).Should().Be(80703636);
    }

    [Fact]
    public void TestPart02Sample()
    {
        Day03.Part02(input).Should().Be(467835);
    }
}
