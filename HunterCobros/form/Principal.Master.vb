Public Class Principal

    Inherits System.Web.UI.MasterPage
    Dim usuarioSistema As String
    Dim usuarioId As Integer

    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Load de Pagina
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session.Item("user") IsNot Nothing Then
                    usuarioId = Session("user_id")
                    usuarioSistema = CType(Session.Item("user"), String)
                    Dim obj As New Clslogin
                    Dim dtsInfoUsuario As New System.Data.DataSet
                    dtsInfoUsuario = obj.DatosLoginUsuario(usuarioSistema)
                    If dtsInfoUsuario.Tables(0).Rows.Count > 0 Then
                        Dim nombre As String = dtsInfoUsuario.Tables(0).Rows(0)("displayname").ToString()
                        Me.lblUserName.Text = nombre
                        Llena_Menu()
                        Habilita_Menu(usuarioSistema)
                    End If
                Else
                    Session("error") = "Debe de iniciar sesión en el sistema"
                    Response.Redirect("login.aspx", False)
                End If
            Else
                usuarioSistema = CType(Session.Item("user"), String)
                Me.RadMenu1.Visible = True
                Me.RadMenu1.Enabled = True
            End If
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    Protected Sub Captura_Error(ByVal tipo As Exception)
        Try
            ExceptionHandler.Captura_Error(tipo)
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Habilitar Menu
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Habilita_Menu(ByVal usuario As String)
        Try
            Dim itemsMenu As New DataSet
            Dim objeto As New Clslogin
            Dim proceso As Integer
            Dim tipoMenu As String
            proceso = 2
            tipoMenu = "R"
            itemsMenu = objeto.DatosMenu(proceso, Session("user"), tipoMenu)
            For i As Integer = 0 To itemsMenu.Tables(0).Rows.Count - 1
                Dim valor As Integer = itemsMenu.Tables(0).Rows(i).Item(2)
                For j As Integer = 0 To RadMenu1.Items.Count - 1
                    If RadMenu1.Items(j).Value = valor Then
                        RadMenu1.Items(j).Enabled = True
                    End If
                    For k As Integer = 0 To RadMenu1.Items(j).Items.Count - 1
                        If RadMenu1.Items(j).Items(k).Value = valor Then
                            RadMenu1.Items(j).Items(k).Enabled = True
                        End If
                    Next
                Next
            Next
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: MÉTODO PARA LLENAR EL MENÚ CON LOS ELEMENTOS DEFINIDOS EN LA BASE DE DATOS
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Llena_Menu()
        Try
            Dim itemsMenu As New DataSet
            Dim objeto As New Clslogin
            Dim tipoMenu As String
            Dim proceso As Integer
            proceso = 1
            tipoMenu = "R"
            itemsMenu = objeto.DatosMenu(proceso, Session("user"), tipoMenu)
            RadMenu1.DataSource = itemsMenu.Tables(0)
            RadMenu1.DataFieldID = "CODIGO_MENU"
            RadMenu1.DataFieldParentID = "CODIGO_PADRE"
            RadMenu1.DataTextField = "CAPTION_FORMA"
            RadMenu1.DataNavigateUrlField = "ASSEMBLY"
            RadMenu1.DataValueField = "CODIGO_MENU"
            RadMenu1.DataBind()
            For i As Integer = 0 To itemsMenu.Tables(0).Rows.Count - 1
                For j As Integer = 0 To RadMenu1.Items.Count - 1
                    RadMenu1.Items(j).Enabled = False
                    For k As Integer = 0 To RadMenu1.Items(j).Items.Count - 1
                        RadMenu1.Items(j).Items(k).Enabled = False
                    Next
                Next
            Next
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Boton Salir
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Try
            Session.Clear()
            Session.Abandon()
            Response.Redirect("login.aspx", False)
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


End Class