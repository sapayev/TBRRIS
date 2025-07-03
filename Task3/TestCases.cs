namespace Task3;

public class TestCases
{
    public static void Run()
    {
        var finder = new Finder();

        void Test(List<uint> list, ulong sum, int expectedStart, int expectedEnd)
        {
            finder.FindElementsForSum(list, sum, out int start, out int end);
            Console.WriteLine($"Sum: {sum}, Start: {start}, End: {end} => {(start == expectedStart && end == expectedEnd ? "PASS" : "FAIL")}");
        }

        Test(new List<uint> { 0, 1, 2, 3, 4, 5, 6, 7 }, 11, 5, 7);
        Test(new List<uint> { 4, 5, 6, 7 }, 18, 1, 4);
        Test(new List<uint> { 0, 1, 2, 3, 4, 5, 6, 7 }, 88, 0, 0);
        Test(new List<uint> { 1, 2, 3, 4, 5 }, 6, 1, 4); 
        Test(new List<uint> { 10, 20, 30 }, 30, 0, 2); 
        Test(new List<uint>(), 0, 0, 0); 
        Test(new List<uint> { 1, 1, 1, 1, 1, 1 }, 3, 0, 3); 
    }
}