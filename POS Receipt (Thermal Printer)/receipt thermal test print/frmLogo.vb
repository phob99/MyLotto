Public Class frmLogo

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Settings.Logo = TextBox1.Text
        My.Settings.Save()

        Form1.PictureBox1.ImageLocation = My.Settings.Logo
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Dim openfiledialog1 As New OpenFileDialog
        openfiledialog1.ShowDialog()
        TextBox1.Text = openfiledialog1.FileName
        PictureBox1.ImageLocation = openfiledialog1.FileName
    End Sub

    Private Sub frmLogo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PictureBox1.ImageLocation = My.Settings.Logo
    End Sub
End Class