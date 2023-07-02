<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarCuenta.aspx.cs" Inherits="TiendaVinilos.RegistrarCuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <div class="CuerpoRegistro">
   
    
      <div class="CuerpoRegistro">
      <div class="FormularioRegistro">
      <h4>Formulario Registro</h4>
      <asp:TextBox ID="TxtNombre" class="controls" type="text" placeholder="Ingrese su Nombre"  aria-label="Ingrese Nombre" runat="server" ></asp:TextBox>
      <asp:TextBox ID="TxtApellido" class="controls" type="text" placeholder="Ingrese su Apellido" aria-label="Ingrese Nombre" runat="server" ></asp:TextBox>
      <asp:TextBox ID="TxtEmail" class="controls" type="email"  placeholder="Ingrese su Email" aria-label="Ingrese Nombre" runat="server" ></asp:TextBox>
      <%//mas dtos posiblemente pensar bien que se necesita del usuario cuando se compre %>
      <asp:TextBox ID="TxtPass" class="controls" MaxLength="8" type="password" placeholder="Ingrese su Contraseña 8 caracteres max" aria-label="Ingrese Nombre" runat="server"></asp:TextBox>
          <asp:Button ID="BtnAgregar" OnClick="BtnAgregar_Click" Text="Registrar"  CssClass="btn btn-primary" runat="server" ToolTip="Click para darse de alta" />
    <asp:Button Text="Cancelar" CssClass="btn btn-outline-info" ID="btnCancelar" AutoPostBack="true" OnClick="btnCancelar_Click" runat="server" />
          <div>

          <asp:Label ID="LblMensaje" runat="server" Visible="false"></asp:Label>
          </div>
    <p><a href="Login.aspx">¿Ya tengo Cuenta?</a></p>
         </div>
        </div>
    
</div>


</asp:Content>
