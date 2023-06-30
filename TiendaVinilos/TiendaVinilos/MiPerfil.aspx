<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TiendaVinilos.MiPerfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Estilos.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
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
    </form>
</body>
</html>

