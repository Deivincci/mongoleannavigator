Imports System.Runtime.CompilerServices
Imports Microsoft.Web.WebView2.WinForms





Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call CenterToScreen()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.WindowState = FormWindowState.Normal

    End Sub
    Private Sub txtURL_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtURL.KeyPress
        '// Press Enter in TextBox
        If Asc(e.KeyChar) = 13 Then
            '//  No Beep
            e.Handled = True
            Try
                Me.WebView21.Source = New Uri(txtURL.Text)
                '// OR
                '// Me.WebView21.CoreWebView2.Navigate(txtURL.Text)
            Catch ex As UriFormatException
                MessageBox.Show("Full URL ex. --> HTTP[S]")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Google.Click
        WebView21.Source = New Uri("https://www.google.com.hk/")
    End Sub

    Private Sub txtURL_TextChanged(sender As Object, e As EventArgs) Handles txtURL.TextChanged

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        WebView21.Source = New Uri("https://www.youtube.com.hk/")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        WebView21.Source = New Uri("https://lamevasalut.gencat.cat/web/cps/welcome/")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        WebView21.GoBack()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        WebView21.GoForward()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        WebView21.Refresh()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        WebView21.Source = New Uri("https://mail.google.com/mail/u/0/#inbox/")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Close()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        System.Diagnostics.Process.Start("C:\DWOLF45\DWOLF\fotos\\")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        System.Diagnostics.Process.Start("C:\DWOLF45\DWOLF\fotos\payaso.jpg\\")
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        WebView21.Source = New Uri("https://www.lavanguardia.com/")
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        WebView21.Source = New Uri("https://web.whatsapp.com/")
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        System.Diagnostics.Process.Start("C:\DWOLF45\Blocdenotaspropio\bin\Debug\net6.0-windows\blocdenotaspropio.exe\\")

    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        WebView21.Source = New Uri("https://earth.google.com/web/search//")
    End Sub
End Class
