<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarUsuarios.aspx.cs" Inherits="TiendaVinilos.ListarUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="CuerpoRegistro">
  
    <table class="table table-hover">
        <thead >
            <tr>
                <th scope="col">Nombre</th>
                <th scope="col">Apellido</th>
                <th scope="col">Email</th>
                <th scope="col">Fecha Creación</th>
                <th scope="col">Estado</th>
                <th ><svg xmlns="http://www.w3.org/2000/svg" height="2em" flood-color="red"  viewBox="0 0 640 512"><!--! Font Awesome Free 6.4.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. --><path d="M96 128a128 128 0 1 1 256 0A128 128 0 1 1 96 128zM0 482.3C0 383.8 79.8 304 178.3 304h91.4C368.2 304 448 383.8 448 482.3c0 16.4-13.3 29.7-29.7 29.7H29.7C13.3 512 0 498.7 0 482.3zM471 143c9.4-9.4 24.6-9.4 33.9 0l47 47 47-47c9.4-9.4 24.6-9.4 33.9 0s9.4 24.6 0 33.9l-47 47 47 47c9.4 9.4 9.4 24.6 0 33.9s-24.6 9.4-33.9 0l-47-47-47 47c-9.4 9.4-24.6 9.4-33.9 0s-9.4-24.6 0-33.9l47-47-47-47c-9.4-9.4-9.4-24.6 0-33.9z"/></svg></th>
                <th scope="col">Estado</th>
            </tr>
             <tr>
             <asp:Button ID="BtnAlta" runat="server" Text="Nuevo Usuario" CssClass="btn btn-outline-success" type="submit" OnClick="BtnAlta_Click" />
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
            </div>
</asp:Content>
