namespace AdventOfCode2023.Day02;

internal record Game(int Id, int Red, int Green, int Blue)
{
    public Game(int id, Ballcount ballcount) : this(id, ballcount.Red, ballcount.Green, ballcount.Blue)
    {
    }
}
