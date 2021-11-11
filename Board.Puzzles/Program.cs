using System;

namespace Board.Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] puzzleFiles = {
                @"D:\Src\Repos\Board.Puzzles\puzzles\puzzle1.txt",
                @"D:\Src\Repos\Board.Puzzles\puzzles\puzzle2.txt",
                @"D:\Src\Repos\Board.Puzzles\puzzles\puzzle3.txt",
                @"D:\Src\Repos\Board.Puzzles\puzzles\puzzle4.txt",
                @"D:\Src\Repos\Board.Puzzles\puzzles\puzzle5.txt"
            };

            foreach (string file in puzzleFiles)
            {
                try
                {
                    Sudoku s = new Sudoku9X9(file);
                    s.SolveSudoku();
                    s.GenerateFile();
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e);
                }
            }

            Console.ReadKey();
        }
    }
}
