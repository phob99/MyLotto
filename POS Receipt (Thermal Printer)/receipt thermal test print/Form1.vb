
Imports System.IO
Imports System.Runtime.InteropServices

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        PictureBox1.ImageLocation = My.Settings.Logo
        PicBarCode.BackgroundImage = Code128(txtNR.Text, "A")

        Panel1.Height = GVReceipt.Height + 220

        GridSettings()

        GVReceipt.Columns(0).Name = "Name"
        GVReceipt.Columns(1).Name = "Qty"
        GVReceipt.Columns(2).Name = "Price"

        GVReceipt.Columns(0).Width = 50
        GVReceipt.Columns(1).Width = 15
        GVReceipt.Columns(2).Width = 50

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim rnum As Integer = GVReceipt.Rows.Add()
        GVReceipt.Rows.Item(rnum).Cells(0).Value = txtName.Text
        GVReceipt.Rows.Item(rnum).Cells(1).Value = txtQty.Text
        GVReceipt.Rows.Item(rnum).Cells(2).Value = txtPrice.Text

        Dim rnum2 As Integer = GVProduct.Rows.Add()
        GVProduct.Rows.Item(rnum2).Cells(0).Value = txtName.Text
        GVProduct.Rows.Item(rnum2).Cells(1).Value = txtQty.Text
        GVProduct.Rows.Item(rnum2).Cells(2).Value = txtPrice.Text

        GridSettings()
        Calc()

        txtName.Clear()
        txtQty.Clear()
        txtPrice.Clear()

        txtName.Focus()
    End Sub

    Private Sub resizeDGV()
        GVReceipt.Height = GVReceipt.ColumnHeadersHeight + GVReceipt.Rows.Cast(Of DataGridViewRow).Sum(Function(r) r.Height)

        Panel1.Height = GVReceipt.Height + 220
        GVReceipt.ClearSelection()

    End Sub

    Private Sub Calc()
        Dim total As Integer = 0
        For index As Integer = 0 To GVReceipt.RowCount - 1
            total += Convert.ToDouble(GVReceipt.Rows(index).Cells(2).Value.ToString)
        Next
        Label4.Text = total.ToString()
    End Sub

    Private Sub GridSettings()
        GVReceipt.ScrollBars = ScrollBars.None
        GVReceipt.ClearSelection()

        GVReceipt.RowHeadersVisible = False
        GVReceipt.ColumnCount = 3

        GVReceipt.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        GVReceipt.CellBorderStyle = DataGridViewCellBorderStyle.None

    End Sub

    Private Sub GVReceipt_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles GVReceipt.RowsAdded
        resizeDGV()
    End Sub

    Private Sub GVReceipt_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles GVReceipt.RowsRemoved
        resizeDGV()
    End Sub

    Private Sub PrintDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage
        Dim bm As New Bitmap(Me.Panel1.Width, Me.Panel1.Height)

        Panel1.DrawToBitmap(bm, New Rectangle(0, 0, Me.Panel1.Width, Me.Panel1.Height))

        e.Graphics.DrawImage(bm, 0, 0)

        Dim aPS As New PageSetupDialog
        aPS.Document = PrintDoc
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click


        Dim GS As String = Convert.ToString(Convert.ToChar(29))
        Dim ESC As String = Convert.ToString(Convert.ToChar(27))

        Dim Command As String = ""
        Command = ESC + "@"
        Command += GS + "V" + Convert.ToChar(1)

        PrintDoc.PrinterSettings.PrinterName = My.Settings.Printer

        PrintDoc.Print()

        RawPrinterHelper.SendStringToPrinter(PrintDoc.PrinterSettings.PrinterName, GiftReceipt)
        RawPrinterHelper.SendStringToPrinter(PrintDoc.PrinterSettings.PrinterName, Command)
        GVReceipt.Rows.Clear()
        GVProduct.Rows.Clear()

        Calc()
    End Sub

    Private Sub PrinterSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrinterSetupToolStripMenuItem.Click
        frmPrinter.ShowDialog()
    End Sub

    Private Sub LogoSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoSetupToolStripMenuItem.Click
        frmLogo.ShowDialog()
    End Sub
    Public Function GiftReceipt() As String

        Try

            Dim displayString As String
            Dim ESC As String = Chr(&H1B) + "a" + Chr(0)
            Dim ESC2 As String = Chr(&H1B) + "@"
            Dim ESC1 As String = Chr(&H1B) + "a" + Chr(1) 'Allign Middle
            Dim ESC4 As String = Chr(&H1B) + "a" + Chr(2) 'Allign right
            Dim ESC5 As String = Chr(&H1B) + "!" + Chr(17) ' Double hight font mode
            Dim ESC6 As String = Chr(&H1B) + "!" + Chr(1) ' Cancel Double hight font mode


            displayString = vbNewLine
            displayString += ESC1 + ESC5 + ESC6 + vbNewLine
            displayString += ESC1 + "สมภพ สระทองอินทร์ Rd, Bandaragama." + vbNewLine
            displayString += ESC1 + "Cash Receipt" + vbNewLine
            displayString += "---------------------------------------"
            displayString += vbNewLine
            displayString += ESC + "Transaction #:"
            displayString += ESC + vbNewLine
            displayString += "Date: " + Date.Today() + vbTab.ToString() + "Time: "
            displayString += DateAndTime.Now().ToLongTimeString() + ESC
            displayString += ESC + vbNewLine

            displayString += "Cashier: " + vbTab.ToString()
            displayString += vbNewLine
            displayString += "Customer: "
            displayString += vbNewLine
            displayString += "Memo: "
            displayString += vbNewLine
            displayString += "---------------------------------------"
            displayString += vbNewLine
            displayString += ESC + "# " + "Item" + vbTab.ToString() + "Rate" + vbTab.ToString() + "Qty" + vbTab.ToString() + "Total" + vbTab.ToString() + "Desc."
            displayString += vbNewLine
            displayString += "---------------------------------------"
            displayString += vbNewLine
            GiftReceipt = displayString





        Catch ex As Exception


        End Try

    End Function
End Class
Public Class RawPrinterHelper
    ' Structure and API declarions:
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Structure DOCINFOW
        <MarshalAs(UnmanagedType.LPWStr)> Public pDocName As String
        <MarshalAs(UnmanagedType.LPWStr)> Public pOutputFile As String
        <MarshalAs(UnmanagedType.LPWStr)> Public pDataType As String
    End Structure

    <DllImport("winspool.Drv", EntryPoint:="OpenPrinterW",
       SetLastError:=True, CharSet:=CharSet.Unicode,
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function OpenPrinter(ByVal src As String, ByRef hPrinter As IntPtr, ByVal pd As Long) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="ClosePrinter",
       SetLastError:=True, CharSet:=CharSet.Unicode,
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function ClosePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="StartDocPrinterW",
       SetLastError:=True, CharSet:=CharSet.Unicode,
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function StartDocPrinter(ByVal hPrinter As IntPtr, ByVal level As Int32, ByRef pDI As DOCINFOW) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="EndDocPrinter",
       SetLastError:=True, CharSet:=CharSet.Unicode,
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function EndDocPrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="StartPagePrinter",
       SetLastError:=True, CharSet:=CharSet.Unicode,
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function StartPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="EndPagePrinter",
       SetLastError:=True, CharSet:=CharSet.Unicode,
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function EndPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="WritePrinter",
       SetLastError:=True, CharSet:=CharSet.Unicode,
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function WritePrinter(ByVal hPrinter As IntPtr, ByVal pBytes As IntPtr, ByVal dwCount As Int32, ByRef dwWritten As Int32) As Boolean
    End Function

    ' SendBytesToPrinter()
    ' When the function is given a printer name and an unmanaged array of  
    ' bytes, the function sends those bytes to the print queue.
    ' Returns True on success or False on failure.
    Public Shared Function SendBytesToPrinter(ByVal szPrinterName As String, ByVal pBytes As IntPtr, ByVal dwCount As Int32) As Boolean
        Dim hPrinter As IntPtr      ' The printer handle.
        Dim dwError As Int32        ' Last error - in case there was trouble.
        Dim di As DOCINFOW          ' Describes your document (name, port, data type).
        Dim dwWritten As Int32      ' The number of bytes written by WritePrinter().
        Dim bSuccess As Boolean     ' Your success code.

        ' Set up the DOCINFO structure.
        With di
            .pDocName = "My Visual Basic .NET RAW Document"
            .pDataType = "RAW"
        End With
        ' Assume failure unless you specifically succeed.
        bSuccess = False
        If OpenPrinter(szPrinterName, hPrinter, 0) Then
            If StartDocPrinter(hPrinter, 1, di) Then
                If StartPagePrinter(hPrinter) Then
                    ' Write your printer-specific bytes to the printer.
                    bSuccess = WritePrinter(hPrinter, pBytes, dwCount, dwWritten)
                    EndPagePrinter(hPrinter)
                End If
                EndDocPrinter(hPrinter)
            End If
            ClosePrinter(hPrinter)
        End If
        ' If you did not succeed, GetLastError may give more information
        ' about why not.
        If bSuccess = False Then
            dwError = Marshal.GetLastWin32Error()
        End If
        Return bSuccess
    End Function ' SendBytesToPrinter()

    ' SendFileToPrinter()
    ' When the function is given a file name and a printer name,
    ' the function reads the contents of the file and sends the
    ' contents to the printer.
    ' Presumes that the file contains printer-ready data.
    ' Shows how to use the SendBytesToPrinter function.
    ' Returns True on success or False on failure.
    Public Shared Function SendFileToPrinter(ByVal szPrinterName As String, ByVal szFileName As String) As Boolean
        ' Open the file.
        Dim fs As New FileStream(szFileName, FileMode.Open)
        ' Create a BinaryReader on the file.
        Dim br As New BinaryReader(fs)
        ' Dim an array of bytes large enough to hold the file's contents.
        Dim bytes(fs.Length) As Byte
        Dim bSuccess As Boolean
        ' Your unmanaged pointer.
        Dim pUnmanagedBytes As IntPtr

        ' Read the contents of the file into the array.
        bytes = br.ReadBytes(fs.Length)
        ' Allocate some unmanaged memory for those bytes.
        pUnmanagedBytes = Marshal.AllocCoTaskMem(fs.Length)
        ' Copy the managed byte array into the unmanaged array.
        Marshal.Copy(bytes, 0, pUnmanagedBytes, fs.Length)
        ' Send the unmanaged bytes to the printer.
        bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, fs.Length)
        ' Free the unmanaged memory that you allocated earlier.
        Marshal.FreeCoTaskMem(pUnmanagedBytes)
        Return bSuccess
    End Function ' SendFileToPrinter()

    ' When the function is given a string and a printer name,
    ' the function sends the string to the printer as raw bytes.
    Public Shared Function SendStringToPrinter(ByVal szPrinterName As String, ByVal szString As String)
        Dim pBytes As IntPtr
        Dim dwCount As Int32
        ' How many characters are in the string?
        dwCount = szString.Length()
        ' Assume that the printer is expecting ANSI text, and then convert
        ' the string to ANSI text.
        pBytes = Marshal.StringToCoTaskMemAnsi(szString)
        ' Send the converted ANSI string to the printer.
        SendBytesToPrinter(szPrinterName, pBytes, dwCount)
        Marshal.FreeCoTaskMem(pBytes)
    End Function
End Class
