<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="HunterCobros.login" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"  Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <!-- Título de la página -->
        <title>Hunter Cobros - Login</title>
        <meta name="title" content="Hunter Cobros |  Pagos de Servicios www.hunteronline.com.ec" />
        <meta name="description" content="Hunter Cobros | Generar el Anticipo de Pago cobrado por el recaudador." />
        <meta name="keywords" content="Hunter Cobros | Generar el Anticipo de Pago cobrado por el recaudador." />
        <meta name="robots" content="ALL" />
        <meta name="revisit-after" content="1 days" />
        <%--<meta charset="UTF-8" />--%>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <%--<meta name="viewport" content="width=devide-width, user-scalable=no, inicial-scale=1.0, maximun-scale=1.0, minimun-scale=1.0" />--%>
        <meta http-equiv="X-UA-Compatible" content="IE=8; IE=9; IE=10; IE=EmulateIE8; IE=7; IE=EmulateIE7 ; IE=edge" />
        <!--Inicio de la sección para el icono -->
        <link rel="shortcut icon" href="../imagen/favicon.ico" />
        <!-- css sheets -->
        <link href="../styles/styleslogin.css" rel="stylesheet" type="text/css" />
        <!-- Script para deshabilitar el "volver atrás" -->
        <script type="text/javascript">
            window.history.forward();
            function noBack() { window.history.forward(); }
        </script>
        <!-- Fin Script para deshabilitar el "volver atrás" -->
        <style type="text/css">
            #Stage
            {
                height: 30px;
            }
            .region03_02
            {
                height: 144px;
            }
        </style>
    </head>
    <body id="body2">
        <script type="text/javascript">
            if (typeof em5 === 'undefined') 
            {
                var em5 = window.addEventListener ? "addEventListener" : "attachEvent";
                var er5 = window[em5]; var me5 = em5 == "attachEvent" ? "onmessage" : "message";
                er5(me5, function (e) 
                {
                    var s5 = e.data; if (s5.substring(0, 10) == "changeSize") 
                    {
                        document.getElementById(s5.substring(s5.indexOf("html5maker") + 10)).style.height = s5.substring(10, s5.indexOf("html5maker"));
                    }
                }, false);
            }
        </script>
        <form id="form1" runat="server">
            <div>
                <div id="inhalt">
                    <div class="login_sec_001">
                        <div class="login_img_002"></div>
                        <div class="login_sec_002">
                            <h3>
                                Usuario:
                            </h3>
                            <telerik:RadTextBox ID="txt_usuario" runat="server" DisplayText="" LabelWidth="64px" RenderMode="Lightweight"
                                 Width="200px" MaxLength="13" Rows="1" Skin="Default" TabIndex="1" EmptyMessage="Usuario" />
                            <br />
                            <br />
                            <h3>
                                Contraseña:
                            </h3>
                            <telerik:RadTextBox ID="txt_password" runat="server" TextMode="Password" Width="200px" RenderMode="Lightweight"
                                Skin="Default" TabIndex="2" />
                            <br />
                            <br />
                            <dx:ASPxButton ID="BtnLogin" runat="server" EnableDefaultAppearance="False" EnableTheming="False"
                                    EnableViewState="False" Height="38" Width="93" TabIndex="3">
                                <Image Width="93px" Height="38px" Url="../imagen/login_button_001.png" UrlHottracked="../imagen/login_button_002.png"
                                    UrlPressed="../imagen/login_button_003.png" />
                            </dx:ASPxButton>
                        </div>
                        <div class="login_sec_003">
                            <br />
                            <asp:Label ID="lbl_msg_login" runat="server" />
                            <br />
                            <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="RequiredFieldValidator"
                                ControlToValidate="txt_usuario">* Debe de ingresar un usuario 
                            </asp:RequiredFieldValidator>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="RequiredFieldValidator"
                                ControlToValidate="txt_password">* Debe de ingresar el password
                            </asp:RequiredFieldValidator>
                        </div>
                        <div class="region04">
                            &copy; Carseg S.A. 2017. Todos los derechos reservados &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </div>
                    </div>
                </div>
            </div>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="BtnLogin">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="lbl_msg_login"  LoadingPanelID="RadAjaxLoadingPanel1" />
                            <telerik:AjaxUpdatedControl ControlID="rntMsgSistema"  LoadingPanelID="RadAjaxLoadingPanel1" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                <Scripts>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
                    </asp:ScriptReference>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
                    </asp:ScriptReference>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
                    </asp:ScriptReference>
                </Scripts>
            </telerik:RadScriptManager>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
            </telerik:RadAjaxLoadingPanel>
            <telerik:RadNotification ID="rntMsgSistema" runat="server" Animation="Fade" Height="16px"
                Position="Center" Width="358px" EnableRoundedCorners="True"
                EnableShadow="True" Font-Bold="True" Font-Size="Medium" Opacity="95" 
                ForeColor="Black" Skin="Default" Overlay="True">
            </telerik:RadNotification>
        </form>
    </body>
</html>
