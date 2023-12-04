using FluentAssertions;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day02;
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
