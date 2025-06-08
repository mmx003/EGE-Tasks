// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;

var conditions = new[]
{
    new
    {
        FilePath = "E:\\Work\\__temp\\School-Task\\EGE-Tasks\\ConsoleApp27_4\\27A_59854.txt"
    },
    new
    {
        FilePath = "E:\\Work\\__temp\\School-Task\\EGE-Tasks\\ConsoleApp27_4\\27B_59854.txt"
    },
};

foreach (var c in conditions)
{
    var lines = File.ReadAllLines(c.FilePath);

    var k = int.Parse(lines[0]);
    var l = int.Parse(lines[1]);

    var ints = lines.Skip(2).Select(int.Parse).ToArray();
    Console.WriteLine($"Data is loaded, k:{k}, length: {l}");

    var minVal = int.MaxValue;
    var minMult = long.MaxValue;
    for (var i = 0; i < ints.Length; i++)
    {
        var val = ints[i];
        if (val > minVal) continue;

        minVal = val;

        for (var j = i + k; j < ints.Length; j++)
        {
            var x = (long)val * ints[j];
            if (x < minMult)
                minMult = x;
        }
    }

    Console.WriteLine("Minimal multi: " + minMult);
}