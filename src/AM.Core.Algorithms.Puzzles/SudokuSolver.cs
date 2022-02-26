using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AM.Core.Algorithms.Puzzles
{
    public class SudokuSolver
    {
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
            bool boardChanged = true;
            List<int[]> emptyCells = GetAllEmptyCells(board);
            Debug.WriteLine($"Trying to solve a board with {emptyCells.Count} empty cells.");
            PrintGrid(board);

            while (emptyCells.Count > 0 && boardChanged)
            {
                boardChanged = false;

                Debug.WriteLine($"Trying to fill {emptyCells.Count} empty cells");

                for (int i = 0; i < emptyCells.Count; i++)
                {
                    int[] cell = emptyCells[i];
                    int row = cell[0];
                    int col = cell[1];
                    char[] options = FindOptionsForCell(board, row, col);
                    if (options.Length == 0)
                    {
                        Debug.WriteLine($"No options available for cell {row}:{col}. DEADLOCK!!!");
                        return false;
                    }

                    if (options.Length == 1)
                    {
                        Debug.WriteLine($"Found a match for position {row}:{col} value {options[0]}");

                        board[row][col] = options[0];
                        emptyCells.RemoveAt(i);
                        if (!boardChanged)
                            boardChanged = true;
                    }
                    else
                    {
                        Debug.WriteLine($"Multiple options are available for position {row}:{col}. {String.Join(",", options)}");
                    }
                }
            }

            PrintGrid(board);
            if (emptyCells.Count > 0)
            {
                // There are still cells that we couldn't find a good answer for. Try out options now.
                Debug.WriteLine($"Processing cells with multiple options");
                for (var i = 0; i < emptyCells.Count; i++)
                {
                    var cell = emptyCells[i];
                    var options = FindOptionsForCell(board, cell[0], cell[1]);
                    foreach (var option in options)
                    {
                        var row = cell[0];
                        var col = cell[1];

                        var copyBoard = GetTempBoard(board);
                        copyBoard[row][col] = option;
                        Debug.WriteLine($"Trying out value {option} for cell {row}:{col}");
                        if (Solve(copyBoard))
                        {
                            CopyBoard(copyBoard, board);
                            board = copyBoard;
                            Debug.WriteLine($"Success for value {option} for cell {row}:{col}");
                            return true;
                        }
                    }
                }

                Debug.WriteLine("Found no solution for suspicious cells");
                return false;
            }
            else
            {
                Debug.WriteLine("Success");
                return true;
            }
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

        private static List<int[]> GetAllEmptyCells(char[][] board)
        {
            List<int[]> result = new List<int[]>();

            for (var i = 0; i < board.Length; i++)
            {
                for (var j = 0; j < board[i].Length; j++)
                {
                    if (IsEmpty(board[i][j]))
                        result.Add(new[] { i, j });
                }
            }

            return result;
        }

        private static bool IsEmpty(char value) => value == '.';

        private static char[] FindOptionsForCell(char[][] board, int row, int col)
        {
            var globalOptions = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            List<char> result = new List<char>();
            foreach (var option in globalOptions)
            {
                if (IsOptionAllowedInRow(board, row, option) && IsOptionAllowedInCol(board, col, option) && IsOptionAllowedInBox(board, row, col, option))
                {
                    result.Add(option);
                }
            }

            return result.ToArray();
        }

        private static bool IsOptionAllowedInRow(char[][] grid, int row, char option)
        {
            for (var col = 0; col < grid[row].Length; col++)
            {
                if (grid[row][col] == option)
                    return false;
            }

            return true;
        }

        private static bool IsOptionAllowedInCol(char[][] grid, int col, char option)
        {
            for (var row = 0; row < grid.Length; row++)
            {
                if (grid[row][col] == option)
                    return false;
            }

            return true;
        }

        private static bool IsOptionAllowedInBox(char[][] grid, int row, int col, char option)
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

        private static void PrintGrid(char[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                Debug.WriteLine(string.Join(", ", grid[i]));
            }
        }
    }
}
