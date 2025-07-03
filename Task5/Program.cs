using Task5;

int[,] board = new int[9, 9]
{
    {0,0,0,0,2,0,3,0,0},
    {0,0,3,0,4,0,0,5,0},
    {0,0,6,7,3,0,0,8,0},
    {0,7,5,8,0,0,1,0,0},
    {0,9,0,0,0,0,0,6,0},
    {6,0,8,0,0,3,2,7,0},
    {0,3,0,0,0,9,5,0,0},
    {5,6,0,0,8,0,7,0,0},
    {0,0,2,0,5,0,0,0,4}
};

Sudoku solver = new Sudoku();
if (solver.SolveSudoku(board))
{
    Console.WriteLine("Решено:");
    PrintBoard(board);
}
else
{
    Console.WriteLine("Нет решения");
}

void PrintBoard(int[,] board)
{
    for (int i = 0; i < 9; i++)
    {
        for (int j = 0; j < 9; j++)
            Console.Write(board[i, j] + " ");
        Console.WriteLine();
    }
}