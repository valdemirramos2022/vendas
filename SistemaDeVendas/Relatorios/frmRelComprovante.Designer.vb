<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelComprovante
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ComprovanteBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.VendasDataSet = New SistemaDeVendas.VendasDataSet()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ComprovanteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ComprovanteTableAdapter = New SistemaDeVendas.VendasDataSetTableAdapters.ComprovanteTableAdapter()
        CType(Me.ComprovanteBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendasDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComprovanteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComprovanteBindingSource1
        '
        Me.ComprovanteBindingSource1.DataMember = "Comprovante"
        Me.ComprovanteBindingSource1.DataSource = Me.VendasDataSet
        '
        'VendasDataSet
        '
        Me.VendasDataSet.DataSetName = "VendasDataSet"
        Me.VendasDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.ComprovanteBindingSource1
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SistemaDeVendas.relComprovante.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(527, 444)
        Me.ReportViewer1.TabIndex = 0
        '
        'ComprovanteBindingSource
        '
        Me.ComprovanteBindingSource.DataMember = "Comprovante"
        Me.ComprovanteBindingSource.DataSource = Me.VendasDataSet
        '
        'ComprovanteTableAdapter
        '
        Me.ComprovanteTableAdapter.ClearBeforeFill = True
        '
        'frmRelComprovante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 444)
        Me.Controls.Add(Me.ReportViewer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmRelComprovante"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comprovante da Venda"
        CType(Me.ComprovanteBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendasDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComprovanteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ComprovanteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendasDataSet As SistemaDeVendas.VendasDataSet
    Friend WithEvents ComprovanteTableAdapter As SistemaDeVendas.VendasDataSetTableAdapters.ComprovanteTableAdapter
    Friend WithEvents ComprovanteBindingSource1 As System.Windows.Forms.BindingSource
End Class
