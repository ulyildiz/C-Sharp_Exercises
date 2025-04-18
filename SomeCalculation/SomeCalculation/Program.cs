using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

class Program
{
    static private decimal[,] CreateMatrix()
    {
        Console.WriteLine("Enter the number of rows:");
        int rows = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the number of columns:");
        int cols = Convert.ToInt32(Console.ReadLine());

        return new decimal[rows, cols];
    }

    static private void FillMatrix(ref decimal[,] matrix)
    {
        Console.WriteLine("Fill the matrix:");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.WriteLine($"Enter element [{i}, {j}]:");
                matrix[i, j] = Convert.ToDecimal(Console.ReadLine());
            }
        }
    }

    static private void Addition(ref decimal[,] matrix)
    {
        Console.WriteLine("Addition");
        decimal[,] matrix2 = CreateMatrix();
        FillMatrix(ref matrix2);
        if (matrix.GetLength(0) != matrix2.GetLength(0) || matrix.GetLength(1) != matrix2.GetLength(1))
            throw new ArgumentException("Matrices must have the same dimensions for addition.");

        decimal[,] result = new decimal[matrix.GetLength(0), matrix.GetLength(1)];
        for (int i = 0; i < result.GetLength(0); i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                result[i, j] = matrix[i, j] + matrix2[i, j];
            }
        }

        Console.WriteLine("Result of addition:");
        for (int i = 0; i < result.GetLength(0); i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                Console.Write(result[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static private void Substraction(ref decimal[,] matrix)
    {
        Console.WriteLine("Substraction");

        decimal[,] matrix2 = CreateMatrix();
        FillMatrix(ref matrix2);
        if (matrix.GetLength(0) != matrix2.GetLength(0) || matrix.GetLength(1) != matrix2.GetLength(1))
            throw new ArgumentException("Matrices must have the same dimensions for addition.");

        decimal[,] result = CreateMatrix();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                result[i, j] = matrix[i, j] + matrix2[i, j];
            }
        }

        Console.WriteLine("Result of substraction:");
        for (int i = 0; i < result.GetLength(0); i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                Console.Write(result[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static private void Multiplication(ref decimal[,] matrix)
    {
        Console.WriteLine("Multiplication");
        decimal[,] matrix2 = CreateMatrix();
        FillMatrix(ref matrix2);

        decimal[,] res = new decimal[matrix.GetLength(0), matrix2.GetLength(1)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix2.GetLength(1); j++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    res[i, j] += matrix[i, k] * matrix2[k, j];
                }
            }
        }

        Console.WriteLine("Result of multiplication:");
        for (int i = 0; i < res.GetLength(0); i++)
        {
            for (int j = 0; j < res.GetLength(1); j++)
            {
                Console.Write(res[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static private void Transpose(ref decimal[,] matrix)
    {
        Console.WriteLine("Transpose");

        decimal[,] transposedMatrix = new decimal[matrix.GetLength(1), matrix.GetLength(0)];
     
        for (int i = 0; i < transposedMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < transposedMatrix.GetLength(1); j++)
            {
                transposedMatrix[i, j] = matrix[j, i];
            }
        }

        Console.WriteLine("Transposed matrix:");
        for (int i = 0; i < transposedMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < transposedMatrix.GetLength(1); j++)
            {
                Console.Write(transposedMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static private decimal Determinant(ref decimal[,] matrix)
    {
        decimal det;

        if (matrix.GetLength(0) != matrix.GetLength(1))
        {
            throw new ArgumentException("Matrix is not square, cannot calculate determinant.");
        }
        else if (matrix.GetLength(0) == 0)
        {
            throw new ArgumentException("Matrix is empty, cannot calculate determinant.");
        }
        else if (matrix.GetLength(0) == 1)
        {
            return matrix[0, 0];
        }
        else if (matrix.GetLength(0) == 2)
        {
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }

        det = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            decimal[,] subMatrix = new decimal[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            for (int j = 1; j < matrix.GetLength(0); j++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (k < i)
                        subMatrix[j - 1, k] = matrix[j, k];
                    else if (k > i)
                        subMatrix[j - 1, k - 1] = matrix[j, k];
                }
            }

            det += (i % 2 == 0 ? 1 : -1) * matrix[0, i] * Determinant(ref subMatrix);
        }

        return det;
    }

    static void QRDecomposition(decimal[,] A, out decimal[,] Q, out decimal[,] R)
    {
        int n = A.GetLength(0);
        Q = new decimal[n, n];
        R = new decimal[n, n];
        decimal[,] V = (decimal[,])A.Clone();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < i; j++) // Ortogonalize
            {
                decimal dot = 0;
                for (int k = 0; k < n; k++)
                    dot += Q[k, j] * V[k, i];

                R[j, i] = dot;

                for (int k = 0; k < n; k++)
                    V[k, i] -= dot * Q[k, j];
            }

            decimal norm = 0; // Normalize et
            for (int k = 0; k < n; k++)
                norm += V[k, i] * V[k, i];
            norm = (decimal)Math.Sqrt((double)norm);

            R[i, i] = norm;
            for (int k = 0; k < n; k++)
                Q[k, i] = V[k, i] / norm;
        }
    }

    static void Eigenvalues(ref decimal[,] A, int iterations = 100)
    {
        int n = A.GetLength(0);
        decimal[,] Ak = (decimal[,])A.Clone();

        for (int iter = 0; iter < iterations; iter++)
        {
            QRDecomposition(Ak, out var Q, out var R);

            // A = R * Q
            decimal[,] AkNew = new decimal[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    for (int k = 0; k < n; k++)
                        AkNew[i, j] += R[i, k] * Q[k, j];

            Ak = AkNew;
        }

        // Özdeğerler köşegen elemanlarda
        decimal[] eigenvalues = new decimal[n];
        for (int i = 0; i < n; i++)
            eigenvalues[i] = Ak[i, i];

        foreach (var eigenvalue in eigenvalues)
        {
            Console.WriteLine($"Eigenvalue: {eigenvalue}");
        }
    }


    static public void Main()
    {
        
        while (true)
        {
            Console.WriteLine("Write which operation do you want to do?");
            Console.WriteLine("(Addition, Subtraction, Multiplication, Transpose, Determinant, Eigenvalues)\n(Write exit to leave)");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
                continue;
            else if (input.ToLower() == "exit")
                break;
            try
            {
                decimal[,] matrix = CreateMatrix();
                FillMatrix(ref matrix);
                if (input.ToLower() == "addition")
                    Addition(ref matrix);
                else if (input.ToLower() == "substraction")
                    Substraction(ref matrix);
                else if (input.ToLower() == "multiplication")
                    Multiplication(ref matrix);
                else if (input.ToLower() == "transpose")
                    Transpose(ref matrix);
                else if (input.ToLower() == "determinant")
                    Console.WriteLine($"The determinant is: {Determinant(ref matrix)}");
                else if (input.ToLower() == "eigenvalues")
                    Eigenvalues(ref matrix);
                else
                {
                    Console.WriteLine("Invalid operation");
                    continue;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}