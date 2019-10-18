Public Class largeUI
    
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim newParams = MyBase.CreateParams
            newParams.ExStyle = newParams.ExStyle Or &H8000000 'WS_EX_NOACTIVATE
            Return newParams
        End Get
    End Property

    Private Sub largeUI_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        'Close Form1 to terminate the program
        Form1.Close()
    End Sub
    Private newpoint As System.Drawing.Point
    Private xpos1 As Integer
    Private ypos1 As Integer

    Private Sub pnlTopBorder_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown, Label1.MouseDown
        xpos1 = Control.MousePosition.X - Me.Location.X
        ypos1 = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub pnlTopBorder_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove, Label1.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= (xpos1)
            newpoint.Y -= (ypos1)
            Me.Location = newpoint
            If shortcuts.visable Then
                shortcuts.adjustThisFormLocation(newpoint)
            End If
            My.Settings.startPositionTop = Top
            My.Settings.startPositionLeft = Left
            My.Settings.numberOfMonitors = Screen.AllScreens.Length
            My.Settings.Save()

        End If
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, Label1.MouseUp
        Form1.saveSettings()
    End Sub
    Public Sub updateUIbyCharCode(charcode As String)

        If Form1.isSelecting Then
            'for selecting Mode only
            loadInterface("e")
            HideSmallLabels()
            Return
        End If

        If (charcode.Length = 0 And Form1.lastusedword = "") Then
            'Home page with lastusedword - display associate  char
            loadInterface("s")
            HideSmallLabels()
            HideLargeLabels()
            Return
        End If

        If (charcode.Length = 0 And Form1.lastusedword <> "") Then
            'Home page with no lastusedword
            loadInterface("c")
            HideLargeLabels()
            ShowSmallLabels()
            Return
        End If

        If (charcode.Length = 1) Then
            loadInterface(charcode)
            HideSmallLabels()
            HideLargeLabels()
            Return
        End If

        If (charcode.Length = 2) Then
            'Char with two parts
            loadInterface("n")
            HideSmallLabels()
            HideLargeLabels()
        End If

        'no need for charcode.Length = 3 because if charcode.Length = 3 , it will in selecting mode
    End Sub

    Public Sub HideLargeLabels()
        l1.Text = ""
        l2.Text = ""
        l3.Text = ""
        l4.Text = ""
        l5.Text = ""
        l6.Text = ""
        l7.Text = ""
        l8.Text = ""
        l9.Text = ""
    End Sub
    Public Sub HideSmallLabels()
        s1.Visible = False
        s2.Visible = False
        s3.Visible = False
        s4.Visible = False
        s5.Visible = False
        s6.Visible = False
        s7.Visible = False
        s8.Visible = False
        s9.Visible = False
    End Sub
    Public Sub ShowSmallLabels()
        s1.Visible = True
        s2.Visible = True
        s3.Visible = True
        s4.Visible = True
        s5.Visible = True
        s6.Visible = True
        s7.Visible = True
        s8.Visible = True
        s9.Visible = True
    End Sub

    Private Sub loadInterface(key As String)
        Dim path As String = IO.Path.GetTempPath.ToString & "cyinput\lui\"
        PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(path & "cyi_" & key & ".png")
    End Sub

    Private Sub largeUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HideLargeLabels()
        HideSmallLabels()
        s1.Location = PictureBox2.PointToClient(Me.PointToScreen(s1.Location))
        s1.Parent = PictureBox2
        s2.Location = PictureBox2.PointToClient(Me.PointToScreen(s2.Location))
        s2.Parent = PictureBox2
        s3.Location = PictureBox2.PointToClient(Me.PointToScreen(s3.Location))
        s3.Parent = PictureBox2
        s4.Location = PictureBox2.PointToClient(Me.PointToScreen(s4.Location))
        s4.Parent = PictureBox2
        s5.Location = PictureBox2.PointToClient(Me.PointToScreen(s5.Location))
        s5.Parent = PictureBox2
        s6.Location = PictureBox2.PointToClient(Me.PointToScreen(s6.Location))
        s6.Parent = PictureBox2
        s7.Location = PictureBox2.PointToClient(Me.PointToScreen(s7.Location))
        s7.Parent = PictureBox2
        s8.Location = PictureBox2.PointToClient(Me.PointToScreen(s8.Location))
        s8.Parent = PictureBox2
        s9.Location = PictureBox2.PointToClient(Me.PointToScreen(s9.Location))
        s9.Parent = PictureBox2
        l1.Location = PictureBox2.PointToClient(Me.PointToScreen(l1.Location))
        l1.Parent = PictureBox2
        l2.Location = PictureBox2.PointToClient(Me.PointToScreen(l2.Location))
        l2.Parent = PictureBox2
        l3.Location = PictureBox2.PointToClient(Me.PointToScreen(l3.Location))
        l3.Parent = PictureBox2
        l4.Location = PictureBox2.PointToClient(Me.PointToScreen(l4.Location))
        l4.Parent = PictureBox2
        l5.Location = PictureBox2.PointToClient(Me.PointToScreen(l5.Location))
        l5.Parent = PictureBox2
        l6.Location = PictureBox2.PointToClient(Me.PointToScreen(l6.Location))
        l6.Parent = PictureBox2
        l7.Location = PictureBox2.PointToClient(Me.PointToScreen(l7.Location))
        l7.Parent = PictureBox2
        l8.Location = PictureBox2.PointToClient(Me.PointToScreen(l8.Location))
        l8.Parent = PictureBox2
        l9.Location = PictureBox2.PointToClient(Me.PointToScreen(l9.Location))
        l9.Parent = PictureBox2
        l10.Location = PictureBox2.PointToClient(Me.PointToScreen(l10.Location))
        l10.Parent = PictureBox2
        l11.Location = PictureBox2.PointToClient(Me.PointToScreen(l11.Location))
        l11.Parent = PictureBox2

        If My.Computer.Info.OSVersion = "6.2.9200.0" And My.Computer.Info.OSFullName.Contains("Windows 8.1") Then
            'Unknown reason caused all items to shift left on this version of Windows 8.1. Fixing it with exceptional patches
            ApplyWin8ThemeBugPatch()
        End If

        'Load system theme color from settings.
        Panel3.BackColor = My.Settings.themeColor
        Panel1.BackColor = My.Settings.themeColor
    End Sub

    Private Sub ApplyWin8ThemeBugPatch()
        shiftAllLabels(18, 0)

    End Sub

    Private Sub shiftAllLabels(x As Integer, y As Integer)
        l1.Top += y
        l2.Top += y
        l3.Top += y
        l4.Top += y
        l5.Top += y
        l6.Top += y
        l7.Top += y
        l8.Top += y
        l9.Top += y

        l1.Left += x
        l2.Left += x
        l3.Left += x
        l4.Left += x
        l5.Left += x
        l6.Left += x
        l7.Left += x
        l8.Left += x
        l9.Left += x
    End Sub
    
    Private Sub Panel1_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel1.MouseClick

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub l_MouseDown(sender As Object, e As MouseEventArgs) Handles l1.MouseDown, l2.MouseDown, l3.MouseDown, l4.MouseDown, l5.MouseDown, l6.MouseDown, l7.MouseDown, l8.MouseDown, l9.MouseDown
        If e.Button = MouseButtons.Left Then
            Select Case sender.Tag
                Case "1"
                    Form1.HandleHotkey(97)
                Case "2"
                    Form1.HandleHotkey(98)
                Case "3"
                    Form1.HandleHotkey(99)
                Case "4"
                    Form1.HandleHotkey(100)
                Case "5"
                    Form1.HandleHotkey(101)
                Case "6"
                    Form1.HandleHotkey(102)
                Case "7"
                    Form1.HandleHotkey(103)
                Case "8"
                    Form1.HandleHotkey(104)
                Case "9"
                    Form1.HandleHotkey(105)
            End Select
        End If
        If e.Button = MouseButtons.Right And Form1.isSelecting = True Then
            Dim labelString As String = sender.Text.ToString.Trim
            Form1.enterHomophonicMode(labelString)
        End If
    End Sub

        Private Sub l10_MouseDown(sender As Object, e As MouseEventArgs) Handles l10.MouseDown
        If e.Button = MouseButtons.Left Then
            Form1.HandleHotkey(96)
        End If
    End Sub

    Private Sub l11_MouseDown(sender As Object, e As MouseEventArgs) Handles l11.MouseDown
        If e.Button = MouseButtons.Left Then
            Form1.HandleHotkey(110)
        End If
    End Sub

    Private Sub s_MouseDown(sender As Object, e As MouseEventArgs) Handles s1.MouseDown, s2.MouseDown, s3.MouseDown, s4.MouseDown, s5.MouseDown, s6.MouseDown, s7.MouseDown, s8.MouseDown, s9.MouseDown
        If e.Button = MouseButtons.Left Then
            Dim labelString As String = sender.Text.ToString.Trim
            Form1.SendAssoWord(labelString)
        End If
    End Sub

    Private Sub Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseClick
        'Dock to the bottom right hand corner of the primary screen when pressing the top right corner arrow
        Dim dockLocation As Integer = My.Settings.dockingLocation
        If (dockLocation = 0) Then
            BottomRightDock()
        ElseIf dockLocation = 1 Then
            BottomLeftDock()
        ElseIf dockLocation = 2 Then
            TopRightDock()
        ElseIf dockLocation = 3 Then
            TopLeftDock()
        End If

    End Sub

    'Docking Functions for docking the form to different corner of the screen
    Private Sub TopLeftDock()
        Location = New Point(0, 0)
    End Sub

    Private Sub BottomRightDock()
        Dim intX As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim intY As Integer = Screen.PrimaryScreen.Bounds.Height
        Location = New Point(intX - Width, intY - Height)
    End Sub

    Private Sub BottomLeftDock()
        Dim intX As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim intY As Integer = Screen.PrimaryScreen.Bounds.Height
        Location = New Point(0, intY - Height)
    End Sub

    Private Sub TopRightDock()
        Dim intX As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim intY As Integer = Screen.PrimaryScreen.Bounds.Height
        Location = New Point(intX - Me.Width, 0)
    End Sub

End Class
