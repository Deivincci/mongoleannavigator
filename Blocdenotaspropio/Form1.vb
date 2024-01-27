Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.IO
Imports System.Windows.Forms

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CenterToScreen()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.WindowState = FormWindowState.Normal
        Try
            ComboBox1.Items.Clear()


            For Each fuentes As FontFamily In FontFamily.Families
                Dim tipo As String
                tipo = fuentes.Name
                ComboBox1.Items.Add(tipo)
            Next
            Try
                ComboBox1.Text = "Calibri"
            Catch ex As Exception
                ComboBox1.SelectedIndex = 0
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ComboBox1.DrawItem
        e.DrawBackground()
        Dim texto As String = ComboBox1.Items(e.Index).ToString
        Dim fon As New Font(texto, e.Font.Size)

        e.Graphics.DrawString(texto, fon, New SolidBrush(e.ForeColor), e.Bounds.Left + 2, e.Bounds.Top + 2)
        e.DrawFocusRectangle()

    End Sub
    Dim negrilla As Boolean = False
    Dim cursiva As Boolean = False
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        If negrilla = False Then
            RichTextBox1.SelectionFont = New Font(ComboBox1.Text, Int(TextBox1.Text), FontStyle.Bold)
            Label2.ForeColor = Color.Chocolate
            negrilla = True
        Else
            RichTextBox1.SelectionFont = New Font(ComboBox1.Text, Int(TextBox1.Text), FontStyle.Regular)
            Label2.ForeColor = Color.White
            negrilla = False
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Try
            If cursiva = True Then
                RichTextBox1.SelectionFont = New Font(ComboBox1.Text, Int(TextBox1.Text), FontStyle.Italic)
                Label2.ForeColor = Color.Chocolate
                cursiva = False
            Else
                RichTextBox1.SelectionFont = New Font(ComboBox1.Text, Int(TextBox1.Text), FontStyle.Regular)
                Label2.ForeColor = Color.White
                cursiva = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            If negrilla = True Then
                RichTextBox1.SelectionFont = New Font(ComboBox1.Text, Int(TextBox1.Text), FontStyle.Bold)
            Else
                RichTextBox1.SelectionFont = New Font(ComboBox1.Text, Int(TextBox1.Text), FontStyle.Regular)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Try
            Dim dlg As ColorDialog = New ColorDialog
            dlg.Color = RichTextBox1.SelectionColor
            If dlg.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                RichTextBox1.SelectionColor = dlg.Color

                PictureBox1.BackColor = dlg.Color
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Label4.Text = TrackBar1.Value * 100 & "%"
        RichTextBox1.ZoomFactor = TrackBar1.Value
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub CopiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiarToolStripMenuItem.Click
        RichTextBox1.Copy()
    End Sub

    Private Sub CortarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CortarToolStripMenuItem.Click
        RichTextBox1.Cut()
    End Sub

    Private Sub PegarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PegarToolStripMenuItem.Click
        RichTextBox1.Paste()
    End Sub

    Private Sub SeleccionarTodoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeleccionarTodoToolStripMenuItem.Click
        RichTextBox1.SelectAll()
    End Sub

    Private Sub DeshacerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeshacerToolStripMenuItem.Click
        RichTextBox1.Undo()
    End Sub

    Private Sub RehacerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RehacerToolStripMenuItem.Click
        RichTextBox1.Redo()
    End Sub

    Private Sub CopiarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CopiarToolStripMenuItem1.Click
        RichTextBox1.Copy()
    End Sub

    Private Sub CortarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CortarToolStripMenuItem1.Click
        RichTextBox1.Cut()
    End Sub

    Private Sub PegarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PegarToolStripMenuItem1.Click
        RichTextBox1.Paste()
    End Sub

    Private Sub SeleccionarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeleccionarToolStripMenuItem.Click
        RichTextBox1.SelectAll()
    End Sub

    Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem.Click
        RichTextBox1.Clear()
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        Dim save As New SaveFileDialog()
        Dim myStreamwriter As System.IO.StreamWriter
        save.Filter = "text (*.txt)|*.txt|Html(*.html*)|*.html|php(*.php*)|*.php*|All Files(*.*)|*.*"
        save.CheckPathExists = True
        save.Title = "Guardar como"
        save.ShowDialog(Me)
        Try
            myStreamwriter = System.IO.File.AppendText(save.FileName)
            myStreamwriter.Write(RichTextBox1.Text)
            myStreamwriter.Flush()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AbrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirToolStripMenuItem.Click
        Dim Open As New OpenFileDialog()
        Dim myStreamReader As System.IO.StreamReader
        Open.Filter = "Texto [*.txt]|*.txt*|all files(*.*)|*.*"
        Open.CheckPathExists = True
        Open.Title = "Abrir Archivo"
        Open.ShowDialog(Me)
        Try
            Open.OpenFile()
            myStreamReader = System.IO.File.OpenText(Open.FileName)
            RichTextBox1.Text = myStreamReader.ReadToEnd()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        End
    End Sub
    Dim estado As Integer = 0
    Private Sub RichTextBox1_SelectionChanged(sender As Object, e As EventArgs)
        Try
            ComboBox1.Text = RichTextBox1.SelectionFont.Name
            TextBox1.Text = RichTextBox1.SelectionFont.Size
            estado = RichTextBox1.SelectionFont.Style
            If estado = 0 Then
                Label2.ForeColor = Color.White
                Label3.ForeColor = Color.White
            ElseIf estado = 1 Then
                Label2.ForeColor = Color.Chocolate
                Label3.ForeColor = Color.White
            ElseIf estado = 2 Then
                Label2.ForeColor = Color.White
                Label3.ForeColor = Color.Chocolate
            End If
            PictureBox1.BackColor = RichTextBox1.SelectionColor

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrintDocument1.Print()
        'En teoria ya tendria que funcionar...
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If RichTextBox1.Text = "" Then
            MsgBox("Tiene que tener algo escrito el formulario para poder ver una preimpresion")
        Else
            PrintPreviewDialog1.ShowDialog()
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim font1 As New Font("arial", 16, FontStyle.Regular)
        e.Graphics.DrawString(RichTextBox1.Text, font1, Brushes.Black, 100, 100)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim save As New SaveFileDialog()
        Dim myStreamwriter As System.IO.StreamWriter
        save.Filter = "text (*.txt)|*.txt|Html(*.html*)|*.html|php(*.php*)|*.php*|All Files(*.*)|*.*"
        save.CheckPathExists = True
        save.Title = "Guardar como"
        save.ShowDialog(Me)
        Try
            myStreamwriter = System.IO.File.AppendText(save.FileName)
            myStreamwriter.Write(RichTextBox1.Text)
            myStreamwriter.Flush()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim Open As New OpenFileDialog()
        Dim myStreamReader As System.IO.StreamReader
        Open.Filter = "Texto [*.txt]|*.txt*|all files(*.*)|*.*"
        Open.CheckPathExists = True
        Open.Title = "Abrir Archivo"
        Open.ShowDialog(Me)
        Try
            Open.OpenFile()
            myStreamReader = System.IO.File.OpenText(Open.FileName)
            RichTextBox1.Text = myStreamReader.ReadToEnd()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        RichTextBox1.Clear()
    End Sub
End Class
