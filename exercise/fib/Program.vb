Module Program
    Sub Main() ' statik olarak adet al�n�r
        Dim n As Integer = 10 ' Hesaplanacak Fibonacci say�s� adedi
        For i As Integer = 0 To n - 1
            Console.WriteLine(Fibonacci(i))
        Next
    End Sub

    Function Fibonacci(ByVal num As Integer) As Integer
        If num <= 1 Then
            Return num
        Else
            Return Fibonacci(num - 1) + Fibonacci(num - 2)
        End If
    End Function
End Module

'Sub Main(args() As String) ' Komut sat�r�ndan adet al�n�r
'    Dim n As Integer = 10
'    If args.Length > 0 Then
'        If Integer.TryParse(args(0), n) = False Then
'            Console.WriteLine("Ge�erli bir say� giriniz.")
'            Return
'        End If
'    End If
'
'    For i As Integer = 0 To n - 1
'        Console.WriteLine(Fibonacci(i))
'    Next
'End Sub