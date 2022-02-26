using Xunit;

namespace AM.Core.Algorithms.Puzzles.Tests
{
    public class SudokuSolverTests
    {
        [Fact]
        public void Solve_Succeeds()
        {
            var board = new char[][]
            {
                new[]{'5', '3', '.', '.', '7', '.', '.', '.', '.'},
                new[]{'6', '.', '.', '1', '9', '5', '.', '.', '.'},
                new[]{'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                new[]{'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                new[]{'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                new[]{'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                new[]{'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                new[]{'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                new[]{'.', '.', '.', '.', '8', '.', '.', '7', '9'},
            };

            new SudokuSolver().SolveSudoku(board);

            Assert.Equal('1', board[8][6]);
        }

        [Fact]
        public void Solve2()
        {
            var board = new char[][]
            {
                new[]{'1','.','.','.','7','.','.','3','.'},
                new[]{'8','3','.','6','.','.','.','.','.'},
                new[]{'.','.','2','9','.','.','6','.','8'},
                new[]{'6','.','.','.','.','4','9','.','7'},
                new[]{'.','9','.','.','.','.','.','5','.'},
                new[]{'3','.','7','5','.','.','.','.','4'},
                new[]{'2','.','3','.','.','9','1','.','.'},
                new[]{'.','.','.','.','.','2','.','4','3'},
                new[]{'.','4','.','.','8','.','.','.','9'}
            };

            new SudokuSolver().SolveSudoku(board);
        }

        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(2, 0)]
        [InlineData(3, 3)]
        [InlineData(4, 3)]
        [InlineData(5, 3)]
        [InlineData(6, 6)]
        [InlineData(7, 6)]
        [InlineData(8, 6)]
        [Theory]
        public void GetSubBoxStart_Succeeds(int index, int expected)
        {
            Assert.Equal(SudokuSolver.GetSubBoxStart(index), expected);
        }
    }
}
