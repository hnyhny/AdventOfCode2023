using FluentAssertions;
using System.Text.RegularExpressions;

namespace AdventOfCode2023;
public class Day02Test
{
    [Fact]
    public void TestPart01PuzzleData()
    {
        var input = File.ReadAllLines(@"inputs\day02.txt");
        Day02.SumPossibleGameIds(input).Should().Be(2406);
    }

    [Fact]
    public void TestPart01SampleData()
    {
        var input = new[] {
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
        };

        Day02.SumPossibleGameIds(input).Should().Be(8);
    }
    [Fact]
    public void TestPart02PuzzleData()
    {
        var input = File.ReadAllLines(@"inputs\day02.txt");
        Day02.SumGamePowers(input).Should().Be(78375);
    }
    [Fact]
    public void TestPart02SampleData()
    {
        var input = new[] {
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
        };

        Day02.SumGamePowers(input).Should().Be(2286);
    }
}
internal class Day02
{
    internal static int SumPossibleGameIds(string[] input)
    {
        var games = input.Select(ParseGame)
            .Where(IsValidGame).ToArray();
        return games.Sum(g => g.Id);
    }

    internal static int SumGamePowers(string[] input)
    {
        var games = input.Select(ParseGame)
            .Sum(g => g.Red * g.Blue * g.Green);
        return games;
    }

    internal static bool IsValidGame(Game game)
    {
        return game switch
        {
            _ when game.Red > 12 => false,
            _ when game.Green > 13 => false,
            _ when game.Blue > 14 => false,
            _ => true
        };
    }
    internal static Game ParseGame(string input)
    {
        var gameSplitted = input.Replace(';', ',')
                                .Split(':');

        var numberString = Regex.Match(gameSplitted[0], @"\d+").Value;
        var gameId = Convert.ToInt32(numberString);

        var ballcount = gameSplitted[1]
            .Split(",")
            .Select(ParseSingleColor)
            .Aggregate(Ballcount.FindMaxValues);

        return new Game(gameId, ballcount);
    }

    internal static Ballcount ParseSingleColor(string input)
    {
        var numberString = Regex.Match(input, @"\d+").Value;
        var number = Convert.ToInt32(numberString);
        return input switch
        {
            _ when input.Contains("red") => new Ballcount(Red: number),
            _ when input.Contains("green") => new Ballcount(Green: number),
            _ when input.Contains("blue") => new Ballcount(Blue: number),
            _ => throw new NotImplementedException()
        };
    }
}
internal record Game(int Id, int Red, int Green, int Blue)
{
    public Game(int id, Ballcount ballcount) : this(id, ballcount.Red, ballcount.Green, ballcount.Blue)
    {
    }
}
internal record Ballcount(int Red = 0, int Green = 0, int Blue = 0)
{
    public static Ballcount FindMaxValues(Ballcount left, Ballcount right)
    {
        return new Ballcount
        (
            Red: Math.Max(left.Red, right.Red),
            Green: Math.Max(left.Green, right.Green),
            Blue: Math.Max(left.Blue, right.Blue)
        );
    }
    public static Ballcount FindMinValues(Ballcount left, Ballcount right)
    {
        return new Ballcount
        (
            Red: Math.Min(left.Red, right.Red),
            Green: Math.Min(left.Green, right.Green),
            Blue: Math.Min(left.Blue, right.Blue)
        );
    }
}
