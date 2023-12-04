namespace AdventOfCode2023.Day02;

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
