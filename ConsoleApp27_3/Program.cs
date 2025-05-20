// See https://aka.ms/new-console-template for more information

var conditions = new[]
{
    new
    {
        FilePath = "E:\\Work\\__temp\\School-Task\\ConsoleApp1\\ConsoleApp27_3\\28129_A.txt"
    },
    new
    {
        FilePath = "E:\\Work\\__temp\\School-Task\\ConsoleApp1\\ConsoleApp27_3\\28129_B.txt"
    },
};

foreach (var c in conditions)
{
    var lines = File.ReadAllLines(c.FilePath);
    Console.WriteLine($"Found lines {lines.First()}");

    var ints = lines.Skip(1).Select(int.Parse).ToArray();

    var list = new List<dynamic>();
    for (var i = 0; i < ints.Length; i++)
    for (var j = 1; j < ints.Length; j++)
    {
        list.Add(
            new
            {
                D0 = ints[i],
                D1 = ints[j],
                Sum = ints[i] + ints[j],
                D160 = ints[i] % 160 != ints[j] % 160,
                D7 = ints[i] % 7 == 0 || ints[j] % 7 == 0,
            });
    }

    var max = list
        .Where(x => x.D160 == true && x.D7 == true)
        .MaxBy(x => x.Sum);

    Console.WriteLine($"max: {max.D0} + {max.D1} = {max.Sum}") ;
}