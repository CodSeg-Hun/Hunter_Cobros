<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/form/Principal.Master" CodeBehind="Recibo.aspx.vb" Inherits="HunterCobros.Recibo" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="x-ua-compatible" content="IE=9"/>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript">

        function keyPress(sender, args) {
            var text = sender.get_value() + args.get_keyCharacter();
            if (!text.match('^[0-9]+$'))
                args.set_cancel(true);
        }


        function checkLength(txt) {
            var txtLength;
            if (txt != null) {
                txtLength = txt.value.length;
                if (txtLength == 3) {
                    //                       alert(txt.value);
                    txt.value += "-";
                }
                if (txtLength == 6) {
                    //                       alert(txtLength);
                    txt.value += "-";
                }
            }
        }

        function numberOnly(sender, eventArgs) {
            var text = sender.get_value() + eventArgs.get_keyCharacter();
            if (!text.match('^[0-9-]+$'))
                eventArgs.set_cancel(true);
        }

        function letterOnly(sender, args) {
            var text = sender.get_value() + args.get_keyCharacter();
            if (!text.match('^[a-zA-Zéíóúñá ]+$'))
                args.set_cancel(true);
        }

        function numberValor(sender, eventArgs) {
            var text = sender.get_value() + eventArgs.get_keyCharacter();
            if (!text.match('^[0-9-]+$'))
                eventArgs.set_cancel(true);
        }
    </script>
    <link href="../styles/estilogrid.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_article">
        <div class="content_linea_bloque04">
            <div class="secc_title01_principal">Anticipo de Pago Nro. </div>
            <div class="content_textbox03">
                <asp:Label ID="lblanticipo" runat="server" Text="" />
            </div> 
            <div class="toolbar_icon_001">
                <telerik:RadButton ID="BtnGuardar" runat="server" Text="" ForeColor="White" Width="32px" Height="32px" ToolTip="Guardar">
                    <Image IsBackgroundImage="True" ImageUrl="../imagen/icons/save.png" HoveredImageUrl="../imagen/icons/save.png"
                        DisabledImageUrl="../imagen/icons/save.png" />
                </telerik:RadButton>
            </div>
            <div class="toolbar_icon_001">
                <telerik:RadButton ID="BtnCancelar" runat="server" Text="" ForeColor="White" Width="32px" Height="32px" ToolTip="Cancelar ">
                    <Image IsBackgroundImage="True" ImageUrl="../imagen/icons/cancel.png" HoveredImageUrl="../imagen/icons/cancel.png"
                        DisabledImageUrl="../imagen/icons/cancel.png" />
                </telerik:RadButton>
            </div>
        </div>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"  Skin="Telerik"></telerik:RadAjaxLoadingPanel>
        <telerik:RadNotification ID="RnMensajesError" runat="server" Animation="Slide"  Height="100px" Position="Center" Width="414px" EnableRoundedCorners="True" EnableShadow="True">
        </telerik:RadNotification> 
        <br />
        <div>
            <div class="content_info_detalleitems">
                <div class="content_bloque">
                    <div class="content_recibo_bloque">
                        <%--<br />--%>
                        <div class="content_linea_bloque01">
                            <div class="content_title02"> Información General</div>
                        </div>
                        <div class="content_linea_bloque">
                            <div class="content_label">
                                <asp:Label ID="Label4" runat="server" Text="Cédula / Ruc" CssClass="content_label05" />
                            </div>
                            <div class="content_textbox05">
                                <telerik:RadTextBox ID="TxtIdentificacion" runat="server" Width="130px" TabIndex="1" EmptyMessage="Cédula/Ruc" RenderMode="Lightweight"
                                    AutoPostBack="True" MaxLength="13" >
                                    <ClientEvents OnKeyPress="keyPress" />
                                </telerik:RadTextBox>
                            </div>
                            <div class="content_espacio">
                                &nbsp;
                            </div>
                            <div class="content_label">
                                Fecha&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </div>
                            <div class="content_textbox05">
                                <asp:Label ID="lblfecha" runat="server" Text="lblfecha" CssClass="content_label06" />
                            </div>
                        </div>
                        <div class="content_linea_bloque">
                            <div class="content_label">
                                <asp:Label ID="Label5" runat="server" Text="Cliente" CssClass="content_label05" />
                            </div>
                            <div class="content_textbox02">
                                <asp:Label ID="lblcliente" runat="server" Text="lblcliente" />
                            </div>
                        </div>
                        <div class="content_linea_bloque">
                            <div class="content_label">
                                <asp:Label ID="Label6" runat="server" Text="Email Cliente" CssClass="content_label05" />
                            </div>
                            <div class="content_textbox02">
                                <telerik:RadTextBox ID="txt_email" runat="server" Width="430px" TabIndex="2" AutoPostBack="True"  Enabled="false" EmptyMessage="Email" RenderMode="Lightweight" />
                            </div>
                        </div>
                       <%--<div class="separador_004" ></div>
                         <div class="separador_003" ></div>--%>
                        <div class="content_linea_bloque">
                            <div class="content_label">
                                <asp:Label ID="Label7" runat="server" Text="Recibimos de" CssClass="content_label05" />
                            </div>
                            <div class="content_textbox05">
                                <telerik:RadTextBox ID="txt_recibe" runat="server" Width="130px" TabIndex="3" AutoPostBack="True" Enabled="false" EmptyMessage="Cédula/Ruc" MaxLength="13" RenderMode="Lightweight">
                                    <ClientEvents OnKeyPress="keyPress" />
                                </telerik:RadTextBox>
                            </div>
                            <div class="content_espacio">
                                &nbsp;
                            </div>
                            <div class="content_label">
                                Cantidad $&nbsp;
                            </div>
                            <div class="content_textbox05">
                                <telerik:RadNumericTextBox ID="lblcantidad" runat="server" Width="130px" AutoPostBack="True" Enabled="false"  MaxLength="13"
                                         EmptyMessage="0" NumberFormat-DecimalDigits="2" Font-Bold="True" ForeColor="Black" />
                            </div>
                        </div>
                        <div class="content_linea_bloque">
                            <div class="content_label">
                                <asp:Label ID="Label8" runat="server" Text="Nombres" CssClass="content_label05" />
                            </div>
                            <div class="content_textbox02">
                                <telerik:RadTextBox ID="txt_nombres_recibimos" runat="server" Width="430px" TabIndex="4" AutoPostBack="True" EmptyMessage="Nombres" 
                                         MaxLength="50" RenderMode="Lightweight" style="text-transform: uppercase;">
                                    <ClientEvents OnKeyPress="letterOnly" />
                                </telerik:RadTextBox>
                            </div>
                        </div>
                        <div class="content_linea_bloque05">
                            <div class="content_label">
                                <asp:Label ID="Label10" runat="server" Text="Observación" CssClass="content_label05" />
                            </div>
                            <div class="content_textbox02">
                                <telerik:RadTextBox ID="txt_observacion" RenderMode="Lightweight"  Width="430px"  runat="server" TextMode="MultiLine"  
                                         EmptyMessage="Observación" AutoPostBack="True"  Enabled="false" TabIndex="6" MaxLength="100"  style="text-transform: uppercase;" />
                            </div>
                        </div>
                        <div class="content_linea_bloque">
                            <div class="content_label">
                                <asp:Label ID="Label17" runat="server" Text="Usuario Cartera" CssClass="content_label05" />
                            </div>
                            <div class="content_textbox02">
                                <telerik:RadComboBox ID="Cbxcartera" runat="server" Width="260px" AutoPostBack="True" Height="130px" TabIndex="8" />
                            </div>
                        </div>

                        <div class="content_tab_master">
                            <div class="content_linea_bloque08">
                                <telerik:RadTabStrip ID="radtabdatos" runat="server" Width="578px" SelectedIndex="0" MultiPageID="RadMultiPage1" Skin="" CssClass="tab_general">
                                    <Tabs>
                                        <%--ImageUrl="../images/background/Datos_Personales.png"
                                        ImageUrl="../images/background/Direccion_de_Domicilio.png"
                                        ImageUrl="../images/background/Direccion_de_oficina.png"--%>
                                        <telerik:RadTab Text="Detalle de Pago" PageViewID="RadPageView1"  CssClass="tab_individual" Selected="True" />
                                        <telerik:RadTab Text="Referencia" PageViewID="RadPageView2"   CssClass="tab_individual"  />
                                        <telerik:RadTab Text="Tipo de Servicio" PageViewID="RadPageView3" CssClass="tab_individual" />
                                    </Tabs>
                                </telerik:RadTabStrip>
                            </div>
                            <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
                                <telerik:RadPageView ID="RadPageView1" runat="server" Width="600px">
                                    <div class="content_linea_bloque06">
                                        <div class="content_linea_bloque07">
                                            <div class="content_label02">
                                               <asp:Label ID="Label2" runat="server" Text="Forma de Pago" CssClass="content_label05" />
                                            </div>
                                            <div class="secc_combo_cbx">
                                                <telerik:RadComboBox ID="Cbxforma" runat="server" Width="160px" AutoPostBack="True" Height="130px" TabIndex="7" />
                                            </div>
                                            <div class="content_label04">
                                                 <asp:Label ID="Label1" runat="server" Text="Valor" CssClass="content_label05" />
                                            </div>
                                            <div class="content_textbox">
                                                <telerik:RadNumericTextBox ID="txt_valor" RenderMode="Lightweight"  runat="server" Width="110px" AutoPostBack="True"  Enabled="false"  
                                                        MaxLength="13" EmptyMessage="0" NumberFormat-DecimalDigits="2" TabIndex="8"/>
                                            </div>
                                        </div>
                                        <div class="content_linea_bloque07">
                                            <div class="content_label02" >
                                                <asp:Label ID="lblbanco" runat="server" Text="Banco" CssClass="content_label05" />
                                            </div>
                                            <div class="secc_combo_cbx">
                                                <%--<telerik:RadComboBox ID="Cbxbanco" runat="server" Width="160px" AutoPostBack="True" Height="130px" Enabled="False" TabIndex="9"/>--%>
                                               <telerik:RadComboBox ID="Cbxbanco" RenderMode="Lightweight" runat="server" EnableVirtualScrolling="true"  
                                                        AutoPostBack="True" Culture="es-ES" Height="130px" Width="160px" Enabled="False" TabIndex="9">
                                               </telerik:RadComboBox>
                                            </div>
                                            <div class="content_label02">
                                                <asp:Label ID="Label3" runat="server" Text="No. Documento" CssClass="content_label05" />
                                            </div>
                                            <div class="content_textbox">
                                                <telerik:RadTextBox ID="txt_documento" RenderMode="Lightweight" runat="server" Width="110px"  AutoPostBack="True"  Enabled="false"  MaxLength="20" EmptyMessage="Documento" TabIndex="10">
                                                    <ClientEvents OnKeyPress="keyPress" />
                                                </telerik:RadTextBox>
                                            </div>
                                            <div class="toolbar_icon_002">
                                                <telerik:RadButton ID="BtnProcesar" runat="server" Text=""  Width="32px" Height="32px" ForeColor="White" ToolTip="Procesar" TabIndex="13">
                                                    <Image  ImageUrl="../imagen/icons/Add3.png" HoveredImageUrl="../imagen/icons/Add3.png" DisabledImageUrl="../imagen/icons/Add3.png" IsBackgroundImage="True"/>
                                                </telerik:RadButton>
                                             <%--  <asp:ImageButton ID="BtnProcesar" runat="server" ImageUrl="../imagen/icons/Add3.png" OnClientClick="BtnProcesar_Click" AlternateText="No Image available" ToolTip="Procesar" TabIndex="13"  /> 
                                            --%>   
                                          <%--      <asp:ImageButton ID="BtnProcesar" runat="server" Height="32px" ImageAlign="Left" ImageUrl="../imagen/icons/Add3.png" OnClick="BtnProcesar_Click" />
                                          --%>  
                                            </div>
                                        </div>
                                        <div class="content_linea_bloque07"  >
                                            <div class="content_label02" >
                                                <asp:Label ID="Label13" runat="server" Text="Plazo" CssClass="content_label05" />
                                            </div>
                                            <div class="secc_combo_cbx" >
                                                <%--<telerik:RadComboBox ID="Cbxplazo" runat="server" Width="160px"  AutoPostBack="True" Height="130px" Enabled="False" TabIndex="11"/>--%>
                                                <telerik:RadComboBox ID="Cbxplazo" RenderMode="Lightweight" runat="server" EnableVirtualScrolling="true"  
                                                        AutoPostBack="True" Culture="es-ES" Height="130px" Width="160px" Enabled="False" TabIndex="11">
                                                </telerik:RadComboBox>
                                                <telerik:RadDatePicker ID="rdpFecha" Runat="server" ToolTip="Ingrese la fecha" 
                                                    Width="160px" Visible="False" EnableTyping="False" >
                                                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                                    </Calendar>
                                                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" 
                                                        LabelWidth="40%" ReadOnly="True">
                                                    </DateInput>
                                                    <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                </telerik:RadDatePicker>
                                              <%--  <dx:ASPxSpinEdit ID="SpinRetencion" runat="server" Height="24px" Number="0"
                                                    MaxValue="100" NumberType="Integer" Visible="False" MaxLength="3"  Width="160px">
                                                     <SpinButtons ShowIncrementButtons="False" ShowLargeIncrementButtons="True" />
                                               </dx:ASPxSpinEdit>--%>
                                              <%--  --%>
                                            </div>
                                            <div class="content_label04">
                                                <asp:Label ID="Label14" runat="server" Text="No. Voucher" CssClass="content_label05" />
                                            </div>
                                            <div class="content_textbox">
                                                <telerik:RadTextBox ID="txt_voucher" RenderMode="Lightweight" runat="server" Width="110px"  AutoPostBack="True"  Enabled="false"  MaxLength="14" EmptyMessage="Voucher" TabIndex="12">
                                                    <ClientEvents OnKeyPress="keyPress" />
                                                </telerik:RadTextBox>
                                            </div>
                                        </div>
                                         <div class="content_linea_bloque07"  >
                                             <div class="content_label02" >
                                                <asp:Label ID="Label15" runat="server" Text="% Retención" CssClass="content_label05" />
                                             </div>
                                             <div class="secc_combo_cbx" >
                                                <%--<dx:ASPxSpinEdit ID="SpinRetencion" runat="server" Number="0" Width="160px"  Height="24px" MaxLength="3" Enabled="false" 
                                                     AutoPostBack="True"  MaxValue="100"  NumberType="Integer" CssClass="content_spinner" TabIndex="13">
                                                    <SpinButtons ShowIncrementButtons="False" ShowLargeIncrementButtons="True" />
                                                </dx:ASPxSpinEdit>--%>
                                                  <%--<telerik:RadNumericTextBox ID="SpinRetencion" RenderMode="Lightweight"  runat="server" Width="160px" AutoPostBack="True"  Enabled="false"  
                                                        MaxLength="5" EmptyMessage="0" NumberFormat-DecimalDigits="2" TabIndex="8"/>--%>
                                                    <telerik:RadComboBox ID="CbxretenIva" runat="server" Width="160px" AutoPostBack="True" Height="130px" TabIndex="13" Enabled="False"/>
                                                    <telerik:RadComboBox ID="CbxretenFuente" runat="server" Width="160px" AutoPostBack="True" Height="130px" TabIndex="13" Enabled="False"  Visible="False"/>
                                             </div>
                                             <div class="content_label04">
                                                <asp:Label ID="Label16" runat="server" Text="No. Serie" 
                                                     CssClass="content_label05" />
                                             </div>
                                             <div class="content_textbox">
                                                <telerik:RadTextBox ID="txt_retencion" RenderMode="Lightweight" runat="server" Width="110px"  AutoPostBack="True"  Enabled="false"  MaxLength="14" EmptyMessage="Retención" TabIndex="14">
                                                    <ClientEvents OnKeyPress="keyPress"  />
                                                </telerik:RadTextBox>
                                               <%-- <telerik:RadTextBox ID="txt_retencion" RenderMode="Lightweight" runat="server" Width="110px"  AutoPostBack="True"  Enabled="false"  MaxLength="14" EmptyMessage="Retención" TabIndex="14" onkeyup="return checkLength(this);">
                                                </telerik:RadTextBox>--%>
                                             </div>
                                         </div>
                                    </div>
                                    <div class="data">
                                       <%-- <telerik:RadGrid ID="Grddetalle" runat="server" AllowCustomPaging="True" AllowPaging="True" Height="190px" Width="580px" PageSize="5" VirtualItemCount="5" 
                                            ShowStatusBar="True" Skin="MyCustomSkin" EnableEmbeddedSkins="False" CellSpacing="0" Culture="es-ES" GridLines="None" ShowFooter="True">--%>
                                        <telerik:RadGrid ID="Grddetalle" runat="server"  AutoGenerateColumns="False" AllowSorting="True"  Height="190px" Width="580px"  
                                            ShowStatusBar="True" Skin="MyCustomSkin" EnableEmbeddedSkins="False" CellSpacing="0"  Culture="es-ES" GridLines="None"  ShowFooter="True" >
                                            <GroupingSettings CaseSensitive="false" />
                                            <SortingSettings SortedBackColor="BurlyWood" />
                                            <ClientSettings EnablePostBackOnRowClick="False">
                                                <Selecting AllowRowSelect="True" CellSelectionMode="None" />   
                                                <Scrolling AllowScroll="True" UseStaticHeaders="True" />                               
                                                <Resizing AllowRowResize="false" />
                                            </ClientSettings>
                                            <MasterTableView Width="100%" AutoGenerateColumns="false" EditMode="InPlace" GridLines="None" TableLayout="Auto" NoMasterRecordsText="" >
                                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"  Visible="True"></RowIndicatorColumn>
                                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True"></ExpandCollapseColumn>
                                                <Columns>
                                                    <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete"
                                                        FilterControlAltText="Filter DeleteColumn column"  Text="Borrar" ImageUrl="../imagen/icons/Trash2.png"
                                                        UniqueName="DeleteColumn" Resizable="false" ConfirmText="Borrar registro?" ButtonCssClass="ButtonColumn">
                                                        <FooterStyle Width="28px" />
                                                        <HeaderStyle Width="28px" />
                                                        <ItemStyle Width="28px"  />
                                                    </telerik:GridButtonColumn>
                                                    <telerik:GridBoundColumn DataField="DETALLE_ID"  FilterControlAltText="Filter DETALLE_ID column" HeaderText="Reg." 
                                                        SortExpression="DETALLE_ID" UniqueName="DETALLE_ID"  AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                                                        <FooterStyle Width="10px" />
                                                        <HeaderStyle Width="40px" Font-Bold="True" />
                                                        <ItemStyle Width="10px" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="FORMA_PAGO" FilterControlAltText="Filter FORMA_PAGO column" HeaderText="Forma Pago" 
                                                        ReadOnly="True" UniqueName="FORMA_PAGO" SortExpression="FORMA_PAGO" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" 
                                                        Aggregate="Count"  FooterText="No. Registros: ">
                                                        <FooterStyle Width="180px" />
                                                        <HeaderStyle Width="180px" Font-Bold="True" />
                                                        <ItemStyle Width="180px" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="BANCO" FilterControlAltText="Filter BANCO column" HeaderText="Banco" 
                                                        SortExpression="BANCO" UniqueName="BANCO" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                                                        <FooterStyle Width="220px" />
                                                        <HeaderStyle Width="220px" Font-Bold="True" />
                                                        <ItemStyle Width="220px" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="VALOR" FilterControlAltText="Filter VALOR column" HeaderText="Valor"    
                                                        SortExpression="VALOR" UniqueName="VALOR"  DataFormatString="{0:F2}" AutoPostBackOnFilter="True" 
                                                        CurrentFilterFunction="Contains"  DataType="System.Decimal" Aggregate="Sum">
                                                        <FooterStyle Width="70px" />
                                                        <HeaderStyle Width="70px" Font-Bold="True" />
                                                        <ItemStyle Width="70px" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="DOCUMENTO"  FilterControlAltText="Filter DOCUMENTO column" HeaderText="Nro. Documento" 
                                                        SortExpression="DOCUMENTO" UniqueName="DOCUMENTO" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                                                        <FooterStyle Width="140px" />
                                                        <HeaderStyle Width="140px" Font-Bold="True" />
                                                        <ItemStyle Width="140px" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="PLAZO" FilterControlAltText="Filter PLAZO column" HeaderText="Plazo" 
                                                        SortExpression="PLAZO" UniqueName="PLAZO" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                                                        <FooterStyle Width="70px" />
                                                        <HeaderStyle Width="70px" Font-Bold="True" />
                                                        <ItemStyle Width="70px" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="VOUCHER" FilterControlAltText="Filter VOUCHER column" HeaderText="Nro. Voucher" 
                                                        SortExpression="VOUCHER" UniqueName="VOUCHER" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                                                        <FooterStyle Width="140px" />
                                                        <HeaderStyle Width="140px" Font-Bold="True" />
                                                        <ItemStyle Width="140px" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="PORC_RETENCION" FilterControlAltText="Filter PORC_RETENCION column" HeaderText="% Retención" 
                                                        SortExpression="PORC_RETENCION" UniqueName="PORC_RETENCION" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                                                        <FooterStyle Width="90px" />
                                                        <HeaderStyle Width="90px" Font-Bold="True" />
                                                        <ItemStyle Width="90px" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="RETENCION" FilterControlAltText="Filter RETENCION column" HeaderText="Nro. Retención" 
                                                        SortExpression="RETENCION" UniqueName="RETENCION" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                                                        <FooterStyle Width="140px" />
                                                        <HeaderStyle Width="140px" Font-Bold="True" />
                                                        <ItemStyle Width="140px" />
                                                    </telerik:GridBoundColumn>
                                                     <telerik:GridBoundColumn DataField="FECHA_CHEQUE" FilterControlAltText="Filter FECHA_CHEQUE column" HeaderText="Fecha Cheque" 
                                                        SortExpression="FECHA_CHEQUE" UniqueName="FECHA_CHEQUE" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                                                        <FooterStyle Width="140px" />
                                                        <HeaderStyle Width="140px" Font-Bold="True" />
                                                        <ItemStyle Width="140px" />
                                                    </telerik:GridBoundColumn>

                                                </Columns>
                                                <EditFormSettings>
                                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                                </EditFormSettings>
                                                <PagerStyle PageButtonCount="5" />
                                            </MasterTableView>
                                            <PagerStyle PageButtonCount="5" />
                                            <FilterMenu EnableImageSprites="False"></FilterMenu>
                                            <HeaderContextMenu EnableEmbeddedSkins="False"></HeaderContextMenu>
                                        </telerik:RadGrid>
                                        <asp:ObjectDataSource ID="BaseAnticipo" runat="server" SelectMethod="Clone" TypeName="HunterCobros.dsHunterCobro+ANTICIPO_DETALLEDataTable">
                                        </asp:ObjectDataSource>
                                    </div>
                                </telerik:RadPageView>
                                <telerik:RadPageView ID="RadPageView2" runat="server" Width="600px">
                                    <div class="content_linea_bloque09">
                                        <div class="content_linea_bloque07">
                                            <div class="content_label">
                                                <asp:Label ID="Label9" runat="server" Text="Doc. Referencia" CssClass="content_label05" />
                                            </div>
                                            <div class="secc_combo_cbx">
                                                <telerik:RadComboBox ID="Cbxreferencia" runat="server" Width="160px" AutoPostBack="True" Height="130px" TabIndex="14" />
                                            </div>
                                            <div class="content_label">
                                                Número &nbsp;
                                            </div>
                                            <div class="content_textbox">
                                                <telerik:RadTextBox ID="txt_ref" RenderMode="Lightweight"  runat="server" Width="110px"  EmptyMessage="Referencia" AutoPostBack="True" MaxLength="16" TabIndex="15" >
                                                    <ClientEvents OnKeyPress="numberOnly" />
                                                </telerik:RadTextBox>
                                            </div>
                                        </div>
                                        <div class="content_linea_bloque07">
                                            <div class="content_label">
                                                <asp:Label ID="Label12" runat="server" Text="Observación" CssClass="content_label05" />
                                            </div>
                                            <div class="content_textbox06">
                                                <telerik:RadTextBox ID="txt_observacionRef" RenderMode="Lightweight"  Width="390px"  runat="server" TextMode="MultiLine"  
                                                         EmptyMessage="Observación" AutoPostBack="True"  Enabled="false" MaxLength="100"  style="text-transform: uppercase;" TabIndex="16" />
                                            </div>
                                            <div class="toolbar_icon_002">
                                                <telerik:RadButton ID="BtnProcesarRef" runat="server" Text=""  Width="32px" Height="32px" ForeColor="White" ToolTip="Procesar" TabIndex="17">
                                                    <Image  ImageUrl="../imagen/icons/Add3.png" HoveredImageUrl="../imagen/icons/Add3.png" DisabledImageUrl="../imagen/icons/Add3.png" IsBackgroundImage="True" />
                                                </telerik:RadButton>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="data">
                                        <telerik:RadGrid ID="Grdreferencia" runat="server" AllowCustomPaging="True"  AllowPaging="True" Height="140px" PageSize="5" VirtualItemCount="5" 
                                            ShowStatusBar="True" Width="580px" Skin="MyCustomSkin" EnableEmbeddedSkins="False" CellSpacing="0" Culture="es-ES" GridLines="None" ShowFooter="True">
                                            <GroupingSettings CaseSensitive="false" />
                                            <SortingSettings SortedBackColor="BurlyWood" />
                                            <ClientSettings EnablePostBackOnRowClick="False">
                                                <Selecting AllowRowSelect="True" CellSelectionMode="None" />                                  
                                                <Resizing AllowRowResize="false" />
                                            </ClientSettings>
                                            <MasterTableView Width="100%" AutoGenerateColumns="false" EditMode="InPlace" GridLines="None" TableLayout="Auto" NoMasterRecordsText="" >
                                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"  Visible="True"></RowIndicatorColumn>
                                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True"></ExpandCollapseColumn>
                                                <Columns>
                                                    <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete"
                                                        FilterControlAltText="Filter DeleteColumn column"  Text="Borrar" ImageUrl="../imagen/icons/Trash2.png"
                                                        UniqueName="DeleteColumn" Resizable="false" ConfirmText="Borrar registro?" ButtonCssClass="ButtonColumn">
                                                        <FooterStyle Width="26px" />
                                                        <HeaderStyle Width="26px" />
                                                        <ItemStyle Width="26px"  />
                                                    </telerik:GridButtonColumn>
                                                    <telerik:GridBoundColumn DataField="REFERENCIA_ID"  FilterControlAltText="Filter REFERENCIA_ID column" HeaderText="Reg." 
                                                        SortExpression="REFERENCIA_ID" UniqueName="REFERENCIA_ID"  AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                                                        <FooterStyle Width="1px" />
                                                        <HeaderStyle Width="1px" />
                                                        <ItemStyle Width="1px" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="DOC_REFERENCIA" FilterControlAltText="Filter DOC_REFERENCIA column" HeaderText="Doc. Referencia" 
                                                        ReadOnly="True" UniqueName="DOC_REFERENCIA" SortExpression="DOC_REFERENCIA" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" 
                                                        Aggregate="Count"  FooterText="No. Registros: ">
                                                        <FooterStyle Width="220px" />
                                                        <HeaderStyle Width="220px" />
                                                        <ItemStyle Width="220px" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="REFERENCIA" FilterControlAltText="Filter REFERENCIA column" HeaderText="Nro. Referencia" 
                                                        SortExpression="REFERENCIA" UniqueName="REFERENCIA" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                                                        <FooterStyle Width="220px" />
                                                        <HeaderStyle Width="220px" />
                                                        <ItemStyle Width="220px" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="OBSERVACION" FilterControlAltText="Filter OBSERVACION column" HeaderText="Observación" 
                                                        SortExpression="OBSERVACION" UniqueName="OBSERVACION" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                                                        <FooterStyle Width="250px" />
                                                        <HeaderStyle Width="250px" />
                                                        <ItemStyle Width="250px" />
                                                    </telerik:GridBoundColumn>
                                                </Columns>
                                                <EditFormSettings>
                                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                    </EditColumn>
                                                </EditFormSettings>
                                                <PagerStyle PageButtonCount="5" />
                                            </MasterTableView>
                                            <PagerStyle PageButtonCount="5" />
                                            <FilterMenu EnableImageSprites="False">
                                            </FilterMenu>
                                            <HeaderContextMenu EnableEmbeddedSkins="False"></HeaderContextMenu>
                                        </telerik:RadGrid>
                                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Clone" TypeName="HunterCobros.dsHunterCobro+ANTICIPO_DETALLEDataTable">
                                        </asp:ObjectDataSource>
                                    </div>
                                </telerik:RadPageView>
                                <telerik:RadPageView ID="RadPageView3" runat="server" Width="600px">
                                    <div class="content_linea_bloque10">
                                        <div class="content_linea_bloque07">
                                            <div class="content_espacio">&nbsp;</div>
                                            <div class="secc_check_cbx">
                                                <asp:CheckBox ID="CheckBox" runat="server" Text="RENOVACIÓN H.LOJACK" TabIndex="18"/>
                                            </div>
                                            <div class="content_espacio">&nbsp;</div>
                                            <div class="secc_check_cbx">
                                                <asp:CheckBox ID="CheckBox1" runat="server" Text="RENOVACIÓN H.MONITOREO" TabIndex="19"/>
                                            </div>
                                        </div>
                                        <div class="content_linea_bloque07">
                                            <div class="content_espacio">&nbsp;</div>
                                            <div class="secc_check_cbx">
                                                <asp:CheckBox ID="CheckBox2" runat="server" Text="INSTALACIÓN H.LOJACK" TabIndex="20"/>
                                            </div>
                                           <div class="content_espacio">&nbsp;</div>
                                            <div class="secc_check_cbx">
                                                <asp:CheckBox ID="CheckBox3" runat="server" Text="INSTALACIÓN H.MONITOREO" TabIndex="21"/>
                                            </div>
                                        </div>
                                        <div class="content_linea_bloque07">
                                            <div class="content_espacio">&nbsp;</div>
                                            <div class="secc_check_cbx">
                                                <asp:CheckBox ID="CheckBox4" runat="server" Text="ALARMAS" TabIndex="22"/>
                                            </div>
                                            <div class="content_espacio">&nbsp;</div>
                                            <div class="secc_check_cbx">
                                                <asp:CheckBox ID="CheckBox5" runat="server" Text="PELICULAS" TabIndex="23"/>
                                            </div>
                                        </div>
                                        <div class="content_linea_bloque07">
                                            <div class="content_espacio">&nbsp;</div>
                                            <div class="secc_check_cbx">
                                                <asp:CheckBox ID="CheckBox6" runat="server" Text="HELP SERVICE" TabIndex="24"/>
                                            </div>
                                            <div class="content_espacio">&nbsp;</div>
                                            <div class="secc_check_cbx">
                                                <asp:CheckBox ID="CheckBox7" runat="server" Text="GARANTÍA EXTENDIDA" TabIndex="25"/>
                                            </div>
                                        </div>
                                        <div class="content_linea_bloque07">
                                            <div class="content_espacio">&nbsp;</div>
                                            <div class="secc_check_cbx">
                                                <asp:CheckBox ID="CheckBox8" runat="server" Text="TRANSFERENCIA" TabIndex="26"/>
                                            </div>
                                        </div>
                                        <div class="content_linea_bloque07"></div>
                                        <div class="content_linea_bloque07">
                                            <div class="content_espacio">&nbsp;</div>
                                            <div class="content_label">
                                                <asp:Label ID="Label11" runat="server" Text="&nbsp;&nbsp;&nbsp;&nbsp;OTROS" CssClass="content_label05" Width="61px" />
                                            </div>
                                            <div class="content_textbox07">
                                                <telerik:RadTextBox ID="Txt_otros" runat="server" Width="270px" AutoPostBack="True" EmptyMessage="Otros" 
                                                         MaxLength="30" RenderMode="Lightweight" style="text-transform: uppercase;" TabIndex="27">
                                                    <ClientEvents OnKeyPress="letterOnly" />
                                                </telerik:RadTextBox>
                                            </div>
                                        </div>
                                    </div>
                                </telerik:RadPageView>
                            </telerik:RadMultiPage>
                        </div>
                    </div>
                </div>
            </div>
        </div>
         <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="BtnGuardar">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="lblanticipo" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="BtnGuardar" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="RnMensajesError" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="TxtIdentificacion"  LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="lblfecha"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                        <telerik:AjaxUpdatedControl ControlID="lblcliente"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                        <telerik:AjaxUpdatedControl ControlID="txt_email"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                        <telerik:AjaxUpdatedControl ControlID="txt_recibe"  LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="lblcantidad" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="txt_nombres_recibimos" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="txt_observacion" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="Cbxforma" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="Cbxcartera" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="txt_valor" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="lblbanco" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="Cbxbanco" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="Cbxplazo" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="txt_documento" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="txt_voucher" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="BtnProcesar" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="Grddetalle" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="Grdreferencia" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="Cbxreferencia" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="txt_ref" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="txt_observacionRef"  LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox1" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox2" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox3" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox4" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox5" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox6" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox7" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox8" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="Txt_otros" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="BtnCancelar">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="lblanticipo" LoadingPanelID="RadAjaxLoadingPanel1"/>
                        <telerik:AjaxUpdatedControl ControlID="BtnGuardar"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                        <telerik:AjaxUpdatedControl ControlID="TxtIdentificacion"   LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="lblcliente"  LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="txt_email"  LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="txt_recibe"    LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="lblcantidad" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="txt_nombres_recibimos" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="txt_observacion" LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="Cbxforma" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="Cbxcartera" LoadingPanelID="RadAjaxLoadingPanel1" />
                       <%-- <telerik:AjaxUpdatedControl ControlID="radtabdatos" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="RadMultiPage1" LoadingPanelID="RadAjaxLoadingPanel1" />--%>
                        <telerik:AjaxUpdatedControl ControlID="txt_retencion" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CbxretenIva" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CbxretenFuente" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="rdpFecha" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="Cbxplazo" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="Cbxreferencia" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="txt_ref" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="txt_observacionRef" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="Grdreferencia" LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="Grddetalle" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox"  LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox1" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox2" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox3" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox4" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox5" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox6" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox7" LoadingPanelID="RadAjaxLoadingPanel1"/>
                        <telerik:AjaxUpdatedControl ControlID="CheckBox8" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="Txt_otros" LoadingPanelID="RadAjaxLoadingPanel1" />
            
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="TxtIdentificacion">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="BtnGuardar" LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="BtnCancelar" LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="RnMensajesError" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="TxtIdentificacion"  LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="lblcliente"   LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="txt_email" LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="Cbxcartera" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="txt_recibe"   LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="txt_nombres_recibimos"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="txt_observacion" LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="Cbxforma" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="Cbxreferencia" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="txt_ref" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="txt_observacionRef" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox"  LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox1" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox2" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox3" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox4" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox5" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox6" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox7" LoadingPanelID="RadAjaxLoadingPanel1"/>
                        <telerik:AjaxUpdatedControl ControlID="CheckBox8" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="Txt_otros" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="radtabdatos">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="radtabdatos"  LoadingPanelID="RadAjaxLoadingPanel1"/>
                        <telerik:AjaxUpdatedControl ControlID="RadMultiPage1" LoadingPanelID="RadAjaxLoadingPanel1"/>
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="Cbxforma">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="txt_valor" LoadingPanelID="RadAjaxLoadingPanel1"/>
                        <telerik:AjaxUpdatedControl ControlID="lblbanco"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="Cbxbanco" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="rdpFecha" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="Cbxplazo" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="txt_documento" LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="txt_voucher" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="BtnProcesar" LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="Label14" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="Label13" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="Cbxplazo" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="txt_retencion" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CbxretenIva" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CbxretenFuente" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <%--<telerik:AjaxUpdatedControl ControlID="div1" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="div2" LoadingPanelID="RadAjaxLoadingPanel1" />--%>
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="BtnProcesar">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RnMensajesError"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="lblcantidad" LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="Cbxforma"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="txt_valor" LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="lblbanco" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="Cbxbanco" LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="Cbxplazo" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="txt_documento" LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="txt_voucher" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="BtnProcesar" LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="Grddetalle" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="txt_retencion" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CbxretenFuente" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="CbxretenIva" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="Grddetalle">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="lblcantidad" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="Grddetalle" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="Cbxreferencia">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="txt_ref"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="txt_observacionRef"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="BtnProcesarRef"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="BtnProcesarRef">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RnMensajesError"  LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="Cbxreferencia" LoadingPanelID="RadAjaxLoadingPanel1"  />
                        <telerik:AjaxUpdatedControl ControlID="txt_ref" LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="txt_observacionRef"  LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="BtnProcesarRef"  LoadingPanelID="RadAjaxLoadingPanel1" />
                        <telerik:AjaxUpdatedControl ControlID="Grdreferencia" LoadingPanelID="RadAjaxLoadingPanel1"  />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="Grdreferencia">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="Grdreferencia"  LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
    </div>
</asp:Content>