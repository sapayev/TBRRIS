namespace Task5;

public class Sudoku
{
    public bool SolveSudoku(int[,] board)
    {
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                if (board[row, col] == 0)
                {
                    for (int num = 1; num <= 9; num++)
                    {
                        if (IsValid(board, row, col, num))
                        {
                            board[row, col] = num;

                            if (SolveSudoku(board))
                                return true;

                            board[row, col] = 0; // backtrack
                        }
                    }
                    return false; // не удалось поставить ни одно число
                }
            }
        }
        return true; // доска заполнена
    }

    private bool IsValid(int[,] board, int row, int col, int num)
    {
        for (int i = 0; i < 9; i++)
        {
            if (board[row, i] == num || board[i, col] == num)
                return false;

            int blockRow = 3 * (row / 3) + i / 3;
            int blockCol = 3 * (col / 3) + i % 3;

            if (board[blockRow, blockCol] == num)
                return false;
        }

        return true;
    }
}