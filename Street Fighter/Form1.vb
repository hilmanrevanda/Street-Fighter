Imports System.Drawing
Imports System.Math

Public Class Form1
    Private bg, Ryu, intro(9), standR(4), standL(4), crouchR(4), crouchL(4) As Bitmap

    Private indexIntro, indexStandR As Integer

    Private x As Integer '= 100
    Private y As Integer '= 100
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
    Sub SetStandR()
        standR(0) = My.Resources.standR0
        standR(1) = My.Resources.standR1
        standR(2) = My.Resources.standR2
        standR(3) = My.Resources.standR3
    End Sub
    Sub SetStandL()
        standL(0) = My.Resources.standL0
        standL(1) = My.Resources.standL1
        standL(2) = My.Resources.standL2
        standL(3) = My.Resources.standL3
    End Sub
    Sub SetCrouchR()
        crouchR(0) = My.Resources.crouchR0
        crouchR(1) = My.Resources.crouchR1
        crouchR(2) = My.Resources.crouchR2
        crouchR(3) = My.Resources.crouchR3
    End Sub
    Sub SetCrouchL()
        crouchL(0) = My.Resources.crouchL0
        crouchL(1) = My.Resources.crouchL1
        crouchL(2) = My.Resources.crouchL2
        crouchL(3) = My.Resources.crouchL3
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
        'set sprite on the bg to be black
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
        'give color to the black sprite
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

        bg = New Bitmap(My.Resources.background)
        Ryu = My.Resources.standR0

        'x = 100
        'y = 150

        indexIntro = 0
        indexStandR = 0
        SetIntro()
        SetStandR()

        Timer1.Interval = 2000
        Timer1.Interval = 2000

        PutSprite(bg, Ryu, x, y)
        pbcanvas.Image = bg

    End Sub

    Sub DrawAgain()

        bg = New Bitmap(My.Resources.background)
        ' x = 100
        'y = 150
        PutSprite(bg, Ryu, x, y)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Ryu = intro(indexIntro)

        If indexIntro > 7 Then
            Timer2.Enabled = True
            Timer1.Enabled = False
        End If

        indexIntro = indexIntro + 1

        DrawAgain()
        pbcanvas.Image = bg


    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Ryu = standR(indexStandR)
        indexStandR = indexStandR + 1

        DrawAgain()
        pbcanvas.Image = bg
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles pbPlay.Click
        pbPlay.Hide()
        Timer1.Start()
    End Sub
    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        End
    End Sub
End Class