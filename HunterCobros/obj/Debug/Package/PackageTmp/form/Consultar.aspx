<%@ Page Title=""  Language="vb" AutoEventWireup="false" MasterPageFile="~/form/Principal.Master" CodeBehind="Consultar.aspx.vb" Inherits="HunterCobros.Consultar" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="x-ua-compatible" content="IE=9"/>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../styles/estilogrid.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .elementsoporte
        { z-index: 9999995 !important; }
    </style>
   <%-- <script type="text/javascript">
         function impre(num) {
             document.getElementById(num).className = "ver";
             print();
             document.getElementById(num).className = "nover";

         }
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_article">
        <h2>
            &nbsp;</h2>
        <h2>
            Consultar
        </h2>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"  Skin="Telerik">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadNotification ID="RnMensajesError" runat="server" Animation="Slide"  Height="100px" Position="Center" Width="414px" EnableRoundedCorners="True" EnableShadow="True">
        </telerik:RadNotification> 
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
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="CbxUsuario">
                    <UpdatedControls>
                         <telerik:AjaxUpdatedControl ControlID="Grdconsultar"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="CbxEstado">
                    <UpdatedControls>
                         <telerik:AjaxUpdatedControl ControlID="Grdconsultar"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="BtnBuscar">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RnMensajesError"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="Grdconsultar"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="BtnImprimir"   LoadingPanelID="RadAjaxLoadingPanel1"/>
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="BtnReenviar">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RnMensajesError"   LoadingPanelID="RadAjaxLoadingPanel1"/>
                        <telerik:AjaxUpdatedControl ControlID="Grdconsultar"    LoadingPanelID="RadAjaxLoadingPanel1"/>
                        <telerik:AjaxUpdatedControl ControlID="BtnReenviar"   LoadingPanelID="RadAjaxLoadingPanel1"/>
                        <telerik:AjaxUpdatedControl ControlID="BtnImprimir"   LoadingPanelID="RadAjaxLoadingPanel1"/>
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="Grdconsultar">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RnMensajesError"  LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="BtnReenviar"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="BtnImprimir"   LoadingPanelID="RadAjaxLoadingPanel1"/>
                        <telerik:AjaxUpdatedControl ControlID="Grdconsultar"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="reciboanulacion"   LoadingPanelID="RadAjaxLoadingPanel1"  />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <%--<div class="separador_001" />--%>
        <div class="toolbar">
            <div class="toolbar_sep_001"></div>
            <div class="toolbar_text">
                <strong> Usuario: </strong>
                <telerik:RadComboBox ID="CbxUsuario" Runat="server" Height="100px" AutoPostBack="True" Width="125px" Culture="es-ES" />
            </div>
            <div class="toolbar_text">
                <strong> Estado: </strong>
                <telerik:RadComboBox ID="CbxEstado" Runat="server" Height="100px" AutoPostBack="True" Width="125px" Culture="es-ES" />
            </div>
            <div class="toolbar_sep_001"></div>
            <div class="toolbar_text_001">
                <strong> Fecha de Inicio: </strong>
                <telerik:RadDatePicker ID="rdpFechaInicio" Runat="server" ToolTip="Ingrese la fecha de inicio" Width="100px" />
            </div>
            <div class="toolbar_text_001">
                <strong> Fecha de Fin: </strong>
                <telerik:RadDatePicker ID="rdpFechaFin" Runat="server" ToolTip="Ingrese la fecha de fin" Width="100px" />
            </div>
            <div class="toolbar_sep_001" ></div>
            <div class="toolbar_icon_003">
                <telerik:RadButton ID="BtnBuscar" runat="server" Text="" ForeColor="White" Width="32px" Height="32px" ToolTip="Buscar los datos" >
                    <Image IsBackgroundImage="True" ImageUrl="../imagen/icons/Preview3.png" />
                </telerik:RadButton>
            </div>
            <div class="toolbar_icon_003">
                <telerik:RadButton ID="BtnReenviar" runat="server" Text="" ForeColor="White" Width="32px" Height="32px" ToolTip="Reenviar Correo" >
                    <Image IsBackgroundImage="True" ImageUrl="../imagen/icons/new_mail.png" DisabledImageUrl="../imagen/icons/new_mail.png" />
                </telerik:RadButton>
            </div>
             <div class="toolbar_icon_003">
                <telerik:RadButton ID="BtnImprimir" runat="server" Text="" ForeColor="White" Width="32px" Height="32px" ToolTip="Imprimir" >
                    <Image IsBackgroundImage="True" ImageUrl="../imagen/icons/imprimir.png" DisabledImageUrl="../imagen/icons/imprimir.png" />
                </telerik:RadButton>
               <%--  <input type="button" onclick="impre('container');return false" 
                        style="background-image: url('../imagen/icons/imprimir.png'); background-repeat: no-repeat; background-position: center center;
                        height: 32px; width: 35px; background-color: #FFFFFF; border: none;" />--%>
            </div>
            <br />
        </div>
        <div class="separador_001" ></div>
        <div class="grid_consulta" >
            <telerik:RadGrid ID="Grdconsultar" runat="server" AutoGenerateColumns="False" CellSpacing="0" AllowSorting="True" Culture="es-ES" GridLines="None" 
                Height="520px" Width="600px" ShowFooter="True" ShowGroupPanel="False">
                <FooterStyle CssClass="FooterStyle" />
                <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle="True" ReorderColumnsOnClient="True" AllowDragToGroup="True" AllowColumnsReorder="True" >
                    <Selecting AllowRowSelect="True" />
                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                    <Resizing AllowRowResize="True" AllowColumnResize="True" EnableRealTimeResize="True" ResizeGridOnColumnResize="False" />
                </ClientSettings>
                <GroupingSettings ShowUnGroupButton="True" />
                <MasterTableView DataKeyNames="NUMERO_ANTICIPO" PageSize="10" ShowGroupFooter="true" AllowMultiColumnSorting="true"
                    NoDetailRecordsText="" NoMasterRecordsText="" Name="Maestra">
                    <DetailTables>
                        <telerik:GridTableView runat="server" Name="Detalle" DataKeyNames="DETALLE_ID" Width="80px" CssClass="grid_detalle">
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="DETALLE_ID" FilterControlAltText="Filter DETALLE_ID column"
                                    HeaderText="DETALLE_ID" UniqueName="DETALLE_ID" AllowFiltering="False">
                                    <FooterStyle Width="1px" />
                                    <HeaderStyle Font-Bold="True" Width="1px" />
                                    <ItemStyle Width="1px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FORMA_PAGO" FilterControlAltText="Filter FORMA_PAGO column"
                                    HeaderText="Forma Pago" UniqueName="FORMA_PAGO" AllowFiltering="False" Aggregate="Count" 
                                    FooterText="Total de Forma de Pago: ">
                                    <FooterStyle Width="180px" />
                                    <HeaderStyle Width="180px" Font-Bold="True" />
                                    <ItemStyle Width="180px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="BANCO" FilterControlAltText="Filter BANCO column"
                                    HeaderText="Banco" UniqueName="BANCO" AllowFiltering="False">
                                    <FooterStyle Width="220px" />
                                    <HeaderStyle Width="220px" Font-Bold="True" />
                                    <ItemStyle Width="220px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="VALOR" FilterControlAltText="Filter VALOR column" HeaderText="Valor " 
                                    UniqueName="VALOR" AllowFiltering="False" DataFormatString="$  {0:F2}" Aggregate="Sum">
                                    <FooterStyle Width="80px" />
                                    <HeaderStyle Width="80px" Font-Bold="True" />
                                    <ItemStyle Width="80px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DOCUMENTO"   FilterControlAltText="Filter DOCUMENTO column"
                                    HeaderText="Documento" UniqueName="DOCUMENTO" AllowFiltering="False">
                                    <FooterStyle Width="150px" />
                                    <HeaderStyle Width="150px" Font-Bold="True" />
                                    <ItemStyle Width="150px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PLAZO"   FilterControlAltText="Filter PLAZO column"
                                    HeaderText="Plazo" UniqueName="PLAZO" AllowFiltering="False">
                                    <FooterStyle Width="50px" />
                                    <HeaderStyle Width="50px" Font-Bold="True" />
                                    <ItemStyle Width="50px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="VOUCHER"   FilterControlAltText="Filter VOUCHER column"
                                    HeaderText="Voucher" UniqueName="VOUCHER" AllowFiltering="False">
                                    <FooterStyle Width="150px" />
                                    <HeaderStyle Width="150px" Font-Bold="True" />
                                    <ItemStyle Width="150px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RETENCION"   FilterControlAltText="Filter RETENCION column"
                                    HeaderText="Retención" UniqueName="RETENCION" AllowFiltering="False">
                                    <FooterStyle Width="150px" />
                                    <HeaderStyle Width="150px" Font-Bold="True" />
                                    <ItemStyle Width="150px" />
                                </telerik:GridBoundColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                            </EditFormSettings>
                            <PagerStyle AlwaysVisible="True" PageSizeControlType="RadComboBox"></PagerStyle>
                        </telerik:GridTableView>
                    </DetailTables>
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Editar" FilterControlAltText="Filter EditarColumn column"  Text="Anular" 
                            ImageUrl="../imagen/icons/Trash2.png" UniqueName="EditarColumn" Resizable="false" ConfirmText="Anular registro?" ButtonCssClass="ButtonColumn">
                            <FooterStyle Width="26px" />
                            <HeaderStyle Width="26px" />
                            <ItemStyle Width="26px"  />
                        </telerik:GridButtonColumn>
                        <telerik:GridBoundColumn DataField="CODIGO_CLIENTE"  FilterControlAltText="Filter CODIGO_CLIENTE column" HeaderText="Codigo Cliente" SortExpression="CODIGO_CLIENTE" 
                            UniqueName="CODIGO_CLIENTE" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" >
                            <FooterStyle Width="1px" />
                            <HeaderStyle Width="1px" Font-Bold="True" />
                            <ItemStyle Width="1px"  BorderStyle="Inset" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NUMERO_ANTICIPO" FilterControlAltText="Filter NUMERO_ANTICIPO column" HeaderText="Cod. Anticipo" ReadOnly="True"
                            UniqueName="NUMERO_ANTICIPO" SortExpression="NUMERO_ANTICIPO" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains"  
                            Aggregate="Count" FooterText="Total de Cobros: ">
                            <FooterStyle Width="180px" />
                            <HeaderStyle Width="180px" Font-Bold="True" />
                            <ItemStyle Width="180px" BorderStyle="Inset" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CLIENTE" FilterControlAltText="Filter CLIENTE column" HeaderText="Cliente" SortExpression="CLIENTE" 
                            UniqueName="CLIENTE" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                            <FooterStyle Width="220px" />
                            <HeaderStyle Width="220px" Font-Bold="True" />
                            <ItemStyle Width="220px" BorderStyle="Inset" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EMAIL_CLIENTE" FilterControlAltText="Filter EMAIL_CLIENTE column" HeaderText="Email" SortExpression="EMAIL_CLIENTE" 
                            UniqueName="EMAIL_CLIENTE" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                            <FooterStyle Width="200px" />
                            <HeaderStyle Width="200px" Font-Bold="True" />
                            <ItemStyle Width="200px" BorderStyle="Inset" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="RECIBE" FilterControlAltText="Filter RECIBE column" HeaderText="Recibe" SortExpression="RECIBE" 
                            UniqueName="RECIBE" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                            <FooterStyle Width="200px" />
                            <HeaderStyle Width="200px" Font-Bold="True" />
                            <ItemStyle Width="200px" BorderStyle="Inset"/>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="VALOR" FilterControlAltText="Filter VALOR column" HeaderText="Valor " SortExpression="VALOR"    
                            UniqueName="VALOR" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" DataFormatString="$  {0:F2}" Aggregate="Sum" >
                            <FooterStyle Width="80px" />
                            <HeaderStyle Width="80px" Font-Bold="True" />
                            <ItemStyle Width="80px" BorderStyle="Inset" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="OBSERVACION"  FilterControlAltText="Filter OBSERVACION column" HeaderText="Comentario" SortExpression="OBSERVACION" 
                            UniqueName="OBSERVACION" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                            <FooterStyle Width="160px" />
                            <HeaderStyle Width="160px" Font-Bold="True" />
                            <ItemStyle Width="160px" BorderStyle="Inset" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ESTADO"  FilterControlAltText="Filter ESTADO column" HeaderText="Estado" SortExpression="ESTADO" 
                            UniqueName="ESTADO" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                            <FooterStyle Width="80px" />
                            <HeaderStyle Width="80px" Font-Bold="True" />
                            <ItemStyle Width="80px" BorderStyle="Inset" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ESTADO_ID"  FilterControlAltText="Filter ESTADO_ID column" HeaderText="EstadoId" SortExpression="ESTADO_ID" 
                            UniqueName="ESTADO_ID" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                            <FooterStyle Width="1px" />
                            <HeaderStyle Width="1px" Font-Bold="True" />
                            <ItemStyle Width="1px" BorderStyle="Inset" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FECHA"  FilterControlAltText="Filter FECHA column" HeaderText="Fecha" SortExpression="FECHA" 
                            UniqueName="FECHA" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                            <FooterStyle Width="100px" />
                            <HeaderStyle Width="100px" Font-Bold="True" />
                            <ItemStyle Width="100px" BorderStyle="Inset" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="USUARIO" FilterControlAltText="Filter USUARIO column" HeaderText="Recaudador" SortExpression="USUARIO" 
                            UniqueName="USUARIO" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                            <FooterStyle Width="140px" />
                            <HeaderStyle Width="140px" Font-Bold="True" />
                            <ItemStyle Width="140px" BorderStyle="Inset" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="USUARIO_CARTERA" FilterControlAltText="Filter USUARIO_CARTERA column" HeaderText="Usu.Cartera" SortExpression="USUARIO_CARTERA" 
                            UniqueName="USUARIO_CARTERA" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                            <FooterStyle Width="140px" />
                            <HeaderStyle Width="140px" Font-Bold="True" />
                            <ItemStyle Width="140px" BorderStyle="Inset" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="MOTIVO" FilterControlAltText="Filter MOTIVO column" HeaderText="Motivo Anulación" SortExpression="MOTIVO" 
                            UniqueName="MOTIVO" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                            <FooterStyle Width="140px" />
                            <HeaderStyle Width="140px" Font-Bold="True" />
                            <ItemStyle Width="140px" BorderStyle="Inset" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TIPO" FilterControlAltText="Filter TIPO column" HeaderText="Tipo" SortExpression="TIPO" 
                            UniqueName="TIPO" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                            <FooterStyle Width="100px" />
                            <HeaderStyle Width="100px" Font-Bold="True" />
                            <ItemStyle Width="100px" BorderStyle="Inset" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="SOLICITUD" FilterControlAltText="Filter SOLICITUD column" HeaderText="Mensaje" SortExpression="SOLICITUD" 
                            UniqueName="SOLICITUD" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                            <FooterStyle Width="100px" />
                            <HeaderStyle Width="100px" Font-Bold="True" />
                            <ItemStyle Width="100px" BorderStyle="Inset" />
                        </telerik:GridBoundColumn>
                    </Columns>
                   <%-- <GroupByExpressions>
                        <telerik:GridGroupByExpression>
                            <SelectFields>
                                <telerik:GridGroupByField FieldAlias="USUARIO"  FieldName="USUARIO" HeaderText="Usuario "></telerik:GridGroupByField>
                            </SelectFields>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="USUARIO" SortOrder="Descending"></telerik:GridGroupByField>
                            </GroupByFields>
                        </telerik:GridGroupByExpression>
                    </GroupByExpressions>--%>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>
                    <PagerStyle AlwaysVisible="True" PageButtonCount="5" />
                </MasterTableView>
                <PagerStyle AlwaysVisible="True" PageButtonCount="5" />
                <FilterMenu EnableImageSprites="False"></FilterMenu>
                <HeaderContextMenu EnableEmbeddedSkins="False"></HeaderContextMenu>
            </telerik:RadGrid>

           
            <telerik:RadWindow ID="reciboanulacion" runat="server" Behaviors="Close"   CssClass="elementsoporte" 
                        NavigateUrl="ReciboAnulacion.aspx"  Opacity = "100" Title="Recibo Anulación" AutoSize="True">
            </telerik:RadWindow>
        </div>
    </div>
</asp:Content>
