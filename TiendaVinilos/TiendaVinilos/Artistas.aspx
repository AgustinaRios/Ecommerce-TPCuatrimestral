<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Artistas.aspx.cs" Inherits="TiendaVinilos.Artistas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <div class="CuerpoRegistro">    
    <style>
        .table {
            width: 100%;
        }

        .table th,
        .table td {
            text-align: left;
            vertical-align: top;
            padding: 8px;
        }

        .table .btn {
            padding: 4px 8px;
            font-size: 14px;
        }
    </style>
        <div class="btn-add-new-container">
        <asp:Button Text=" Nuevo Artista" CssClass="btn btn-outline-success" ID="btnAgregarNuevo" OnClick="btnAgregarNuevo_Click" runat="server" />
    </div>

    <table class="table">
        <thead class="thead-dark">
             
            <tr>
                <th scope="col">Id</th>
                <th scope="col">Nombre</th>
                <th scope="col">Activo</th>
                <th scope="col">Acciones</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Id") %></td>
                        <td><%# Eval("Nombre") %></td>
                        <td><%# Eval("Activo") %></td>
                        <td>
                            <asp:Button Text="Desactivar" CssClass="btn btn-danger" ID="btnEliminar" OnClientClick="return confirm('¿Está seguro de que quiere dejar INACTIVO a este usuario?');" OnClick="btnEliminar_Click" runat="server" CommandName="UsuarioId" CommandArgument='<%# Eval("Id") %>' />
                            <asp:Button Text="Activar" CssClass="btn btn-success" ID="btnActivar" OnClientClick="return confirm('¿Está seguro de que quiere ACTIVAR a este usuario?');" OnClick="btnActivar_Click" runat="server" CommandName="UsuarioId" CommandArgument='<%# Eval("Id") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <asp:Label ID="lblMensaje" runat="server" CssClass="message" Visible="false"></asp:Label>
     </div>
</asp:Content>






