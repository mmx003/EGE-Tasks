// See https://aka.ms/new-console-template for more information

string ReplaceLoop(string input)
{
    var previous = string.Empty;

    // Выполняем цикл до тех пор, пока строка изменяется
    while (input != previous)
    {
        previous = input;
        input = input
            .Replace("01", "2302")
            .Replace("02", "10")
            .Replace("03", "201");
    }

    return input;
}

string Generator1(int number)
{
    var s = "0";
    while (true)
    {
        s += "1";
        if (--number < 1) break;
        s += "2";
        if (--number < 1) break;
        s += "3";
        if (--number < 1) break;
    }

    return s;
}

string Generator(int number)
{
    var s1 = "";
    var s2 = "";
    var s3 = "";
    while (true)
    {
        s1 += "1";
        if (--number < 1) break;
        s2 += "2";
        if (--number < 1) break;
        s3 += "3";
        if (--number < 1) break;
    }

    return "0" + s1 + s2 + s3;
}

var start = 1;
while (start < 100)
{
    var s = Generator(start++);
    var r = ReplaceLoop(s);
    if (r.Count(x => x == '1') == 50 && r.Count(x => x == '2') == 12 && r.Count(x => x == '3') == 7)
    {
        Console.WriteLine(r);
        break;
    }
}