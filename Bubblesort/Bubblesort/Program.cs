int n = 5;
int m = 3;

if (m <= n)
{
    int result1 = 1;
    for (int i = 1; i <= n; i++)
    {
        result1 *= i;
    }

    int result2 = 1;
    for (int j = 1; j <= n-m; j++)
    {
        result2 *= j;
    }

    Console.WriteLine(result1 / result2);
}
