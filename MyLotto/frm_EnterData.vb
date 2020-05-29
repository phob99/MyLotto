Imports System.Data.SqlClient

Public Class frm_EnterData
    Private NumberType As Int16 = 0
    Private LottoTime_ID As Integer
    Private LottoType As String
    Private AllValid As Boolean
    Private Sub TxtNumber_KeyUp(sender As Object, e As KeyEventArgs) Handles txtNumber.KeyUp
        If (e.KeyValue = 13) Then
            If (txtNumber.Text.Count = 0) Then
                e.Handled = False
            End If
        End If
    End Sub

    Private Sub PrepareForm()
        AllValid = False
        getLottoTime()

    End Sub
    Private Sub getLottoTime()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        connetionString = My.Settings.LottoDB
        Dim sql As String = "Get_LottoDate"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("LottoDate_ID", SqlDbType.Int).Value = 1
            adapter.Fill(ds)

            lblLottoDate.Text = CDate(ds.Tables(0)(0)("LottoDate")).ToString("dd/MM/yyyy")
            LottoTime_ID = ds.Tables(0)(0)("LottoDate_ID")
            adapter.Dispose()
            command.Dispose()
            connection.Close()

        Catch ex As Exception
            MessageBox.Show("Can not open connection ! ")
        End Try
    End Sub


    Private Sub TxtNumber_TextChanged(sender As Object, e As EventArgs) Handles txtNumber.TextChanged
        With txtNumber

            NumberType = .Text.Count
                txtTod.Enabled = True
                If .Text.Count = 0 Then
                    lblNumberType.Text = ""
                    LottoType = ""
                ElseIf .Text.Count = 1 Then
                    lblNumberType.Text = "วิ่ง"
                    LottoType = "R"
                ElseIf .Text.Count = 2 Then
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
    Private Function Add_LottoBill(intLottoTime_ID As Integer, intBuyer_ID As Integer, ByRef BillNumber As Integer) As Integer
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand

        connetionString = My.Settings.LottoDB
        Dim sql As String = "Add_LottoBill"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("LottoDate_ID", SqlDbType.Int).Value = intLottoTime_ID
            command.Parameters.Add("Buyer_ID", SqlDbType.Int).Value = intBuyer_ID
            command.Parameters.Add("BillNumber", SqlDbType.Int).Direction = ParameterDirection.Output
            Dim returnVal As New SqlParameter
            returnVal.Direction = ParameterDirection.ReturnValue
            command.Parameters.Add(returnVal)
            command.ExecuteNonQuery()
            Add_LottoBill = returnVal.Value
            BillNumber = command.Parameters("BillNumber").Value
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

    Private Sub txtNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumber.KeyPress, txtBon.KeyPress, txtTod.KeyPress, txtLang.KeyPress, txtBonAddValue.KeyPress, txtLangAddValue.KeyPress, txtTodAddValue.KeyPress, txtTodTotal.KeyPress, txtLangTotal.KeyPress, txtBonTotal.KeyPress
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers
        If (Asc(e.KeyChar) = 13) Then

            If (CType(sender, TextBox).Name = "txtLang") Then
                Dim LottoBill_ID, BonVal, TodVal, LangVal, BonAddVal, TodAddVal, LangAddVal As Integer
                BonVal = ConvertStrToInt(txtBon.Text)
                TodVal = ConvertStrToInt(txtTod.Text)
                LangVal = ConvertStrToInt(txtLang.Text)
                BonAddVal = ConvertStrToInt(txtBonAddValue.Text)
                TodAddVal = ConvertStrToInt(txtTodAddValue.Text)
                LangAddVal = ConvertStrToInt(txtLangAddValue.Text)
                LottoBill_ID = ConvertStrToInt(lblLottoBill_ID.Text)
                ValidateLottoNumber()
                If (AllValid) Then
                    If (Add_LottoBill_Detail(LottoBill_ID, txtNumber.Text, BonVal, TodVal, LangVal, BonAddVal, TodAddVal, LangAddVal) > 1) Then
                        ClsNumberInput()
                        refreshBillDetail()
                    End If

                End If
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
    Private Sub ClsNumberInput()
        txtBon.Text = ""
        txtBonAddValue.Text = ""
        txtBonTotal.Text = ""
        txtTod.Text = ""
        txtTodAddValue.Text = ""
        txtTodTotal.Text = ""
        txtLang.Text = ""
        txtLangAddValue.Text = ""
        txtLangTotal.Text = ""
        txtNumber.Text = ""
        txtNumber.Select()
    End Sub
    Private Function Add_LottoBill_Detail(LottoBill_ID As Integer, LottoNumber As String, BonValue As Integer, TodValue As Integer _
                                          , LangValue As Integer, BonAddValue As Integer, TodAddValue As Integer, LangAddValue As Integer) As Integer
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand

        connetionString = My.Settings.LottoDB
        Dim sql As String = "Add_LottoBill_Detail"

        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@LottoBill_ID", SqlDbType.Int).Value = LottoBill_ID
            command.Parameters.Add("@LottoNumber", SqlDbType.VarChar, 3).Value = LottoNumber
            command.Parameters.Add("@BonValue", SqlDbType.Int).Value = (BonValue)
            command.Parameters.Add("@TodValue", SqlDbType.Int).Value = TodValue
            command.Parameters.Add("@LangValue", SqlDbType.Int).Value = (LangValue)
            command.Parameters.Add("@LottoType", SqlDbType.NChar, 1).Value = LottoType
            command.Parameters.Add("@BonAddValue", SqlDbType.Int).Value = BonAddValue
            command.Parameters.Add("@TodAddValue", SqlDbType.Int).Value = TodAddValue
            command.Parameters.Add("@LangAddValue", SqlDbType.Int).Value = LangAddValue


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
        'TODO: This line of code loads data into the 'MyLottoDBDataSet.T_LottoBill_Detail' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'MyLottoDBDataSet.T_LottoBill_Detail' table. You can move, or remove it, as needed.

        cbBuyer.AutoCompleteMode = AutoCompleteMode.Append
        cbBuyer.DropDownStyle = ComboBoxStyle.DropDown
        cbBuyer.AutoCompleteSource = AutoCompleteSource.ListItems

        BindCBBuyer()

        PrepareForm()

    End Sub
    Private Sub refreshBillDetail()
        Dim row As DataGridViewRow = Me.DataGridView1.RowTemplate
        row.DefaultCellStyle.BackColor = Color.Bisque
        row.Height = 35
        row.MinimumHeight = 20
        DataGridView1.AutoGenerateColumns = False
        Dim ds As DataSet = getLottoBill_Detail(ConvertStrToInt(lblLottoBill_ID.Text))
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "LottoBill_Detail"
    End Sub
    Private Function getLottoBill_Detail(LottoBill_ID As Integer) As DataSet
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        connetionString = My.Settings.LottoDB
        Dim sql As String = "getLottoBill_Detail"

        '@LottoBill_ID int,
        '@LottoType nchar(1)
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            With command

                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("LottoBill_ID", SqlDbType.Int).Value = LottoBill_ID
                '.Parameters.Add("LottoType", SqlDbType.NChar, 1).Value = LottoType

            End With
            adapter.SelectCommand = command
            adapter.Fill(ds, "LottoBill_Detail")

            adapter.Dispose()
            command.Dispose()
            connection.Close()
            Return ds
        Catch ex As Exception
            MessageBox.Show("Can not open connection ! ")
            Return Nothing
        End Try
    End Function


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
            Dim LottoBillNumber As Integer
            If (lblLottoBill_ID.Text = "") Then

                lblLottoBill_ID.Text = Add_LottoBill(LottoTime_ID, cbBuyer.SelectedValue, LottoBillNumber)
                lblLottoBillNumber.Text = LottoBillNumber.ToString
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
        connetionString = My.Settings.LottoDB
        Dim sql As String = "SELECT * FROM T_Buyer"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)

            With cbBuyer
                .DataSource = ds.Tables(0)
                .DisplayMember = "Buyer_Name"
                .ValueMember = "Buyer_ID"
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

        connetionString = My.Settings.LottoDB
        Dim sql As String = "Add_Buyer"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("Buyer_Name", SqlDbType.VarChar).Value = strBuyer
            Dim returnVal As New SqlParameter("Buyer_ID", SqlDbType.Int)
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

    Private Sub TxtBon_TextChanged(sender As Object, e As EventArgs) Handles txtBon.TextChanged
        ' If (rdbGetFree.Checked) Then
        Dim BonValue, BonAddValue As Integer
        BonValue = ConvertStrToInt(txtBon.Text)
        BonAddValue = BonValue / 10
        txtBonAddValue.Text = BonAddValue.ToString
        txtBonTotal.Text = (BonAddValue + BonValue).ToString
        '  Else

        'End If
    End Sub

    Private Sub TxtTod_TextChanged(sender As Object, e As EventArgs) Handles txtTod.TextChanged
        Dim TodValue, TodAddValue As Integer
        TodValue = ConvertStrToInt(txtTod.Text)
        TodAddValue = TodValue / 10
        txtTodAddValue.Text = TodAddValue.ToString
        txtTodTotal.Text = (TodAddValue + TodValue).ToString
    End Sub


    ''Function

    Function ConvertStrToInt(strVal As String) As Integer
        If (strVal = "") Then
            ConvertStrToInt = 0
        Else
            ConvertStrToInt = Int(strVal)
        End If

    End Function

    Private Sub TxtLang_TextChanged(sender As Object, e As EventArgs) Handles txtLang.TextChanged
        Dim LangValue, LangAddValue As Integer
        LangValue = ConvertStrToInt(txtLang.Text)
        LangAddValue = LangValue / 10
        txtLangAddValue.Text = LangAddValue.ToString
        txtLangTotal.Text = (LangAddValue + LangValue).ToString
    End Sub

    Private Sub txtNumber_LostFocus(sender As Object, e As EventArgs) Handles txtNumber.LostFocus

        ValidateLottoNumber()
    End Sub

    Private Sub ValidateLottoNumber()
        If (txtNumber.Text = "") Then
            lblValLottoNum.Text = "กรุณาใส่เลข"
            lblValLottoNum.Visible = True
            AllValid = False
        Else
            lblValLottoNum.Visible = False
            AllValid = True
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub


End Class