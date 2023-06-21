<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarUsuarios.aspx.cs" Inherits="TiendaVinilos.ListarUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <table class="table">
        <thead class="thead-dark">
            <tr>
                 
                <th scope="col" for="txtId">Id</th>
                <th scope="col" for="txtTitulo">UserName</th>
                <th scope="col"> Pass</th>
                <th scope="col">FechaCreacion</th>
                
            </tr>
            <tr>
             <asp:Button ID="BtnAlta" runat="server" Text="Nuevo Vinilo" CssClass="btn btn-outline-success" type="submit" OnClick="BtnAlta_Click" />
             </tr>
        </thead>
        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <tbody>
                    <tr>

                        
                     
                   </tr>
                </tbody>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <asp:Label ID="lblMensaje" runat="server" CssClass="message" Visible="false"></asp:Label>

        
</asp:Content>
