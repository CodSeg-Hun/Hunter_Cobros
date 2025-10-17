<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReciboAnulacion.aspx.vb" Inherits="HunterCobros.ReciboAnulacion" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title></title>
        <meta http-equiv="x-ua-compatible" content="IE=9"/>
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <link href="../styles/estilomodal.css" rel="stylesheet" type="text/css" />
    </head>
    <body class="body">
        <form id="form1" method="post" runat="server">
            <div class="contenedor">
                <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                </telerik:RadScriptManager>
                <telerik:RadNotification ID="rntMensajes" runat="server" Animation="Fade" Position="Center" EnableRoundedCorners="True" Overlay="True">
                </telerik:RadNotification>
                <script type="text/javascript">
                    function GetRadWindow() 
                    {
                        var oWindow = null;
                        if (window.radWindow) oWindow = window.radWindow;
                        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                        return oWindow;
                    }

                    function AdjustRadWidow() 
                    {
                        var oWindow = GetRadWindow();
                        setTimeout(function () { oWindow.autoSize(true); if ($telerik.isChrome || $telerik.isSafari) ChromeSafariFix(oWindow); }, 500);
                    }

                    function ChromeSafariFix(oWindow) 
                    {
                        var iframe = oWindow.get_contentFrame();
                        var body = iframe.contentWindow.document.body;
                        setTimeout(function () 
                        {
                            var height = body.scrollHeight;
                            var width = body.scrollWidth;
                            var iframeBounds = $telerik.getBounds(iframe);
                            var heightDelta = height - iframeBounds.height;
                            var widthDelta = width - iframeBounds.width;
                            if (heightDelta > 0) oWindow.set_height(oWindow.get_height() + heightDelta);
                            if (widthDelta > 0) oWindow.set_width(oWindow.get_width() + widthDelta);
                            oWindow.center();
                        }, 310);
                    }

                    function returnParent() 
                    {
                        var oWnd = GetRadWindow();
                        oWnd.close();
                    }

                    function CloseAndRedirect(sender, args) 
                    {
                        GetRadWindow().BrowserWindow.location.href = 'Consultar.aspx';
                        GetRadWindow().close();
                    }

                    function AnularRecibo() 
                    {
                        document.getElementById('Btnaceptar').addEventListener("click", function (e) 
                        {
                            e.preventDefault();
                            alert("No se pudo cargar el método");
                        });
                    }
                </script>
                <div class="menu">
                    <div class="secc_title01">
                         Anticipo de Pago Nro. &nbsp; &nbsp;
                        <asp:Label ID="lblanticipo" runat="server" Text="lblanticipo" />
                    </div>
                </div>
                <div class="menu">
                    <div class="column01_cell_label">
                        Motivo &nbsp; &nbsp;
                    </div>
                    <div class="column02_cell">
                        <telerik:RadComboBox ID="CbxMotivo" Runat="server" Height="100px" Width="220px" Culture="es-ES" AutoPostBack="True" />
                    </div>
                    <div class="icono">
                        <telerik:RadButton ID="Btnaceptar" runat="server" Text="" ForeColor="White" Width="32px" Height="32px" ToolTip="Solicitud de Anulación de Registro"
                                 OnClientClicked="AnularRecibo"  >
                            <Image IsBackgroundImage="True" ImageUrl="../imagen/icons/Trash2.png" />
                        </telerik:RadButton>
                    </div>
                    <div class="icono">
                        <telerik:RadButton ID="Btnclose" runat="server" Text="" ForeColor="White"  Width="32px" Height="32px" ToolTip="Cerrar pantalla" 
                                 OnClientClicked="returnParent" AutoPostBack="False">
                            <Image IsBackgroundImage="True" ImageUrl="../imagen/icons/turnoff.png" />
                        </telerik:RadButton>
                    </div>
                </div>
                <div class="menu2">
                     <div class="column01_cell_label">
                            Comentario &nbsp; &nbsp;
                     </div>
                     <div class="column03_cell">
                        <telerik:RadTextBox ID="txt_comentario" RenderMode="Lightweight" Width="390px"  runat="server"
                                 TextMode="MultiLine" EmptyMessage="Observación" AutoPostBack="True"  Height="64px"  />
                     </div>
                </div>
            </div>
        </form>
    </body>
</html>
