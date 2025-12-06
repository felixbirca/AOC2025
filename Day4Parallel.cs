using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2025
{
  public static class Day4Parallel
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
      Parallel.For(0, matrix.Length, (i) =>
      {
        Parallel.For(0, matrix[i].Length, (j) =>
        {
          if (matrix[i][j] != '@')
          {
            return;
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
            lock (passLock)
            {
              pass++;
            }
          }
        });
      });

      stopwatch.Stop();
      Console.WriteLine($"Parallel solved in {stopwatch.ElapsedMilliseconds}");

      Console.WriteLine(pass);
    }
  }
}
