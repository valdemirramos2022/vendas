<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class listaVendas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(listaVendas))
        Me.dg = New System.Windows.Forms.DataGridView()
        Me.cbCliente = New System.Windows.Forms.ComboBox()
        Me.rbFuncionario = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbCliente = New System.Windows.Forms.RadioButton()
        Me.rbData = New System.Windows.Forms.RadioButton()
        Me.cbFuncionario = New System.Windows.Forms.ComboBox()
        Me.dtData = New System.Windows.Forms.DateTimePicker()
        Me.btnSair = New System.Windows.Forms.Button()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dg
        '
        Me.dg.AllowUserToAddRows = False
        Me.dg.AllowUserToDeleteRows = False
        Me.dg.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg.Location = New System.Drawing.Point(12, 61)
        Me.dg.Name = "dg"
        Me.dg.ReadOnly = True
        Me.dg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg.Size = New System.Drawing.Size(754, 209)
        Me.dg.TabIndex = 97
        '
        'cbCliente
        '
        Me.cbCliente.FormattingEnabled = True
        Me.cbCliente.Location = New System.Drawing.Point(632, 25)
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(129, 21)
        Me.cbCliente.TabIndex = 98
        '
        'rbFuncionario
        '
        Me.rbFuncionario.AutoSize = True
        Me.rbFuncionario.Location = New System.Drawing.Point(463, 28)
        Me.rbFuncionario.Name = "rbFuncionario"
        Me.rbFuncionario.Size = New System.Drawing.Size(80, 17)
        Me.rbFuncionario.TabIndex = 101
        Me.rbFuncionario.TabStop = True
        Me.rbFuncionario.Text = "Funcionario"
        Me.rbFuncionario.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(342, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "Buscar:"
        '
        'rbCliente
        '
        Me.rbCliente.AutoSize = True
        Me.rbCliente.Location = New System.Drawing.Point(392, 28)
        Me.rbCliente.Name = "rbCliente"
        Me.rbCliente.Size = New System.Drawing.Size(57, 17)
        Me.rbCliente.TabIndex = 100
        Me.rbCliente.TabStop = True
        Me.rbCliente.Text = "Cliente"
        Me.rbCliente.UseVisualStyleBackColor = True
        '
        'rbData
        '
        Me.rbData.AutoSize = True
        Me.rbData.Location = New System.Drawing.Point(560, 28)
        Me.rbData.Name = "rbData"
        Me.rbData.Size = New System.Drawing.Size(48, 17)
        Me.rbData.TabIndex = 102
        Me.rbData.TabStop = True
        Me.rbData.Text = "Data"
        Me.rbData.UseVisualStyleBackColor = True
        '
        'cbFuncionario
        '
        Me.cbFuncionario.FormattingEnabled = True
        Me.cbFuncionario.Location = New System.Drawing.Point(632, 25)
        Me.cbFuncionario.Name = "cbFuncionario"
        Me.cbFuncionario.Size = New System.Drawing.Size(129, 21)
        Me.cbFuncionario.TabIndex = 103
        '
        'dtData
        '
        Me.dtData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtData.Location = New System.Drawing.Point(632, 25)
        Me.dtData.Name = "dtData"
        Me.dtData.Size = New System.Drawing.Size(129, 20)
        Me.dtData.TabIndex = 104
        '
        'btnSair
        '
        Me.btnSair.BackColor = System.Drawing.Color.Transparent
        Me.btnSair.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSair.FlatAppearance.BorderSize = 0
        Me.btnSair.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Azure
        Me.btnSair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSair.Image = CType(resources.GetObject("btnSair.Image"), System.Drawing.Image)
        Me.btnSair.Location = New System.Drawing.Point(12, 10)
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Size = New System.Drawing.Size(40, 36)
        Me.btnSair.TabIndex = 110
        Me.btnSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSair.UseVisualStyleBackColor = False
        '
        'listaVendas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(775, 319)
        Me.Controls.Add(Me.btnSair)
        Me.Controls.Add(Me.dtData)
        Me.Controls.Add(Me.cbFuncionario)
        Me.Controls.Add(Me.rbData)
        Me.Controls.Add(Me.rbFuncionario)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rbCliente)
        Me.Controls.Add(Me.cbCliente)
        Me.Controls.Add(Me.dg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "listaVendas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "listaVendas"
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dg As System.Windows.Forms.DataGridView
    Friend WithEvents cbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents rbFuncionario As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbCliente As System.Windows.Forms.RadioButton
    Friend WithEvents rbData As System.Windows.Forms.RadioButton
    Friend WithEvents cbFuncionario As System.Windows.Forms.ComboBox
    Friend WithEvents dtData As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSair As System.Windows.Forms.Button
End Class
