namespace ConsoleApp27;

public record Cluster(Point X, double W, double H)
{
    public override string ToString()
    {
        return $"Left {X}, Right {new Point(X.X + W, X.Y + H)}";
    }

    public bool Contains(Point point)
    {
        return point.X >= X.X && point.X <= X.X + W &&
               point.Y >= X.Y && point.Y <= X.Y + H;
    }
}