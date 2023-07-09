<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TiendaVinilos.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="ContenedorPrincipal">
        <div class="container-Formularios" style="width: 564px; height: 483px">
           <h4 style="color: #FFFFFF">Mi Perfil</h4>
                <div class="row"> 
                <div class="col">
                <asp:Label runat="server" Text="Nombre" ForeColor="White" Font-Size="Medium" ></asp:Label>
                </div>
                <div class="col">
                <asp:TextBox ID="TxtNombre" runat="server" class="controls"></asp:TextBox>
                </div>
                </div>
                <div class="row"> 
                <div class="col">
               <asp:Label runat="server" Text="Apellido" ForeColor="White" Font-Size="Medium" ></asp:Label>
                </div>
                <div class="col">
                <asp:TextBox ID="TxtApellido" class="controls" aria-label="Apellido" runat="server"></asp:TextBox>
                </div>
                </div>
                <div class="row"> 
                <div class="col">
                <asp:Label runat="server" Text="Email" ForeColor="White" Font-Size="Medium" ></asp:Label>
                </div>
                <div class="col">
                <asp:TextBox ID="TxtEmail" CssClass="controls" type="Mail" aria-label="Email" runat="server" />
                </div>
                </div>
                <div class="row"> 
                <div class="col">
                <asp:Label runat="server" Text="Direccion" ForeColor="White" Font-Size="Medium" ></asp:Label>
                </div>
                <div class="col">
                <asp:TextBox ID="TxtDireccion" runat="server" class="controls"></asp:TextBox>
                </div>
                </div>
                <div class="row"> 
                <div class="col">
                <asp:Label runat="server" Text="Localidad" ForeColor="White" Font-Size="Medium" ></asp:Label>
                </div>
                <div class="col">
                <asp:TextBox ID="TxtLocalidad" runat="server" class="controls"></asp:TextBox>
                </div>
                </div>
                <div class="row"> 
                <div class="col">
                <asp:Label runat="server" Text="Provincia" ForeColor="White" Font-Size="Medium" ></asp:Label>
                </div>
                <div class="col">
                <asp:TextBox ID="TxtProvincia" runat="server" class="controls"></asp:TextBox>
                </div>
                </div> 
                <div class="row"> 
                <div class="col">
                <asp:Button ID="BtnAceptar" Text="GUARDAR CAMBIOS" OnClick="BtnAceptar_Click" runat="server" CssClass="btn btn-primary" />
                </div>
                <div class="col">   
               <asp:Button ID="BtnCancelar" Text="CANCELAR" OnClick="BtnCancelar_Click" runat="server" CssClass="btn btn-danger" />
                 </div>
                </div> 
        </div>
  </div>

</asp:Content>
