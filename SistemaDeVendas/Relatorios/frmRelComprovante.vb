

Public Class frmRelComprovante

    Public Sub New(ByVal num As String)

        InitializeComponent()

        Me.ComprovanteTableAdapter.Fill(Me.VendasDataSet.Comprovante, num)

        Me.ReportViewer1.RefreshReport()

    End Sub

    Private Sub frmRelComprovante_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'VendasDataSet.Comprovante' table. You can move, or remove it, as needed.
        
    End Sub
End Class