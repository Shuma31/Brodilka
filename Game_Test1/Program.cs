string [,] matrix = {
    {" ", " ", " ", " ", " ", " "},
    {" ", " ", " ", " ", " ", " "},
    {" ", "@", " ", "*", " ", " "},
    {" ", " ", " ", " ", " ", " "},
    {" ", " ", " ", " ", " ", " "},
    {" ", " ", " ", " ", " ", " "}};
int x = 1;
int y = 2;
int count = 0;
void WriteArrayMatrix(string[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
}

void WriteCoordinates(int x, int y, int count)
{
    Console.WriteLine("x = " + x + " y = " + y + " Bonus = " + count);
}

int BonusCreator(string[,] matrix, int x, int y, int count)
{
    while(matrix[y, x] == "*")
    {
        count++;
        matrix[y, x] = " ";
        int newBonusy = new Random().Next(0, matrix.GetLength(0));
        int newBonusx = new Random().Next(0, matrix.GetLength(1));
        matrix[newBonusy, newBonusx] = "*";
    }
    return count;
}

void Game(string[,] matrix, int x, int y, int count)
{
    while (true)
    {
        matrix [y, x] = " ";
        ConsoleKeyInfo user_keyTab = Console.ReadKey();
        if (user_keyTab.Key == ConsoleKey.W) y--;
        if (user_keyTab.Key == ConsoleKey.S) y++;
        if (user_keyTab.Key == ConsoleKey.A) x--;
        if (user_keyTab.Key == ConsoleKey.D) x++;
        if (y < 0) y = 0;
        if (x < 0) x = 0;
        if (x > matrix.GetLength(1) - 1) x = matrix.GetLength(1) - 1;
        if (y > matrix.GetLength(0) - 1) y = matrix.GetLength(0) - 1;
        count = BonusCreator(matrix, x, y, count);
        matrix[y ,x] = "@";
        Console.Clear();
        WriteArrayMatrix(matrix);
        WriteCoordinates(x, y, count);
        
    }
}
WriteArrayMatrix(matrix);
Game(matrix, x, y, count);
