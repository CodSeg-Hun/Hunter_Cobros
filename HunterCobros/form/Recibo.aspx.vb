Imports System.Net.Mail
Imports Telerik.Web.UI
Imports System.Net

Public Class Recibo
    Inherits System.Web.UI.Page
    Dim valorTotal As Double
    Dim valorEliminado As Double

    Public Enum Operacion
        OExistosa = 1
        OInvalida = 2
        CSinDatos = 3
    End Enum

#Region "Eventos de la pagina"

    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Load de Pagina
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Session("user") IsNot Nothing Then
                    Session("tiponuevo") = Session("tipo")
                    LimpiaControles()
                    Habilita_Control(False, "1")
                    lblfecha.Text = FechaSistema()
                    CargaPago()
                    ControlFecha()
                    CargaSeleccionTab()
                    CargaReferencia()
                    CargaPlazo()
                    CargaCartera()
                    CargaRetencionIva()
                    CargaRetencionFuente()
                    InicializarControl()
                    ConsultaRuta()
                    Clsrecibo.RegistroLog("RECIBO", "Ingreso de Recibo", Session("user"))
                Else
                    Response.Redirect("./login.aspx", False)
                End If
            Else
                If Session("user") Is Nothing Then
                    Response.Redirect("./login.aspx", False)
                End If
            End If
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


#End Region

#Region "Procedimientos Generales"


    Private Sub ControlFecha()
        Try
            Me.rdpFecha.MinDate = Date.Now.Date
            Me.rdpFecha.MaxDate = "31/12/" & Date.Now.Year + 2
            Me.rdpFecha.SelectedDate = Date.Now
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Habilitar Control
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Habilita_Control(ByVal valor As Boolean, ByVal opcion As String)
        Try

            If opcion = "1" Then
                txt_email.Enabled = valor
                txt_recibe.Enabled = valor
                txt_nombres_recibimos.Enabled = valor
                txt_ref.Enabled = valor
                txt_observacion.Enabled = valor
                txt_observacionRef.Enabled = valor
                Cbxreferencia.Enabled = valor
                Cbxforma.Enabled = valor
                Cbxcartera.Enabled = valor
                txt_retencion.Enabled = valor
                'SpinRetencion.Enabled = valor
                CbxretenIva.Enabled = valor
                CbxretenFuente.Enabled = valor
                BtnProcesar.Enabled = valor
                BtnProcesarRef.Enabled = valor
                BtnGuardar.Enabled = valor
                BtnCancelar.Enabled = valor
                CheckBox.Enabled = valor
                CheckBox1.Enabled = valor
                CheckBox2.Enabled = valor
                CheckBox3.Enabled = valor
                CheckBox4.Enabled = valor
                CheckBox5.Enabled = valor
                CheckBox6.Enabled = valor
                CheckBox7.Enabled = valor
                CheckBox8.Enabled = valor
                Txt_otros.Enabled = valor
            End If
            If opcion = "2" Then
                Cbxbanco.Enabled = valor
                txt_valor.Enabled = valor
                txt_documento.Enabled = valor
                BtnProcesar.Enabled = valor
            End If
            If opcion = "3" Then
                TxtIdentificacion.Enabled = valor
            End If
            If opcion = "4" Then
                txt_email.Enabled = valor
                txt_recibe.Enabled = valor
                txt_nombres_recibimos.Enabled = valor
                txt_observacion.Enabled = valor
                Cbxreferencia.Enabled = valor
                Cbxforma.Enabled = valor
                Cbxcartera.Enabled = valor
                txt_valor.Enabled = valor
                Cbxbanco.Enabled = valor
                txt_documento.Enabled = valor
                BtnGuardar.Enabled = valor
                BtnCancelar.Enabled = valor
                CheckBox.Enabled = valor
                CheckBox1.Enabled = valor
                CheckBox2.Enabled = valor
                CheckBox3.Enabled = valor
                CheckBox4.Enabled = valor
                CheckBox5.Enabled = valor
                CheckBox6.Enabled = valor
                CheckBox7.Enabled = valor
                CheckBox8.Enabled = valor
                Txt_otros.Enabled = valor
            End If
            If opcion = "5" Then
                txt_valor.Enabled = valor
                Cbxbanco.Enabled = Not valor
                Cbxplazo.Enabled = Not valor
                txt_documento.Enabled = Not valor
                txt_voucher.Enabled = Not valor
                txt_retencion.Enabled = Not valor
                'SpinRetencion.Enabled = Not valor
                CbxretenIva.Enabled = Not valor
                CbxretenFuente.Enabled = Not valor
                BtnProcesar.Enabled = valor
            End If
            If opcion = "6" Then
                txt_email.Enabled = valor
                txt_recibe.Enabled = valor
                txt_nombres_recibimos.Enabled = valor
                txt_ref.Enabled = valor
                txt_observacion.Enabled = valor
                txt_observacionRef.Enabled = valor
                TxtIdentificacion.Enabled = valor
                Cbxreferencia.Enabled = valor
                Cbxforma.Enabled = valor
                Cbxcartera.Enabled = valor
                txt_valor.Enabled = valor
                Cbxbanco.Enabled = valor
                Cbxplazo.Enabled = valor
                txt_retencion.Enabled = valor
                'SpinRetencion.Enabled = valor
                CbxretenIva.Enabled = valor
                CbxretenFuente.Enabled = valor
                txt_documento.Enabled = valor
                txt_voucher.Enabled = valor
                BtnProcesar.Enabled = valor
                BtnProcesarRef.Enabled = valor
                BtnGuardar.Enabled = valor
                CheckBox.Enabled = valor
                CheckBox1.Enabled = valor
                CheckBox2.Enabled = valor
                CheckBox3.Enabled = valor
                CheckBox4.Enabled = valor
                CheckBox5.Enabled = valor
                CheckBox6.Enabled = valor
                CheckBox7.Enabled = valor
                CheckBox8.Enabled = valor
                Txt_otros.Enabled = valor
            End If
            If opcion = "7" Then
                txt_ref.Enabled = valor
                txt_observacionRef.Enabled = valor
                BtnProcesarRef.Enabled = valor
            End If
            If opcion = "8" Then
                Cbxplazo.Enabled = valor
                txt_voucher.Enabled = valor
            End If
            If opcion = "9" Then
                txt_retencion.Enabled = valor
                'SpinRetencion.Enabled = valor
                CbxretenIva.Enabled = valor
                CbxretenFuente.Enabled = valor
            End If
            If opcion = "10" Then
                txt_documento.Enabled = valor
            End If
            If opcion = "11" Then
                CheckBox.Checked = valor
                CheckBox1.Checked = valor
                CheckBox2.Checked = valor
                CheckBox3.Checked = valor
                CheckBox4.Checked = valor
                CheckBox5.Checked = valor
                CheckBox6.Checked = valor
                CheckBox7.Checked = valor
                CheckBox8.Checked = valor
            End If
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    Private Sub CargaSeleccionTab()
        Try
            Me.radtabdatos.SelectedIndex = 0
            Me.RadMultiPage1.SelectedIndex = 0
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Limpiar Controles
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LimpiaControles()
        Try
            TxtIdentificacion.Text = ""
            lblcliente.Text = ""
            lblfecha.Text = ""
            txt_email.Text = ""
            txt_recibe.Text = ""
            txt_nombres_recibimos.Text = ""
            txt_ref.Text = "0"
            txt_observacion.Text = ""
            txt_valor.Text = 0
            txt_documento.Text = ""
            lblcantidad.Text = ""
            lblanticipo.Text = ""
            lblbanco.Text = "Banco "
            valorTotal = 0
            lblcantidad.Text = 0
            Session("Nombre") = ""
            txt_observacionRef.Text = ""
            txt_voucher.Text = ""
            txt_retencion.Text = ""
            'SpinRetencion.Text = 0
            CbxretenFuente.SelectedValue = "000"
            CbxretenIva.SelectedValue = "000"
            CargaSeleccionTab()
            'Label14.Text = "No. Voucher"
            'Label13.Text = "Plazo"
            'txt_voucher.EmptyMessage = "Voucher "
            'Cbxplazo.Visible = True
            'div1.Visible = "False"
            'div2.Visible = "True"
            'SpinRetencion.Visible = False
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
    Private Sub InicializarControl()
        Try
            Cbxforma.SelectedValue = "NN"
            Cbxcartera.SelectedValue = "NN"
            Cbxreferencia.SelectedValue = "NNN"
            Cbxplazo.SelectedValue = "NN"
            Dim dtDetalle As New dsHunterCobro.ANTICIPO_DETALLEDataTable
            dtDetalle.Clear()
            Me.Grddetalle.DataSource = dtDetalle
            Session("recibo") = dtDetalle
            Me.Grddetalle.DataBind()
            Me.Grddetalle.Rebind()
            lblfecha.Text = FechaSistema()
            Dim dtReferencia As New dsHunterCobro.REFERENCIA_DETALLEDataTable
            dtReferencia.Clear()
            Me.Grdreferencia.DataSource = dtReferencia
            Session("referencia") = dtReferencia
            Me.Grdreferencia.DataBind()
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Fecha de Sistema
    ''' </summary>
    ''' <remarks></remarks>
    Private Function FechaSistema()
        Dim fechaStr As String = ""
        Try
            Dim day, month As Integer
            Dim dayStr, monthStr, yearStr As String
            day = Now.Day
            If day <= 9 Then
                dayStr = "0" & day
            Else
                dayStr = day.ToString
            End If
            month = Now.Month
            If month = 1 Then
                monthStr = "Enero"
            ElseIf month = 2 Then
                monthStr = "Febrero"
            ElseIf month = 3 Then
                monthStr = "Marzo"
            ElseIf month = 4 Then
                monthStr = "Abril"
            ElseIf month = 5 Then
                monthStr = "Mayo"
            ElseIf month = 6 Then
                monthStr = "Junio"
            ElseIf month = 7 Then
                monthStr = "Julio"
            ElseIf month = 8 Then
                monthStr = "Agosto"
            ElseIf month = 9 Then
                monthStr = "Septiembre"
            ElseIf month = 10 Then
                monthStr = "Octubre"
            ElseIf month = 11 Then
                monthStr = "Noviembre"
            ElseIf month = 12 Then
                monthStr = "Diciembre"
            Else
                monthStr = ""
            End If
            yearStr = Now.Year.ToString
            fechaStr = dayStr & "/" & monthStr & "/" & yearStr
        Catch ex As Exception
            Captura_Error(ex)
        End Try
        Return fechaStr
    End Function


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


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Carga Forma de Pago
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CargaPago()
        Try
            Dim datos As New Clsrecibo
            Dim dt As New dsHunterCobro.FORMADataTable
            dt.Load(datos.CargaForma.CreateDataReader)
            Me.Cbxforma.DataValueField = "CODIGO"
            Me.Cbxforma.DataTextField = "DESCRIPCION"
            Me.Cbxforma.DataSource = dt
            Me.Cbxforma.DataBind()
            'Cbxforma.AllowCustomText = True
            'Cbxforma.MarkFirstMatch = True
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Carga Usuario Cartera
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CargaCartera()
        Try
            Dim datos As New Clsrecibo
            Dim dt As New dsHunterCobro.CARTERADataTable
            dt.Load(datos.CargaCartera.CreateDataReader)
            Me.Cbxcartera.DataValueField = "CODIGO"
            Me.Cbxcartera.DataTextField = "DESCRIPCION"
            Me.Cbxcartera.DataSource = dt
            Me.Cbxcartera.DataBind()
            'Cbxforma.AllowCustomText = True
            'Cbxforma.MarkFirstMatch = True
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub

    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Carga Forma de Pago
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CargaPlazo()
        Try
            Dim datos As New Clsrecibo
            Dim dt As New dsHunterCobro.PLAZODataTable
            dt.Load(datos.CargaPlazo.CreateDataReader)
            Me.Cbxplazo.DataValueField = "CODIGO"
            Me.Cbxplazo.DataTextField = "DESCRIPCION"
            Me.Cbxplazo.DataSource = dt
            Me.Cbxplazo.DataBind()
            Cbxplazo.AllowCustomText = True
            Cbxplazo.MarkFirstMatch = True
            Cbxplazo.Filter = DirectCast(Convert.ToInt32(1), RadComboBoxFilter)
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    Private Sub CargaRetencionIva()
        Try
            Dim datos As New Clsrecibo
            Dim dt As New dsHunterCobro.RETENCIONIVADataTable
            dt.Load(datos.CargaRetencionIva.CreateDataReader)
            Me.CbxretenIva.DataValueField = "CODIGO"
            Me.CbxretenIva.DataTextField = "DESCRIPCION"
            Me.CbxretenIva.DataSource = dt
            Me.CbxretenIva.DataBind()
            'CbxretenIva.AllowCustomText = True
            'CbxretenIva.MarkFirstMatch = True
            'CbxretenIva.Filter = DirectCast(Convert.ToInt32(1), RadComboBoxFilter)
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub

    Private Sub CargaRetencionFuente()
        Try
            Dim datos As New Clsrecibo
            Dim dt As New dsHunterCobro.RETENCIONFUENTEDataTable
            dt.Load(datos.CargaRetencionFuente.CreateDataReader)
            Me.CbxretenFuente.DataValueField = "CODIGO"
            Me.CbxretenFuente.DataTextField = "DESCRIPCION"
            Me.CbxretenFuente.DataSource = dt
            Me.CbxretenFuente.DataBind()
            'CbxretenFuente.AllowCustomText = True
            'CbxretenFuente.MarkFirstMatch = True
            'CbxretenFuente.Filter = DirectCast(Convert.ToInt32(1), RadComboBoxFilter)
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Carga Forma de Pago
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CargaReferencia()
        Try
            Dim datos As New Clsrecibo
            Dim dt As New dsHunterCobro.REFERENCIADataTable
            dt.Load(datos.CargaReferencia.CreateDataReader)
            Me.Cbxreferencia.DataValueField = "CODIGO"
            Me.Cbxreferencia.DataTextField = "TIPO"
            Me.Cbxreferencia.DataSource = dt
            Me.Cbxreferencia.DataBind()
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Cargar Banco
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CargaBanco()
        Try
            Dim datos As New Clsrecibo
            Dim dt As New dsHunterCobro.BANCODataTable
            dt.Load(datos.CargaBanco.CreateDataReader)
            Me.Cbxbanco.DataValueField = "CODIGO"
            Me.Cbxbanco.DataTextField = "DESCRIPCION"
            Me.Cbxbanco.DataSource = dt
            Me.Cbxbanco.DataBind()
            Cbxbanco.AllowCustomText = True
            Cbxbanco.MarkFirstMatch = True
            Cbxbanco.Filter = DirectCast(Convert.ToInt32(1), RadComboBoxFilter)
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Cargar Tarjeta
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CargaTarjeta()
        Try
            Dim datos As New Clsrecibo
            Dim dt As New dsHunterCobro.FORMADataTable
            dt.Load(datos.CargaTarjeta.CreateDataReader)
            Me.Cbxbanco.DataValueField = "CODIGO"
            Me.Cbxbanco.DataTextField = "DESCRIPCION"
            Me.Cbxbanco.DataSource = dt
            Me.Cbxbanco.DataBind()
            Cbxbanco.AllowCustomText = True
            Cbxbanco.MarkFirstMatch = True
            Cbxbanco.Filter = DirectCast(Convert.ToInt32(1), RadComboBoxFilter)
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Adicionar Registro
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AdicionarRegistro()
        Try
            Dim dtDetalle As New dsHunterCobro.ANTICIPO_DETALLEDataTable
            Dim dtv As DataRow
            dtDetalle = Session("recibo")
            Dim validacion As Boolean = True
            For i As Integer = 0 To dtDetalle.Rows.Count - 1
                If Cbxforma.SelectedValue = "RT" Then
                    If dtDetalle.Rows(i).Item("VALOR") = txt_valor.Text And dtDetalle.Rows(i).Item("CODIGO_FORMA") = Cbxforma.SelectedValue And dtDetalle.Rows(i).Item("FORMA_PAGO") = Cbxforma.Text & " " & CbxretenFuente.Text & "%" _
                        And dtDetalle.Rows(i).Item("DOCUMENTO") = txt_documento.Text _
                        And dtDetalle.Rows(i).Item("RETENCION") = txt_retencion.Text Then
                        Me.Grddetalle.DataSource = dtDetalle
                        Me.Grddetalle.DataBind()
                        Me.Grddetalle.Rebind()
                        validacion = False
                        Mensaje("Verificar ingreso de datos duplicados", Operacion.OInvalida)
                        Exit For
                        'Else
                        '    validacion = True
                    End If
                ElseIf Cbxforma.SelectedValue = "RI" Then
                    If dtDetalle.Rows(i).Item("VALOR") = txt_valor.Text And dtDetalle.Rows(i).Item("CODIGO_FORMA") = Cbxforma.SelectedValue And dtDetalle.Rows(i).Item("FORMA_PAGO") = Cbxforma.Text & " " & CbxretenIva.Text & "%" _
                        And dtDetalle.Rows(i).Item("DOCUMENTO") = txt_documento.Text _
                        And dtDetalle.Rows(i).Item("RETENCION") = txt_retencion.Text Then
                        Me.Grddetalle.DataSource = dtDetalle
                        Me.Grddetalle.DataBind()
                        Me.Grddetalle.Rebind()
                        Mensaje("Verificar ingreso de datos duplicados", Operacion.OInvalida)
                        validacion = False
                        Exit For
                        'Else
                        '    validacion = True
                    End If
                ElseIf dtDetalle.Rows(i).Item("VALOR") = txt_valor.Text And dtDetalle.Rows(i).Item("CODIGO_FORMA") = Cbxforma.SelectedValue And dtDetalle.Rows(i).Item("FORMA_PAGO") = Cbxforma.Text _
                      And dtDetalle.Rows(i).Item("VOUCHER") = txt_voucher.Text And dtDetalle.Rows(i).Item("BANCO") = Cbxbanco.Text And dtDetalle.Rows(i).Item("DOCUMENTO") = txt_documento.Text _
                      And dtDetalle.Rows(i).Item("RETENCION") = txt_retencion.Text And (dtDetalle.Rows(i).Item("PORC_RETENCION") = CbxretenIva.SelectedValue Or dtDetalle.Rows(i).Item("PORC_RETENCION") = CbxretenFuente.SelectedValue) Then
                    Me.Grddetalle.DataSource = dtDetalle
                    Me.Grddetalle.DataBind()
                    Me.Grddetalle.Rebind()
                    validacion = False
                    Exit For
                Else
                    validacion = True
                End If
            Next
            If validacion Then
                dtv = dtDetalle.NewRow()
                dtv("CODIGO_FORMA") = Cbxforma.SelectedValue
                dtv("FORMA_PAGO") = Cbxforma.Text
                dtv("FECHA_CHEQUE") = "1900-01-01"
                If Cbxforma.SelectedValue = "DE" Then
                    dtv("CODIGO_BANCO") = ""
                Else
                    dtv("CODIGO_BANCO") = Cbxbanco.SelectedValue
                End If
                If Cbxforma.SelectedValue = "RT" Then   ' POR RETENCIONES de Fuente
                    dtv("RETENCION") = txt_retencion.Text
                    dtv("PORC_RETENCION") = CbxretenFuente.Text
                    dtv("FORMA_PAGO") = Cbxforma.Text & " " & CbxretenFuente.Text & "%"
                    dtv("COD_RETENCION") = CbxretenFuente.SelectedValue
                ElseIf Cbxforma.SelectedValue = "RI" Then   ' POR RETENCIONES de Iva 
                    dtv("RETENCION") = txt_retencion.Text
                    dtv("PORC_RETENCION") = CbxretenIva.Text
                    dtv("FORMA_PAGO") = Cbxforma.Text & " " & CbxretenIva.Text & "%"
                    dtv("COD_RETENCION") = CbxretenIva.SelectedValue
                Else
                    dtv("RETENCION") = ""
                    dtv("PORC_RETENCION") = ""
                    dtv("COD_RETENCION") = ""
                End If
                If Cbxforma.SelectedValue = "CP" Then 'Cheque a fecha
                    Session("tiponuevo") = "RTC"
                End If
                If Cbxforma.SelectedValue = "DC" Or Cbxforma.SelectedValue = "CP" Then 'Cheque a Vista O Cheque a fecha
                    dtv("FECHA_CHEQUE") = rdpFecha.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", "-")
                End If
                If Cbxbanco.SelectedValue = "NN" Then
                    dtv("CODIGO_BANCO") = ""
                End If
                If Cbxplazo.SelectedValue = "NN" Then
                    dtv("PLAZO") = ""
                Else
                    dtv("PLAZO") = Cbxplazo.SelectedValue
                End If
                dtv("VOUCHER") = txt_voucher.Text
                dtv("BANCO") = Cbxbanco.Text
                dtv("VALOR") = Convert.ToDecimal(txt_valor.Text).ToString("#,##0.00")
                dtv("DOCUMENTO") = txt_documento.Text
                dtv("DETALLE_ID") = dtDetalle.Rows.Count + 1
                dtDetalle.Rows.Add(dtv)
                'Dim valor1 As Double = lblcantidad.Text
                'Dim valor2 As Double = txt_valor.Text
                'valorTotal = valor1 + valor2
            End If
            For i As Integer = 0 To dtDetalle.Rows.Count - 1
                valorTotal += dtDetalle.Rows(i).Item("VALOR")
            Next
            lblcantidad.Text = valorTotal.ToString("#,##0.00")
            Me.Grddetalle.DataSource = dtDetalle
            Me.Grddetalle.DataBind()
            Me.Grddetalle.Rebind()
            Session("recibo") = dtDetalle
            txt_valor.Text = 0
            txt_documento.Text = ""
            Cbxforma.SelectedValue = "NN"
            Cbxbanco.SelectedValue = "NN"
            Cbxplazo.SelectedValue = "NN"
            txt_voucher.Text = ""
            txt_retencion.Text = ""
            ' SpinRetencion.Text = 0
            CbxretenIva.SelectedValue = "000"
            CbxretenFuente.SelectedValue = "000"
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Adicionar Registro
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AdicionarReferencia()
        Try
            Dim dtReferencia As New dsHunterCobro.REFERENCIA_DETALLEDataTable
            Dim dtv As DataRow
            dtReferencia = Session("referencia")
            Dim validacion As Boolean = True
            For i As Integer = 0 To dtReferencia.Rows.Count - 1
                If dtReferencia.Rows(i).Item("DOC_REFERENCIA") = Cbxreferencia.Text And dtReferencia.Rows(i).Item("REFERENCIA") = txt_ref.Text And dtReferencia.Rows(i).Item("OBSERVACION") = txt_observacionRef.Text.ToUpper Then
                    Me.Grdreferencia.DataSource = dtReferencia
                    Me.Grdreferencia.DataBind()
                    Me.Grdreferencia.Rebind()
                    validacion = False
                    Exit For
                Else
                    validacion = True
                End If
            Next
            If validacion Then
                dtv = dtReferencia.NewRow()
                dtv("CODIGO_REFERENCIA") = Cbxreferencia.SelectedValue
                dtv("DOC_REFERENCIA") = Cbxreferencia.Text
                dtv("REFERENCIA") = txt_ref.Text
                dtv("OBSERVACION") = txt_observacionRef.Text.ToUpper()
                dtv("REFERENCIA_ID") = dtReferencia.Rows.Count + 1
                dtReferencia.Rows.Add(dtv)
            End If
            Me.Grdreferencia.DataSource = dtReferencia
            Me.Grdreferencia.DataBind()
            Me.Grdreferencia.Rebind()
            Session("referencia") = dtReferencia
            Cbxreferencia.SelectedValue = "NNN"
            Me.txt_observacionRef.Text = ""
            Me.txt_ref.Text = "0"
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Obter Ruta del Pdf
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
    ''' COMENTARIO: Para Generar el Documento
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Documento()
        Try
            Dim objDocumento As New GenerarPdf
            objDocumento.GenerarDocumento(Session("Nombre"), Session("RutaFile"), Session("recibo"), _
                                          Me.lblanticipo.Text, Me.TxtIdentificacion.Text, Me.txt_email.Text, Me.txt_nombres_recibimos.Text, Me.lblcantidad.Text, _
                                          Me.txt_observacion.Text, Me.lblcliente.Text, Session("name"), Me.lblfecha.Text, Session("referencia"))
            EnvioEmailPdf()
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Validar de Tarjeta
    ''' </summary>
    ''' <remarks></remarks>
    Private Function ValidaTarjeta(ByVal tarjeta As String) As Boolean
        ValidaTarjeta = True
        Try
            Dim dtConsultar As New System.Data.DataSet
            dtConsultar = Clsrecibo.VerificaTarjeta(tarjeta)
            If dtConsultar.Tables(0).Rows(0)("VALIDO").ToString() = "0" Then
                ValidaTarjeta = False
            End If
            Return ValidaTarjeta
        Catch ex As Exception
            ExceptionHandler.Captura_Error(ex)
        End Try
    End Function


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Generar el PDf
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnvioEmailPdf()
        Try
            Dim dTCstData As New System.Data.DataSet
            Dim anticipo As String = Me.lblanticipo.Text
            dTCstData = Clsrecibo.LeerEmail(Me.TxtIdentificacion.Text, anticipo.Substring(0, 19), "I", Session("user"))
            If dTCstData.Tables(0).Rows.Count > 0 Then
                Dim correo As New System.Net.Mail.MailMessage()
                correo.From = New System.Net.Mail.MailAddress(ConfigurationManager.AppSettings.Get("VentasMailAddress").ToString())
                correo.To.Add(Me.txt_email.Text.Trim)
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
                Dim rutafactura As String = Session("RutaFile")
                Dim fileName As String = Session("Nombre")
                Dim urlfilename As String = rutafactura & "Cobros_" & fileName
                correo.Attachments.Add(New Attachment(urlfilename))
                correo.Subject = "Hunter Cobros " & Me.lblcliente.Text & " Nro. " & Me.lblanticipo.Text
                Dim htmlbody As String = dTCstData.Tables(0).Rows(0)("HTMLBODY")
                correo.Body = htmlbody
                correo.Priority = MailPriority.High
                correo.IsBodyHtml = True
                'Dim smtp As New System.Net.Mail.SmtpClient
                ''---------------------------------------------
                ''  DATOS DE LA CONFIGURACIÓN DE LA CUENTA ENVÍA
                ''---------------------------------------------
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


    Private Function Tipo_Servicio()
        Dim cadenaCaracter As String = ""
        Try
            If CheckBox.Checked Then
                cadenaCaracter += "RHL" & ";"
            End If
            If CheckBox1.Checked Then
                cadenaCaracter += "RHM" & ";"
            End If
            If CheckBox2.Checked Then
                cadenaCaracter += "IHL" & ";"
            End If
            If CheckBox3.Checked Then
                cadenaCaracter += "IHM" & ";"
            End If
            If CheckBox4.Checked Then
                cadenaCaracter += "ALA" & ";"
            End If
            If CheckBox5.Checked Then
                cadenaCaracter += "PEL" & ";"
            End If
            If CheckBox6.Checked Then
                cadenaCaracter += "HSE" & ";"
            End If
            If CheckBox7.Checked Then
                cadenaCaracter += "GEX" & ";"
            End If
            If CheckBox8.Checked Then
                cadenaCaracter += "TRA" & ";"
            End If
            If Me.Txt_otros.Text <> "" Then
                cadenaCaracter += Me.Txt_otros.Text.ToUpper() & ";"
            End If
        Catch ex As Exception
            Captura_Error(ex)
        End Try
        Return cadenaCaracter
    End Function

#End Region

#Region "Eventos de los controles"


    Protected Sub BtnProcesarRef_Click(sender As Object, e As EventArgs) Handles BtnProcesarRef.Click
        Try
            If Cbxreferencia.SelectedValue = "NNN" Then
                Mensaje("Debe de Ingresar el tipo de documento.", Operacion.OInvalida)
                'ElseIf txt_ref.Text = 0 Or txt_ref.Text = "" Then
            ElseIf txt_ref.Text = "" Or txt_ref.Text = "0" Then
                Mensaje("Debe de Ingresar el documento.", Operacion.OInvalida)
            Else
                AdicionarReferencia()
                Habilita_Control(False, "7")
            End If
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Boton Procesar
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub BtnProcesar_Click(sender As Object, e As EventArgs) Handles BtnProcesar.Click
        Try
            BtnProcesar.Enabled = False
            If Cbxforma.SelectedValue = "DE" Then
                If txt_valor.Text = 0 Or txt_valor.Text = "" Then
                    Mensaje("Debe de Ingresar el valor entregado.", Operacion.OInvalida)
                Else
                    AdicionarRegistro()
                    Habilita_Control(False, "2")
                    Habilita_Control(False, "10")
                    BtnProcesar.Enabled = True
                End If
            ElseIf Cbxforma.SelectedValue = "DC" Or Cbxforma.SelectedValue = "CP" Or Cbxforma.SelectedValue = "PD" Then ' cheque vista, cheque fecha, papeleta deposito
                If Cbxforma.SelectedValue = "PD" Then
                    Habilita_Control(False, "10")
                End If
                If txt_documento.Text = "" And Cbxforma.SelectedValue <> "PD" Then
                    Mensaje("Debe de Ingresar el numero de documento.", Operacion.OInvalida)
                ElseIf Cbxbanco.SelectedValue = "NN" Then
                    'If Cbxforma.SelectedValue = "DC" Or Cbxforma.SelectedValue = "CP" Or Cbxforma.SelectedValue = "PD" Or Cbxforma.SelectedValue = "TD" Then
                    Mensaje("Debe de Ingresar el Banco", Operacion.OInvalida)
                    'Else
                    '    Mensaje("Debe de Ingresar la tarjeta", Operacion.OInvalida)
                    'End If
                ElseIf Cbxforma.SelectedValue = "CP" And Me.rdpFecha.SelectedDate = Format(Date.Now, "dd/MMM/yyyy") Then
                    Mensaje("Para Cheque a fecha  no puede tener la misma fecha de hoy", Operacion.OInvalida)
                ElseIf txt_valor.Text = 0 Or txt_valor.Text = "" Then
                    Mensaje("Debe de Ingresar el valor entregado.", Operacion.OInvalida)
                Else
                    AdicionarRegistro()
                    Habilita_Control(False, "2")
                    BtnProcesar.Enabled = True
                End If
            ElseIf Cbxforma.SelectedValue = "TJ" Or Cbxforma.SelectedValue = "TI" Or Cbxforma.SelectedValue = "TD" Then ' Tarjeta de credito sin interes, con interes, debito
                If Cbxbanco.SelectedValue = "NN" Then
                    Mensaje("Debe de Ingresar la tarjeta", Operacion.OInvalida)
                    'ElseIf Cbxplazo.SelectedValue = "NN" Then
                    ' Mensaje("Debe escoger el plazo", Operacion.OInvalida)
                ElseIf txt_valor.Text = 0 Or txt_valor.Text = "" Then
                    Mensaje("Debe de Ingresar el valor entregado.", Operacion.OInvalida)
                ElseIf txt_voucher.Text = "" Then
                    Mensaje("Debe de Ingresar el Voucher", Operacion.OInvalida)
                Else
                    'If Len(txt_documento.Text) > 8 Then
                    AdicionarRegistro()
                    Habilita_Control(False, "2")
                    Habilita_Control(False, "8")
                    Habilita_Control(False, "10")
                    BtnProcesar.Enabled = True
                    'Else
                    'Mensaje("Debe Ingresar minimo 9 digitos, por favor verifique.", Operacion.OInvalida)
                    'End If
                End If
            ElseIf Cbxforma.SelectedValue = "RT" Or Cbxforma.SelectedValue = "RI" Then 'Por retencion de Iva y Fuente
                If txt_valor.Text = 0 Or txt_valor.Text = "" Then
                    Mensaje("Debe de Ingresar el valor entregado.", Operacion.OInvalida)
                ElseIf txt_documento.Text = 0 Then
                    Mensaje("Debe de Ingresar el Nro. de Documento", Operacion.OInvalida)
                ElseIf txt_retencion.Text = 0 Then
                    Mensaje("Debe de Ingresar el Nro. de la Serie", Operacion.OInvalida)
                    'ElseIf txt_retencion.Text = "" Then
                    '    Mensaje("Debe de Ingresar el Nro. de Retención", Operacion.OInvalida)
                ElseIf CbxretenFuente.SelectedValue = "000" And Cbxforma.SelectedValue = "RT" Then ' RETENCION FUENTE
                    Mensaje("Debe de Ingresar el Porcentaje de Retención", Operacion.OInvalida)
                ElseIf CbxretenIva.SelectedValue = "000" And Cbxforma.SelectedValue = "RI" Then ' RETENCION IVA
                    Mensaje("Debe de Ingresar el Porcentaje de Retención", Operacion.OInvalida)
                Else
                    'If Len(txt_documento.Text) > 1 Then
                    If Len(txt_retencion.Text) = 6 Then
                        AdicionarRegistro()
                        Habilita_Control(False, "2")
                        Habilita_Control(False, "8")
                        Habilita_Control(False, "9")
                        Habilita_Control(False, "10")
                        BtnProcesar.Enabled = True
                    Else
                        Mensaje("Debe Ingresar minimo 6 digitos en el campo Nro. de la Serie, por favor verifique.", Operacion.OInvalida)
                    End If
                    'Else
                    '    Mensaje("Debe Ingresar minimo 2 digitos en el campo Nro. de Documento, por favor verifique.", Operacion.OInvalida)
                    'End If
                End If
            Else
                Mensaje("Debe selecionar una forma de pago", Operacion.OInvalida)
            End If
            BtnProcesar.Enabled = True
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Boton Guardar
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If Session("user") Is Nothing Then
                Response.Redirect("./login.aspx", False)
            End If
            If Me.TxtIdentificacion.Text <> "" Then
                If Me.txt_email.Text <> "" Then
                    If Session("recibo").Rows.Count > 0 Then
                        Dim datos As New Clsrecibo
                        Dim codigoAnticipo As String
                        codigoAnticipo = datos.RegistraInformacion(Me.TxtIdentificacion.Text, Me.txt_email.Text, Me.txt_recibe.Text, Me.txt_nombres_recibimos.Text,
                                                                   Session("user"), Me.lblcantidad.Text, Session("recibo"), Me.txt_observacion.Text,
                                                                   Session("tiponuevo"), Me.lblcliente.Text, Session("referencia"), Tipo_Servicio(),
                                                                   Cbxcartera.SelectedValue)


                        If codigoAnticipo = "1" Or codigoAnticipo = "-1" Then
                            Mensaje("Error al procesar los datos", Operacion.OInvalida)
                        ElseIf codigoAnticipo = "2" Then
                            Mensaje("Documento ya ingresado", Operacion.OInvalida)
                        Else
                            Me.lblanticipo.Text = codigoAnticipo
                            Documento()
                            Habilita_Control(False, "6")
                            Mensaje("Se proceso correctamente.", Operacion.OExistosa)
                            Session("tiponuevo") = Session("tipo")
                        End If
                    Else
                        Mensaje("Debe la forma de pago", Operacion.OInvalida)
                    End If
                Else
                    Mensaje("Debe Ingresar el Email", Operacion.OInvalida)
                End If
            Else
                Mensaje("Debe Ingresar la identificación ", Operacion.OInvalida)
            End If
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
    Private Sub BtnCancelar_Click(sender As Object, e As System.EventArgs) Handles BtnCancelar.Click
        Try
            Habilita_Control(False, "4")
            Habilita_Control(True, "3")
            Habilita_Control(False, "8")
            Habilita_Control(False, "9")
            Habilita_Control(False, "10")
            Habilita_Control(False, "11")
            '*BtnProcesar.Enabled = False
            BtnProcesarRef.Enabled = False
            Cbxplazo.Visible = True
            CbxretenIva.Enabled = False
            CbxretenIva.Visible = True
            LimpiaControles()
            InicializarControl()
            Session("tiponuevo") = Session("tipo")
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Control de Identificacion
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub TxtIdentificacion_TextChanged(sender As Object, e As EventArgs) Handles TxtIdentificacion.TextChanged
        Try
            'If Len(TxtIdentificacion.Text) = 10 Or Len(TxtIdentificacion.Text) = 13 Then
            Dim dtConsultar As New System.Data.DataSet
            dtConsultar = Nothing
            dtConsultar = Clsrecibo.DatosGeneral(Me.TxtIdentificacion.Text.Trim(), 4, Session("user"))
            If dtConsultar.Tables.Count > 0 Then
                If dtConsultar.Tables(0).Rows.Count > 0 Then
                    lblcliente.Text = dtConsultar.Tables(0).Rows(0)("Nombre").ToString()
                    txt_email.Text = dtConsultar.Tables(0).Rows(0)("Email").ToString()
                    txt_recibe.Text = TxtIdentificacion.Text
                    txt_nombres_recibimos.Text = lblcliente.Text
                    Session("Nombre") = TxtIdentificacion.Text + "_" + DateTime.Now.ToString("HHmmss") + ".PDF"
                    Habilita_Control(True, "4")
                    Habilita_Control(False, "3")
                Else
                    Mensaje("La Cédula/Ruc no existen.", Operacion.OInvalida)
                End If
            Else
                Mensaje("Ingrese el Cédula/Ruc correcta.", Operacion.OInvalida)
            End If
            'Else
            '    lblcliente.Text = ""
            '    Mensaje("Ingrese el Cédula/Ruc correcta.", Operacion.OInvalida)
            'End If
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    Private Sub Cbxreferencia_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles Cbxreferencia.SelectedIndexChanged
        Try
            If Cbxreferencia.SelectedValue = "NNN" Then
                Habilita_Control(False, "7")
            Else
                Habilita_Control(True, "7")
            End If
            Me.txt_ref.Text = "0"
            txt_observacionRef.Text = ""
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Control de Forma 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Cbxforma_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles Cbxforma.SelectedIndexChanged
        Try
            'Label14.Text = "No. Voucher"
            'Label13.Text = "Plazo"
            'lblbanco.Text = "Banco "
            'txt_voucher.EmptyMessage = "Voucher "
            'Cbxplazo.Visible = True
            'SpinRetencion.Visible = False
            Label13.Text = "Plazo"
            Cbxplazo.Visible = True
            rdpFecha.Visible = False
            txt_retencion.Enabled = False
            'SpinRetencion.Enabled = False
            'CbxretenFuente.Enabled = False
            CbxretenFuente.Visible = False
            'CbxretenIva.Enabled = False
            CbxretenIva.Visible = True
            If Cbxforma.SelectedValue = "NN" Then
                Habilita_Control(False, "2")
                Habilita_Control(False, "10")
            ElseIf Cbxforma.SelectedValue = "DE" Then 'efectivo
                'lblbanco.Text = "Banco "
                txt_documento.MaxLength = 10
                Habilita_Control(True, "5")
                Habilita_Control(False, "10")
                Habilita_Control(False, "9")
                txt_documento.Text = ""
                txt_retencion.Text = ""
            ElseIf Cbxforma.SelectedValue = "RT" Or Cbxforma.SelectedValue = "RI" Then 'Por retencion de Iva y Fuente
                txt_documento.MaxLength = 10
                txt_retencion.MaxLength = 6
                Habilita_Control(True, "2")
                Habilita_Control(False, "8")
                Habilita_Control(True, "9")
                'Habilita_Control(False, "10")
                Habilita_Control(True, "10")
                Cbxbanco.Enabled = False
                If Cbxforma.SelectedValue = "RT" Then 'RETENCION FUENTE
                    CbxretenFuente.Visible = True
                    CbxretenFuente.Enabled = True
                    CbxretenIva.Visible = False
                    CbxretenIva.Enabled = False
                ElseIf Cbxforma.SelectedValue = "RI" Then  'RETENCION IVA
                    CbxretenFuente.Visible = False
                    CbxretenFuente.Enabled = False
                    CbxretenIva.Visible = True
                    CbxretenIva.Enabled = True
                End If
                txt_documento.Text = "0"
                txt_retencion.Text = "0"
            ElseIf Cbxforma.SelectedValue = "DC" Or Cbxforma.SelectedValue = "CP" Or Cbxforma.SelectedValue = "PD" Or Cbxforma.SelectedValue = "TD" Then 'cheque vista, cheque fecha, Papeleta Deposito, tarjeta debito
                'lblbanco.Text = "Banco "
                Habilita_Control(True, "2")
                Habilita_Control(False, "10")
                Habilita_Control(False, "9")
                If Cbxforma.SelectedValue = "TD" Then
                    txt_documento.MaxLength = 20
                    txt_voucher.Enabled = True
                    Cbxplazo.Enabled = False
                    Cbxplazo.SelectedValue = "01M"
                Else
                    txt_documento.MaxLength = 10
                    Habilita_Control(False, "8")
                End If
                If Cbxforma.SelectedValue = "DC" Or Cbxforma.SelectedValue = "CP" Then
                    Habilita_Control(True, "10")
                    Cbxplazo.Visible = False
                    Label13.Text = "Fecha Cheque"
                    rdpFecha.Visible = True
                End If
                CargaBanco()
                Cbxbanco.SelectedValue = "NN"
                txt_documento.Text = ""
                txt_retencion.Text = ""
            ElseIf Cbxforma.SelectedValue = "TJ" Or Cbxforma.SelectedValue = "TI" Then 'tarjeta con interes y sin interes
                lblbanco.Text = "Tarjeta "
                txt_documento.MaxLength = 20
                Habilita_Control(True, "2")
                Habilita_Control(True, "8")
                Habilita_Control(False, "10")
                Habilita_Control(False, "9")
                CargaTarjeta()
                Cbxbanco.SelectedValue = "NN"
                txt_documento.Text = ""
                txt_retencion.Text = ""
            End If
            txt_valor.Text = 0
            txt_voucher.Text = ""
            'SpinRetencion.Text = 0
            CbxretenIva.SelectedValue = "000"
            CbxretenFuente.SelectedValue = "000"
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: captura el error
    ''' </summary>
    ''' <remarks></remarks>
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
    ''' COMENTARIO: Control para llenar el grid
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Grddetalle_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles Grddetalle.NeedDataSource
        Try
            Grddetalle.DataSource = Session("recibo")
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: control del grid
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Grddetalle_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles Grddetalle.ItemCommand
        Try
            If e.CommandName = "Delete" Then
                Dim dataItem As GridDataItem = CType(e.Item, GridDataItem)
                Dim valor2 As Double = Convert.ToDecimal(dataItem("VALOR").Text).ToString("#,##0.00")
                Dim valor1 As Double = Convert.ToDecimal(lblcantidad.Text).ToString("#,##0.00")
                Dim valueCell As Int32 = dataItem("DETALLE_ID").Text
                Dim dtRecibo As New DataTable
                dtRecibo = CType(Session("recibo"), DataTable)
                If dtRecibo IsNot Nothing Then
                    Dim view As New DataView(dtRecibo)
                    view.Sort = "DETALLE_ID"
                    If view.Find(valueCell) <> -1 Then
                        Dim i As Integer = view.Find(valueCell)
                        view.Delete(i)
                        If valor1 > 0 Then
                            valorEliminado = valor1 - valor2
                            lblcantidad.Text = valorEliminado.ToString("#,##0.00")
                        End If
                    End If
                    If dtRecibo.Rows.Count > 0 Then
                        For i As Integer = 0 To dtRecibo.Rows.Count - 1
                            dtRecibo.Rows(i).Item("DETALLE_ID") = i + 1
                        Next
                    End If
                    Session("recibo") = dtRecibo
                    Grddetalle.DataSource = Session("recibo")
                    Me.Grddetalle.DataBind()
                    Me.Grddetalle.Rebind()
                End If
            End If
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: Control para llenar el grid
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Grdreferencia_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles Grdreferencia.NeedDataSource
        Try
            Grdreferencia.DataSource = Session("referencia")
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    ''' <summary>
    ''' AUTOR: Galo Alvarado
    ''' FECHA: 07/07/2017
    ''' COMENTARIO: control del grid
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Grdreferencia_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles Grdreferencia.ItemCommand
        Try
            If e.CommandName = "Delete" Then
                Dim dataItem As GridDataItem = CType(e.Item, GridDataItem)
                Dim dtReferencia As New DataTable
                Dim valueCell As Int32 = dataItem("REFERENCIA_ID").Text
                dtReferencia = CType(Session("referencia"), DataTable)
                If dtReferencia IsNot Nothing Then
                    Dim view As New DataView(dtReferencia)
                    view.Sort = "REFERENCIA_ID"
                    If view.Find(valueCell) <> -1 Then
                        Dim i As Integer = view.Find(valueCell)
                        view.Delete(i)
                    End If
                    If dtReferencia.Rows.Count > 0 Then
                        For i As Integer = 0 To dtReferencia.Rows.Count - 1
                            dtReferencia.Rows(i).Item("REFERENCIA_ID") = i + 1
                        Next
                    End If
                    Session("referencia") = dtReferencia
                    Grdreferencia.DataSource = Session("referencia")
                    Grdreferencia.DataBind()
                End If
            End If
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub




#End Region


End Class