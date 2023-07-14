<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="FormularioCompra.aspx.cs" Inherits="TiendaVinilos.FormularioCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="ContenedorPrincipal">
        <div class="container-Formularios"style="width: 600px; height: 500px; margin-top: 20px">
                  
                      <div class="row">
                    <asp:DropDownList runat="server" ID="ddlFormaEntrega" class="controls" AutoPostBack="true" />
                          </div>
              <div class="row">
                    <div class="col">
                    <asp:Label ID="LblDomicilio" runat="server"  ></asp:Label>
                        </div>
                    <div class="col">
                    <asp:Button ID="BtnModificar" Cssclass="btn btn-secondary" visible="false" runat="server" Text="Cambiar" Onclick="BtnModificar_Click"  />
                        </div>
                  </div>
              <div class="row">
                    <asp:DropDownList runat="server" ID="ddlFormaPago" class="controls" AutoPostBack="true" />
                 
                    <% 
                        if (ddlFormaPago.SelectedIndex == 2)
                        {%>
              </div>
              <div class="row">
                    <a href="https://www.mercadopago.com.ar/"target="_blank">Logo Mercado</a>
                 
                    <%}
                        if (ddlFormaPago.SelectedIndex == 3)
                        { %>
                       </div>
                        <div class="row">
                       <div class="col">
                        <label for="TxtNroTarjeta">Numero Tarjeta</label>
                        </div>
                              <div class="col">
                        <asp:TextBox ID="TxtNroTarjeta" runat="server" class="controls small"></asp:TextBox>    
                            </div>
                           </div>
                    <div class="row">
                          <div class="col">
                        <label for="TxtCodSeguridad">Codigo Seguridad</label>
                              </div>
                          <div class="col">
                        <asp:TextBox ID="TxtCodSeguridad" runat="server" class="controls small"></asp:TextBox>
                        </div>
                        </div>
                     <div class="row">
                           <div class="col">
                    <asp:Label ID="lblFechaVto" runat="server" Text="Fecha Vencimiento" Font-Size="Small"></asp:Label>
                               </div>
                           <div class="col">
                    <asp:TextBox ID="TxtFechaVto" class="control" type="date" runat="server"></asp:TextBox>
                      </div>
                         

                    <%} %>
              </div>
            <br />
              <div class="row">
                    <div class="col">
                      <asp:Button ID="BtnAceptar" Text="Comprar" OnClick="BtnAceptar_Click" runat="server" CssClass="btn btn-primary" ToolTip="Click para loguerte" />
                        </div>
                    <div class="col">
                <asp:Button Text="Cancelar" CssClass="btn btn-danger" ID="btnCancelar" AutoPostBack="true" OnClick="btnCancelar_Click" runat="server" />      
                  </div>
                  </div>
              <div class="row">
                      <asp:Label ID="LblMensaje" ForeColor="red" runat="server" Visible="false"></asp:Label> 
                  </div>
                  <asp:RangeValidator ID="rvclass" runat="server" ControlToValidate="TxtNroTarjeta"
                        ErrorMessage="Solo números" ForeColor="red" MaximumValue="10000000000000000"
                        MinimumValue="1" Type="Double">
                    </asp:RangeValidator>
                    <asp:RangeValidator ID="rvlclass2" runat="server" ControlToValidate="TxtCodSeguridad"
                        ErrorMessage="Solo números" ForeColor="red" MaximumValue="5000"
                        MinimumValue="1" Type="Double">
                    </asp:RangeValidator>
            </div>
            </div>
    
</asp:Content>
