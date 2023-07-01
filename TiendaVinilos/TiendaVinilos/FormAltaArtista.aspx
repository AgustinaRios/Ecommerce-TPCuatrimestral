<%@ Page Title="Formulario" Language="C#" AutoEventWireup="true" CodeBehind="FormAltaArtista.aspx.cs" Inherits="TiendaVinilos.FormAltaArtista" %>

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
                <asp:Label ID="Lbltitlulo" runat="server" Text="Nuevo Artista"></asp:Label>
                <div>

                    <label for="TxtNombre">Nombre</label>
                    <asp:TextBox ID="TxtNombre" runat="server" type="text" placeholder="Ingrese Nombre" class="controls"></asp:TextBox>
                   

                   


                </div>

                <updatepanel>
                    <contentemplate>
                        <br />

                       <asp:Button ID="BtnAceptar" Text="Aceptar" OnClick="BtnAceptar_Click" runat="server" CssClass="btn btn-primary" ToolTip="Click para loguerte" />
                        <asp:Button Text="Cancelar" CssClass="btn btn-outline-info" ID="btnCancelar" AutoPostBack="true" OnClick="btnCancelar_Click" runat="server" />
                        <div>
                            <asp:Label ID="LblMensaje" runat="server" Visible="false"></asp:Label>
                        </div>
            </div>
        </div>
    </form>
</body>
</html>
