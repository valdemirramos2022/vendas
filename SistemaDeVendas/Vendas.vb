Imports System.Data.SqlClient
Imports System.IO

Public Class Vendas
    Private Sub Vendas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DesabilitarCampos()

        btnSalvar.Enabled = False

        CarregarProdutos()
        CarregarClientes()

        Listar()


        btnExcluir.Enabled = False
        btnRel.Enabled = False
        totalizar()

    End Sub


    Private Sub Listar()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter

        Try
            abrir()
            ' da = New SqlDataAdapter("SELECT ven.id_vendas, ven.num_vendas, pro.nome, cli.nome, pro.valor, ven.quantidade, ven.valor, ven.funcionario, ven.data_venda, ven.id_produto, ven.id_cliente FROM tbVendas as ven INNER JOIN tbProdutos as pro on ven.id_produto = pro.id_produto INNER JOIN tbClientes as cli on ven.id_cliente = cli.id_cliente order by num_vendas desc", con)
            ' da = New SqlDataAdapter("SELECT ven.id_vendas, ven.num_vendas, pro.nome, cli.nome, pro.valor, ven.quantidade, ven.valor, ven.funcionario, ven.data_venda, ven.id_produto, ven.id_cliente FROM tbVendas as ven INNER JOIN tbProdutos as pro on ven.id_produto = pro.id_produto INNER JOIN tbClientes as cli on ven.id_cliente = cli.id_cliente order by num_vendas desc", con)
            da = New SqlDataAdapter("pa_vendasListar", con)

            da.Fill(dt)
            dg.DataSource = dt


            FormatarDG()

        Catch ex As Exception
            MessageBox.Show("Erro ao Listar" + ex.Message)
            fechar()
        End Try

    End Sub

    Private Sub FormatarDG()
        dg.Columns(0).Visible = False
        dg.Columns(1).Visible = False
        dg.Columns(2).Visible = False

        dg.Columns(3).HeaderText = "Núm Venda"
        dg.Columns(4).HeaderText = "Produto"
        dg.Columns(5).HeaderText = "Cliente"
        dg.Columns(6).HeaderText = "Valor Unit"
        dg.Columns(7).HeaderText = "Quantidade"
        dg.Columns(8).HeaderText = "Valor Total"
        dg.Columns(9).HeaderText = "Funcionário"
        dg.Columns(10).HeaderText = "Data Venda"


        dg.Columns(4).Width = 100
        dg.Columns(5).Width = 100
        dg.Columns(6).Width = 60
        dg.Columns(9).Width = 100

    End Sub

    Private Sub DesabilitarCampos()
        txtNum.Enabled = False
        txtQuantidade.Enabled = False
        cbCliente.Enabled = False
        cbProduto.Enabled = False
        btnRel.Enabled = False

    End Sub

    Private Sub HabilitarCampos()
        txtNum.Enabled = True
        txtQuantidade.Enabled = True
        cbCliente.Enabled = True
        cbProduto.Enabled = True


    End Sub

    Private Sub Limpar()
        txtNum.Focus()
        txtNum.Text = ""
        txtQuantidade.Text = ""

        txtBuscar.Text = ""

    End Sub

    Sub CarregarProdutos()
        Dim DT As New DataTable
        Dim DA As SqlDataAdapter
        Try
            abrir()
            DA = New SqlDataAdapter("SELECT * FROM tbProdutos", con)
            DA.Fill(DT)
            cbProduto.DisplayMember = "nome"
            cbProduto.ValueMember = "id_produto"
            cbProduto.DataSource = DT
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
        fechar()
    End Sub


    Sub CarregarClientes()
        Dim DT As New DataTable
        Dim DA As SqlDataAdapter
        Try
            abrir()
            DA = New SqlDataAdapter("SELECT * FROM tbClientes", con)
            DA.Fill(DT)
            cbCliente.DisplayMember = "nome"
            cbCliente.ValueMember = "id_cliente"
            cbCliente.DataSource = DT
        Catch ex As Exception : MessageBox.Show(ex.Message)
        End Try
        fechar()
    End Sub

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        HabilitarCampos()
        ' Limpar()
        btnSalvar.Enabled = True
        gerarnum()
    End Sub

    Private Sub cbProduto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProduto.SelectedIndexChanged

        atualizarValor()

    End Sub

    Private Sub atualizarValor()
        Dim cmd As New SqlCommand("pa_produtobuscarValorVenda", con)
        Try
            abrir()
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@id_produto", cbProduto.SelectedValue)
            cmd.Parameters.Add("@valor", SqlDbType.Decimal).Direction = 2
            cmd.Parameters.Add("@quant", SqlDbType.Int).Direction = 2
            '  cmd.Parameters.Add("@imagem", SqlDbType.Image).Direction = 2
            cmd.ExecuteNonQuery()

            Dim valor As Decimal = cmd.Parameters("@valor").Value
            txtValor.Text = CStr(valor)

            Dim quant As Int32 = cmd.Parameters("@quant").Value
            txtEstoque.Text = CStr(quant)

            ' ----------------------------------------------------------------------------
            'Dim cmd2 As New SqlCommand("pa_produtoBuscaFoto", con)
            Dim cmd2 As New SqlCommand("select imagem from tbProdutos where id_produto = @id_produto", con)
            cmd2.Parameters.AddWithValue("@id_produto", cbProduto.SelectedValue)
            cmd2.ExecuteNonQuery()


            Dim tempImagem As Byte() = DirectCast(cmd2.ExecuteScalar, Byte())
            If tempImagem Is Nothing Then
                MessageBox.Show("Imagem não localizada", "Erro")
                Exit Sub
            End If
            Dim strArquivo As String = Convert.ToString(DateTime.Now.ToFileTime())
            Dim fs As New FileStream(strArquivo, FileMode.CreateNew, FileAccess.Write)
            fs.Write(tempImagem, 0, tempImagem.Length)
            fs.Flush()
            fs.Close()

            imagem.Image = Image.FromFile(strArquivo)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        fechar()
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Dim cmd As SqlCommand

        Dim quantidade As Decimal
        Dim estoque As Decimal
        Dim Totestoque As Decimal

        quantidade = txtQuantidade.Text
        estoque = txtEstoque.Text
        Totestoque = estoque - quantidade


        If txtNum.Text <> "" And Totestoque >= 0 Then
            Dim total As Decimal
            Dim valor As Decimal
            Dim quant As Decimal

            valor = txtValor.Text
            quant = txtQuantidade.Text

            total = valor * quant

            Try
                abrir()

                'ABATENDO PRODUTOS NO ESTOQUE

                cmd = New SqlCommand("pa_produtoEditarEstoque", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@quantidade", Totestoque)
                cmd.Parameters.AddWithValue("@id_produto", cbProduto.SelectedValue)
                cmd.ExecuteNonQuery()

                cmd = New SqlCommand("pa_vendasalvar", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@num_vendas", txtNum.Text)
                cmd.Parameters.AddWithValue("@id_produto", cbProduto.SelectedValue)
                cmd.Parameters.AddWithValue("@id_cliente", cbCliente.SelectedValue)
                cmd.Parameters.AddWithValue("@quantidade", txtQuantidade.Text) 'txtQuantidade
                cmd.Parameters.AddWithValue("@valor", total)
                cmd.Parameters.AddWithValue("@funcionario", usuarioNome)
                cmd.Parameters.AddWithValue("@data_venda", Now.Date())

                cmd.Parameters.Add("@mensagem", SqlDbType.VarChar, 100).Direction = 2
                cmd.ExecuteNonQuery()

                Dim msg As String = cmd.Parameters("@mensagem").Value.ToString
                MessageBox.Show(msg, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)


                atualizarValor()
                'Listar()
                buscarVenda()
                totalizar()

                cbCliente.Enabled = False
                txtNum.Enabled = False

                txtQuantidade.Text = ""
                btnRel.Enabled = True

            Catch ex As Exception
                MessageBox.Show("Erro ao salvar os dados" + ex.Message)
                fechar()
            End Try

        Else
            MsgBox("A quantidade em estoque é Insuficiente!!!")

        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs)
        Dim cmd As SqlCommand

        If txtNum.Text <> "" Then

            Dim total As Decimal
            Dim valor As Decimal
            Dim quant As Decimal

            valor = txtValor.Text
            quant = txtQuantidade.Text

            total = valor * quant

            Try
                abrir()
                cmd = New SqlCommand("pa_vendaseditar", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@id_vendas", txtCodigo.Text)
                cmd.Parameters.AddWithValue("@num_vendas", txtNum.Text)
                cmd.Parameters.AddWithValue("@id_produto", cbProduto.SelectedValue)

                cmd.Parameters.AddWithValue("@quantidade", txtQuantidade.Text)
                cmd.Parameters.AddWithValue("@valor", total)

                cmd.Parameters.Add("@mensagem", SqlDbType.VarChar, 100).Direction = 2
                cmd.ExecuteNonQuery()

                Dim msg As String = cmd.Parameters("@mensagem").Value.ToString
                MessageBox.Show(msg, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)


                Listar()
                Limpar()
                totalizar()

            Catch ex As Exception
                MessageBox.Show("Erro ao editar os dados" + ex.Message)
                fechar()
            End Try
        End If
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click

        Dim quantidade As Decimal
        Dim estoque As Decimal
        Dim Totestoque As Decimal

        quantidade = txtQuantidade.Text
        estoque = txtEstoque.Text
        Totestoque = estoque + quantidade


        Dim cmd As SqlCommand

        If txtCodigo.Text <> "" Then

            Try
                abrir()

                'DEVOLVENDO PRODUTOS AO ESTOQUE

                cmd = New SqlCommand("pa_produtoEditarEstoque", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@quantidade", Totestoque)
                cmd.Parameters.AddWithValue("@id_produto", cbProduto.SelectedValue)
                cmd.ExecuteNonQuery()


                cmd = New SqlCommand("pa_vendasexcluir", con)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@id_vendas", txtCodigo.Text)

                cmd.Parameters.Add("@mensagem", SqlDbType.VarChar, 100).Direction = 2
                cmd.ExecuteNonQuery()

                Dim msg As String = cmd.Parameters("@mensagem").Value.ToString
                MessageBox.Show(msg, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)


                Listar()
                Limpar()
                totalizar()
                atualizarValor()

                btnExcluir.Enabled = False


            Catch ex As Exception
                MessageBox.Show("Erro ao excluir os dados" + ex.Message)
                fechar()
            End Try
        End If
    End Sub

    Private Sub dg_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg.CellClick

        btnRel.Enabled = True
        btnExcluir.Enabled = True
        HabilitarCampos()

        txtCodigo.Text = dg.CurrentRow.Cells(0).Value
        txtNum.Text = dg.CurrentRow.Cells(3).Value
        cbProduto.SelectedValue = dg.CurrentRow.Cells(1).Value
        cbCliente.SelectedValue = dg.CurrentRow.Cells(2).Value
        txtQuantidade.Text = CInt(dg.CurrentRow.Cells(7).Value)



    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        If txtBuscar.Text = "" And dg.Rows.Count > 0 Then
            Listar()
            totalizar()

        Else
            Dim dt As New DataTable
            Dim da As SqlDataAdapter

            Try
                abrir()
                da = New SqlDataAdapter("pa_vendaPesquisar", con)
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.AddWithValue("@num_vendas", txtBuscar.Text)

                da.Fill(dt)
                dg.DataSource = dt


                totalizar()


            Catch ex As Exception
                MessageBox.Show("Erro ao Listar" + ex.Message)
                fechar()
            End Try
        End If
    End Sub

    Private Sub totalizar()
        Dim total As Decimal
        For Each lin As DataGridViewRow In dg.Rows
            total = total + lin.Cells(8).Value
        Next

        lblTotal.Text = total
    End Sub


    Private Sub buscarVenda()
        If txtNum.Text = "" Then
            Listar()
            totalizar()

        Else
            Dim dt As New DataTable
            Dim da As SqlDataAdapter
            '  FormatarDG()
            Try
                abrir()
                da = New SqlDataAdapter("pa_vendaPesquisar", con)
                ' da = New SqlDataAdapter("SELECT ven.id_vendas, ven.num_vendas, pro.nome, cli.nome, pro.valor, ven.quantidade, ven.valor, ven.funcionario, ven.data_venda, ven.id_produto, ven.id_cliente FROM tbVendas as ven INNER JOIN tbProdutos as pro on ven.id_produto = pro.id_produto INNER JOIN tbClientes as cli on ven.id_cliente = cli.id_cliente order by num_vendas desc", con)
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.AddWithValue("@num_vendas", txtNum.Text)

                da.Fill(dt)
                dg.DataSource = dt


                totalizar()


            Catch ex As Exception
                MessageBox.Show("Erro ao Listar" + ex.Message)
                fechar()
            End Try
        End If
    End Sub



    Private Sub btnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

    Private Sub gerarnum()
        Dim cmd As New SqlCommand("pa_VendabuscarNum", con)
        Try
            abrir()
            cmd.CommandType = 4
            cmd.Parameters.Add("@num_venda", SqlDbType.Int).Direction = 2

            cmd.ExecuteNonQuery()

            Dim num As Integer = cmd.Parameters("@num_venda").Value
            Dim hora As String = Now.Second

            Dim num_final As Integer
            num_final = num + 1

            Dim num_pers As String

            num_pers = num_final.ToString + hora

            txtNum.Text = CStr(num_pers)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        fechar()

    End Sub


    Private Sub btnRel_Click(sender As Object, e As EventArgs) Handles btnRel.Click
        If txtNum.Text = "" Then
            MsgBox("Selecione uma venda na tabela!")
            Exit Sub
        End If

        Dim num As String
        num = txtNum.Text
        Dim form = New frmRelComprovante(num)
        form.ShowDialog()
    End Sub

    
End Class