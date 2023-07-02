<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TiendaVinilos.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>


<body>
  
        <div class="CuerpoRegistro">
            <div class="FormularioRegistro">
                <h4>Mi Perfil</h4>
                <label for="TxtNombre">Nombre</label>
                <asp:TextBox ID="TxtNombre" runat="server" class="controls"></asp:TextBox>
                <label for="TxtApellido">Apellido</label>

                <asp:TextBox ID="TxtApellido" class="controls" aria-label="Apellido" runat="server"></asp:TextBox>
                <label for="TxtEmail">Email</label>


                <asp:TextBox ID="TxtEmail" CssClass="controls" type="Mail" aria-label="Email" runat="server" />
                <asp:Button ID="BtnAceptar" Text="GUARDAR CAMBIOS" OnClick="BtnAceptar_Click" runat="server" CssClass="btn btn-primary" />
                <asp:Button ID="BtnCancelar" Text="CANCELAR" OnClick="BtnCancelar_Click" runat="server" CssClass="btn btn-success" />

            </div>
        </div>
</body>
</html>


</asp:Content>
