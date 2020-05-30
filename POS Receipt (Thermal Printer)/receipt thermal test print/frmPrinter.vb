Public Class frmPrinter
    Private Sub frmPrinter_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        My.Settings.Printer = txtPrinter.Text
        My.Settings.Save()
    End Sub

    Private Sub frmPrinter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtPrinter.Text = My.Settings.Printer
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If PrintDLG.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        txtPrinter.Text = PrintDLG.PrinterSettings.PrinterName
        'PopupSucess.Show()
        'PopupSucess.Label1.Text = "PRINTER"
        'PopupSucess.lbl_text.Text = "Emri i printerit: " & PrintDLG.PrinterSettings.PrinterName
    End Sub
End Class