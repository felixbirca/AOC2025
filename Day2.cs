namespace AOC2025
{
  public static class Day2
  {
    public static void Solve(string[] args)
    {
      var rawRanges = File.ReadAllText(args[0]);
      var ranges = rawRanges.Split(',');
      var pass = (long)0;

      foreach (var range in ranges)
      {
        var bounds = range.Split('-');
        if (bounds[0].Length % 2 != 0 && bounds[1].Length % 2 != 0)
        {
          continue;
        }
        var start = long.Parse(bounds[0]);
        var end = long.Parse(bounds[1]);
        for (long i = start; i <= end; i++)
        {
          if (i.ToString().Length % 2 != 0)
          {
            continue;
          }

          if (IsInvalidId(i))
          {
            pass += i;
          }
        }
      }
      Console.WriteLine(pass);
    }

    private static bool IsInvalidId(long id)
    {
      var idString = id.ToString();
      if (idString.Substring(0, idString.Length / 2) == idString.Substring(idString.Length / 2, idString.Length / 2))
      {
        return true;
      }
      return false;
    }
  }
}
