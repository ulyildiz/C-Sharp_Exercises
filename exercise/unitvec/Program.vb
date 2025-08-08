Imports System

Module Program
    Function CrossProduct(a() As Double, b() As Double) As Double()
        If a.Length <> 3 OrElse b.Length <> 3 Then
            Throw New ArgumentException("Her iki vektör de 3 boyutlu olmalý.")
        End If

        Dim result(2) As Double

        result(0) = a(1) * b(2) - a(2) * b(1)
        result(1) = a(2) * b(0) - a(0) * b(2)
        result(2) = a(0) * b(1) - a(1) * b(0)

        Return result
    End Function

    Sub Main(args As String())
        Dim v1() As Double = {1 / Math.Sqrt(3), 1 / Math.Sqrt(3), 1 / Math.Sqrt(3)} ' Birim vektör örneði
        Dim v2() As Double = {0, 1, 0} ' Birim vektör

        Dim cross() As Double = CrossProduct(v1, v2)

        Console.WriteLine("Cross product sonucu: ({0}, {1}, {2})", cross(0), cross(1), cross(2))

    End Sub
End Module
