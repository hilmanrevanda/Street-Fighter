Imports System.Drawing
Imports System.Math

Public Class Form1
    Private bg, Ryu, intro(9), stand(4) As Bitmap


    Private indexIntro, indexStand As Integer
    Sub SetIntro()
        intro(0) = My.Resources.intro0
        intro(1) = My.Resources.intro1
        intro(2) = My.Resources.intro2
        intro(3) = My.Resources.intro3
        intro(4) = My.Resources.intro4
        intro(5) = My.Resources.intro5
        intro(6) = My.Resources.intro6
        intro(7) = My.Resources.intro7
        intro(8) = My.Resources.intro8
    End Sub

    Sub SetStand()
        stand(0) = My.Resources.stand0
        stand(1) = My.Resources.stand1
        stand(2) = My.Resources.stand2
        stand(3) = My.Resources.stand3

    End Sub
    Sub PutSprite(c As Bitmap, d As Bitmap, x As Integer, y As Integer)
        Dim mask, sprite As Bitmap
        mask = MaskOf(d)
        sprite = SpriteOf(d)
        spriteand(bg, mask, x, y)
        spriteor(bg, sprite, x, y)
    End Sub
    Function MaskOf(b As Bitmap) As Bitmap
        'Bg = white, sprite = black
        Dim a As Bitmap
        Dim c As Color
        Dim i, j As Integer

        a = b.Clone
        c = a.GetPixel(0, 0) ' color of bg of sprite
        For i = 0 To b.Width - 1
            For j = 0 To b.Height - 1
                If a.GetPixel(i, j) = c Then
                    a.SetPixel(i, j, Color.White)
                Else
                    a.SetPixel(i, j, Color.Black)
                End If
            Next
        Next

        Return a
    End Function
    Function SpriteOf(b As Bitmap) As Bitmap
        'Bg = black, sprite = white
        Dim a As Bitmap
        Dim c As Color
        Dim i, j As Integer

        a = b.Clone
        c = a.GetPixel(0, 0) ' color of bg of sprite
        For i = 0 To b.Width - 1
            For j = 0 To b.Height - 1
                If a.GetPixel(i, j) = c Then
                    a.SetPixel(i, j, Color.Black)
                End If
            Next
        Next

        Return a
    End Function
    Sub spriteand(c As Bitmap, d As Bitmap, x As Integer, y As Integer)
        Dim i, j, a, r, g, b As Integer

        For i = 0 To d.Width - 1
            For j = 0 To d.Height - 1
                a = c.GetPixel(i + x, j + y).A And d.GetPixel(i, j).A
                r = c.GetPixel(i + x, j + y).R And d.GetPixel(i, j).R
                g = c.GetPixel(i + x, j + y).G And d.GetPixel(i, j).G
                b = c.GetPixel(i + x, j + y).B And d.GetPixel(i, j).B
                c.SetPixel(i + x, j + y, Color.FromArgb(a, r, g, b))
            Next
        Next
    End Sub
    Sub spriteor(c As Bitmap, d As Bitmap, x As Integer, y As Integer)
        Dim i, j, a, r, g, b As Integer

        For i = 0 To d.Width - 1
            For j = 0 To d.Height - 1
                a = c.GetPixel(i + x, j + y).A Or d.GetPixel(i, j).A
                r = c.GetPixel(i + x, j + y).R Or d.GetPixel(i, j).R
                g = c.GetPixel(i + x, j + y).G Or d.GetPixel(i, j).G
                b = c.GetPixel(i + x, j + y).B Or d.GetPixel(i, j).B
                c.SetPixel(i + x, j + y, Color.FromArgb(a, r, g, b))
            Next
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x, y As Integer
        x = 100
        y = 100

        bg = New Bitmap(My.Resources.background)
        Ryu = My.Resources.stand0

        indexIntro = 0
        SetIntro()

        Timer1.Interval = 100
        Timer1.Start()
        PutSprite(bg, Ryu, x, y)
        pbcanvas.Image = bg

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        End
    End Sub

    Sub DrawAgain()
        Dim x, y As Integer
        bg = New Bitmap(My.Resources.background)

        PutSprite(bg, Ryu, x, y)


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Ryu = intro(indexIntro)
        indexIntro = indexIntro + 1
        indexStand = indexStand + 1

        If indexIntro > 7 Then Ryu = stand(indexStand)

        DrawAgain()
        pbcanvas.Image = bg


    End Sub

End Class