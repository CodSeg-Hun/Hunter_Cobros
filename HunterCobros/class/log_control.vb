Imports System


Public Module log_control


    Public Sub RegistraPermanencia(ByVal ip As String, ByVal idUsuario As Integer, ByVal idFormularioBack As Integer, ByVal idFormulario As Integer, ByVal descUsuario As String)
        Dim obj As New Log
        'Dim dtRegistroLog As New System.Data.DataSet
        'dtRegistroLog =
        obj.Registro_Actividad_Formulario(ip, idUsuario, idFormularioBack, idFormulario, descUsuario)
    End Sub


    Public Function RegistraPermanencia2(ByVal usuarioIngreso As Integer, ByVal ip As String, ByVal idMenu As Integer, ByVal refMenu As Integer, ByVal idMenuBack As Integer, _
                                         ByVal refIdBack As Integer) As Long
        Dim obj As New Log
        Dim idLastObtenido As Int64
        idLastObtenido = obj.Registro_Actividad_Formulario2(usuarioIngreso, ip, idMenu, refMenu, idMenuBack, refIdBack)
        Return idLastObtenido
    End Function


    Public Sub Consulta_Formulario(ByVal formulario As String)
        Dim obj As New Log
        'Dim dtConsultaFormulario As New System.Data.DataSet
        'dtConsultaFormulario =
        obj.Consulta_Formulario(formulario)
    End Sub

End Module



