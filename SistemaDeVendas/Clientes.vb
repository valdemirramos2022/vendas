Imports System.Data.SqlClient

Public Class Clientes
    Private Sub Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DesabilitarCampos()

        btnSalvar.Enabled = False
        txtBuscarCPF.Visible = False

        Listar()

        btnEditar.Enabled = False
        btnExcluir.Enabled = False
        rbNome.Checked = True
    End Sub


    Private Sub Listar()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter

        Try
            abrir()
            da = New SqlDataAdapter("pa_cliente_listar", con)
            da.Fill(dt)
            dg.DataSource = dt

            ContarLinhas()
            FormatarDG()

        Catch ex As Exception
            MessageBox.Show("Erro ao Listar" + ex.Message)
            fechar()
        End Try

    End Sub

    Private Sub FormatarDG()
        dg.Columns(0).Visible = False
        
        dg.Columns(1).HeaderText = "Nome"
        dg.Columns(2).HeaderText = "Sexo"
        dg.Columns(3).HeaderText = "rg"
        dg.Columns(4).HeaderText = "CPF"
        dg.Columns(5).HeaderText = "telcel"
        dg.Columns(6).HeaderText = "email"
        dg.Columns(7).HeaderText = "Endereço"
        dg.Columns(8).HeaderText = "Num"
        dg.Columns(9).HeaderText = "Compl"
        dg.Columns(10).HeaderText = "Bairro"
        dg.Columns(11).HeaderText = "Cidade"
        dg.Columns(12).HeaderText = "UF"
        dg.Columns(13).HeaderText = "CEP"
        dg.Columns(14).HeaderText = "Data Cadastro"

        dg.Columns(6).Width = 130
        dg.Columns(7).Width = 130


    End Sub

    Private Sub DesabilitarCampos()
        txtNome.Enabled = False
        cbSexo.Enabled = False
        txtRG.Enabled = False
        txtCPF.Enabled = False
        txtTel.Enabled = False
        txtEmail.Enabled = False
        txtEndereco.Enabled = False
        txtNumero.Enabled = False
        txtCompl.Enabled = False
        txtBairro.Enabled = False
        txtCidade.Enabled = False
        txtUF.Enabled = False
        txtCEP.Enabled = False
        ' nome,sexo,rg,cpf,telcel,email,endereco,num,compl,bairro,cidade,UF,cep,data_cadastro
    End Sub

    Private Sub HabilitarCampos()
        txtNome.Enabled = True
        cbSexo.Enabled = True
        txtRG.Enabled = True
        txtCPF.Enabled = True
        txtTel.Enabled = True
        txtEmail.Enabled = True
        txtEndereco.Enabled = True
        txtNumero.Enabled = True
        txtCompl.Enabled = True
        txtBairro.Enabled = True
        txtCidade.Enabled = True
        txtUF.Enabled = True
        txtCEP.Enabled = True

    End Sub

    Private Sub Limpar()
        txtNome.Focus()
        txtNome.Text = ""
        cbSexo.Text = ""
        txtRG.Text = ""
        txtCPF.Text = ""
        txtTel.Text = ""
        txtEmail.Text = ""
        txtEndereco.Text = ""
        txtNumero.Text = ""
        txtCompl.Text = ""
        txtBairro.Text = ""
        txtCidade.Text = ""
        txtUF.Text = ""
        txtCEP.Text = ""
        txtBuscar.Text = ""

    End Sub

    Private Sub ContarLinhas()
        Dim total As Integer = dg.Rows.Count
        lblTotal.Text = CInt(total)

    End Sub


    Private Sub btnNovo_Click_1(sender As Object, e As EventArgs) Handles btnNovo.Click
        HabilitarCampos()
        Limpar()
        btnSalvar.Enabled = True
    End Sub

    Private Sub btnSalvar_Click_1(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Dim cmd As SqlCommand

        If txtCPF.Text <> "" And txtNome.Text <> "" Then

            Try
                abrir()
                cmd = New SqlCommand("pa_clientesalvar", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@nome", txtNome.Text)
                cmd.Parameters.AddWithValue("@sexo", cbSexo.Text)
                cmd.Parameters.AddWithValue("@rg", txtRG.Text)
                cmd.Parameters.AddWithValue("@cpf", txtCPF.Text)
                cmd.Parameters.AddWithValue("@telcel", txtTel.Text)
                cmd.Parameters.AddWithValue("@email", txtEmail.Text)
                cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text)
                cmd.Parameters.AddWithValue("@num", txtNumero.Text)
                cmd.Parameters.AddWithValue("@compl", txtCompl.Text)
                cmd.Parameters.AddWithValue("@bairro", txtBairro.Text)
                cmd.Parameters.AddWithValue("@cidade", txtCidade.Text)
                cmd.Parameters.AddWithValue("@UF", txtUF.Text)
                cmd.Parameters.AddWithValue("@cep", txtCEP.Text)

                cmd.Parameters.AddWithValue("@data_cadastro", Now.Date())
                cmd.Parameters.Add("@mensagem", SqlDbType.VarChar, 100).Direction = 2
                cmd.ExecuteNonQuery()

                Dim msg As String = cmd.Parameters("@mensagem").Value.ToString
                MessageBox.Show(msg, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)


                Listar()
                Limpar()

                btnSalvar.Enabled = False

            Catch ex As Exception
                MessageBox.Show("Erro ao salvar os dados" + ex.Message)
                fechar()
            End Try
        End If
    End Sub

    Private Sub btnEditar_Click_1(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim cmd As SqlCommand

        If txtCPF.Text <> "" And txtNome.Text <> "" Then

            Try
                abrir()
                cmd = New SqlCommand("pa_clienteceditar", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@nome", txtNome.Text)
                cmd.Parameters.AddWithValue("@sexo", cbSexo.Text)
                cmd.Parameters.AddWithValue("@rg", txtRG.Text)
                cmd.Parameters.AddWithValue("@cpf", txtCPF.Text)
                cmd.Parameters.AddWithValue("@telcel", txtTel.Text)
                cmd.Parameters.AddWithValue("@email", txtEmail.Text)
                cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text)
                cmd.Parameters.AddWithValue("@num", txtNumero.Text)
                cmd.Parameters.AddWithValue("@compl", txtCompl.Text)
                cmd.Parameters.AddWithValue("@bairro", txtBairro.Text)
                cmd.Parameters.AddWithValue("@cidade", txtCidade.Text)
                cmd.Parameters.AddWithValue("@UF", txtUF.Text)
                cmd.Parameters.AddWithValue("@cep", txtCEP.Text)

                cmd.Parameters.Add("@mensagem", SqlDbType.VarChar, 100).Direction = 2
                cmd.ExecuteNonQuery()

                Dim msg As String = cmd.Parameters("@mensagem").Value.ToString
                MessageBox.Show(msg, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)


                Listar()
                Limpar()

            Catch ex As Exception
                MessageBox.Show("Erro ao editar os dados" + ex.Message)
                fechar()
            End Try
        End If
    End Sub

    Private Sub btnExcluir_Click_1(sender As Object, e As EventArgs) Handles btnExcluir.Click
        Dim cmd As SqlCommand

        If txtCPF.Text <> "" Then

            Try
                abrir()
                cmd = New SqlCommand("pa_cliente_excluir", con)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@cpf", txtCPF.Text)

                cmd.Parameters.Add("@mensagem", SqlDbType.VarChar, 100).Direction = 2
                cmd.ExecuteNonQuery()

                Dim msg As String = cmd.Parameters("@mensagem").Value.ToString
                MessageBox.Show(msg, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)


                Listar()
                Limpar()

                btnExcluir.Enabled = False
                btnEditar.Enabled = False

            Catch ex As Exception
                MessageBox.Show("Erro ao excluir os dados" + ex.Message)
                fechar()
            End Try
        End If
    End Sub

    Private Sub btSair_Click(sender As Object, e As EventArgs) Handles btSair.Click
        Me.Close()
    End Sub

    Private Sub rbNome_CheckedChanged_1(sender As Object, e As EventArgs) Handles rbNome.CheckedChanged
        txtBuscarCPF.Text = ""
        txtBuscar.Text = ""
        txtBuscar.Visible = True
        txtBuscarCPF.Visible = False
        txtBuscar.Focus()
        Listar()
    End Sub

    Private Sub rbCPF_CheckedChanged_1(sender As Object, e As EventArgs) Handles rbCPF.CheckedChanged
        txtBuscar.Text = ""
        txtBuscarCPF.Text = ""
        txtBuscar.Visible = False
        txtBuscarCPF.Visible = True
        txtBuscarCPF.Focus()
        Listar()
    End Sub

    Private Sub dg_CellClick1(sender As Object, e As DataGridViewCellEventArgs) Handles dg.CellClick
        btnEditar.Enabled = True
        btnExcluir.Enabled = True
        HabilitarCampos()
        txtCPF.Enabled = False

        txtNome.Text = dg.CurrentRow.Cells(1).Value
        cbSexo.Text = dg.CurrentRow.Cells(2).Value
        txtRG.Text = dg.CurrentRow.Cells(3).Value
        txtCPF.Text = dg.CurrentRow.Cells(4).Value
        txtTel.Text = dg.CurrentRow.Cells(5).Value
        txtEmail.Text = dg.CurrentRow.Cells(6).Value
        txtEndereco.Text = dg.CurrentRow.Cells(7).Value
        txtNumero.Text = dg.CurrentRow.Cells(8).Value
        txtCompl.Text = dg.CurrentRow.Cells(9).Value
        txtBairro.Text = dg.CurrentRow.Cells(10).Value
        txtCidade.Text = dg.CurrentRow.Cells(11).Value
        txtUF.Text = dg.CurrentRow.Cells(12).Value
        txtCEP.Text = dg.CurrentRow.Cells(13).Value
    End Sub

    Private Sub txtBuscarCPF_TextChanged_1(sender As Object, e As EventArgs) Handles txtBuscarCPF.TextChanged
        If txtBuscarCPF.Text = "   .   .   -" And dg.Rows.Count > 0 Then
            Listar()

        Else
            Dim dt As New DataTable
            Dim da As SqlDataAdapter

            Try
                abrir()
                da = New SqlDataAdapter("pa_ClienteCpfbuscar", con)
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.AddWithValue("@cpf", txtBuscarCPF.Text)

                da.Fill(dt)
                dg.DataSource = dt

                ContarLinhas()


            Catch ex As Exception
                MessageBox.Show("Erro ao Listar" + ex.Message)
                fechar()
            End Try
        End If

    End Sub

    Private Sub txtBuscar_TextChanged_1(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        If txtBuscar.Text = "" And dg.Rows.Count > 0 Then
            Listar()

        Else
            Dim dt As New DataTable
            Dim da As SqlDataAdapter

            Try
                abrir()
                da = New SqlDataAdapter("pa_ClientePesquisarNome", con)
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.AddWithValue("@nome", txtBuscar.Text)

                da.Fill(dt)
                dg.DataSource = dt

                ContarLinhas()
            Catch ex As Exception
                MessageBox.Show("Erro ao Listar" + ex.Message)
                fechar()
            End Try
        End If
    End Sub
End Class