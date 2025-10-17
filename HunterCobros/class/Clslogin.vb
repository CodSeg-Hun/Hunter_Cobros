
Imports System.Security.Cryptography

Public Class Clslogin


    Function DatosMenu(ByVal opcion As Integer, ByVal usuario As String, ByVal tipomenu As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", opcion)
            base.AddParrameter("@USUARIO", usuario)
            base.AddParrameter("@TIPO_MENU", tipomenu)
            ds = base.Consulta("Extranet.SP_MENU_WEB_HUNTERRECIBO")
            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Function DatosLoginUsuario(ByVal usuario As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            base.AddParrameter("@OPCION", 3)
            base.AddParrameter("@USUARIO", usuario)
            ds = base.Consulta("Extranet.SP_MENU_WEB_HUNTERRECIBO")
            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Function LoginUsuario(ByVal usuario As String, ByVal password As String) As DataSet
        Dim ds As New DataSet
        Dim base As New DataBaseApp.CommandApp
        Try
            Dim obj As New Clslogin
            base.AddParrameter("@OPCION", 4)
            base.AddParrameter("@USUARIO", usuario)
            base.AddParrameter("@PASSWORD", obj.Encriptar3S(password))
            ds = base.Consulta("Extranet.SP_MENU_WEB_HUNTERRECIBO")
            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Function Encriptar3S(ByVal password As String) As Byte()
        Encriptar3s = Nothing
        Dim objSha256 As New SHA256Managed
        Dim objTemporal As Byte()
        Try
            objTemporal = System.Text.Encoding.UTF8.GetBytes(password)
            objTemporal = objSha256.ComputeHash(objTemporal)
            Return objTemporal
        Catch ex As Exception
            Throw
        Finally
            objSha256.Clear()
        End Try
    End Function


End Class
