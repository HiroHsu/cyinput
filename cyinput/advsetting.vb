Public Class advsetting
    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click
        'Me.BackColor = Color.FromArgb(117, 123, 56)
    End Sub

    'Real time update the preview color if there are changes
    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        Panel3.BackColor = Color.FromArgb(NumericUpDown1.Value, NumericUpDown2.Value, NumericUpDown3.Value)
    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        Panel3.BackColor = Color.FromArgb(NumericUpDown1.Value, NumericUpDown2.Value, NumericUpDown3.Value)
    End Sub

    Private Sub NumericUpDown3_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown3.ValueChanged
        Panel3.BackColor = Color.FromArgb(NumericUpDown1.Value, NumericUpDown2.Value, NumericUpDown3.Value)
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            My.Settings.themeColor = Panel1.BackColor
            My.Settings.Save()
            Form1.saveSettings()
        End If

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            My.Settings.themeColor = Panel2.BackColor
            My.Settings.Save()
            Form1.saveSettings()
        End If

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            My.Settings.themeColor = Panel6.BackColor
            My.Settings.Save()
            Form1.saveSettings()
        End If

    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked = True Then
            My.Settings.themeColor = Panel7.BackColor
            My.Settings.Save()
            Form1.saveSettings()
        End If

    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        If RadioButton5.Checked Then
            My.Settings.themeColor = Color.FromArgb(NumericUpDown1.Value, NumericUpDown2.Value, NumericUpDown3.Value)
            My.Settings.Save()
            Form1.saveSettings()
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.themeColor = Color.FromArgb(NumericUpDown1.Value, NumericUpDown2.Value, NumericUpDown3.Value)
        My.Settings.Save()
        Form1.saveSettings()
    End Sub

    Private Sub clearAllThemeColorSelection()
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        RadioButton5.Checked = False
    End Sub

    Private Sub Advsetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Initialize the theme color selection
        Dim defaultBackColor As Color = My.Settings.themeColor
        If defaultBackColor.Equals(Panel1.BackColor) Then
            clearAllThemeColorSelection()
            RadioButton1.Checked = True
        ElseIf defaultBackColor.Equals(Panel2.BackColor) Then
            clearAllThemeColorSelection()
            RadioButton2.Checked = True
        ElseIf defaultBackColor.Equals(Panel6.BackColor) Then
            clearAllThemeColorSelection()
            RadioButton3.Checked = True
        ElseIf defaultBackColor.Equals(Panel7.BackColor) Then
            clearAllThemeColorSelection()
            RadioButton4.Checked = True
        Else
            NumericUpDown1.Value = defaultBackColor.R
            NumericUpDown2.Value = defaultBackColor.G
            NumericUpDown3.Value = defaultBackColor.B
            clearAllThemeColorSelection()
            RadioButton5.Checked = True
        End If

        'Load the shortcut key words from setting
        TextBox1.Text = My.Settings.shortcutKeywords
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Settings.shortcutKeywords = TextBox1.Text
        My.Settings.Save()
        Form1.saveSettings()
        Label4.Visible = True
        hideMessage.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Settings.shortcutKeywords = "屌柒閪嗰囖噏啲喺㗎"
        My.Settings.Save()
        Form1.saveSettings()
        TextBox1.Text = My.Settings.shortcutKeywords
        Label4.Visible = True
        hideMessage.Enabled = True
    End Sub

    Private Sub HideMessage_Tick(sender As Object, e As EventArgs) Handles hideMessage.Tick
        hideMessage.Enabled = False
        Label4.Visible = False
    End Sub
End Class