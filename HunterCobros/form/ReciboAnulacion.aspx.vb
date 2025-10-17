Imports Telerik.Web.UI
Imports System.Net.Mail
Imports System.Net

Public Class ReciboAnulacion
    Inherits System.Web.UI.Page

    Public Enum Operacion
        OExistosa = 1
        OInvalida = 2
        CSinDatos = 3
    End Enum


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Load de la Pagina
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                lblanticipo.Text = Session("NUMERO_ANTICIPO")
                CargaMotivo()
                CbxMotivo.SelectedValue = 0
                Session("Anulacion") = ""
                'Else
                '    Btnaceptar_Click(Nothing, Nothing)
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
    Protected Sub Btnaceptar_Click(sender As Object, e As EventArgs) Handles Btnaceptar.Click
        Try
            If Validacion() Then
                'CambiarEstado(1033, Me.txt_comentario.Text, CbxMotivo.SelectedValue)
                CambiarEstado(0, Me.txt_comentario.Text, CbxMotivo.SelectedValue)
            End If
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Proceso de Cambiar Estado
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CambiarEstado(ByVal estadoId As String, ByVal observacion As String, ByVal motivo As Int32)
        Try
            If Session("NUMERO_ANTICIPO") <> "" Then
                Dim dtConsultar As New System.Data.DataSet
                dtConsultar = Clsrecibo.GrabaEstado(Session("user"), estadoId, Session("NUMERO_ANTICIPO").Substring(0, 19), observacion, motivo)
                If dtConsultar.Tables(0).Rows.Count > 0 Then
                    If dtConsultar.Tables(0).Rows(0).Item(0) = "CORRECTO" Then
                        EnvioEmail()
                        Session("NUMERO_ANTICIPO") = ""
                        MostrarMensaje("Se Actualizo correctamente", Operacion.OExistosa)
                        CargaNuevaSesion()
                    Else
                        MostrarMensaje("No se puedo Actualizar el registro", Operacion.OInvalida)
                    End If
                End If
            Else
                MostrarMensaje("No a Seleccionado un registro", Operacion.OInvalida)
            End If
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Envio Mail
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnvioEmail()
        Try
            Dim dTCstData As New System.Data.DataSet
            Dim anticipo As String = Session("NUMERO_ANTICIPO").Substring(0, 19)
            'dTCstData = Clsrecibo.LeerEmail(Session("CLIENTEID"), anticipo, "A")
            dTCstData = Clsrecibo.LeerEmail(Session("CLIENTEID"), anticipo, "S", Session("user"))
            If dTCstData.Tables(0).Rows.Count > 0 Then
                Dim correo As New System.Net.Mail.MailMessage()
                correo.From = New System.Net.Mail.MailAddress(ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
                'correo.To.Add(dTCstData.Tables(0).Rows(0)("EMAIL"))
                Dim mailTo As String = dTCstData.Tables(0).Rows(0)("EMAIL").ToString()
                Dim mailToCollection As [String]() = mailTo.Split(";")
                For Each mailToo As String In mailToCollection
                    If ExceptionHandler.ValidarEMail(mailToo) Then
                        correo.To.Add(mailToo)
                    End If
                Next
                Dim mailToBcc As String = ConfigurationManager.AppSettings.Get("UsuarioMailToBcc").ToString()
                Dim mailToBccCollection As [String]() = mailToBcc.Split(";")
                For Each mailTooBcc As String In mailToBccCollection
                    If ExceptionHandler.ValidarEMail(mailTooBcc) Then
                        correo.Bcc.Add(mailTooBcc)
                    End If
                Next
                If Len(Session("email")) > 10 Then
                    correo.Bcc.Add(Session("email"))
                End If
                correo.Subject = "Hunter Cobros " & dTCstData.Tables(0).Rows(0)("CLIENTE") & " Anulación de Nro. " & Session("NUMERO_ANTICIPO")
                Dim htmlbody As String = dTCstData.Tables(0).Rows(0)("HTMLBODY")
                correo.Body = htmlbody
                correo.Priority = MailPriority.High
                correo.IsBodyHtml = True
                'Dim smtp As New System.Net.Mail.SmtpClient
                '---------------------------------------------
                '  DATOS DE LA CONFIGURACIÓN DE LA CUENTA ENVÍA
                '---------------------------------------------
                'smtp.Host = ConfigurationManager.AppSettings.Get("SmptCliente").ToString()
                'smtp.Credentials = New System.Net.NetworkCredential(ConfigurationManager.AppSettings.Get("VentasMailUser").ToString(), ConfigurationManager.AppSettings.Get("VentasMailPassword").ToString())
                'smtp.EnableSsl = True
                'smtp.Port = ConfigurationManager.AppSettings.Get("SmptPort").ToString()
                'smtp.Send(correo)
                ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
                Dim smtp As New SmtpClient(ConfigurationManager.AppSettings.Get("SmptCliente").ToString(), ConfigurationManager.AppSettings.Get("SmptPort"))
                smtp.EnableSsl = True
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                smtp.UseDefaultCredentials = False
                smtp.Credentials = New Net.NetworkCredential(ConfigurationManager.AppSettings.Get("VentasMailUser").ToString(), ConfigurationManager.AppSettings.Get("VentasMailPassword").ToString())
                smtp.Send(correo)
                correo.Dispose()
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
    ''' COMENTARIO: Validacion de datos
    ''' </summary>
    ''' <remarks></remarks>
    Private Function Validacion() As Boolean
        Validacion = True
        Try
            If Session("NUMERO_ANTICIPO") = "" Then
                MostrarMensaje("Anticipo no valido.", Operacion.OInvalida)
                Validacion = False
            End If
            If CbxMotivo.SelectedValue = 0 Then
                MostrarMensaje("Debe de seleccionar un Motivo.", Operacion.OInvalida)
                Validacion = False
            End If
            If Me.txt_comentario.Text = "Observación" Or Me.txt_comentario.Text = "" Then
                MostrarMensaje("Debe de Ingresar un Comentario.", Operacion.OInvalida)
                Validacion = False
            End If
            Return Validacion
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function


    Private Sub MostrarMensaje(ByVal texto As String, ByVal operacionRealizar As Int32)
        Try
            Dim titulo As String = String.Empty
            Dim icono As String = String.Empty
            Select Case operacionRealizar
                Case Operacion.OInvalida
                    titulo = "Operación Inválida"
                    icono = "Warning"
                Case Operacion.OExistosa
                    titulo = "Operación Exitosa"
                    icono = "Info"
                Case Operacion.CSinDatos
                    titulo = "Consulta sin Datos"
                    icono = "Info"
            End Select
            Me.rntMensajes.Text = texto
            Me.rntMensajes.Title = titulo
            Me.rntMensajes.TitleIcon = icono
            Me.rntMensajes.ContentIcon = icono
            rntMensajes.Width = 400
            rntMensajes.Height = 100
            Me.rntMensajes.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Cargar Motivo
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CargaMotivo()
        Try
            Dim dtCargaMotivo As New System.Data.DataSet
            Dim opcion As Integer = 13
            dtCargaMotivo = Clsrecibo.DatosGeneral("", opcion, Session("user"))
            Session("dtCargaMotivo") = dtCargaMotivo
            Me.CbxMotivo.DataSource = dtCargaMotivo
            Me.CbxMotivo.DataValueField = "CODIGO"
            Me.CbxMotivo.DataTextField = "MOTIVO"
            Me.CbxMotivo.DataBind()
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Cargar Sesion
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CargaNuevaSesion()
        Try
            Session("Anulacion") = "Si"
            Dim script As String = "<script language='javascript' type='text/javascript'>Sys.Application.add_load(CloseAndRedirect());</script>"
            RadScriptManager.RegisterStartupScript(Me, Me.GetType(), "CloseAndRedirect()", script, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class