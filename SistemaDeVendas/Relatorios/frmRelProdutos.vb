Public Class frmRelProdutos

    Private Sub frmRelProdutos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ProdutosDataSet.tbProdutos' table. You can move, or remove it, as needed.
        Me.tbProdutosTableAdapter.Fill(Me.ProdutosDataSet.tbProdutos)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class