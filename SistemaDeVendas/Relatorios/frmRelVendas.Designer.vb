<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelVendas
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
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.dtData = New System.Windows.Forms.DateTimePicker()
        Me.cbFuncionario = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListadeVendasBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.VendasDataSet = New SistemaDeVendas.VendasDataSet()
        Me.ListadeVendasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ListadeVendasTableAdapter = New SistemaDeVendas.VendasDataSetTableAdapters.ListadeVendasTableAdapter()
        CType(Me.ListadeVendasBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendasDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListadeVendasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.ListadeVendasBindingSource1
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SistemaDeVendas.RelVenda.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 44)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(728, 418)
        Me.ReportViewer1.TabIndex = 0
        '
        'dtData
        '
        Me.dtData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtData.Location = New System.Drawing.Point(592, 12)
        Me.dtData.Name = "dtData"
        Me.dtData.Size = New System.Drawing.Size(102, 20)
        Me.dtData.TabIndex = 1
        '
        'cbFuncionario
        '
        Me.cbFuncionario.FormattingEnabled = True
        Me.cbFuncionario.Location = New System.Drawing.Point(449, 12)
        Me.cbFuncionario.Name = "cbFuncionario"
        Me.cbFuncionario.Size = New System.Drawing.Size(121, 21)
        Me.cbFuncionario.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(381, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Funcionario"
        '
        'ListadeVendasBindingSource1
        '
        Me.ListadeVendasBindingSource1.DataMember = "ListadeVendas"
        Me.ListadeVendasBindingSource1.DataSource = Me.VendasDataSet
        '
        'VendasDataSet
        '
        Me.VendasDataSet.DataSetName = "VendasDataSet"
        Me.VendasDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ListadeVendasBindingSource
        '
        Me.ListadeVendasBindingSource.DataMember = "ListadeVendas"
        Me.ListadeVendasBindingSource.DataSource = Me.VendasDataSet
        '
        'ListadeVendasTableAdapter
        '
        Me.ListadeVendasTableAdapter.ClearBeforeFill = True
        '
        'frmRelVendas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(742, 511)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbFuncionario)
        Me.Controls.Add(Me.dtData)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmRelVendas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vendas por Data"
        CType(Me.ListadeVendasBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendasDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListadeVendasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ListadeVendasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VendasDataSet As SistemaDeVendas.VendasDataSet
    Friend WithEvents ListadeVendasTableAdapter As SistemaDeVendas.VendasDataSetTableAdapters.ListadeVendasTableAdapter
    Friend WithEvents ListadeVendasBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents dtData As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbFuncionario As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
