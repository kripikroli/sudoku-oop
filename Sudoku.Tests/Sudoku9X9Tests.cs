using System;
using Xunit;

namespace Sudoku.Tests
{
    public class Sudoku9X9Tests
    {
        [Fact]
        public void IsGuessInRow_GuessExistInRow_ReturnsTrue()
        {
            // Arrange
            const string guess = "6";
            const int row = 2;
            const string filePath = @"D:\Src\Repos\Board.Puzzles\puzzles\tests_puzzle\puzzle_check_guess_in_file.txt";

            var sudoku9x9 = new Sudoku9X9(filePath);

            // Act
            bool result = sudoku9x9.IsGuessInRow(guess, row);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsGuessInRow_GuessDontExistInRow_ReturnsFalse()
        {
            // Arrange
            const string guess = "8";
            const int row = 0;
            const string filePath = @"D:\Src\Repos\Board.Puzzles\puzzles\tests_puzzle\puzzle_check_guess_in_file.txt";

            var sudoku9x9 = new Sudoku9X9(filePath);

            // Act
            bool result = sudoku9x9.IsGuessInRow(guess, row);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsGuessInCol_GuessExistInCol_ReturnsTrue()
        {
            // Arrange
            const string guess = "4";
            const int col = 8;
            const string filePath = @"D:\Src\Repos\Board.Puzzles\puzzles\tests_puzzle\puzzle_check_guess_in_file.txt";

            var sudoku9x9 = new Sudoku9X9(filePath);

            // Act
            bool result = sudoku9x9.IsGuessInCol(guess, col);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsGuessInCol_GuessDontExistInCol_ReturnsFalse()
        {
            // Arrange
            const string guess = "9";
            const int col = 1;
            const string filePath = @"D:\Src\Repos\Board.Puzzles\puzzles\tests_puzzle\puzzle_check_guess_in_file.txt";

            var sudoku9x9 = new Sudoku9X9(filePath);

            // Act
            bool result = sudoku9x9.IsGuessInCol(guess, col);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsGuessInMiniGrid_GuessExistInMiniGrid_ReturnsTrue()
        {
            // Arrange
            const string guess = "6";
            const int row = 2;
            const int col = 1;
            const string filePath = @"D:\Src\Repos\Board.Puzzles\puzzles\tests_puzzle\puzzle_check_guess_in_file.txt";

            var sudoku9x9 = new Sudoku9X9(filePath);

            // Act
            bool result = sudoku9x9.IsGuessInMiniGrid(guess, row, col);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsGuessInMiniGrid_GuessDontExistInMiniGrid_ReturnsFalse()
        {
            // Arrange
            const string guess = "6";
            const int row = 2;
            const int col = 1;
            const string filePath = @"D:\Src\Repos\Board.Puzzles\puzzles\tests_puzzle\puzzle_check_guess_in_file.txt";

            var sudoku9x9 = new Sudoku9X9(filePath);

            // Act
            bool result = sudoku9x9.IsGuessInMiniGrid(guess, row, col);

            // Assert
            Assert.False(result);
        }
    }
}
