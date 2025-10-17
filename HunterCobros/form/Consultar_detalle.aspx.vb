Imports Telerik.Web.UI

Public Class Consulta_detalle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim dt As DateTime = Now.Date
            lbltitulo.Text = "Hunter Cobros " + [String].Format("{0:dd/MMM/yyyy}", dt) + " " + DateTime.Now.ToString("HH:mm:ss")
            Me.GrdConsultarDetalle.DataSource = Session("consultar")
            Me.GrdConsultarDetalle.DataBind()
            Me.GrdConsolidado.DataSource = Session("consolidado")
            Me.GrdConsolidado.DataBind()
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub


    Protected Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        Try
            Dim dt As DateTime = Now.Date
            'Me.GrdConsultarDetalle.ExportSettings.ExportOnlyData = True
            'Me.GrdConsultarDetalle.ExportSettings.IgnorePaging = True
            'Me.GrdConsultarDetalle.ExportSettings.OpenInNewWindow = True
            'Me.GrdConsultarDetalle.ExportSettings.UseItemStyles = True
            'Me.GrdConsultarDetalle.ExportSettings.HideStructureColumns = True
            'Me.GrdConsultarDetalle.ExportSettings.SuppressColumnDataFormatStrings = False

            Me.GrdConsultarDetalle.MasterTableView.HierarchyDefaultExpanded = False
            Me.GrdConsultarDetalle.MasterTableView.DetailTables(0).HierarchyDefaultExpanded = False
            Me.GrdConsultarDetalle.MasterTableView.DetailTables(0).BackColor = System.Drawing.Color.FromArgb(201, 201, 201)


            Me.GrdConsultarDetalle.MasterTableView.DetailTables(1).HierarchyDefaultExpanded = False
            ' Me.GrdConsultarDetalle.MasterTableView.DetailTables(1).MultiHeaderItemStyle.BackColor = System.Drawing.Color.LightGray
            '    Me.GrdConsultarDetalle.MasterTableView.DetailTables(1).ItemStyle.CssClass = "ExpandCollapse"
            'MultiHeaderItemStyle.ForeColor = System.Drawing.Color.White

            Me.GrdConsultarDetalle.MasterTableView.DetailTables(1).BackColor = System.Drawing.Color.FromArgb(168, 168, 168)

            Me.GrdConsultarDetalle.Rebind()
            Me.GrdConsultarDetalle.ExportSettings.ExportOnlyData = True
            Me.GrdConsultarDetalle.ExportSettings.OpenInNewWindow = True
            Me.GrdConsultarDetalle.ExportSettings.IgnorePaging = True



           
            Me.GrdConsultarDetalle.ExportSettings.FileName = Session("user") & "_" & [String].Format("{0:dd/MMM/yyyy}", dt)
            GrdConsultarDetalle.MasterTableView.ExportToExcel()
            'GrdConsultarDetalle.MasterTableView.ExportToWord()
            'GrdConsultarDetalle.MasterTableView.ExportToPdf()
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

   
    Protected Sub GrdConsultarDetalle_NeedDataSource(source As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs)
        If Not e.IsFromDetailTable Then
            GrdConsultarDetalle.DataSource = Session("consultar")
        End If
    End Sub

    Protected Sub GrdConsultarDetalle_DetailTableDataBind(source As Object, e As Telerik.Web.UI.GridDetailTableDataBindEventArgs)
        Dim dataItem As GridDataItem = DirectCast(e.DetailTableView.ParentItem, GridDataItem)
        Select Case e.DetailTableView.Name
            Case "Detalle"
                If True Then
                    Dim numeroID As String = dataItem.GetDataKeyValue("NUMERO_ANTICIPO").ToString()
                    Dim dsConsulta As New dsHunterCobro.ANTICIPO_DETALLEDataTable
                    Dim obj As New Clsrecibo
                    dsConsulta.Load(obj.ConsultaInformacionDetalle(numeroID.Substring(0, 19), "D").CreateDataReader())
                    Session("CONSULTA_DETALLE_DATOS") = dsConsulta
                    e.DetailTableView.DataSource = dsConsulta
                    Session("NUMERO_ANTICIPO") = numeroID.Substring(0, 19)
                    If Session("NUMERO_ANTICIPO") <> "" Then
                        Dim valor As String = dataItem("VALOR").Text.Trim.ToString
                        Reimpresion(numeroID, dataItem("CODIGO_CLIENTE").Text.Trim.ToString, dataItem("EMAIL_CLIENTE").Text.Trim.ToString, valor.Replace("$", ""), _
                                    dataItem("OBSERVACION").Text.Trim.ToString, dataItem("CLIENTE").Text.Trim.ToString, dataItem("FECHA").Text.Trim.ToString, _
                                    dataItem("CODIGO_CLIENTE").Text.Trim.ToString + "_" + DateTime.Now.ToString("HHmmss") + ".PDF")
                    End If
                End If
            Case "Referencia"
                If True Then
                    Dim numeroID As String = dataItem.GetDataKeyValue("NUMERO_ANTICIPO").ToString()
                    Dim dsRefencia As New dsHunterCobro.ANTICIPO_REFERENCIADataTable
                    Dim obj As New Clsrecibo
                    'dsRefencia.Clear()
                    dsRefencia.Load(obj.ConsultaInformacionDetalle(numeroID.Substring(0, 19), "R").CreateDataReader())
                    Session("CONSULTA_REFERENCIA_DATOS") = dsRefencia
                    e.DetailTableView.DataSource = dsRefencia
                    'Session("NUMERO_ANTICIPO") = numeroID.Substring(0, 19)
                    'If Session("NUMERO_ANTICIPO") <> "" Then
                    '    Dim valor As String = dataItem("VALOR").Text.Trim.ToString
                    '    Reimpresion(numeroID, dataItem("CODIGO_CLIENTE").Text.Trim.ToString, dataItem("EMAIL_CLIENTE").Text.Trim.ToString, valor.Replace("$", ""), _
                    '                dataItem("OBSERVACION").Text.Trim.ToString, dataItem("CLIENTE").Text.Trim.ToString, dataItem("FECHA").Text.Trim.ToString, _
                    '                dataItem("CODIGO_CLIENTE").Text.Trim.ToString + "_" + DateTime.Now.ToString("HHmmss") + ".PDF")
                    'End If
                End If
        End Select
    End Sub


    Protected Sub GrdConsultarDetalle_PreRender(sender As Object, e As EventArgs)
        If Not Page.IsPostBack Then
            CollapseAllRows()
        Else
            GrdConsultarDetalle.MasterTableView.HierarchyDefaultExpanded = True
            GrdConsultarDetalle.Rebind()
        End If
    End Sub

    

    Sub Reimpresion(ByVal numero As String, ByVal codcliente As String, ByVal email As String, ByVal valor As Decimal, ByVal observacion As String, ByVal cliente As String, _
                  ByVal fecha As String, ByVal nombre As String)
        Try
            Dim dtConsultar As New dsHunterCobro.REIMPRESIONDataTable
            dtConsultar.Clear()
            Session("Data") = dtConsultar
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


    Private Sub CollapseAllRows()
        Try
            'Me.GrdConsultarDetalle.MasterTableView.DetailTables(0).HierarchyDefaultExpanded = False
            For Each item As GridItem In GrdConsultarDetalle.MasterTableView.Items
                item.Expanded = True
            Next
        Catch ex As Exception
            Captura_Error(ex)
        End Try
    End Sub
   

  
End Class