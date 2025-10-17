Imports System.Drawing

Public Class login
    Inherits System.Web.UI.Page

    Dim usuario As String
    Dim password As String
    Dim urlpage As String

    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Pagina Load
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.txt_usuario.Focus()
            urlpage = ""
            urlpage = System.IO.Path.GetFileName(Request.PhysicalPath)
            Session("ref_id") = 0
            If Not IsPostBack Then
                If Session("alert") IsNot Nothing Then
                    lbl_msg_login.Text = Session("alert")
                    Me.lbl_msg_login.ForeColor = Color.Red
                    Me.lbl_msg_login.Font.Bold = True
                End If
            End If
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Boton Aceptar
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        Try
            Dim obj As New Clslogin
            Dim dtLoginUsuario As New System.Data.DataSet
            usuario = ""
            password = ""
            usuario = Me.txt_usuario.Text
            password = Me.txt_password.Text
            dtLoginUsuario = obj.LoginUsuario(usuario, password)
            Dim msg As String = dtLoginUsuario.Tables(0).Rows(0).Item("MSG").ToString()
            Datos_Log_Ingreso("LOGIN", msg, usuario)
            If msg = "UNE" Then
                Me.lbl_msg_login.Text = "El usuario no existe en el sistema"
            End If
            If msg = "UNA" Then
                Me.lbl_msg_login.Text = "El usuario no se encuentra en estado ACTIVO"
            End If
            If msg = "PIN" Then
                Me.lbl_msg_login.Text = "La contraseña es incorrecta"
            End If
            If msg = "PCD" Then
                Me.lbl_msg_login.Text = "Su contraseña ha caducado"
            End If
            If msg = "ROL" Then
                Me.lbl_msg_login.Text = "No tiene permiso para Ingresar por Rol"
            End If
            If msg = "RTI" Then
                Me.lbl_msg_login.Text = "No tiene configurado el tipo de Recibo"
            End If
            If msg = "PCR" Then
                Dim usuarioId As Integer = dtLoginUsuario.Tables(0).Rows(0)("USUARIO_ID").ToString()
                Session("user_id") = usuarioId
                Session("user") = Me.txt_usuario.Text
                Session("tipo") = dtLoginUsuario.Tables(0).Rows(0)("TIPO").ToString()
                Session("name") = dtLoginUsuario.Tables(0).Rows(0)("NOMBRE_CORTO").ToString()
                Session("email") = dtLoginUsuario.Tables(0).Rows(0)("EMAIL").ToString()
                Response.Redirect("Inicio.aspx", False)
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
    ''' COMENTARIO: Registrar el Log de Ingreso
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Datos_Log_Ingreso(ByVal opcion As String, ByVal msg As String, ByVal usuario As String)
        Try
            Dim mensaje As String = ""
            If msg = "UNE" Then
                mensaje = "El usuario no existe en el sistema"
            End If
            If msg = "UNA" Then
                mensaje = "El usuario no se encuentra en estado ACTIVO"
            End If
            If msg = "PIN" Then
                mensaje = "La contraseña es incorrecta"
            End If
            If msg = "PCD" Then
                mensaje = "Su contraseña ha caducado"
            End If
            If msg = "ROL" Then
                mensaje = "No tiene permiso para Ingresar por Rol"
            End If
            If msg = "RTI" Then
                mensaje = "No tiene configurado el tipo de Recibo"
            End If
            If msg = "PCR" Then
                mensaje = "Usuario con login satisfactorio"
            End If
            Clsrecibo.RegistroLog(opcion, mensaje, usuario)
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


End Class