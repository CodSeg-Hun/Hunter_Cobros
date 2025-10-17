Imports System.Data

'''AUTOR:       Galo
'''FECHA:       25/08/2017
'''OBJETIVO:    ADMINISTRA LAS FUNCIONES DE CONEXIÓN E INGRESO DE DATOS PARA EL LOG DE USUARIOS

Public Class Log


    Function Registro_Actividad_Formulario(ByVal ip As String, ByVal idUsuario As Integer, ByVal idFormularioBack As Integer, ByVal idFormulario As Integer, _
                                           ByVal descUsuario As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@IP", ip)
            base.AddParrameter("@ID_USUARIO", idUsuario)
            base.AddParrameter("@ID_FORMULARIO_BACK", idFormularioBack)
            base.AddParrameter("@ID_FORMULARIO", idFormulario)
            base.AddParrameter("@DESC_USUARIO", descUsuario)
            ds = base.Consulta("Intranet.SP_USUARIO_INGRESO_NEW")
            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   
    Function Registro_Actividad_Formulario2(ByVal usuarioIngreso As Integer, ByVal ip As String, ByVal idMenu As Integer, ByVal refMenu As Integer, _
                                            ByVal idMenuBack As Integer, ByVal refIdBack As Integer) As Int64
        Dim base As New DataBaseApp.CommandApp
        Dim cnn As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim tran As SqlClient.SqlTransaction = Nothing
        Try
            cmd = New SqlClient.SqlCommand
            cnn = base.Connection
            cnn.Open()
            base.ProcedureName = "Intranet.SP_USUARIO_INGRESO_NEW"
            cmd.Connection = cnn
            tran = cnn.BeginTransaction("INGRESO")
            base.AddParrameter("@USUARIO_INGRESO", usuarioIngreso)
            base.AddParrameter("@IP", ip)
            base.AddParrameter("@ID_MENU", idMenu)
            base.AddParrameter("@REF_ID", refMenu)
            base.AddParrameter("@ID_MENU_BACK", idMenuBack)
            base.AddParrameter("@REF_ID_BACK", refIdBack)
            base.EjecutaTransaction(cmd, tran)
            Dim lastId As Long = Convert.ToInt64(cmd.Parameters("@REF_ID").Value)
            Return lastId
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' AUTOR: JONATHAN COLOMA
    ''' FECHA: 23/07/2012
    ''' COMENTARIO: MÉTODO PARA OBTENER LA INFORMACIÓN DEL FORMULARIO AL CUAL SE INGRESA
    ''' </summary>
    ''' <param name="formulario"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Consulta_Formulario(ByVal formulario As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@FORMULARIO", formulario)
            ds = base.Consulta("Intranet.SP_CONSULTA_ID_FORMULARIO_WEB")
            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
