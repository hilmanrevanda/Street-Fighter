Imports System.Drawing
Imports System.Math
Public Class Form1
    'sprites
    Private bg, Ryu, intro(9), standR(4), standL(4), crouch(7) As Bitmap
    'index of activity
    Private indexIntro, indexStandR, indexStandL, indexCrouch As Integer
    'what Ryu is doing
    Private doing As String
    'location of Ryu
    Dim x As Integer = 280
    Dim y As Integer = 140
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
    Sub SetCrouch()
        crouch(0) = My.Resources.crouchR0
        crouch(1) = My.Resources.crouchR1
        crouch(2) = My.Resources.crouchR2
        crouch(3) = My.Resources.crouchR3
        crouch(4) = My.Resources.crouchR3
        crouch(5) = My.Resources.crouchL3
        crouch(6) = My.Resources.crouchL3
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
        'set sprite on the bg to be black using and operation
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
        'give color to the black sprite using or operation
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
    Sub PlayLoopingBackgroundSoundFile()
        My.Computer.Audio.Play(My.Resources.sfmusic, AudioPlayMode.BackgroundLoop)
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PlayLoopingBackgroundSoundFile()

        indexIntro = 0
        indexStandR = 0
        indexStandR = 0
        indexCrouch = 0
        SetIntro()
        SetStandR()
        SetStandL()
        SetCrouch()

        Timer1.Interval = 100
        Timer2.Interval = 100

        bg = My.Resources.background
        pbcanvas.Image = bg
    End Sub
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Left Then
            doing = "walkL"
            If x = 35 Then
                x = 35
            Else
                x = x - 5
            End If

        ElseIf e.KeyCode = Keys.Right Then
            doing = "walkR"
            If x = 550 Then
                x = 550
            Else
                x = x + 5
            End If

        End If

        If e.KeyCode = Keys.Down Then doing = "crouch"
    End Sub
    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Down Then
            doing = "walkR"
        End If
    End Sub
    Sub ReDraw()
        bg = New Bitmap(My.Resources.background)
        PutSprite(bg, Ryu, x, y)
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Ryu = intro(indexIntro)

        If indexIntro > 7 Then
            Timer1.Enabled = False
            Timer2.Enabled = True
            doing = "walkR"
        End If

        indexIntro = indexIntro + 1

        ReDraw()
        pbcanvas.Image = bg
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If doing = "walkL" Then
            Ryu = standL(indexStandL)
            indexStandL = indexStandL + 1

        ElseIf doing = "walkR" Then
            Ryu = standR(indexStandR)

            indexStandR = indexStandR + 1
        ElseIf doing = "crouch" Then
            Ryu = crouch(indexCrouch)
            indexCrouch = indexCrouch + 1
            'If indexCrouch > 3 Then y = +20
        End If

        ReDraw()
        pbcanvas.Image = bg

        If indexStandR > 3 Then
            indexStandR = 0
        ElseIf indexStandL > 3 Then
            indexStandL = 0
        End If

        If indexCrouch > 6 Then
            indexCrouch = 4
        End If
    End Sub
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick

    End Sub
    Private Sub pbPlay_Click(sender As Object, e As EventArgs) Handles pbPlay.Click
        pbPlay.Hide()
        Timer1.Start()
        bg = New Bitmap(My.Resources.background)
        Ryu = My.Resources.standR0

        PutSprite(bg, Ryu, x, y)
    End Sub
    Private Sub pbExit_Click(sender As Object, e As EventArgs) Handles pbexit.Click
        My.Computer.Audio.Stop()
        Timer2.Stop()
        End
    End Sub
End Class