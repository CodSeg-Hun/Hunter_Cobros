Imports Telerik.Web.UI
Imports System.Drawing
Imports System.Net.Mail
Imports System.Net

'Imports System.IO

Public Class Consultar

    Inherits System.Web.UI.Page
    Dim fechaString As String
    Dim fechaInicio, fechaFin As String


    Public Enum Operacion
        OExistosa = 1
        OInvalida = 2
        CSinDatos = 3
    End Enum

#Region "Eventos de la pagina"


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Pagina Load
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                InicializaControles()
                If Session("Anulacion") Is DBNull.Value Or Session("Anulacion") = "" Then
                    If Session("user") IsNot Nothing Then
                        Clsrecibo.RegistroLog("CONSULTA", "Consulta de Recibo", Session("user"))
                    Else
                        Response.Redirect("./login.aspx", False)
                    End If
                Else
                    Me.rdpFechaInicio.SelectedDate = Session("fechaInicio")
                    Me.rdpFechaFin.SelectedDate = Session("fechaFin")
                    CbxUsuario.SelectedValue = Session("Recaudador")
                    CbxEstado.SelectedValue = Session("estado")
                    Dim dtConsultar As New System.Data.DataSet
                    dtConsultar = Clsrecibo.ProcesoConsultar(10, ObtenerFechaInicio(), ObtenerFechaFin(), Session("Recaudador"), Session("estado"), Session("user"))
                    Session("consultar") = dtConsultar
                    Me.Grdconsultar.DataSource = dtConsultar
                    Me.Grdconsultar.DataBind()
                    Session("Anulacion") = ""
                End If
            End If
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


#End Region

#Region "Eventos de los controles"

    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Boton Buscar
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Try
            If ValidaFecha() = 0 Then
                Consultar()
            Else
                Mensaje("Fecha no valida.", Operacion.OInvalida)
            End If
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Boton Reenviar
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub BtnReenviar_Click(sender As Object, e As EventArgs) Handles BtnReenviar.Click
        Try
            ConsultaRuta()
            Dim objDocumento As New GenerarPdf
            Dim dtConsultar As New dsHunterCobro.REIMPRESIONDataTable
            dtConsultar = Session("Data")
            objDocumento.GenerarDocumento(dtConsultar.Rows(0)(7), Session("RutaFile"), Session("CONSULTA_DETALLE_DATOS"), _
                                          dtConsultar.Rows(0)(0), dtConsultar.Rows(0)(1), dtConsultar.Rows(0)(2), "", dtConsultar.Rows(0)(3), _
                                          dtConsultar.Rows(0)(4), dtConsultar.Rows(0)(5), Session("name"), dtConsultar.Rows(0)(6), Session("referencia"))
            EnvioEmailPdf(dtConsultar.Rows(0)(0), dtConsultar.Rows(0)(1), dtConsultar.Rows(0)(2), dtConsultar.Rows(0)(5), dtConsultar.Rows(0)(7))
            Habilita_Control(False, 1)
            Mensaje("Se Reenvió correctamente.", Operacion.OExistosa)
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Seleccionar en el grid 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Grdconsultar_DetailTableDataBind(sender As Object, e As Telerik.Web.UI.GridDetailTableDataBindEventArgs) Handles Grdconsultar.DetailTableDataBind
        Try
            Dim dataItem As GridDataItem = CType(e.DetailTableView.ParentItem, GridDataItem)
            Select Case e.DetailTableView.Name
                Case "Detalle"
                    Dim numeroID As String = dataItem.GetDataKeyValue("NUMERO_ANTICIPO").ToString()
                    Dim estadoID As String = dataItem("ESTADO_ID").Text.Trim.ToString
                    Dim dsConsulta As New dsHunterCobro.ANTICIPO_DETALLEDataTable
                    Dim dsReferencia As New dsHunterCobro.REFERENCIA_DETALLEDataTable
                    Dim obj As New Clsrecibo
                    dsConsulta.Load(obj.ConsultaInformacionDetalle(numeroID.Substring(0, 19), "D").CreateDataReader())
                    Session("CONSULTA_DETALLE_DATOS") = dsConsulta
                    e.DetailTableView.DataSource = dsConsulta
                    dsReferencia.Load(obj.ConsultaInformacionDetalle(numeroID.Substring(0, 19), "R").CreateDataReader())
                    Session("referencia") = dsReferencia
                    Session("NUMERO_ANTICIPO") = numeroID.Substring(0, 19)
                    If estadoID = "1068" And Session("NUMERO_ANTICIPO") <> "" Then 'se procede a Anular el registro
                        Habilita_Control(True, 1)
                        Dim valor As String = dataItem("VALOR").Text.Trim.ToString
                        Reimpresion(numeroID, dataItem("CODIGO_CLIENTE").Text.Trim.ToString, dataItem("EMAIL_CLIENTE").Text.Trim.ToString, valor.Replace("$", ""), _
                                    dataItem("OBSERVACION").Text.Trim.ToString, dataItem("CLIENTE").Text.Trim.ToString, dataItem("FECHA").Text.Trim.ToString, _
                                    dataItem("CODIGO_CLIENTE").Text.Trim.ToString + "_" + DateTime.Now.ToString("HHmmss") + ".PDF")
                    Else
                        Habilita_Control(False, 1)
                    End If
            End Select
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Para Eliminar el Registro
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Grdconsultar_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles Grdconsultar.ItemCommand
        Try
            If e.CommandName = "Editar" Then
                Dim anticipoId, clienteId As String
                Dim dataItem As GridDataItem = CType(e.Item, GridDataItem)
                anticipoId = dataItem("NUMERO_ANTICIPO").Text.Trim.ToString
                clienteId = dataItem("CODIGO_CLIENTE").Text.Trim.ToString
                If e.CommandName = "Editar" Then
                    Session("NUMERO_ANTICIPO") = anticipoId
                    Session("CLIENTEID") = clienteId
                    Dim script As String = String.Format("function f(){{$find(""{0}"").show(); Sys.Application.remove_load(f);}}Sys.Application.add_load(f);", reciboanulacion.ClientID)
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, True)
                End If
            End If
            If e.CommandName = "RowClick" OrElse e.CommandName = "ExpandCollapse" Then
                Dim lastState As Boolean = e.Item.Expanded
                If e.CommandName = "ExpandCollapse" Then
                    lastState = Not lastState
                End If
                CollapseAllRows()
                e.Item.Expanded = Not lastState
            End If
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Color por Estado
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Grdconsultar_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles Grdconsultar.ItemDataBound
        Try
            If TypeOf e.Item Is GridDataItem AndAlso e.Item.OwnerTableView.Name <> "Detalle" Then
                Dim dataItem As GridDataItem = CType(e.Item, GridDataItem)
                Dim anticipoId As String
                Dim editar As ImageButton = CType(dataItem("EditarColumn").Controls(0), ImageButton)
                anticipoId = dataItem("NUMERO_ANTICIPO").Text.Trim.ToString
                If dataItem("ESTADO_ID").Text = "108" Then  'RECHAZADO
                    dataItem.ForeColor = Color.FromArgb(&HE6, &HA6, &HE)
                    editar.Visible = False
                End If
                If dataItem("ESTADO_ID").Text = "1033" Then 'ANULADO
                    dataItem.ForeColor = Color.FromArgb(255, 181, 5, 5)
                    editar.Visible = False
                End If
                If dataItem("ESTADO_ID").Text = "5" Then  ' PROCESADO
                    dataItem.ForeColor = Color.FromArgb(&HFA, &H10, &H51, &HF6)
                    editar.Visible = False
                End If
                If dataItem("ESTADO_ID").Text = "1068" And dataItem("SOLICITUD").Text.Contains("Solicitud") Then
                    dataItem.ForeColor = Color.FromArgb(&HFA, &H6, &HB5, &H2A)
                    editar.Visible = False
                Else
                    If dataItem("ESTADO_ID").Text = "1068" Then  ' PROCESADO
                        editar.Attributes("onclick") = "return confirm('Esta seguro de Anular el Anticipo Nro. " & anticipoId & "?')"
                        editar.Visible = True
                    End If
                End If
            End If
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Actualizar el grid
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Grdconsultar_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles Grdconsultar.NeedDataSource
        Grdconsultar.DataSource = Session("consultar")
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Boton Reemprimir el documento
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Grdconsultar_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles Grdconsultar.SelectedIndexChanged
        Try
            Dim item As GridDataItem = Nothing
            Dim anticipoId, estadoID As String
            item = Grdconsultar.SelectedItems(0)
            anticipoId = item("NUMERO_ANTICIPO").Text.Trim.ToString
            estadoID = item("ESTADO_ID").Text.Trim.ToString
            If anticipoId <> "" Then
                Session("NUMERO_ANTICIPO") = anticipoId.Substring(0, 19)
                If estadoID = "1068" Then 'se procede a Anular el registro
                    Habilita_Control(True, 1)
                    Dim valor As String = item("VALOR").Text.Trim.ToString
                    Reimpresion(anticipoId, item("CODIGO_CLIENTE").Text.Trim.ToString, item("EMAIL_CLIENTE").Text.Trim.ToString, valor.Replace("$", ""), _
                                item("OBSERVACION").Text.Trim.ToString, item("CLIENTE").Text.Trim.ToString, item("FECHA").Text.Trim.ToString, _
                                item("CODIGO_CLIENTE").Text.Trim.ToString + "_" + DateTime.Now.ToString("HHmmss") + ".PDF")
                Else
                    Habilita_Control(False, 1)
                End If
            End If
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


#End Region

#Region "Procedimientos Generales"

    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Proceso de Enviar el Pdf
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnvioEmailPdf(ByVal anticipo As String, ByVal codigoid As String, ByVal email As String, ByVal cliente As String, ByVal file As String)
        Try
            Dim dTCstData As New System.Data.DataSet
            dTCstData = Clsrecibo.LeerEmail(codigoid, anticipo.Substring(0, 19), "I", Session("user"))
            If dTCstData.Tables(0).Rows.Count > 0 Then
                Dim correo As New System.Net.Mail.MailMessage()
                correo.From = New System.Net.Mail.MailAddress(ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
                correo.To.Add(email)
                'correo.To.Add("galvarado@carsegsa.com")
                Dim mailToBcc As String = ConfigurationManager.AppSettings.Get("UsuarioMailToBcc").ToString()
                Dim mailToBccCollection As [String]() = mailToBcc.Split(";")
                For Each mailTooBcc As String In mailToBccCollection
                    If ExceptionHandler.ValidarEMail(mailTooBcc) Then
                        correo.Bcc.Add(mailTooBcc)
                    End If
                Next
                Dim rutafactura As String = Session("RutaFile")
                Dim fileName As String = file
                Dim urlfilename As String = rutafactura & "Cobros_" & fileName
                correo.Attachments.Add(New Attachment(urlfilename))
                correo.Subject = "Reenvío de Hunter Cobros " & cliente & " Nro. " & anticipo
                Dim htmlbody As String = dTCstData.Tables(0).Rows(0)("HTMLBODY")
                correo.Body = htmlbody
                correo.Priority = MailPriority.High
                correo.IsBodyHtml = True


                'Dim smtp As New System.Net.Mail.SmtpClient
                '---------------------------------------------
                '  DATOS DE LA CONFIGURACIÓN DE LA CUENTA ENVÍA
                '---------------------------------------------
                'smtp.Host = ConfigurationManager.AppSettings.Get("SmptCliente").ToString()
                'Dim smtp As New SmtpClient("smtp.office365.com", 587)
                ''smtp.Credentials = New System.Net.NetworkCredential(ConfigurationManager.AppSettings.Get("VentasMailUser").ToString(), ConfigurationManager.AppSettings.Get("VentasMailPassword").ToString())
                'smtp.Credentials = New System.Net.NetworkCredential("hunteronlinec@carsegsa.com", "%%HO#2025##")

                'smtp.EnableSsl = True
                'smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                'smtp.UseDefaultCredentials = False
                ''smtp.Port = ConfigurationManager.AppSettings.Get("SmptPort").ToString()
                'smtp.Send(correo)
                'correo.Dispose()
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


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Iniciar Variables
    ''' </summary>
    ''' <remarks></remarks>
    Sub InicializaVariable()
        Try
            Dim dtConsultar As New dsHunterCobro.REIMPRESIONDataTable
            dtConsultar.Clear()
            Session("Data") = dtConsultar
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Collapse Registro
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CollapseAllRows()
        Try
            For Each item As GridItem In Grdconsultar.MasterTableView.Items
                item.Expanded = False
            Next
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: consulta Ruta
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ConsultaRuta()
        Try
            Dim dTCstGeneral As New System.Data.DataSet
            dTCstGeneral = Clsrecibo.ConsultaRuta()
            Session("RutaFile") = dTCstGeneral.Tables(0).Rows(0)("RUTA_FILE")
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Reemprision de Documento
    ''' </summary>
    ''' <remarks></remarks>
    Sub Reimpresion(ByVal numero As String, ByVal codcliente As String, ByVal email As String, ByVal valor As Decimal, ByVal observacion As String, ByVal cliente As String, _
                   ByVal fecha As String, ByVal nombre As String)
        Try
            InicializaVariable()
            Dim dtConsultar As New dsHunterCobro.REIMPRESIONDataTable
            Dim dtv As DataRow
            dtConsultar = Session("Data")
            dtv = dtConsultar.NewRow()
            dtv("NUMERO_ANTICIPO") = numero
            dtv("CODIGO_CLIENTE") = codcliente
            dtv("EMAIL_CLIENTE") = email
            dtv("VALOR") = valor
            If observacion = "&nbsp;" Then
                observacion = ""
            End If
            dtv("OBSERVACION") = observacion
            dtv("CLIENTE") = cliente
            dtv("FECHA") = fecha
            dtv("NOMBRE") = nombre
            dtConsultar.Rows.Add(dtv)
            Session("Data") = dtConsultar
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Habilitar Cobntrol
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Habilita_Control(ByVal valor As Boolean, ByVal opcion As String)
        Try
            If opcion = "1" Then
                BtnReenviar.Enabled = valor
            End If
            If opcion = "2" Then
                BtnImprimir.Enabled = valor
            End If
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    Private Sub Mensaje(ByVal texto As String, ByVal operacionRealizar As Int32)
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
            Me.RnMensajesError.Text = texto
            Me.RnMensajesError.Title = titulo
            Me.RnMensajesError.TitleIcon = icono
            Me.RnMensajesError.ContentIcon = icono
            Me.RnMensajesError.Show()
        Catch ex As Exception
            Throw
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
    ''' COMENTARIO: Iniciar Controles
    ''' </summary>
    ''' <remarks></remarks>
    Sub InicializaControles()
        Try
            ControlFecha()
            CargaUsuario()
            CargaEstado()
            SetDatos()
            Session("NUMERO_ANTICIPO") = ""
            Session("CLIENTEID") = ""
            Habilita_Control(False, 1)
            Habilita_Control(False, 2)
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Proceso de Consultar
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Consultar()
        Try
            Dim dtConsultando As New System.Data.DataSet
            dtConsultando = Nothing
            Dim usuarioId, estadoId As String
            If CbxUsuario.SelectedValue = "NNN" Then
                usuarioId = ""
            Else
                usuarioId = CbxUsuario.SelectedValue
            End If
            estadoId = CbxEstado.SelectedValue
            Session("Recaudador") = usuarioId
            Session("fechaInicio") = Me.rdpFechaInicio.SelectedDate
            Session("fechaFin") = Me.rdpFechaFin.SelectedDate
            Session("estado") = estadoId
            dtConsultando = Clsrecibo.ProcesoConsultar(10, ObtenerFechaInicio(), ObtenerFechaFin(), usuarioId, estadoId, Session("user"))
            Dim dtConsolidado As New System.Data.DataSet
            If dtConsultando.Tables(0).Rows.Count > 0 Then
                Session("consultar") = dtConsultando
                Me.Grdconsultar.DataSource = dtConsultando
                Me.Grdconsultar.DataBind()
                Habilita_Control(True, 2)
                dtConsolidado = Clsrecibo.ProcesoConsultar(19, ObtenerFechaInicio(), ObtenerFechaFin(), usuarioId, estadoId, Session("user"))
                Session("consolidado") = dtConsolidado
            Else
                Mensaje("La consulta no devolvió datos.", Operacion.OInvalida)
                Session("consultar") = ""
                Session("consolidado") = ""
                Me.Grdconsultar.DataSource = Session("consultar")
                Me.Grdconsultar.DataBind()
            End If
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Cargar Usuario
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CargaUsuario()
        Try
            Dim dtCargaUsuario As New System.Data.DataSet
            Dim opcion As Integer = 9
            dtCargaUsuario = Clsrecibo.DatosGeneral("", opcion, Session("user"))
            Session("dtCargaUsuario") = dtCargaUsuario
            Me.CbxUsuario.DataSource = dtCargaUsuario
            Me.CbxUsuario.DataValueField = "CODIGO_ID"
            Me.CbxUsuario.DataTextField = "USUARIO"
            Me.CbxUsuario.DataBind()
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Cargar Usuario
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CargaEstado()
        Try
            Dim dtCargaEstado As New System.Data.DataSet
            Dim opcion As Integer = 18
            dtCargaEstado = Clsrecibo.DatosGeneral("", opcion, Session("user"))
            Session("dtEstado") = dtCargaEstado
            Me.CbxEstado.DataSource = dtCargaEstado
            Me.CbxEstado.DataValueField = "CODIGO"
            Me.CbxEstado.DataTextField = "ESTADO"
            Me.CbxEstado.DataBind()
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Control de Fecha
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ControlFecha()
        Try
            Me.rdpFechaInicio.MinDate = "1/1/2012"
            Me.rdpFechaInicio.MaxDate = "31/12/" & Date.Now.Year
            Me.rdpFechaFin.MinDate = "1/1/2012"
            Me.rdpFechaFin.MaxDate = "31/12/" & Date.Now.Year
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Setear Datos
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetDatos()
        Try
            Me.rdpFechaInicio.SelectedDate = Date.Now
            Me.rdpFechaFin.SelectedDate = Date.Now
            Me.CbxUsuario.SelectedValue = Session("user").ToUpper
            Me.CbxEstado.SelectedValue = "0"
            Dim dtDetalle As New dsHunterCobro.CONSULTARDataTable
            dtDetalle.Clear()
            Me.Grdconsultar.DataSource = dtDetalle
            Session("consultar") = dtDetalle
            Me.Grdconsultar.DataBind()
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Obtener Fecha de Inicio
    ''' </summary>
    ''' <remarks></remarks>
    Private Function ObtenerFechaInicio()
        Try
            If Me.rdpFechaInicio.SelectedDate Is Nothing Then
                fechaString = Date.Now.ToString("yyyy/MM/dd")
                fechaInicio = fechaString.Replace("/", "")
            Else
                fechaString = Me.rdpFechaInicio.SelectedDate.Value.ToString("yyyy/MM/dd")
                fechaInicio = fechaString.Replace("/", "")
            End If
        Catch ex As Exception
            Captura_Error(ex)
        End Try
        Return fechaInicio
    End Function


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Obtener Fecha Final
    ''' </summary>
    ''' <remarks></remarks>
    Private Function ObtenerFechaFin()
        Try
            If Me.rdpFechaFin.SelectedDate Is Nothing Then
                fechaString = Date.Now.ToString("yyyy/MM/dd")
                fechaFin = fechaString.Replace("/", "")
            Else
                fechaString = Me.rdpFechaFin.SelectedDate.Value.ToString("yyyy/MM/dd")
                fechaFin = fechaString.Replace("/", "")
            End If
        Catch ex As Exception
            Captura_Error(ex)
        End Try
        Return fechaFin
    End Function


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Validar Fecha
    ''' </summary>
    ''' <remarks></remarks>
    Private Function ValidaFecha()
        Dim i As Int32 = 0
        Try
            If Me.rdpFechaFin.SelectedDate Is Nothing Then
                Me.rdpFechaFin.DbSelectedDate = Date.Now.ToString("yyyy/MM/dd")
            End If
            If Me.rdpFechaInicio.SelectedDate Is Nothing Then
                Me.rdpFechaInicio.DbSelectedDate = Date.Now.ToString("yyyy/MM/dd")
            End If
            If rdpFechaFin.SelectedDate.Value >= rdpFechaInicio.SelectedDate.Value Then
                i = 0
            Else
                i = 1
            End If
        Catch ex As Exception
            Captura_Error(ex)
        End Try
        Return i
    End Function

#End Region


    Private Sub BtnImprimir_Click(sender As Object, e As System.EventArgs) Handles BtnImprimir.Click
        Try
            'Grdconsultar.ExportSettings.ExportOnlyData = True
            'Grdconsultar.ExportSettings.IgnorePaging = True
            'Grdconsultar.ExportSettings.OpenInNewWindow = True
            'Grdconsultar.ExportSettings.UseItemStyles = True
            'Grdconsultar.ExportSettings.HideStructureColumns = True
            'Grdconsultar.ExportSettings.SuppressColumnDataFormatStrings = False
            'Grdconsultar.MasterTableView.HierarchyDefaultExpanded = True
            'Grdconsultar.MasterTableView.DetailTables(0).HierarchyDefaultExpanded = True
            'Grdconsultar.MasterTableView.HierarchyLoadMode = GridChildLoadMode.Client
            'Grdconsultar.MasterTableView.DetailTables(0).HierarchyLoadMode = GridChildLoadMode.Client
            ''        'Grdconsultar.MasterTableView.ExportToWord()
            'Grdconsultar.MasterTableView.ExportToExcel()
            '        'For Each col As GridColumn In Grdconsultar.MasterTableView.RenderColumns
            '        '    col.HeaderStyle.Width = Unit.Pixel(20)
            '        'Next
            '        'Grdconsultar.ExportSettings.Pdf. 
            '        Grdconsultar.ExportSettings.Pdf.AllowPrinting = True
            '        Grdconsultar.ExportSettings.Pdf.PaperSize = GridPaperSize.Letter
            '        Grdconsultar.ExportSettings.Pdf.PageWidth = 1500
            '        Grdconsultar.ExportSettings.Pdf.PageTitle = "Users"
            '        Grdconsultar.ExportSettings.Pdf.AllowModify = True
            '        Grdconsultar.ExportSettings.Pdf.AllowCopy = True
            '        Grdconsultar.ExportSettings.Pdf.FontType = Telerik.Web.Apoc.Render.Pdf.FontType.Embed
            '        'Grdconsultar.ExportSettings.Pdf.PageHeight = Unit.Parse("600mm")
            '        'Grdconsultar.ExportSettings.Pdf.PageWidth = Unit.Parse("800mm")
            '        Grdconsultar.MasterTableView.ExportToPdf()
            Redirect("Consultar_detalle.aspx", "_blank", "menubar=0,width=1450,height=700")
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub



    Public Shared Sub Redirect(url As String, target As String, windowFeatures As String)
        Dim context As HttpContext = HttpContext.Current
        If ([String].IsNullOrEmpty(target) OrElse target.Equals("_self", StringComparison.OrdinalIgnoreCase)) AndAlso [String].IsNullOrEmpty(windowFeatures) Then
            context.Response.Redirect(url)
        Else
            Dim page As Page = DirectCast(context.Handler, Page)
            If page Is Nothing Then
                Throw New InvalidOperationException("Cannot redirect to new window outside Page context.")
            End If
            url = page.ResolveClientUrl(url)
            Dim script As String
            If Not [String].IsNullOrEmpty(windowFeatures) Then
                script = "window.open(""{0}"", ""{1}"", ""{2}"");"
            Else
                script = "window.open(""{0}"", ""{1}"");"
            End If
            script = [String].Format(script, url, target, windowFeatures)
            ScriptManager.RegisterStartupScript(page, GetType(Page), "Redirect", script, True)
        End If
    End Sub

End Class