Imports System.Data.SqlClient
Imports System.Text

Public Class clsCliente
    Private _id_cliente As Integer
    Public Property id_cliente() As Integer
        Get
            Return _id_cliente
        End Get
        Set(ByVal value As Integer)
            _id_cliente = value
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

    Private _data_cadastro As DateTime
    Public Property data_cadastro() As DateTime
        Get
            Return _data_cadastro
        End Get
        Set(ByVal value As DateTime)
            _data_cadastro = value
        End Set
    End Property


   

End Class
