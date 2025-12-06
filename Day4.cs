using System.Diagnostics;

namespace AOC2025
{
  public static class Day4
  {
    public static void Solve(string[] args)
    {
      Lock passLock = new();
      var lines = File.ReadAllLines("day4.txt");
      char[][] matrix = new char[lines.Length][];

      for (int i = 0; i < lines.Length; i++)
      {
        matrix[i] = lines[i].ToCharArray();
      }

      int pass = 0;
      var stopwatch = new Stopwatch();
      stopwatch.Start();
      for (int i = 0; i < matrix.Length; i++)
      {
        for (int j = 0; j < matrix[i].Length; j++)
        {
          if (matrix[i][j] != '@')
          {
            continue;
          }

          var adjasent = 0;
          if (i > 0)
          {
            if (matrix[i - 1][j] == '@')
            {
              adjasent++;
            }
          }

          if (i > 0 && j > 0)
          {
            if (matrix[i - 1][j - 1] == '@')
            {
              adjasent++;
            }
          }

          if (j > 0)
          {
            if (matrix[i][j - 1] == '@')
            {
              adjasent++;
            }
          }

          if (j > 0 && i < matrix.Length - 1)
          {
            if (matrix[i + 1][j - 1] == '@')
            {
              adjasent++;
            }
          }

          if (i < matrix.Length - 1)
          {
            if (matrix[i + 1][j] == '@')
            {
              adjasent++;
            }
          }

          if (i < matrix.Length - 1 && j < matrix[i].Length - 1)
          {
            if (matrix[i + 1][j + 1] == '@')
            {
              adjasent++;
            }
          }

          if (j < matrix[i].Length - 1)
          {
            if (matrix[i][j + 1] == '@')
            {
              adjasent++;
            }
          }

          if (i > 0 && j < matrix[i].Length - 1)
          {
            if (matrix[i - 1][j + 1] == '@')
            {
              adjasent++;
            }
          }

          if (adjasent < 4)
          {
            pass++;
          }
        }
      }

      Console.WriteLine($"Sequantial solved in {stopwatch.ElapsedMilliseconds}");
      Console.WriteLine(pass);
    }
  }
}
