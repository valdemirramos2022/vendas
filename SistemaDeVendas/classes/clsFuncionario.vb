Imports System.Data.SqlClient
Imports System.Text

Public Class clsFuncionario

    Dim param As SqlParameter
    'Dim abre As New cldBancoDados
    ' Dim Conn As New SqlConnection()

    Private _id_func As Integer
    Public Property id_func() As Integer
        Get
            Return _id_func
        End Get
        Set(ByVal value As Integer)
            _id_func = value
        End Set
    End Property

    Private _nome As String
    Public Property nome() As String
        Get
            Return _nome
        End Get
        Set(ByVal value As String)
            _nome = value
        End Set
    End Property

    Private _sexo As String
    Public Property sexo() As String
        Get
            Return _sexo
        End Get
        Set(ByVal value As String)
            _sexo = value
        End Set
    End Property

    Private _rg As String
    Public Property rg() As String
        Get
            Return _rg
        End Get
        Set(ByVal value As String)
            _rg = value
        End Set
    End Property

    Private _cpf As String
    Public Property cpf() As String
        Get
            Return _cpf
        End Get
        Set(ByVal value As String)
            _cpf = value
        End Set
    End Property

    Private _telcel As String
    Public Property telcel() As String
        Get
            Return _telcel
        End Get
        Set(ByVal value As String)
            _telcel = value
        End Set
    End Property

    Private _email As String
    Public Property email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Private _endereco As String
    Public Property endereco() As String
        Get
            Return _endereco
        End Get
        Set(ByVal value As String)
            _endereco = value
        End Set
    End Property

    Private _num As String
    Public Property num() As String
        Get
            Return _num
        End Get
        Set(ByVal value As String)
            _num = value
        End Set
    End Property

    Private _compl As String
    Public Property compl() As String
        Get
            Return _compl
        End Get
        Set(ByVal value As String)
            _compl = value
        End Set
    End Property
    'id_func,nome,sexo,rg,cpf,telcel,email,endereco,num,compl,bairro,cidade,UF,cep,turno,data_contratado,data_demissao
    Private _bairro As String
    Public Property bairro() As String
        Get
            Return _bairro
        End Get
        Set(ByVal value As String)
            _bairro = value
        End Set
    End Property

    Private _cidade As String
    Public Property cidade() As String
        Get
            Return _cidade
        End Get
        Set(ByVal value As String)
            _cidade = value
        End Set
    End Property

    Private _uf As String
    Public Property uf() As String
        Get
            Return _uf
        End Get
        Set(ByVal value As String)
            _uf = value
        End Set
    End Property

    Private _cep As String
    Public Property cep() As String
        Get
            Return _cep
        End Get
        Set(ByVal value As String)
            _cep = value
        End Set
    End Property

    Private _turno As String
    Public Property turno() As String
        Get
            Return _turno
        End Get
        Set(ByVal value As String)
            _turno = value
        End Set
    End Property


    Private _data_contratado As DateTime
    Public Property data_contratado() As DateTime
        Get
            Return _data_contratado
        End Get
        Set(ByVal value As DateTime)
            _data_contratado = value
        End Set
    End Property

    Private _data_demissao As DateTime
    Public Property data_demissao() As DateTime
        Get
            Return _data_demissao
        End Get
        Set(ByVal value As DateTime)
            _data_demissao = value
        End Set
    End Property

    Public Function ListarFunc() As DataTable

        Dim dt As New DataTable
        Dim da As SqlDataAdapter

        Try
            abrir()
            da = New SqlDataAdapter("pa_func_listar", con)
            da.Fill(dt)
            Funcionarios.dg.DataSource = dt

        Catch ex As Exception
            MessageBox.Show("Erro ao Listar" + ex.Message)
            fechar()
        End Try

        Return dt
    End Function


    Public Sub Gravar()
       
        Dim SqlQuery As String = "pa_funcsalvar"
        Dim cmd As New SqlClient.SqlCommand(SqlQuery)
        cmd.CommandType = CommandType.StoredProcedure

        param = Paramete.nome
        param.Value = nome
        cmd.Parameters.Add(param)

        param = Paramete.sexo
        param.Value = sexo
        cmd.Parameters.Add(param)

        param = Paramete.rg
        param.Value = rg
        cmd.Parameters.Add(param)

        param = Paramete.cpf
        param.Value = cpf
        cmd.Parameters.Add(param)

        param = Paramete.telcel
        param.Value = telcel
        cmd.Parameters.Add(param)
        'id_func,nome,sexo,rg,cpf,telcel,email,endereco,num,compl,bairro,cidade,UF,cep,turno,data_contratado,data_demissa
        param = Paramete.email
        param.Value = email
        cmd.Parameters.Add(param)

        param = Paramete.endereco
        param.Value = endereco
        cmd.Parameters.Add(param)

        param = Paramete.num
        param.Value = num
        cmd.Parameters.Add(param)

        param = Paramete.compl
        param.Value = compl
        cmd.Parameters.Add(param)

        param = Paramete.bairro
        param.Value = bairro
        cmd.Parameters.Add(param)

        param = Paramete.cidade
        param.Value = cidade
        cmd.Parameters.Add(param)

        param = Paramete.uf
        param.Value = uf
        cmd.Parameters.Add(param)

        param = Paramete.cep
        param.Value = cep
        cmd.Parameters.Add(param)

        param = Paramete.turno
        param.Value = turno
        cmd.Parameters.Add(param)

        param = Paramete.data_contratado
        param.Value = data_contratado
        cmd.Parameters.Add(param)

        param = Paramete.data_demissao
        param.Value = data_demissao
        cmd.Parameters.Add(param)

        'Conn = abre.AbreBanco()
        'cmd.Connection = Conn
        'cmd.ExecuteNonQuery()


        ' cldBancoDados.ExecutaComando(str)
    End Sub
    'id_func,nome,sexo,rg,cpf,telcel,email,endereco,num,compl,bairro,cidade,UF,cep,turno,data_contratado,data_demissao

    Public Sub Alterar()
        
        Dim SqlQuery As String = "pa_clnCliente_alterar"
        Dim cmd As New SqlClient.SqlCommand(SqlQuery)
        cmd.CommandType = CommandType.StoredProcedure

        param = Paramete.id_func
        param.Value = id_func
        cmd.Parameters.Add(param)

        

        'Conn = abre.AbreBanco()
        'cmd.Connection = Conn
        'cmd.ExecuteNonQuery()
        'cldBancoDados.ExecutaComando(str)
    End Sub



    Public Class Paramete
        Shared Function id_func() As SqlParameter
            Return New SqlParameter("@id_func", SqlDbType.Int)
        End Function
        Shared Function nome() As SqlParameter
            Return New SqlParameter("@nome", SqlDbType.VarChar)
        End Function

        Shared Function sexo() As SqlParameter
            Return New SqlParameter("@sexo", SqlDbType.VarChar)
        End Function
        Shared Function rg() As SqlParameter
            Return New SqlParameter("@rg", SqlDbType.VarChar)
        End Function
        Shared Function cpf() As SqlParameter
            Return New SqlParameter("@cpf", SqlDbType.VarChar)
        End Function
        Shared Function telcel() As SqlParameter
            Return New SqlParameter("@telcel", SqlDbType.VarChar)
        End Function
        Shared Function email() As SqlParameter
            Return New SqlParameter("@email", SqlDbType.VarChar)
        End Function
        Shared Function endereco() As SqlParameter
            Return New SqlParameter("@endereco", SqlDbType.VarChar)
        End Function
        Shared Function num() As SqlParameter
            Return New SqlParameter("@num", SqlDbType.VarChar)
        End Function
        Shared Function compl() As SqlParameter
            Return New SqlParameter("@compl", SqlDbType.VarChar)
        End Function
        Shared Function bairro() As SqlParameter
            Return New SqlParameter("@bairro", SqlDbType.VarChar)
        End Function
        Shared Function cidade() As SqlParameter
            Return New SqlParameter("@cidade", SqlDbType.VarChar)
        End Function
        Shared Function uf() As SqlParameter
            Return New SqlParameter("@uf", SqlDbType.VarChar)
        End Function
        Shared Function cep() As SqlParameter
            Return New SqlParameter("@cep", SqlDbType.VarChar)
        End Function
        Shared Function turno() As SqlParameter
            Return New SqlParameter("@turno", SqlDbType.VarChar)
        End Function
        Shared Function data_contratado() As SqlParameter
            Return New SqlParameter("@data_contratado", SqlDbType.DateTime)
        End Function
        Shared Function data_demissao() As SqlParameter
            Return New SqlParameter("@data_demissao", SqlDbType.DateTime)
        End Function
    End Class
End Class
