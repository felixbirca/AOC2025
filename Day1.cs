namespace AOC2025
{
  public class Day1
  {
    public static void Solve(string[] args)
    {
      var moves = File.ReadAllLines(args[0]);

      var location = 50;
      var pass = 0;

      foreach (var move in moves)
      {
        var direction = move.Substring(0, 1);
        var distance = int.Parse(move.Substring(1, move.Length - 1));
        var normalizedDistance = distance % 100;
        if (direction == "R")
        {
          location = location + normalizedDistance;
        }
        else
        {

          location = location - normalizedDistance;
        }

        if (location >= 100)
        {
          location = location - 100;
        }

        if (location < 0)
        {
          location = location + 100;
        }
        Console.WriteLine($"location {location}");

        if (location == 0)
        {
          pass++;
        }
      }
      Console.WriteLine(pass);
    }
  }
}
