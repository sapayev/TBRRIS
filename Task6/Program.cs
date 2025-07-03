using System;

class Program
{
    // Для подсчета общего количества ходов
    static int moveCount = 0;

    static void Main(string[] args)
    {
        int numberOfDisks = 3; // Количество дисков
        int totalMoves = (1 << numberOfDisks) - 1; // Вычисляем 2^3 - 1 = 7

        Console.WriteLine($"Перенос пирамиды из {numberOfDisks} дисков");
        Console.WriteLine($"Минимальное количество ходов: {totalMoves}");
        Console.WriteLine("Последовательность ходов:");

        // Вызываем рекурсивную функцию для переноса дисков
        // A - исходный стержень, C - целевой, B - вспомогательный
        DiskCount(numberOfDisks, 'A', 'C', 'B');

        Console.WriteLine($"\nОбщее количество ходов: {moveCount}");
    }

    // Рекурсивная функция для решения задачи
    // n - количество дисков, source - исходный стержень, destination - целевой, auxiliary - вспомогательный
    static void DiskCount(int n, char source, char destination, char auxiliary)
    {
        if (n == 0) return; // База рекурсии: если нет дисков, ничего не делаем

        // Шаг 1: Перемещаем n-1 дисков с исходного стержня на вспомогательный
        DiskCount(n - 1, source, auxiliary, destination);

        // Шаг 2: Перемещаем n-й диск с исходного стержня на целевой
        moveCount++;
        Console.WriteLine($"Ход {moveCount}: Переместить диск {n} с {source} на {destination}");

        // Шаг 3: Перемещаем n-1 дисков с вспомогательного стержня на целевой
        DiskCount(n - 1, auxiliary, destination, source);
    }
}