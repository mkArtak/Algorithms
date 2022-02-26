using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AM.Core.Algorithms.Puzzles
{
    public class SudokuSolver
    {
        private static char[] globalOptions = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public void SolveSudoku(char[][] board)
        {
            // Iterate over each empty cell and try to find such that can have only one value
            // If cell found, add that value and Solve the puzzle again
            // If no such cell found - find the cell with minimal options of values (only 2 possible values, or only 3 possible values as examples)
            // Until found a valid solution try out the options

            Solve(board);
        }

        private static bool Solve(char[][] board)
        {
            Stack<char[][]> baordStates = new Stack<char[][]>();

            if (!TryPopulateEmptyCells(board, out var emptyCells))
                return false;

            if (emptyCells.Count == 0)
            {
                // There are no more empty cells left. The board was filled
                return true;
            }

            // Store the snapshot of current board in case the next option doens't work out
            var snapshot = GetTempBoard(board);

            // There are still cells that we couldn't find a good answer for. Try out options now.
            for (var i = 0; i < emptyCells.Count; i++)
            {
                var cell = emptyCells[i];

                var options = FindOptionsForCell(board, cell.Row, cell.Col);

                foreach (var option in options)
                {
                    board[cell.Row][cell.Col] = option;
                    if (Solve(board))
                        return true;

                    // Restore back to the original state
                    CopyBoard(snapshot, board);
                }
            }

            return false;
        }

        private static bool TryPopulateEmptyCells(char[][] board, out List<Cell> emptyCells)
        {
            emptyCells = GetAllEmptyCells(board);
            bool boardChanged = true;
            while (emptyCells.Count > 0 && boardChanged)
            {
                boardChanged = false;

                for (int i = 0; i < emptyCells.Count; i++)
                {
                    var cell = emptyCells[i];
                    char[] options = FindOptionsForCell(board, cell.Row, cell.Col);
                    if (options.Length == 0)
                    {
                        return false;
                    }

                    if (options.Length == 1)
                    {
                        board[cell.Row][cell.Col] = options[0];
                        emptyCells.RemoveAt(i);
                        if (!boardChanged)
                            boardChanged = true;
                    }
                }
            }

            return true;
        }

        private static List<Cell> GetAllEmptyCells(char[][] board)
        {
            var result = new List<Cell>();

            for (var i = 0; i < board.Length; i++)
            {
                for (var j = 0; j < board[i].Length; j++)
                {
                    if (IsCellEmpty(board[i][j]))
                        result.Add(new Cell(i, j));
                }
            }

            return result;
        }

        private static bool IsCellEmpty(char cellValue) => cellValue == '.';

        private static char[] FindOptionsForCell(char[][] board, int row, int col)
        {
            List<char> result = new List<char>();
            foreach (var option in globalOptions)
            {
                if (IsValueAllowedInRow(board, row, option) && IsValueAllowedInColumn(board, col, option) && IsValueAllowedInBox(board, row, col, option))
                {
                    result.Add(option);
                }
            }

            return result.ToArray();
        }

        private static bool IsValueAllowedInRow(char[][] grid, int row, char option)
        {
            for (var col = 0; col < grid[row].Length; col++)
            {
                if (grid[row][col] == option)
                    return false;
            }

            return true;
        }

        private static bool IsValueAllowedInColumn(char[][] grid, int col, char option)
        {
            for (var row = 0; row < grid.Length; row++)
            {
                if (grid[row][col] == option)
                    return false;
            }

            return true;
        }

        private static bool IsValueAllowedInBox(char[][] grid, int row, int col, char option)
        {
            var boxRowStart = GetSubBoxStart(row);
            var boxColStart = GetSubBoxStart(col);
            for (var i = 0; i < 3; i++)
                for (var j = 0; j < 3; j++)
                {
                    if (grid[boxRowStart + i][boxColStart + j] == option)
                        return false;
                }

            return true;
        }

        internal static int GetSubBoxStart(int row) => 3 * (int)Math.Floor((float)row / 3);

        private static char[][] GetTempBoard(char[][] board)
        {
            char[][] result = new char[board.Length][];

            for (int i = 0; i < board.Length; i++)
            {
                result[i] = new char[board[i].Length];
                for (int j = 0; j < board[i].Length; j++)
                    result[i][j] = board[i][j];
            }

            return result;
        }

        private static void CopyBoard(char[][] source, char[][] dest)
        {
            for (int i = 0; i < source.Length; i++)
            {
                for (int j = 0; j < source[i].Length; j++)
                {
                    dest[i][j] = source[i][j];
                }
            }
        }

        private readonly struct Cell
        {
            public Cell(int row, int col)
            {
                Row = row;
                Col = col;
            }

            public int Row { get; }

            public int Col { get; }
        }
    }
}
