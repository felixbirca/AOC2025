using System.Diagnostics;

namespace AOC2025
{
  public static class Day3Sliding
  {
    public static void Solve(string[] args)
    {
      var pass = (ulong)0;
      var k = 12;
      var stopwatch = new Stopwatch();
      stopwatch.Start();

      var lines = File.ReadAllLines("./day3.txt");

      foreach (var line in lines)
      {
        var arr = line.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
        var currentIndex = 0;
        var result = new List<int>();
        for (var i = 0; i < k; i++)
        {
          var arrLen = arr.Length - k + i;
          var subarr = arr[(i == 0 ? currentIndex : currentIndex + 1)..(arrLen + 1)];
          var max = subarr.Max();
          var updatedIndex = 0;
          if (currentIndex != 0)
          {
            do
            {
              updatedIndex = Array.IndexOf(arr, max, currentIndex + 1);
            } while (updatedIndex <= currentIndex);
            currentIndex = updatedIndex;
          }
          else
          {
            currentIndex = Array.IndexOf(arr, max, i == 0 ? 0 : currentIndex + 1);
          }
          result.Add(max);
        }
        Console.WriteLine(ulong.Parse(result.Select(x => x.ToString()).Aggregate("", (acc, current) => { return acc + current; })));
        pass += ulong.Parse(result.Select(x => x.ToString()).Aggregate("", (acc, current) => { return acc + current; }));
      }
      stopwatch.Stop();
      Console.WriteLine(pass);
      Console.WriteLine($"Solved in {stopwatch.ElapsedMilliseconds} ms");
    }
  }
}
