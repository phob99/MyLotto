Imports System.Data.SqlClient

Public Class frm_EnterData
    Private NumberType As Int16 = 0
    Private LottoTime_ID As Integer
    Private LottoType As String
    Private Sub TxtNumber_KeyUp(sender As Object, e As KeyEventArgs) Handles txtNumber.KeyUp
        If (e.KeyValue = 13) Then
            If (txtNumber.Text.Count = 0) Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub PrepareForm()
        getLottoTime()
    End Sub
    Private Sub getLottoTime()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        connetionString = My.Settings.LottoDBConnectionString1
        Dim sql As String = "Get_LottoTime"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("LottoTime_ID", SqlDbType.Int).Value = 1
            adapter.Fill(ds)

            lblLottoDate.Text = CDate(ds.Tables(0)(0)("LottoDate")).ToString("dd/MM/yyyy")
            LottoTime_ID = ds.Tables(0)(0)("ID")
            adapter.Dispose()
            command.Dispose()
            connection.Close()

        Catch ex As Exception
            MessageBox.Show("Can not open connection ! ")
        End Try
    End Sub


    Private Sub TxtNumber_TextChanged(sender As Object, e As EventArgs) Handles txtNumber.TextChanged, txtBon.TextChanged, txtTod.TextChanged, txtLang.TextChanged
        With txtNumber.Text.Trim
            NumberType = .Count
            txtTod.Enabled = True
            If .Count = 0 Then
                lblNumberType.Text = ""
                LottoType = ""
            ElseIf .Count = 1 Then
                lblNumberType.Text = "วิ่ง"
                LottoType = "R"
            ElseIf .Count = 2 Then
                txtTod.Text = ""
                txtTod.Enabled = False
                LottoType = "2"
                lblNumberType.Text = "2 ตัว"
            Else
                lblNumberType.Text = "3 ตัว"
                LottoType = "3"
            End If
        End With
    End Sub
    Private Function Add_LottoBill(intLottoTime_ID As Integer, intBuyer_ID As Integer) As Integer
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand

        connetionString = My.Settings.LottoDBConnectionString1
        Dim sql As String = "Add_LottoBill"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("LottoTime_ID", SqlDbType.Int).Value = intLottoTime_ID
            command.Parameters.Add("Buyer_ID", SqlDbType.Int).Value = intBuyer_ID
            Dim returnVal As New SqlParameter
            returnVal.Direction = ParameterDirection.ReturnValue
            command.Parameters.Add(returnVal)
            command.ExecuteNonQuery()
            Add_LottoBill = returnVal.Value

            command.Dispose()
            connection.Close()

        Catch ex As Exception
            MessageBox.Show("Can not open connection ! ")
            Return 0
        End Try
    End Function
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click, Label3.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GB1.Enter

    End Sub

    Private Sub txtNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumber.KeyPress, txtBon.KeyPress, txtTod.KeyPress, txtLang.KeyPress
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers
        If (Asc(e.KeyChar) = 13) Then
            If (CType(sender, TextBox).Name = "txtLang") Then

                Add_LottoBill_Detail(Asc(lblLottoBill_ID.Text), txtNumber.Text, txtBon.Text, txtTod.Text, txtLang.Text)
            Else
                SendKeys.Send("{TAB}")

            End If
        End If
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If

    End Sub
    Private Function Add_LottoBill_Detail(LottoBill_ID As Integer, LottoNumber As String, BonValue As String, TodValue As String _
                                          , LangValue As String) As Integer
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand

        connetionString = My.Settings.LottoDBConnectionString1
        Dim sql As String = "Add_LottoBill_Detail"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@LottoBill_ID", SqlDbType.Int).Value = LottoBill_ID
            command.Parameters.Add("@LottoNumber", SqlDbType.VarChar).Value = LottoNumber
            command.Parameters.Add("@BonValue", SqlDbType.Int).Value = Int(BonValue)
            command.Parameters.Add("@TodValue", SqlDbType.Int).Value = Int(IIf(TodValue = "", 0, TodValue))
            command.Parameters.Add("@LangValue", SqlDbType.Int).Value = Int(LangValue)
            command.Parameters.Add("@LottoType", SqlDbType.NChar).Value = LottoType
            Dim returnVal As New SqlParameter
            returnVal.Direction = ParameterDirection.ReturnValue
            command.Parameters.Add(returnVal)
            command.ExecuteNonQuery()
            Add_LottoBill_Detail = returnVal.Value

            command.Dispose()
            connection.Close()

        Catch ex As Exception
            MessageBox.Show("Can not open connection ! ")
            Return 0
        End Try
    End Function
    Private Sub txtNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumber.KeyDown


    End Sub

    Private Sub txtTod_GotFocus(sender As Object, e As EventArgs) Handles txtTod.GotFocus

    End Sub

    Private Sub txtBuyer_KeyPress(sender As Object, e As KeyPressEventArgs)
        If (Asc(e.KeyChar) = 13) Then



            SendKeys.Send("{TAB}")
        End If
    End Sub



    Private Sub frm_EnterData_Load(sender As Object, e As EventArgs) Handles Me.Load
        cbBuyer.AutoCompleteMode = AutoCompleteMode.Append
        cbBuyer.DropDownStyle = ComboBoxStyle.DropDown
        cbBuyer.AutoCompleteSource = AutoCompleteSource.ListItems

        BindCBBuyer()

        PrepareForm()

    End Sub

    Private Sub cbBuyer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBuyer.SelectedIndexChanged

    End Sub

    Private Sub cbBuyer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbBuyer.KeyPress
        If (Asc(e.KeyChar) = 13) Then
            Console.Write(cbBuyer.SelectedValue)
        End If
    End Sub

    Private Sub cbBuyer_KeyUp(sender As Object, e As KeyEventArgs) Handles cbBuyer.KeyUp

        'Console.Write(cbBuyer.SelectedValue)
        If (e.KeyCode = 13) Then
            If (cbBuyer.SelectedValue = Nothing) Then
                Dim strNewBuyer As String
                strNewBuyer = cbBuyer.Text
                Dim newID As Integer = AddBuyer(cbBuyer.Text)
                BindCBBuyer()
                cbBuyer.SelectedValue = newID
                ' Console.Write(cbBuyer.SelectedValue)
            End If
            Console.Write(cbBuyer.SelectedValue)
            If (lblLottoBill_ID.Text = "") Then
                lblLottoBill_ID.Text = Add_LottoBill(LottoTime_ID, cbBuyer.SelectedValue)
            End If
            btnEditBuyer.Visible = True
            cbBuyer.Enabled = False
            'SendKeys.Send("{TAB}")

        End If
    End Sub

    Private Function BindCBBuyer() As DataSet
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        connetionString = My.Settings.LottoDBConnectionString1
        Dim sql As String = "SELECT * FROM T_Buyer"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)

            With cbBuyer
                .DataSource = ds.Tables(0)
                .DisplayMember = "BuyerName"
                .ValueMember = "ID"
                .DropDownStyle = ComboBoxStyle.DropDown
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
            End With



            adapter.Dispose()
            command.Dispose()
            connection.Close()
            Return ds
        Catch ex As Exception
            MessageBox.Show("Can not open connection ! ")
            Return Nothing
        End Try
    End Function

    Private Function AddBuyer(strBuyer As String) As Integer
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand

        connetionString = My.Settings.LottoDBConnectionString1
        Dim sql As String = "AddBuyer"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("strBuyerName", SqlDbType.VarChar).Value = strBuyer
            Dim returnVal As New SqlParameter("ID", SqlDbType.Int)
            returnVal.Direction = ParameterDirection.Output
            command.Parameters.Add(returnVal)
            command.ExecuteNonQuery()
            AddBuyer = returnVal.Value

            command.Dispose()
            connection.Close()

        Catch ex As Exception
            MessageBox.Show("Can not open connection ! ")
            Return 0
        End Try
    End Function

    Private Sub cbBuyer_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles cbBuyer.PreviewKeyDown

    End Sub

    Private Sub BtnEditBuyer_Click(sender As Object, e As EventArgs) Handles btnEditBuyer.Click
        If (cbBuyer.Enabled) Then
            cbBuyer.Enabled = False
            btnEditBuyer.Text = "..."
        Else
            cbBuyer.Enabled = True
            btnEditBuyer.Text = "บันทึก"
        End If

    End Sub


    ''Function


End Class