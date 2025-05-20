namespace ConsoleApp27;

public record Point
{
    public double X { get; init; }
    public double Y { get; init; }

    public Point(params double[] c)
    {
        if (c.Length != 2)
            throw new ArgumentException();

        X = c.First();
        Y = c.Last();
    }

    public double DistanceTo(Point other)
    {
        var dx = X - other.X;
        var dy = Y - other.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
}