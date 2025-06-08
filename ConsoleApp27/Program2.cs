// See https://aka.ms/new-console-template for more information

using ConsoleApp27;

var conditions = new[]
{
    new
    {
        ClusterCount = 2,
        FilePath = "E:\\Work\\__temp\\School-Task\\ConsoleApp1\\ConsoleApp27\\demo_2025_27_А\\demo_2025_27_А.txt"
    },
    new
    {
        ClusterCount = 3,
        FilePath = "E:\\Work\\__temp\\School-Task\\EGE-Tasks\\ConsoleApp27\\demo_2025_27_Б\\demo_2025_27_Б.txt"
    },
};

var current = conditions[1];

double h = 3, w = 3;
int clusterCount = current.ClusterCount;

var points = File.ReadAllLines(current.FilePath)
    .Skip(1)
    .Select(x => new Point(x.Split().Select(double.Parse).ToArray()))
    .ToArray();
Console.WriteLine($"All points: {points.Length} ");

var centroids = new Dictionary<Point, double>();
for (int i = 0; i < clusterCount; i++)
{
    var xMin = points.Select(x => x.X).Min();
    var yMin = points.Where(x => x.X < xMin + w).Select(x => x.Y).Min();
    Console.WriteLine($"XMin: {xMin}, YMin: {yMin}");

    var cluster = new Cluster(new Point(xMin, yMin), w, h);
    Console.WriteLine($"Cluster: {cluster}");

    var pointsInCluster = points.Where(x => cluster.Contains(x)).ToArray();
    Console.WriteLine($"Points: {pointsInCluster.Length}");

    var c = GetCentroid(pointsInCluster);
    centroids[c.Point] = c.Distance;
    Console.WriteLine($"Centroid: {c}");

    points = points.Where(x => !cluster.Contains(x)).ToArray();
    Console.WriteLine($"{points.Length} points left");
}

if (points.Length != 0) throw new InvalidOperationException("some points were not found");

var averageX = centroids.Keys.Average(x => x.X);
var averageY = centroids.Keys.Average(x => x.Y);

Console.WriteLine($"Result: {(uint)(averageX * 10_000)}, {(uint)(averageY * 10_000)}");

// end
return;

(Point Point, double Distance) GetCentroid(Point[] sequence)
{
    var pointsWithDistance = sequence.Select(x => new { X = x, D = sequence.Where(a => a != x).Select(x.DistanceTo).Sum() }).ToArray();
    var minDistance = pointsWithDistance.Min(x => x.D);
    var centroid = pointsWithDistance.First(x => Math.Abs(x.D - minDistance) < 0.001);
    return new ValueTuple<Point, double>(centroid.X, centroid.D);
}