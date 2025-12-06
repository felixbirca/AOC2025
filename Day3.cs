using System.Diagnostics;

namespace AOC2025
{
  public static class Day3
  {
    public static void Solve(string[] args)
    {
      var pass = 0;
      var stopwatch = new Stopwatch();
      stopwatch.Start();

      var lines = File.ReadAllLines("./day3.txt");

      foreach (var line in lines)
      {
        var dict = LineToDict(line);
        var biggest = FindBiggest(dict);
        Console.WriteLine(biggest);
        pass += biggest;

      }

      stopwatch.Stop();
      Console.WriteLine($"Solved in {stopwatch.ElapsedMilliseconds} ms");
      Console.WriteLine(pass);
    }

    private static Dictionary<int, List<int>> LineToDict(string line)
    {
      var x = new Dictionary<int, List<int>>();
      // number - key, values - positions

      for (int i = 0; i < line.Length; i++)
      {
        var key = int.Parse(line.Substring(i, 1));

        var list = x.GetValueOrDefault(key);
        if (list == null)
        {
          list = new List<int>();
          list.Add(i);
          x[key] = list;
        }
        else
        {
          list.Add(i);
          x[key] = list;
        }
      }

      return x;
    }

    private static int FindBiggest(Dictionary<int, List<int>> dict)
    {
      for (int i = 9; i >= 0; i--)
      {
        dict.TryGetValue(i, out var list);
        if (list == null)
        {
          continue;
        }

        for (int j = 9; j >= 0; j--)
        {
          dict.TryGetValue(j, out var listJ);
          if (listJ == null)
          {
            continue;
          }

          if (listJ.Any(x => list.First() < x))
          {
            return i * 10 + j;
          }
        }
      }
      return -1;
    }
  }
}
