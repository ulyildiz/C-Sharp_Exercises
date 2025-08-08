Imports System

Module Program
    Sub Main(args As String())
        Dim lenght As Integer = 5 ' Elmasýn köþeðe kadar olan uzaklýðý

        ' Üst yarým (ortasý dahil)
        For i As Integer = 0 To lenght - 1
            ' Sol boþluklar
            For j As Integer = 0 To lenght - i - 2
                Console.Write(".")
            Next

            ' Yýldýzlar
            For k As Integer = 0 To 2 * i
                Console.Write("*")
            Next

            Console.WriteLine()
        Next

        ' Alt yarým
        For i As Integer = lenght - 2 To 0 Step -1
            ' Sol boþluklar
            For j As Integer = 0 To lenght - i - 2
                Console.Write(".")
            Next

            ' Yýldýzlar
            For k As Integer = 0 To 2 * i
                Console.Write("*")
            Next

            Console.WriteLine()
        Next
    End Sub
End Module