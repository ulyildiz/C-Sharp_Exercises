Imports System

Module Program
    Function DotDynamic(a() As Double, b() As Double) As Double
        Dim n As Integer = a.Length
        If b.Length <> n Then
            Throw New ArgumentException("Vectors must be the same length.")
        End If

        Dim result As Double = 0
        For i As Integer = 0 To n - 1
            result += a(i) * b(i)
        Next
        Return result
    End Function

    ' Cross product generalization
    Function CrossDynamic(a() As Double, b() As Double) As Double()
        Dim n As Integer = a.Length
        If b.Length <> n Then
            Throw New ArgumentException("Vectors must be the same length.")
        End If

        ' 3D case
        If n = 3 Then
            Return {
                a(1) * b(2) - a(2) * b(1),
                a(2) * b(0) - a(0) * b(2),
                a(0) * b(1) - a(1) * b(0)
            }
        End If

        ' Higher dimensions
        ' Output is an array of size n*(n-1)/2 for all 2D planes in nD space
        Dim resultSize As Integer = n * (n - 1) \ 2
        Dim result(resultSize - 1) As Double

        Dim index As Integer = 0
        For i As Integer = 0 To n - 2
            For j As Integer = i + 1 To n - 1
                result(index) = a(i) * b(j) - a(j) * b(i)
                index += 1
            Next
        Next
        Return result
    End Function

    Sub Main()
        ' Example 2D
        Dim v2D_1() As Double = {1, 2}
        Dim v2D_2() As Double = {3, 4}
        Console.WriteLine("2D Cross: " & String.Join(", ", CrossDynamic(v2D_1, v2D_2)))

        ' Example 3D
        Dim v3D_1() As Double = {1, 2, 3}
        Dim v3D_2() As Double = {4, 5, 6}
        Console.WriteLine("3D Cross: " & String.Join(", ", CrossDynamic(v3D_1, v3D_2)))

        ' Example 4D
        Dim v4D_1() As Double = {1, 2, 3, 4}
        Dim v4D_2() As Double = {5, 6, 7, 8}
        Console.WriteLine("4D Wedge components: " & String.Join(", ", CrossDynamic(v4D_1, v4D_2)))

        Console.ReadLine()
    End Sub
End Module
