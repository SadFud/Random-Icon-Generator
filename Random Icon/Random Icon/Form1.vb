Imports System.IO
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rutaicono As String = TextBox1.Text
        Dim tamaño As String
        If ComboBox1.Text = "32x32" Then
            tamaño = "33"
        End If
        If ComboBox1.Text = "48x48" Then
            tamaño = "49"
        End If
        If ComboBox1.Text = "52x52" Then
            tamaño = "53"
        End If
        If File.Exists(rutaicono) Then
            File.Delete(rutaicono)
            Call generateicon()
            MsgBox("Icono generado en " & TextBox1.Text & " satisfactoriamente.")
        Else
            Call generateicon()
            MsgBox("Icono generado en " & TextBox1.Text & " satisfactoriamente.")
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Function generateicon() As String
        Dim tamaño As String
        If ComboBox1.Text = "32x32" Then
            tamaño = "33"
        End If
        If ComboBox1.Text = "48x48" Then
            tamaño = "49"
        End If
        If ComboBox1.Text = "52x52" Then
            tamaño = "53"
        End If
        Dim ancho As Integer = tamaño
        Dim alto As Integer = tamaño
        Dim bmp As New Bitmap(ancho, alto)
        Dim rand As Random = New Random()
        For y As Integer = 0 To alto - 1
            For x As Integer = 0 To ancho - 1
                Dim a As Integer = rand.Next(256)
                Dim r As Integer = rand.Next(256)
                Dim g As Integer = rand.Next(256)
                Dim b As Integer = rand.Next(256)
                bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b))
            Next
        Next
        Dim HIcon As IntPtr = bmp.GetHicon()
        Dim nuevoicono As Icon = Icon.FromHandle(HIcon)

        ' Dim rutafinal As String = Path.GetTempPath() + "iconorandom.ico"
        Dim rutafinal As String = TextBox1.Text
        Dim oFileStream As FileStream = New IO.FileStream(rutafinal, FileMode.CreateNew)
        nuevoicono.Save(oFileStream)
        oFileStream.Close()
        Return rutafinal
    End Function
End Class
