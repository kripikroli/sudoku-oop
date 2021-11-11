using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Puzzles
{
    class Sudoku9X9 : Sudoku
    {
        private const int GridRows = 9;
        private const int GridCols = 9;

        /*
     *      Cols
     *        1  2  3  4  5  6  7  8  9
     * Rows +--------------------------+
     *   1  | X| X| X| 1| 5| X| X| 7| X|
     *   2  | 1| X| 6| X| X| X| 8| 2| X|
     *   3  | 3| X| X| 8| 6| X| X| 4| X|
     *   4  | 9| X| X| 4| X| X| 5| 6| 7|
     *   5  | X| X| 4| 7| X| 8| 3| X| X|
     *   6  | 7| 3| 2| X| X| 6| X| X| 4|
     *   7  | X| 4| X| X| 8| 1| X| X| 9|
     *   8  | X| 1| 7| X| X| X| 2| X| 8|
     *   9  | X| 5| X| X| 3| 7| X| X| X|
     *      +--------------------------+
     * 
     * Represents the items in the puzzle.
     * We will use X to denote an empty cell.
     */
        protected string[,] grid = new string[GridRows, GridCols];

        private string _fileName = String.Empty;
        private string _fileDir = String.Empty;


        private string GetCellValue(int row, int col)
        {
            return this.grid[row, col];
        }

        private void SetCellValue(int row, int col, string val)
        {
            this.grid[row, col] = val;
        }

        private void Initialize9X9Grid(string board)
        {
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    SetCellValue(r, c, board[r * 9 + c].ToString());
                }
            }
        }

        private void SetFileName(string path)
        {
            string[] dir = path.Split("\\");

            this._fileName = dir[dir.Length - 1].Split(".")[0];
        }

        private string GetFileName()
        {
            return this._fileName;
        }

        private void SetFileDir(string path)
        {
            string[] dir = path.Split("\\");

            dir = dir.SkipLast(1).ToArray();

            this._fileDir = String.Join("\\", dir);
        }

        private string GetFileDir()
        {
            return this._fileDir;
        }

        public override void GenerateFile()
        {
            Utils.ExtractAnswersToFile(this.grid, this._fileDir, this._fileName);
        }

        public Sudoku9X9(string path)
        {
            string initialBoard = Utils.ExtractPuzzleFromFile(path);

            if (!Utils.ValidateGridSize(initialBoard))
                throw new ArgumentException("Invalid puzzle board size.");

            if (!Utils.ValidateNumberOfHints(initialBoard))
                throw new ArgumentException("Invalid number of hints.");

            if (!Utils.ValidateCellItems(initialBoard))
                throw new ArgumentException("Invalid puzzle board characters.");

            SetFileName(path);
            SetFileDir(path);

            Initialize9X9Grid(initialBoard);
        }

        private void FindNextOpenCell(out int row, out int col)
        {
            row = col = -1;

            for (int r = 0; r < GridRows; r++)
            {
                for (int c = 0; c < GridCols; c++)
                {
                    if (GetCellValue(r, c) == "X")
                    {
                        row = r;
                        col = c;
                    }
                }
            }

        }

        // Internal for testing
        // This will check if the guess value exist in a specific row 
        internal bool IsGuessInRow(string guess, int row)
        {
            for (int c = 0; c < GridRows; c++)
            {
                if (GetCellValue(row, c) == guess) return true;
            }

            return false;
        }

        // Internal for testing
        // This will check if the guess value exist in a specific column 
        internal bool IsGuessInCol(string guess, int col)
        {
            for (int r = 0; r < GridCols; r++)
            {
                if (GetCellValue(r, col) == guess) return true;
            }

            return false;
        }


        // Internal for testing
        // This will check if the guess value exist in a mini cage (3x3) 
        internal bool IsGuessInMiniGrid(string guess, int row, int col)
        {
            var rowStartingPoint = (row / 3) * 3;
            var colStartingPoint = (col / 3) * 3;

            for (int r = rowStartingPoint; r < rowStartingPoint + 3; r++)
            {
                for (int c = colStartingPoint; c < colStartingPoint + 3; c++)
                {
                    if (GetCellValue(r, c) == guess) return true;
                }
            }

            return false;
        }

        private bool IsGuessValid(string guess, int row, int col)
        {
            if (IsGuessInRow(guess, row) || IsGuessInCol(guess, col) || IsGuessInMiniGrid(guess, row, col))
                return false;

            return true;
        }

        public override bool SolveSudoku()
        {
            int row = -1;
            int col = -1;

            FindNextOpenCell(out row, out col);

            if (row == -1) return true;

            // We need to use backtracking algorithm to solve the grid.
            // When a number exists in the row, col or cage, the routine will proceed to the next guess.
            for (int guess = 1; guess < 10; guess++)
            {
                if (IsGuessValid(guess.ToString(), row, col))
                {
                    SetCellValue(row, col, guess.ToString());

                    if (SolveSudoku()) return true;
                }

                SetCellValue(row, col, "X");
            }

            return false;
        }
    }
}
