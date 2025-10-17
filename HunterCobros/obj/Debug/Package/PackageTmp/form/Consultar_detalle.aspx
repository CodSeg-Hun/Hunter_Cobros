<%@ Page EnableEventValidation="false"  Language="vb" AutoEventWireup="false" CodeBehind="Consultar_detalle.aspx.vb" Inherits="HunterCobros.Consulta_detalle" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>Detalle de Cobros</title>
        <script type="text/javascript">
            function impre(num) {
                document.getElementById(num).className = "ver";
                print();
                document.getElementById(num).className = "nover";
            }
        </script>
        <style type="text/css">
            .autosize
            { 
                height : auto !important ;
                 }
     .ExpandCollapse
  {
    background-color: Yellow !important ;
  }
                  </style>   
    
    </head>
    <body>
        <form id="form1" runat="server">
            <div id="container" style=" height: 35px;">
                <div style=" width: 450px; height: 30px; float: left; margin-top:-5px;">
                    <h2>
                        <asp:Label ID="lbltitulo" runat="server" Text=""></asp:Label>
                    </h2>
                </div>
                <div style=" width: 40px; height: 30px; float: left;">
                    <telerik:RadButton ID="BtnExportar" runat="server" Text="Exportar" ForeColor="Black" style="top: 0px; left: 0px; height: 32px; width: 32px" 
                        ToolTip="Exporta el listado al formato de archivo especificado" >
                        <Image IsBackgroundImage="False" ImageUrl="../imagen/icons/download32x32.png" />
                    </telerik:RadButton>
                </div>
                <div style=" width: 40px; height: 30px; float: left;">
                    <input type="button" onclick="impre('container');return false" 
                        style="background-image: url('../imagen/icons/printer232x32.png'); background-repeat: no-repeat; background-position: center center;
                        height: 32px; width: 32px; background-color: #FFFFFF; border: none;" />
                </div>
            </div>
            <div style=" margin-top: 10px;">
                <telerik:RadGrid ID="GrdConsolidado" runat="server"  AutoGenerateColumns="False"  CellSpacing="0" Culture="es-ES"
                    GridLines="None" Height="180px"  Width="500px" ShowFooter="True"  Skin="WebBlue" >
                    <FooterStyle CssClass="FooterStyle" />
                    <ClientSettings EnablePostBackOnRowClick="False" EnableRowHoverStyle="True" ReorderColumnsOnClient="False" AllowDragToGroup="True" AllowColumnsReorder="False" >
                        <Selecting AllowRowSelect="False" />
                        <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                        <Resizing AllowRowResize="False" AllowColumnResize="False" EnableRealTimeResize="True" ResizeGridOnColumnResize="False" />
                    </ClientSettings>
                    <GroupingSettings CaseSensitive="false" ShowUnGroupButton="True" />
                    <MasterTableView >
                        <Columns>
                            <telerik:GridBoundColumn DataField="FORMA_PAGO" FilterControlAltText="Filter FORMA_PAGO column" HeaderText="Forma Pago"
                                    UniqueName="FORMA_PAGO" AllowFiltering="False" Aggregate="Count"  FooterText="Total de Forma de Pago: ">
                                <FooterStyle Width="300px"  BackColor="#6F87A0"/>
                                <HeaderStyle Width="300px" Font-Bold="True" HorizontalAlign="left" />
                                <ItemStyle Width="300px" HorizontalAlign="left" BackColor="#FFFFFF" BorderColor="#FFFFFF"/>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="VALOR" FilterControlAltText="Filter VALOR column" HeaderText="Valor " 
                                    UniqueName="VALOR" AllowFiltering="False" DataFormatString="$  {0:F2}" Aggregate="Sum">
                                <FooterStyle Width="140px" BackColor="#6F87A0" />
                                <HeaderStyle Width="140px" Font-Bold="True" HorizontalAlign="left" />
                                <ItemStyle Width="140px" HorizontalAlign="left" BackColor="#FFFFFF" BorderColor="#FFFFFF"/>
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                    <FilterMenu EnableImageSprites="False"></FilterMenu>
                </telerik:RadGrid>
            </div>
            <div style=" margin-top: 10px;">
                <telerik:RadGrid ID="GrdConsultarDetalle" runat="server" AutoGenerateColumns="False"  CellSpacing="0" Culture="es-ES" Skin="WebBlue"
                    GridLines="None" Height="950px" OnDetailTableDataBind="GrdConsultarDetalle_DetailTableDataBind"
                    OnNeedDataSource="GrdConsultarDetalle_NeedDataSource" OnPreRender="GrdConsultarDetalle_PreRender">
                    
                   <%-- <GroupingSettings ShowUnGroupButton="True" />--%>

                   
                    <MasterTableView DataKeyNames="NUMERO_ANTICIPO" PageSize="10" ShowGroupFooter="true" AllowMultiColumnSorting="true"
                     NoDetailRecordsText="" NoMasterRecordsText="" Name="Maestra">
                        <DetailTables>
                            <telerik:GridTableView runat="server" Name="Detalle" DataKeyNames="DETALLE_ID" CssClass="grid_detalle"  Width="900px">
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="DETALLE_ID" FilterControlAltText="Filter DETALLE_ID column"
                                        HeaderText="DETALLE_ID" UniqueName="DETALLE_ID" AllowFiltering="False" Visible="False">
                                        <FooterStyle Width="1px" />
                                        <HeaderStyle Font-Bold="True" Width="1px" />
                                        <ItemStyle Width="1px"  HorizontalAlign="left" BackColor="#FFFFFF"/>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FORMA_PAGO" FilterControlAltText="Filter FORMA_PAGO column"
                                        HeaderText="Forma Pago" UniqueName="FORMA_PAGO" AllowFiltering="False" Aggregate="Count" 
                                        FooterText="Total de Forma de Pago: ">
                                        <FooterStyle Width="300px" />
                                        <HeaderStyle Width="300px" Font-Bold="True" />
                                        <ItemStyle Width="300px" HorizontalAlign="left" BackColor="#FFFFFF" BorderColor="#FFFFFF"/>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BANCO" FilterControlAltText="Filter BANCO column"
                                        HeaderText="Banco" UniqueName="BANCO" AllowFiltering="False">
                                        <FooterStyle Width="300px" />
                                        <HeaderStyle Width="300px" Font-Bold="True" />
                                        <ItemStyle Width="300px" HorizontalAlign="left" BackColor="#FFFFFF" BorderColor="#FFFFFF"/>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="VALOR" FilterControlAltText="Filter VALOR column" HeaderText="Valor " 
                                        UniqueName="VALOR" AllowFiltering="False" DataFormatString="$  {0:F2}" Aggregate="Sum">
                                        <FooterStyle Width="140px" />
                                        <HeaderStyle Width="140px" Font-Bold="True" />
                                        <ItemStyle Width="140px" HorizontalAlign="left" BackColor="#FFFFFF" BorderColor="#FFFFFF"/>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DOCUMENTO"   FilterControlAltText="Filter DOCUMENTO column"
                                        HeaderText="Documento" UniqueName="DOCUMENTO" AllowFiltering="False">
                                        <FooterStyle Width="200px" />
                                        <HeaderStyle Width="200px" Font-Bold="True" />
                                        <ItemStyle Width="200px" HorizontalAlign="left" BackColor="#FFFFFF" BorderColor="#FFFFFF"/>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PLAZO"   FilterControlAltText="Filter PLAZO column"
                                        HeaderText="Plazo" UniqueName="PLAZO" AllowFiltering="False">
                                        <FooterStyle Width="50px" />
                                        <HeaderStyle Width="50px" Font-Bold="True" />
                                        <ItemStyle Width="50px" HorizontalAlign="left" BackColor="#FFFFFF" BorderColor="#FFFFFF"/>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="VOUCHER"   FilterControlAltText="Filter VOUCHER column"
                                        HeaderText="Voucher" UniqueName="VOUCHER" AllowFiltering="False">
                                        <FooterStyle Width="300px" />
                                        <HeaderStyle Width="300px" Font-Bold="True" />
                                        <ItemStyle Width="300px" HorizontalAlign="left" BackColor="#FFFFFF" BorderColor="#FFFFFF"/>
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                </EditFormSettings>
                                <PagerStyle AlwaysVisible="True" PageSizeControlType="RadComboBox"></PagerStyle>
                            </telerik:GridTableView>
                        </DetailTables>

                        <DetailTables>
                            <telerik:GridTableView runat="server" Name="Referencia" DataKeyNames="REFERENCIA_ID" CssClass="grid_detalle"  Width="900px">
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="REFERENCIA_ID" FilterControlAltText="Filter REFERENCIA_ID column"
                                        HeaderText="REFERENCIA_ID" UniqueName="REFERENCIA_ID" AllowFiltering="False" Visible="False">
                                        <FooterStyle Width="1px" />
                                        <HeaderStyle Font-Bold="True" Width="1px" />
                                        <ItemStyle Width="1px"  HorizontalAlign="left" BackColor="#FFFFFF"/>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DOC_REFERENCIA" FilterControlAltText="Filter DOC_REFERENCIA column"
                                        HeaderText="DOC_REFERENCIA " UniqueName="DOC_REFERENCIA" AllowFiltering="False" >
                                        <FooterStyle Width="300px" />
                                        <HeaderStyle Width="300px" Font-Bold="True" />
                                        <ItemStyle Width="300px" HorizontalAlign="left" BackColor="#FFFFFF" BorderColor="#FFFFFF"/>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="REFERENCIA" FilterControlAltText="Filter REFERENCIA column"
                                        HeaderText="REFERENCIA" UniqueName="REFERENCIA" AllowFiltering="False">
                                        <FooterStyle Width="300px" />
                                        <HeaderStyle Width="300px" Font-Bold="True" />
                                        <ItemStyle Width="300px" HorizontalAlign="left" BackColor="#FFFFFF" BorderColor="#FFFFFF"/>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="OBSERVACION" FilterControlAltText="Filter OBSERVACION column"
                                        HeaderText="OBSERVACION" UniqueName="OBSERVACION" AllowFiltering="False">
                                        <FooterStyle Width="300px" />
                                        <HeaderStyle Width="300px" Font-Bold="True" />
                                        <ItemStyle Width="300px" HorizontalAlign="left" BackColor="#FFFFFF" BorderColor="#FFFFFF"/>
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                </EditFormSettings>
                                <PagerStyle AlwaysVisible="True" PageSizeControlType="RadComboBox"></PagerStyle>
                            </telerik:GridTableView>
                        </DetailTables>

                       
                        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="CODIGO_CLIENTE"  FilterControlAltText="Filter CODIGO_CLIENTE column" HeaderText="Codigo Cliente" 
                                SortExpression="CODIGO_CLIENTE"  UniqueName="CODIGO_CLIENTE" AutoPostBackOnFilter="True" 
                                CurrentFilterFunction="Contains" Visible="False" >
                                <FooterStyle Width="1px" />
                                <HeaderStyle Width="1px" Font-Bold="True" />
                                <ItemStyle Width="1px"  BorderStyle="Inset" HorizontalAlign="left" BackColor="#DAE2E8" BorderColor="#DAE2E8"/>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NUMERO_ANTICIPO" FilterControlAltText="Filter NUMERO_ANTICIPO column" HeaderText="Cod. Anticipo" ReadOnly="True"
                                UniqueName="NUMERO_ANTICIPO" SortExpression="NUMERO_ANTICIPO" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains"  
                                Aggregate="Count" FooterText="Total de Cobros: ">
                                <FooterStyle Width="200px" />
                                <HeaderStyle Width="200px" Font-Bold="True" />
                                <ItemStyle Width="200px" BorderStyle="Inset" HorizontalAlign="left" BackColor="#DAE2E8" BorderColor="#DAE2E8"/>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CLIENTE" FilterControlAltText="Filter CLIENTE column" HeaderText="Cliente" SortExpression="CLIENTE" 
                                UniqueName="CLIENTE" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                                <FooterStyle Width="220px" />
                                <HeaderStyle Width="220px" Font-Bold="True" />
                                <ItemStyle Width="220px" BorderStyle="Inset" HorizontalAlign="left" BackColor="#DAE2E8" BorderColor="#DAE2E8"/>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="RECIBE" FilterControlAltText="Filter RECIBE column" HeaderText="Recibe" SortExpression="RECIBE" 
                                UniqueName="RECIBE" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                                <FooterStyle Width="200px" />
                                <HeaderStyle Width="200px" Font-Bold="True" />
                                <ItemStyle Width="200px" BorderStyle="Inset" HorizontalAlign="left" BackColor="#DAE2E8" BorderColor="#DAE2E8"/>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="VALOR" FilterControlAltText="Filter VALOR column" HeaderText="Valor " SortExpression="VALOR"    
                                UniqueName="VALOR" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains" DataFormatString="$  {0:F2}" Aggregate="Sum" >
                                <FooterStyle Width="80px" />
                                <HeaderStyle Width="80px" Font-Bold="True" />
                                <ItemStyle Width="80px" BorderStyle="Inset" HorizontalAlign="left" BackColor="#DAE2E8" BorderColor="#DAE2E8"/>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="OBSERVACION"  FilterControlAltText="Filter OBSERVACION column" HeaderText="Comentario" SortExpression="OBSERVACION" 
                                UniqueName="OBSERVACION" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                                <FooterStyle Width="160px" />
                                <HeaderStyle Width="160px" Font-Bold="True" />
                                <ItemStyle Width="160px" BorderStyle="Inset" HorizontalAlign="left" BackColor="#DAE2E8" BorderColor="#DAE2E8"/>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ESTADO"  FilterControlAltText="Filter ESTADO column" HeaderText="Estado" SortExpression="ESTADO" 
                                UniqueName="ESTADO" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                                <FooterStyle Width="80px" />
                                <HeaderStyle Width="80px" Font-Bold="True" />
                                <ItemStyle Width="80px" BorderStyle="Inset" HorizontalAlign="left" BackColor="#DAE2E8" BorderColor="#DAE2E8"/>
                            </telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="EMAIL_CLIENTE" FilterControlAltText="Filter EMAIL_CLIENTE column" HeaderText="Email" SortExpression="EMAIL_CLIENTE" 
                                UniqueName="EMAIL_CLIENTE" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                                <FooterStyle Width="200px" />
                                <HeaderStyle Width="200px" Font-Bold="True" />
                                <ItemStyle Width="200px" BorderStyle="Inset" HorizontalAlign="left" BackColor="#DAE2E8" BorderColor="#DAE2E8"/>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FECHA"  FilterControlAltText="Filter FECHA column" HeaderText="Fecha" SortExpression="FECHA" 
                                UniqueName="FECHA" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                                <FooterStyle Width="100px" />
                                <HeaderStyle Width="100px" Font-Bold="True" />
                                <ItemStyle Width="100px" BorderStyle="Inset" HorizontalAlign="left" BackColor="#DAE2E8" BorderColor="#DAE2E8"/>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="USUARIO" FilterControlAltText="Filter USUARIO column" HeaderText="Recaudador" SortExpression="USUARIO" 
                                UniqueName="USUARIO" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                                <FooterStyle Width="140px" />
                                <HeaderStyle Width="140px" Font-Bold="True" />
                                <ItemStyle Width="140px" BorderStyle="Inset" HorizontalAlign="left" BackColor="#DAE2E8" BorderColor="#DAE2E8"/>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="USUARIO_CARTERA" FilterControlAltText="Filter USUARIO_CARTERA column" HeaderText="Usu.Cartera" SortExpression="USUARIO_CARTERA" 
                                UniqueName="USUARIO_CARTERA" AutoPostBackOnFilter="True" CurrentFilterFunction="Contains">
                                <FooterStyle Width="140px" />
                                <HeaderStyle Width="140px" Font-Bold="True" />
                                <ItemStyle Width="140px" BorderStyle="Inset" HorizontalAlign="left" BackColor="#DAE2E8" BorderColor="#DAE2E8"/>
                            </telerik:GridBoundColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                        </EditFormSettings>
                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                    </MasterTableView>
                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                    <FilterMenu EnableImageSprites="False"></FilterMenu>
                </telerik:RadGrid>
            </div>
            <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
            </telerik:RadScriptManager>
        </form>
    </body>
</html>

