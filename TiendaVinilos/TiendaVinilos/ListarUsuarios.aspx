<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarUsuarios.aspx.cs" Inherits="TiendaVinilos.ListarUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table">
        <thead class="thead-dark">
            <tr>
                <th scope="col">Nombre</th>
                <th scope="col">Apellido</th>
                <th scope="col">Email</th>
                <th scope="col">Fecha Creación</th>
                 <th scope="col">Activo</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Nombre") %></td>
                        <td><%# Eval("Apellido") %></td>
                         <td><%# Eval("Email") %></td>
                        <td><%# Eval("FechaCreacion") %></td>
                        <td><%# Eval("Activo")%></td>
                                                <td> 

                          <asp:Button Text="Desactivar" Cssclass="btn btn-danger" ID="btnEliminar" OnClientClick="return confirm('Esta seguro de que quiere dejar INACTIVO a este usuario ?');" OnClick="btnEliminar_Click" runat="server" CommandName="UsuarioId" CommandArgument='<%# Eval("Id")%> '/>  
                          <asp:Button Text="Activar" Cssclass="btn btn-success" ID="btnActivar" OnClientClick="return confirm('Esta seguro de quiere ACTIVAR a este usuario?');" OnClick="BtnActivar_Click" runat="server" CommandName="UsuarioId" CommandArgument='<%# Eval("Id")%> '/>  
                       </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <asp:Label ID="lblMensaje" runat="server" CssClass="message" Visible="false"></asp:Label>
</asp:Content>
