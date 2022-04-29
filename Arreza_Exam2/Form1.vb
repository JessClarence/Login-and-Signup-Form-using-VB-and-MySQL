Imports MySql.Data.MySqlClient


Public Class Form1
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


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        mynewform.Show()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Connect()
        query = "SELECT * FROM register WHERE username = @username AND password = @password"
        With command
            .CommandText = query
            .Connection = conn
            With .Parameters
                .Clear()
                .Add("@username", MySqlDbType.VarChar).Value = username.Text
                .Add("@password", MySqlDbType.VarChar).Value = password.Text
            End With
        End With
        reader = command.ExecuteReader

        If reader.Read Then

            MessageBox.Show("User's Information " &
                            ControlChars.NewLine &
                            "Username: " & username.Text &
                            ControlChars.NewLine &
                            "Password: " & password.Text &
                            ControlChars.NewLine &
                            "Access Type: " & accessType.Text)



        Else
            errorMessage.Text = "Error! Username & Password does not Match"
            errorMessage.ForeColor = Color.Red

        End If

        username.Text = ""
        password.Text = ""
        accessType.Text = ""
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles username.TextChanged

    End Sub
End Class
