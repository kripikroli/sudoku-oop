using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

namespace Board.Puzzles
{
    class Utils
    {
        public static string ExtractPuzzleFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            return string.Join("", lines);
        }

        public static bool ValidateGridSize(string board)
        {
            return (board.Length == 81);
        }

        public static bool ValidateNumberOfHints(string board)
        {
            int count = board.Count(x => x == 'X');

            return (count < 64);
        }

        public static bool ValidateCellItems(string board)
        {
            var acceptableChars = @"^[X1-9]{81}$";

            var match = Regex.Match(board, acceptableChars);

            if (!match.Success) return false;

            return true;
        }

        public static void ExtractAnswersToFile(string[,] answers, string dir, string file)
        {
            string fileSlnName = dir + "\\" + file + ".sln.txt";

            StringBuilder sb = new StringBuilder();

            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    sb.Append(answers[r, c]);
                }

                sb.Append("\n");
            }

            if (File.Exists(fileSlnName)) File.Delete(fileSlnName);

            using (var tw = new StreamWriter(fileSlnName, true))
            {
                tw.WriteLine(sb);
            }
        }
    }
}
