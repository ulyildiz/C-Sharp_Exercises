Imports System

Module Program
    Sub Main(args As String())
        Dim lenght As Integer = 5 ' Elmas�n k��e�e kadar olan uzakl���

        ' �st yar�m (ortas� dahil)
        For i As Integer = 0 To lenght - 1
            ' Sol bo�luklar
            For j As Integer = 0 To lenght - i - 2
                Console.Write(".")
            Next

            ' Y�ld�zlar
            For k As Integer = 0 To 2 * i
                Console.Write("*")
            Next

            Console.WriteLine()
        Next

        ' Alt yar�m
        For i As Integer = lenght - 2 To 0 Step -1
            ' Sol bo�luklar
            For j As Integer = 0 To lenght - i - 2
                Console.Write(".")
            Next

            ' Y�ld�zlar
            For k As Integer = 0 To 2 * i
                Console.Write("*")
            Next

            Console.WriteLine()
        Next
    End Sub
End Module