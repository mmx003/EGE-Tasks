// See https://aka.ms/new-console-template for more information

var conditions = new[]
{
    new
    {
        FilePath = "E:\\Work\\__temp\\School-Task\\ConsoleApp1\\ConsoleApp27_2\\27-A_demo.txt"
    },
    new
    {
        FilePath = "E:\\Work\\__temp\\School-Task\\ConsoleApp1\\ConsoleApp27_2\\27-B_demo.txt"
    },
};

foreach (var c in conditions)
{
    var lines = File.ReadAllLines(c.FilePath);
    Console.WriteLine($"Found lines {lines.First()}");

    lines = lines.Select(x => x.Replace("  ", " ")).ToArray();

    var max = lines
        .Skip(1)
        .Sum(line => line.Split().Select(int.Parse).Max());

    Console.WriteLine($"Max: {max}");

    var subs = lines
        .Skip(1)
        .Select(line => line.Split().Select(int.Parse).ToArray())
        .Select(d => new
        {
            d0 = d[0],
            d1 = d[1],
            s = Math.Abs(d[0] - d[1]),
            f = Math.Abs(d[0] - d[1]) % 3 > 0
        })
        .ToArray();

    var min = subs.Where(x => x.f).MinBy(x => x.s);

    max -= min.s;
    Console.WriteLine($"Max not-dev by 3: {max}");
}