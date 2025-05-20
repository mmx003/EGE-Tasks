// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using ConsoleApp27;

double h = 3, w = 3;

var points = File.ReadAllLines("E:\\Work\\__temp\\School-Task\\ConsoleApp1\\ConsoleApp27\\demo_2025_27_А\\demo_2025_27_А.txt")
// var points = File.ReadAllLines("E:\\Work\\__temp\\School-Task\\ConsoleApp1\\ConsoleApp27\\demo_2025_27_Б\\demo_2025_27_Б.txt")
    .Skip(1)
    .Select(x => new Point(x.Split().Select(double.Parse).ToArray()))
    .ToArray();
Console.WriteLine($"All points: {points.Length} ");

var xMin = points.Select(x => x.X).Min();
var xMax = points.Select(x => x.X).Max();

// выравниваем кластера по ширине 
var lX = 2 * w - (xMax - xMin);
var xShift = lX / 2;
if (xShift > 0)
{
    xMin -= xShift;
    xMax += xShift;
}

var yMin = points.Select(x => x.Y).Min();
var yMax = points.Select(x => x.Y).Max();

// выравниваем кластера по высоте
var lY = 2 * h - (yMax - yMin);
var yShift = lY / 2;
if (yShift > 0)
{
    yMin -= yShift;
    yMax += yShift;
}

Console.WriteLine($"XMin: {xMin}, XMax: {xMax}, YMin: {yMin}, YMax: {yMax}");

var cluster1 = new Cluster(new Point(xMin, yMin), h, w);
var cluster2 = new Cluster(new Point(xMax - w, yMax - h), h, w);

Console.WriteLine($"Cluster1: {cluster1}");
Console.WriteLine($"Cluster2: {cluster2}");

var intersected = cluster1.Intersects2D(cluster2);
if (intersected) throw new InvalidOperationException("Intersected cluster");
Console.WriteLine($"Cluster1 is intersected to Cluster2, {intersected}");

var points1 = points.Where(cluster1.Contains).ToArray();
Console.WriteLine($"Cluster1: {points1.Length}");
var points2 = points.Where(cluster2.Contains).ToArray();
Console.WriteLine($"Cluster2: {points2.Length}");

var ct1 = GetCentroid(points1);
var ct2 = GetCentroid(points2);
Console.WriteLine($"Centroid1: {ct1}, Centroid2: {ct2}");

var average1 = new[] { ct1.p.X, ct2.p.X }.Average();
var average2 = new[] { ct1.p.Y, ct2.p.Y }.Average();
Console.WriteLine($"AvgX: {average1}, AvgY: {average2}");
Console.WriteLine($"Result: {(uint)(average1 * 10_000)}, {(uint)(average2 * 10_000)}");

// end
return;

(Point p, double Distance) GetCentroid(Point[] sequence)
{
    var pointsWithDistance = sequence.Select(x => new { X = x, D = sequence.Where(a => a != x).Select(x.DistanceTo).Sum() }).ToArray();
    var minDistance = pointsWithDistance.Min(x => x.D);
    var centroid = pointsWithDistance.First(x => Math.Abs(x.D - minDistance) < 0.001);
    return new ValueTuple<Point, double>(centroid.X, centroid.D);
}