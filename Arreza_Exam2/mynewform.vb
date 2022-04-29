Imports MySql.Data.MySqlClient
Public Class mynewform
    Dim conn As MySqlConnection
    Dim command As New MySqlCommand
    Dim reader As MySqlDataReader
    Dim query As String

    Sub Connect()
        conn = New MySqlConnection With {
            .ConnectionString = "server=localhost; userid=root; password=; database=db_user"
            }
        conn.Open()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Read Query'
        Connect()
        query = "SELECT username from register where username = @username"
        With command
            .CommandText = query
            .Connection = conn
            .Parameters.Clear()
            .Parameters.Add("@username", MySqlDbType.VarChar).Value = username.Text
        End With
        reader = command.ExecuteReader
        If reader.Read Then
            MsgBox("User is already added, pick another name")
        Else
            'Insert Query'
            If password.Text = confirmpass.Text Then

                Connect()
                query = "INSERT INTO register (username, password, accessType) 
                    values (@username, @password, @accessType)"

                With command
                    .CommandText = query
                    .Connection = conn
                    With .Parameters
                        .Clear()
                        .Add("@username", MySqlDbType.VarChar).Value = username.Text.Trim
                        .Add("@password", MySqlDbType.VarChar).Value = password.Text.Trim
                        .Add("@accessType", MySqlDbType.VarChar).Value = accessType.Text
                    End With
                    .ExecuteNonQuery()
                End With
                MsgBox("User data is saved")
                username.Text = ""
                password.Text = ""
                confirmpass.Text = ""
                accessType.Text = ""
            Else
                MsgBox("Password and Confirm Password did not match!")
            End If
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub mynewform_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class