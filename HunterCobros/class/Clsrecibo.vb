Public Class Clsrecibo


    Public Shared Function DatosGeneral(ByVal cliente As String, ByVal opcion As Integer, ByVal usuario As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", opcion)
            base.AddParrameter("@CLIENTE_ID", cliente)
            base.AddParrameter("@USUARIO_ID", usuario)
            ds = base.Consulta("Extranet.SP_WEB_HUNTERRECIBO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    Public Function CargaForma() As DataTable
        CargaForma = Nothing
        Dim dt As New DataTable
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", 1)
            dt.Load(base.ConsultaReader("Extranet.SP_WEB_HUNTERRECIBO"))
            CargaForma = dt
        Catch ex As Exception
            Throw
        Finally
            If base.Connection.State = ConnectionState.Open Then base.Connection.Close()
        End Try
    End Function


    Public Function CargaCartera() As DataTable
        CargaCartera = Nothing
        Dim dt As New DataTable
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", 27)
            dt.Load(base.ConsultaReader("Extranet.SP_WEB_HUNTERRECIBO"))
            CargaCartera = dt
        Catch ex As Exception
            Throw
        Finally
            If base.Connection.State = ConnectionState.Open Then base.Connection.Close()
        End Try
    End Function


    Public Function CargaPlazo() As DataTable
        CargaPlazo = Nothing
        Dim dt As New DataTable
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", 17)
            dt.Load(base.ConsultaReader("Extranet.SP_WEB_HUNTERRECIBO"))
            CargaPlazo = dt
        Catch ex As Exception
            Throw
        Finally
            If base.Connection.State = ConnectionState.Open Then base.Connection.Close()
        End Try
    End Function


    Public Function CargaRetencionIva() As DataTable
        CargaRetencionIva = Nothing
        Dim dt As New DataTable
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", 23)
            dt.Load(base.ConsultaReader("Extranet.SP_WEB_HUNTERRECIBO"))
            CargaRetencionIva = dt
        Catch ex As Exception
            Throw
        Finally
            If base.Connection.State = ConnectionState.Open Then base.Connection.Close()
        End Try
    End Function


    Public Function CargaRetencionFuente() As DataTable
        CargaRetencionFuente = Nothing
        Dim dt As New DataTable
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", 22)
            dt.Load(base.ConsultaReader("Extranet.SP_WEB_HUNTERRECIBO"))
            CargaRetencionFuente = dt
        Catch ex As Exception
            Throw
        Finally
            If base.Connection.State = ConnectionState.Open Then base.Connection.Close()
        End Try
    End Function


    Public Shared Function VerificaTarjeta(ByVal tarjeta As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", 16)
            base.AddParrameter("@DOCUMENTO", tarjeta)
            ds = base.Consulta("Extranet.SP_WEB_HUNTERRECIBO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    Public Function CargaBanco() As DataTable
        CargaBanco = Nothing
        Dim dt As New DataTable
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", 2)
            dt.Load(base.ConsultaReader("Extranet.SP_WEB_HUNTERRECIBO"))
            CargaBanco = dt
        Catch ex As Exception
            Throw
        Finally
            If base.Connection.State = ConnectionState.Open Then base.Connection.Close()
        End Try
    End Function


    Public Function CargaReferencia() As DataTable
        CargaReferencia = Nothing
        Dim dt As New DataTable
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", 14)
            dt.Load(base.ConsultaReader("Extranet.SP_WEB_HUNTERRECIBO"))
            CargaReferencia = dt
        Catch ex As Exception
            Throw
        Finally
            If base.Connection.State = ConnectionState.Open Then base.Connection.Close()
        End Try
    End Function


    Public Function CargaTarjeta() As DataTable
        CargaTarjeta = Nothing
        Dim dt As New DataTable
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", 3)
            dt.Load(base.ConsultaReader("Extranet.SP_WEB_HUNTERRECIBO"))
            CargaTarjeta = dt
        Catch ex As Exception
            Throw
        Finally
            If base.Connection.State = ConnectionState.Open Then base.Connection.Close()
        End Try
    End Function


    Public Shared Function ConsultaRuta() As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", 8)
            ds = base.Consulta("Extranet.SP_WEB_HUNTERRECIBO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    Public Shared Function LeerEmail(ByVal cliente As String, ByVal documentoId As String, ByVal tipo As String, ByVal usuario As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@CODIGO_REFERENCIAL", cliente)
            base.AddParrameter("@DOCUMENTO_ID", documentoId)
            base.AddParrameter("@USUARIO_ID", usuario)
            base.AddParrameter("@TIPO", tipo)
            ds = base.Consulta("Extranet.SP_WEB_HUNTERRECIBO_EMAIL")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function

 
    Public Shared Function DatosGeneralPdf(ByVal cliente As String, ByVal anticipo As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", 15)
            base.AddParrameter("@CLIENTE_ID", cliente)
            base.AddParrameter("@NUMERO_ANTICIPO", anticipo)
            ds = base.Consulta("Extranet.SP_WEB_HUNTERRECIBO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    'Function ProcesoConsultar(ByVal opcion As Integer, ByVal fechainicio As String, ByVal fechafin As String, ByVal usuarioId As String) As DataSet
    '    Dim ds As New DataSet
    '    Dim base As New DataBaseApp.CommandApp
    '    Try
    '        base.AddParrameter("@OPCION", opcion)
    '        base.AddParrameter("@FECHA_INICIO", fechainicio)
    '        base.AddParrameter("@FECHA_FIN", fechafin)
    '        base.AddParrameter("@USUARIO_ID", usuarioId)
    '        ds = base.Consulta("Extranet.SP_WEB_HUNTERRECIBO")
    '        Return ds
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function


    Public Shared Function ProcesoConsultar(ByVal opcion As Integer, ByVal fechainicio As String, ByVal fechafin As String, ByVal usuarioId As String, ByVal estadoId As String, ByVal usuario As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", opcion)
            base.AddParrameter("@FECHA_INICIO", fechainicio)
            base.AddParrameter("@FECHA_FIN", fechafin)
            base.AddParrameter("@USUARIO", usuarioId)
            base.AddParrameter("@ESTADO_ID", estadoId)
            base.AddParrameter("@USUARIO_ID", usuario)
            ds = base.Consulta("Extranet.SP_WEB_HUNTERRECIBO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    'Function ConsultaInformacionDetalle(ByVal numero As String) As DataSet
    '    ConsultaInformacionDetalle = New DataSet
    '    Try
    '        Dim datos As New DataBaseApp.CommandApp
    '        datos.AddParrameter("@OPCION", 11)
    '        datos.AddParrameter("@NUMERO_ANTICIPO", numero)
    '        ConsultaInformacionDetalle = datos.Consulta("Extranet.SP_WEB_HUNTERRECIBO")
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function


    Function ConsultaInformacionDetalle(ByVal numero As String, ByVal tipo As String) As DataTable
        ConsultaInformacionDetalle = New DataTable
        Dim datos As New DataBaseApp.CommandApp
        Try
            datos.AddParrameter("@OPCION", 11)
            datos.AddParrameter("@NUMERO_ANTICIPO", numero)
            datos.AddParrameter("@TIPO_INGRESO", tipo)
            ConsultaInformacionDetalle.Load(datos.ConsultaReader("Extranet.SP_WEB_HUNTERRECIBO"))
        Catch ex As Exception
            Throw ex
        Finally
            If datos.Connection.State <> ConnectionState.Closed Then datos.Connection.Close()
            datos.Dispose()
        End Try
    End Function


    Public Shared Function GrabaEstado(ByVal usuarioId As String, ByVal estadoId As String, ByVal numero As String, ByVal observacion As String, ByVal motivo As Int32)
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            'base.AddParrameter("@OPCION", 12)
            base.AddParrameter("@OPCION", 20)
            base.AddParrameter("@USUARIO_ID", usuarioId)
            base.AddParrameter("@ESTADO_ID", estadoId)
            base.AddParrameter("@NUMERO_ANTICIPO", numero)
            base.AddParrameter("@COMENTARIO", observacion)
            base.AddParrameter("@MOTIVO_ID", motivo)
            ds = base.Consulta("Extranet.SP_WEB_HUNTERRECIBO")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function


    Public Shared Sub RegistroLog(ByVal opcion As String, ByVal mensaje As String, ByVal usuarioid As String)
        Dim base As New DataBaseApp.CommandApp
        Dim cnn As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim tran As SqlClient.SqlTransaction = Nothing
        Try
            cmd = New SqlClient.SqlCommand
            cnn = base.Connection
            cnn.Open()
            cmd.CommandTimeout = 1000
            cmd.Connection = cnn
            tran = cnn.BeginTransaction()
            base.ClearParrameter(cmd)
            base.ProcedureName = "Extranet.EXT_SP_GRABA_HUNTERRECIBO_LOG"
            base.AddParrameter("@PROCESO", 100)
            base.AddParrameter("@OPCION", opcion)
            base.AddParrameter("@USUARIO_ID", usuarioid.ToUpper)
            base.AddParrameter("@DESCRIPCION", mensaje)
            base.EjecutaTransaction(cmd, tran)
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            Throw ex
        End Try
    End Sub


    Public Function RegistraInformacion(ByVal clienteId As String, ByVal email As String, ByVal recibeId As String, ByVal recibeNombre As String, _
                                        ByVal usuarioId As String, ByVal valor As Double, ByVal detalle As dsHunterCobro.ANTICIPO_DETALLEDataTable, ByVal comentario As String, _
                                        ByVal tipo As String, ByVal cliente As String, ByVal referencia As dsHunterCobro.REFERENCIA_DETALLEDataTable, ByVal tipoServicio As String, _
                                        ByVal usuariocartera As String)
        Dim base As New DataBaseApp.CommandApp
        Dim cnn As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim tran As SqlClient.SqlTransaction = Nothing
        Dim numeroAnticipo, datofinal, tipoMovimiento As String
        Dim codigoId, codigoError As Int32
        Dim aperturaCaja, numeroMovimiento As Int32
        Try
            cmd = New SqlClient.SqlCommand
            cnn = base.Connection
            cnn.Open()
            base.ProcedureName = "Extranet.SP_WEB_HUNTERRECIBO"
            cmd.Connection = cnn
            tran = cnn.BeginTransaction("Mantenimiento")
            base.AddParrameter("@OPCION", 5)
            base.AddParrameter("@CLIENTE_ID", clienteId)
            base.AddParrameter("@CLIENTE", cliente)
            base.AddParrameter("@EMAIL_CLIENTE", email)
            'base.AddParrameter("@TIPO_REF", tipoRef)
            'base.AddParrameter("@REFERENCIA", ref)
            base.AddParrameter("@TIPO_SERVICIO", tipoServicio.ToUpper)
            base.AddParrameter("@VALOR", valor)
            base.AddParrameter("@USUARIO_ID", usuarioId.ToUpper)
            base.AddParrameter("@RECIBE_ID", recibeId)
            base.AddParrameter("@TIPO", tipo)
            base.AddParrameter("@RECIBE_CLIENTE", recibeNombre)
            base.AddParrameter("@COMENTARIO", comentario)
            base.AddParrameter("@USUARIO_CARTERA", usuariocartera)
            base.EjecutaTransaction(cmd, tran)
            codigoId = Convert.ToInt32(cmd.Parameters("@CODIGO_ID").Value)
            numeroAnticipo = Convert.ToString(cmd.Parameters("@NUMERO_ANTICIPO").Value)
            codigoError = Convert.ToInt32(cmd.Parameters("@CODIGO_ERROR").Value)
            aperturaCaja = Convert.ToInt32(cmd.Parameters("@APERTURA_CAJA").Value)
            numeroMovimiento = Convert.ToInt32(cmd.Parameters("@MOVIMIENTO_NUMERO").Value)
            tipoMovimiento = Convert.ToString(cmd.Parameters("@MOVIMIENTO_TIPO").Value)
            If codigoError = 0 Then
                datofinal = numeroAnticipo.ToUpper + "-" + Convert.ToString(codigoId)
                For i As Integer = 0 To detalle.Rows.Count - 1
                    base.ClearParrameter(cmd)
                    base.ProcedureName = "Extranet.SP_WEB_HUNTERRECIBO"
                    base.AddParrameter("@OPCION", 6)
                    base.AddParrameter("@CODIGO_ID", codigoId)
                    base.AddParrameter("@FORMA_ID", detalle.Rows(i).Item("CODIGO_FORMA").ToString())
                    base.AddParrameter("@BANCO_ID", detalle.Rows(i).Item("CODIGO_BANCO").ToString())
                    base.AddParrameter("@VALOR", detalle.Rows(i).Item("VALOR"))
                    base.AddParrameter("@TIPO", tipo)
                    base.AddParrameter("@SECUENCIA", i + 1)
                    base.AddParrameter("@CLIENTE", cliente)
                    base.AddParrameter("@TIPO_INGRESO", "D")
                    base.AddParrameter("@PLAZO", detalle.Rows(i).Item("PLAZO"))
                    base.AddParrameter("@VOUCHER", detalle.Rows(i).Item("VOUCHER").ToString())
                    base.AddParrameter("@DOCUMENTO", detalle.Rows(i).Item("DOCUMENTO").ToString())
                    'base.AddParrameter("@POR_RETENCION", detalle.Rows(i).Item("PORC_RETENCION").ToString())
                    base.AddParrameter("@POR_RETENCION", detalle.Rows(i).Item("COD_RETENCION").ToString())
                    base.AddParrameter("@RETENCION", detalle.Rows(i).Item("RETENCION").ToString())
                    base.AddParrameter("@FECHA_CHEQUE", detalle.Rows(i).Item("FECHA_CHEQUE").ToString())
                    base.AddParrameter("@USUARIO_ID", usuarioId.ToUpper)
                    base.AddParrameter("@APERTURA_CAJA", aperturaCaja)
                    base.AddParrameter("@MOVIMIENTO_TIPO", tipoMovimiento)
                    base.AddParrameter("@MOVIMIENTO_NUMERO", numeroMovimiento)
                    base.EjecutaTransaction(cmd, tran)
                    codigoError = Convert.ToInt32(cmd.Parameters("@CODIGO_ERROR").Value)
                    If codigoError <> 0 Then
                        tran.Rollback()
                        datofinal = Convert.ToString(codigoError)
                        Exit For
                    End If
                Next
                If codigoError = 0 Then
                    For i As Integer = 0 To referencia.Rows.Count - 1
                        base.ClearParrameter(cmd)
                        base.ProcedureName = "Extranet.SP_WEB_HUNTERRECIBO"
                        base.AddParrameter("@OPCION", 6)
                        base.AddParrameter("@SECUENCIA", i + 1)
                        base.AddParrameter("@TIPO_INGRESO", "R")
                        base.AddParrameter("@CODIGO_ID", codigoId)
                        base.AddParrameter("@TIPO_REF", referencia.Rows(i).Item("CODIGO_REFERENCIA").ToString())
                        base.AddParrameter("@REFERENCIA", referencia.Rows(i).Item("REFERENCIA").ToString())
                        base.AddParrameter("@OBSERVACION", referencia.Rows(i).Item("OBSERVACION").ToString())
                        base.AddParrameter("@USUARIO_ID", usuarioId.ToUpper)
                        base.AddParrameter("@APERTURA_CAJA", aperturaCaja)
                        base.AddParrameter("@MOVIMIENTO_TIPO", tipoMovimiento)
                        base.AddParrameter("@MOVIMIENTO_NUMERO", numeroMovimiento)
                        base.EjecutaTransaction(cmd, tran)
                        codigoError = Convert.ToInt32(cmd.Parameters("@CODIGO_ERROR").Value)
                        If codigoError <> 0 Then
                            tran.Rollback()
                            datofinal = Convert.ToString(codigoError)
                            Exit For
                        End If
                    Next
                End If
                If codigoError = 0 Then
                    base.ClearParrameter(cmd)
                    base.ProcedureName = "Extranet.SP_WEB_HUNTERRECIBO"
                    base.AddParrameter("@OPCION", 7)
                    base.AddParrameter("@CLIENTE_ID", clienteId)
                    base.AddParrameter("@CLIENTE", cliente)
                    base.AddParrameter("@APERTURA_CAJA", aperturaCaja)
                    base.AddParrameter("@MOVIMIENTO_TIPO", tipoMovimiento)
                    base.AddParrameter("@MOVIMIENTO_NUMERO", numeroMovimiento)
                    base.AddParrameter("@VALOR", valor)
                    base.AddParrameter("@USUARIO_ID", usuarioId.ToUpper)
                    base.AddParrameter("@TIPO", tipo)
                    base.AddParrameter("@COMENTARIO", comentario)
                    base.EjecutaTransaction(cmd, tran)
                    codigoError = Convert.ToInt32(cmd.Parameters("@CODIGO_ERROR").Value)
                    If codigoError = 0 Then
                        tran.Commit()
                    Else
                        tran.Rollback()
                        datofinal = Convert.ToString(codigoError)
                    End If
                Else
                    tran.Rollback()
                    datofinal = Convert.ToString(codigoError)
                End If
            Else
                tran.Rollback()
                datofinal = Convert.ToString(codigoError)
            End If
            'Return (numeroAnticipo)
            Return (datofinal)
        Catch ex As Exception
            datofinal = (1)
            tran.Rollback()
            Return (datofinal)
            Throw ex
        End Try
    End Function

End Class
