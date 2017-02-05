Option Explicit On
Option Strict On
Option Infer On

Public Class MainForm
    Dim canvas As Bitmap
    Dim graphics As Graphics

    Dim eyeballs As List(Of Eyeball) = New List(Of Eyeball)()

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        canvas = New Bitmap(MainPictureBox.Width, MainPictureBox.Height)
        graphics = Graphics.FromImage(canvas)

        eyeballs = New List(Of Eyeball)() From
        {
            New Eyeball(New RectangleF(10, 10, 70, 50), Color.Azure, Color.Black, Color.DarkBlue, graphics),
            New Eyeball(New RectangleF(90, 10, 70, 50), Color.Azure, Color.Black, Color.DarkBlue, graphics)
        }

        GameTimer.Start()
    End Sub

    Private Sub GameTimer_Tick(sender As Object, e As EventArgs) Handles GameTimer.Tick
        graphics.Clear(BackColor)

        For Each eyeball In eyeballs
            With eyeball
                .Update(PointToClient(Cursor.Position))
                .Draw()
            End With
        Next

        MainPictureBox.Image = canvas
    End Sub
End Class
