Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Math
Public Class Form1
    'sprites
    Private bg, Ryu, obsR, obsL, intro(9), standR(4), standL(4), crouchL(5), crouchR(5), JumpR(9), jumpL(9), hdkL(5), hdkR(5), beeL(6), beeR(6) As Bitmap
    'index of activity
    Private indexIntro, indexStandR, indexStandL, indexCrouch, indexJumpL, indexJumpR, indexBeeR, indexBeeL, indexHdkL, indexHdkR As Integer
    'what Ryu is doing
    Private doing As String
    Private facing As String
    Private DLEFT As String = "LEFT"
    Private DRIGHT As String = "RIGHT"
    Private Direction As String = "DRIGHT"
    'location of Ryu
    Dim Rx As Integer = 280
    Dim Ry As Integer = 130
    'location of obstacle
    Dim Bx As Integer = 500
    Dim By As Integer = 100

    'ryu box
    Public RyuBox As List(Of Point)

    'Enemies box
    Public EnemiesBoxFromRight As List(Of List(Of Point)) = New List(Of List(Of Point))
    Public EnemiesBoxFromLeft As List(Of List(Of Point)) = New List(Of List(Of Point))

    Sub Emove(ke As String)
        If (ke Is "Right") Then
            For i = 0 To EnemiesBoxFromLeft.Count - 1
                EnemiesBoxFromLeft(i) = GoMove(EnemiesBoxFromLeft(i), 1)
            Next
        Else
            For i = 0 To EnemiesBoxFromRight.Count - 1
                EnemiesBoxFromRight(i) = GoMove(EnemiesBoxFromRight(i), -1)
            Next
        End If
    End Sub

    Function GoMove(P As List(Of Point), count As Integer) As List(Of Point)
        Dim TempPoint As Point
        For index = 0 To P.Count - 1
            TempPoint = P(index)
            TempPoint.X = P(index).X + count
            P(index) = TempPoint
        Next
        Return P
    End Function

    Sub InitEnemyBox()
        Dim A As Point
        EnemiesBoxFromLeft = New List(Of List(Of Point))
        Dim box As List(Of Point) = New List(Of Point)
        A.X = 606
        A.Y = 133
        box.Add(A)
        A.X = 652
        A.Y = 133
        box.Add(A)
        A.X = 652
        A.Y = 221
        box.Add(A)
        A.X = 606
        A.Y = 221
        box.Add(A)
        EnemiesBoxFromLeft.Add(box)
    End Sub
    Sub InitRyuBox()
        Dim A As Point
        RyuBox = New List(Of Point)
        A.X = 343
        A.Y = 163
        RyuBox.Add(A)
        A.X = 398
        A.Y = 163
        RyuBox.Add(A)
        A.X = 398
        A.Y = 259
        RyuBox.Add(A)
        A.X = 343
        A.Y = 259
        RyuBox.Add(A)
    End Sub
    Private Sub Pbcanvas_MouseClick(sender As Object, e As MouseEventArgs) Handles pbcanvas.MouseClick
        Console.WriteLine(e.Location)
    End Sub
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
        crouchR(4) = My.Resources.crouchR3
    End Sub
    Sub SetCrouchL()
        crouchL(0) = My.Resources.crouchL0
        crouchL(1) = My.Resources.crouchL1
        crouchL(2) = My.Resources.crouchL2
        crouchL(3) = My.Resources.crouchL3
        crouchL(4) = My.Resources.crouchL3
    End Sub
    Sub SetJumpR()
        JumpR(0) = My.Resources.jump0
        JumpR(1) = My.Resources.jump1
        JumpR(2) = My.Resources.jump2
        JumpR(3) = My.Resources.jump3
        JumpR(4) = My.Resources.jump4
        JumpR(5) = My.Resources.jump5
        JumpR(6) = My.Resources.jump6
        JumpR(7) = My.Resources.jump7
        JumpR(8) = My.Resources.jump8
    End Sub
    Sub SetJumpL()
        jumpL(0) = My.Resources.jumpL0
        jumpL(1) = My.Resources.jumpL1
        jumpL(2) = My.Resources.jumpL2
        jumpL(3) = My.Resources.jumpL3
        jumpL(4) = My.Resources.jumpL4
        jumpL(5) = My.Resources.jumpL5
        jumpL(6) = My.Resources.jumpL6
        jumpL(7) = My.Resources.jumpL7
        jumpL(8) = My.Resources.jumpL8
    End Sub
    Sub SethdkL()
        hdkL(0) = My.Resources.hdkL0
        hdkL(1) = My.Resources.hdkL1
        hdkL(2) = My.Resources.hdkL2
        hdkL(3) = My.Resources.hdkL3
        hdkL(4) = My.Resources.hdkL4
    End Sub
    Sub SethdkR()
        hdkR(0) = My.Resources.hdkR0
        hdkR(1) = My.Resources.hdkR1
        hdkR(2) = My.Resources.hdkR2
        hdkR(3) = My.Resources.hdkR3
        hdkR(4) = My.Resources.hdkR4
    End Sub
    Sub SetBeeL()
        beeL(0) = My.Resources.bee0
        beeL(1) = My.Resources.bee1
        beeL(2) = My.Resources.bee2
        beeL(3) = My.Resources.bee3
        beeL(4) = My.Resources.bee4
        beeL(5) = My.Resources.bee5
    End Sub
    Sub SetBeeR()
        beeR(0) = My.Resources.beeR0
        beeR(1) = My.Resources.beeR1
        beeR(2) = My.Resources.beeR2
        beeR(3) = My.Resources.beeR3
        beeR(4) = My.Resources.beeR4
        beeR(5) = My.Resources.beeR5
    End Sub
    Sub PutSprite(c As Bitmap, d As Bitmap, x As Integer, y As Integer)
        Dim mask, sprite As Bitmap
        mask = MaskOf(d)
        sprite = SpriteOf(d)
        Spriteand(bg, mask, x, y)
        Spriteor(bg, sprite, x, y)
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
        'Bg = black
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

    Private Sub Pbcanvas_Paint(sender As Object, e As PaintEventArgs) Handles pbcanvas.Paint
        e.Graphics.DrawPolygon(Pens.Red, RyuBox.ToArray)

        For Each enemy In EnemiesBoxFromLeft
            e.Graphics.DrawPolygon(Pens.Blue, enemy.ToArray)
        Next
    End Sub

    Sub Spriteand(c As Bitmap, d As Bitmap, x As Integer, y As Integer)
        'set sprite on the bg to be black using and operation bcs d is mask
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
    Sub Spriteor(c As Bitmap, d As Bitmap, x As Integer, y As Integer)
        'give color to the black sprite using or operation bcs d is sprite(white)
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
        indexJumpL = 0
        indexJumpR = 0
        indexBeeL = 0
        indexBeeR = 0
        indexHdkR = 0
        indexHdkL = 0

        SetIntro()
        SetStandR()
        SetStandL()
        SetCrouchL()
        SetCrouchR()
        SetJumpR()
        SetJumpL()
        SetBeeL()
        SetBeeR()
        SethdkR()
        SethdkL()
        InitRyuBox()
        InitEnemyBox()
        'pbcanvas.Invalidate()

        Timer1.Interval = 50
        Timer2.Interval = 50
        Timer3.Interval = 50

        bg = My.Resources.background
        pbcanvas.Image = bg

        If doing = "walkR" Then facing = "right"
        If doing = "walkL" Then facing = "left"
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.A Then
            If Conditions() Then
                doing = "walkL"
                facing = "left"
            End If
            If Rx = 20 Then
                Rx = 20
            Else
                Rx = Rx - 10
                RyuBox = GoMove(RyuBox, -10)
                pbcanvas.Invalidate()
                Console.WriteLine(RyuBox.First.X)
                BoxsCheck()
            End If

        ElseIf e.KeyCode = Keys.Right Or e.KeyCode = Keys.D Then
            If Conditions() Then
                doing = "walkR"
                facing = "right"
            End If
            If Rx = 490 Then
                Rx = 490
            Else
                Rx = Rx + 10
                RyuBox = GoMove(RyuBox, 10)
                pbcanvas.Invalidate()
                Console.WriteLine(RyuBox.First.X)
                BoxsCheck()
            End If
        End If

        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.S Then
            doing = "crouch"
        End If

        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.W Then
            doing = "jump"
        End If
        '20 550
        If e.KeyCode = Keys.End Or e.KeyCode = Keys.E Then
            If Rx >= 470 Then
                doing = "jump"
            Else
                doing = "jumpFR"
            End If
        End If

        If e.KeyCode = Keys.Q Or e.KeyCode = Keys.ShiftKey Then
            If Rx <= 40 Then
                doing = "jump"
            Else
                doing = "jumpFL"
            End If
        End If
    End Sub

    Function Conditions() As Boolean
        If doing IsNot "jumpR" And doing IsNot "jumpR" And doing IsNot "crouch" Then Return True
        Return False
    End Function

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.W Then
            If facing = "right" Then doing = "walkR"
            If facing = "left" Then doing = "walkL"
            Ry = 130
        End If
    End Sub
    Sub ReDraw()
        bg = New Bitmap(My.Resources.background)
        PutSprite(bg, Ryu, Rx, Ry)

        If Timer3.Enabled = True Then
            PutSprite(bg, obsL, Bx, By)
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Ryu = intro(indexIntro)

        If indexIntro > 7 Then
            Timer1.Enabled = False
            Timer2.Enabled = True
            doing = "walkR"
            Timer3.Enabled = True
        End If

        indexIntro = indexIntro + 1

        ReDraw()
        pbcanvas.Image = bg
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'walks to left side
        If doing = "walkL" Then
            Ryu = standL(indexStandL)
            indexStandL = indexStandL + 1

            'walks to right side
        ElseIf doing = "walkR" Then
            Ryu = standR(indexStandR)
            indexStandR = indexStandR + 1

            'crouchs
        ElseIf doing = "crouch" Then
            'crouchs facing right
            If facing = "right" Then
                Ryu = crouchR(indexCrouch)
                indexCrouch = indexCrouch + 1
                'crouchs facing right
            ElseIf facing = "left" Then
                Ryu = crouchL(indexCrouch)
                indexCrouch = indexCrouch + 1
            End If
            If indexCrouch > 3 Then Ry = 158

            'jumps 
        ElseIf doing = "jump" Then
            'jumps facing right
            If facing = "right" Then
                Ryu = JumpR(indexJumpR)
                If indexJumpR > 7 Then
                    doing = "walkR"
                    indexJumpR = 0
                End If
                indexJumpR = indexJumpR + 1
                If indexJumpR = 2 Then Ry = Ry - 10
                If indexJumpR = 3 Or indexJumpR = 4 Or indexJumpR = 6 Then Ry = Ry - 15
                If indexJumpR = 5 Then Ry = Ry - 20
                If indexJumpR = 7 Then Ry = 130
                'jumps facing left
            ElseIf facing = "left" Then
                Ryu = jumpL(indexJumpL)
                If indexJumpL > 7 Then
                    doing = "walkL"
                    indexJumpL = 0
                End If
                indexJumpL = indexJumpL + 1
                If indexJumpL = 2 Then Ry = Ry - 10
                If indexJumpL = 3 Or indexJumpL = 4 Or indexJumpL = 6 Then Ry = Ry - 15
                If indexJumpL = 5 Then Ry = Ry - 20
                If indexJumpL = 7 Then Ry = 130
            End If

            'jumps forward to right side
        ElseIf doing = "jumpFR" Then
        Ryu = jumpL(indexJumpR)
        indexJumpR = indexJumpR + 1
            If indexJumpR = 2 Or indexJumpR = 3 Then
                Rx = Rx + 5
                Ry = Ry - 10
            End If
            If indexJumpR = 4 Or indexJumpR = 5 Then
                Rx = Rx + 10
                Ry = Ry - 15
            End If
            If indexJumpR = 6 Then
                Rx = Rx + 15
                Ry = Ry - 20
            End If
            If indexJumpR = 7 Then
                Rx = Rx + 20
                Ry = 130
            End If
        If indexJumpR > 7 Then
            doing = "walkR"
            indexJumpR = 0
        End If


        'jumps forward to left side
        ElseIf doing = "jumpFL" Then
        Ryu = jumpL(indexJumpL)
            indexJumpL = indexJumpL + 1
            If indexJumpL = 2 Or indexJumpL = 3 Then
                Rx = Rx - 5
                Ry = Ry - 10
            End If
            If indexJumpL = 4 Or indexJumpL = 5 Then
                Rx = Rx - 10
                Ry = Ry - 15
            End If
            If indexJumpL = 6 Then
                Rx = Rx - 15
                Ry = Ry - 20
            End If
            If indexJumpL = 7 Then
                Rx = Rx - 20
                Ry = 130
            End If
            If indexJumpL > 7 Then
                doing = "walkL"
                indexJumpL = 0
            End If
        End If


        ReDraw()
        pbcanvas.Image = bg

        If indexStandR > 3 Then
            indexStandR = 0
        ElseIf indexStandL > 3 Then
            indexStandL = 0
        End If

        If indexCrouch > 4 Then
            indexCrouch = 3
        End If

    End Sub
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        obsL = beeL(indexBeeL)
        obsR = beeR(indexBeeR)

        ReDraw()
        pbcanvas.Image = bg

        indexBeeL = indexBeeL + 1
        indexBeeR = indexBeeR + 1

        If indexBeeL > 4 Then indexBeeL = 0
        If indexBeeR > 4 Then indexBeeR = 0

    End Sub
    Private Sub PbPlay_Click(sender As Object, e As EventArgs) Handles PbPlay.Click
        PbPlay.Hide()
        Timer1.Start()
        bg = New Bitmap(My.Resources.background)
        Ryu = My.Resources.standR0
        obsL = My.Resources.bee0
        obsR = My.Resources.beeR0

        PutSprite(bg, Ryu, Rx, Ry)
    End Sub
    Private Sub PbExit_Click(sender As Object, e As EventArgs) Handles Pbexit.Click
        My.Computer.Audio.Stop()
        Timer2.Stop()
        Close()
    End Sub



    'check box

    Function BoxsCheck() As Point
        For Each Enemy In EnemiesBoxFromLeft
            If IsBoxClip(Enemy) Then
                Console.WriteLine("hit")
                MsgBox("HIT!!")
            Else
                Console.WriteLine("not hit")
            End If
        Next
    End Function

    Function IsBoxClip(Enemy As List(Of Point)) As Boolean
        Dim B, T As Integer
        Dim NP, NW As Point
        Dim IsAInside, IsBInside, TAisAcc, TBisAcc As Boolean

        'NewPolygon = New List(Of Point)()
        For A = 0 To RyuBox.Count - 1
            B = NextPoint(A, RyuBox.Count)

            For S = 0 To Enemy.Count - 1
                T = NextPoint(S, Enemy.Count)
                NW = Normal(Enemy(S), Enemy(T))
                NP = Normal(RyuBox(A), RyuBox(B))

                'Declare In Out
                IsAInside = InsidePoint(Enemy(S), Enemy(T), RyuBox(B))
                IsBInside = InsidePoint(Enemy(S), Enemy(T), RyuBox(A))

                If IsAInside = Not IsBInside Then
                    'Than In Out Validation
                    TAisAcc = TisAcc(Tis(RyuBox(A), RyuBox(B), Enemy(S), NW))
                    TBisAcc = TisAcc(Tis(Enemy(S), Enemy(T), RyuBox(A), NP))
                    If TAisAcc And TBisAcc Then Return True
                End If
            Next
        Next
        Return False
    End Function

    Function NextPoint(Point As Integer, Total As Integer) As Integer
        If Point + 1 = Total Then Return 0
        Return Point + 1
    End Function

    Function Normal(WA As Point, WB As Point) As Point
        Dim N As Point
        N.X = WB.Y - WA.Y
        N.Y = WB.X - WA.X
        N.Y = N.Y * -1 'Clockwise
        Return N
    End Function

    Function InsidePoint(WA As Point, WB As Point, S As Point) As Boolean
        Dim N As Point
        Dim D As Point

        N = Normal(WA, WB)

        D.X = (S.X - WA.X) * N.X
        D.Y = (S.Y - WA.Y) * N.Y

        Dim result = D.Y + D.X
        If result >= 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function Tis(A As Point, B As Point, P As Point, N As Point) As Decimal
        Return ((((P.X - A.X) * N.X) + ((P.Y - A.Y) * N.Y)) / (((B.X - A.X) * N.X) + ((B.Y - A.Y) * N.Y))) * 1.0
    End Function

    Function TisAcc(X As Decimal) As Boolean
        If X >= 0 And X <= 1 Then Return True
        Return False
    End Function
End Class