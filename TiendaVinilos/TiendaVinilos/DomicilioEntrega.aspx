<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DomicilioEntrega.aspx.cs" Inherits="TiendaVinilos.Domicilio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ContenedorPrincipal" >
        <div class="container-Formularios"style="width: 600px; height: 400px; margin-top: 20px">
               <h4 style="color: #FFFFFF">Domicilio</h4>
                <div class="row"> 
                <div class="col">
                <label for="TxtDireccion">Direccion</label>
                </div>
                <div class="col">
                <asp:TextBox ID="TxtDireccion" runat="server" class="controls"></asp:TextBox>
                </div>
                </div>
                <div class="row"> 
                <div class="col">
                <label for="TxtLocalidad">Localidad</label>
                </div>
                <div class="col"> 
                <asp:TextBox ID="TxtLocalidad" runat="server" class="controls"></asp:TextBox>
                </div>
                </div>
                <div class="row"> 
                <div class="col">
                <label for="TxtProvincia">Provincia</label>
                </div> 
                <div class="col">
                <asp:TextBox ID="TxtProvincia" runat="server" class="controls"></asp:TextBox>
                </div>
                </div>
               
                <div class="row"> 
                <div class="col">
            <asp:Button ID="BtnAceptar" Text="Cambiar el domicilio " OnClick="BtnAceptar_Click" runat="server" CssClass="btn btn-primary" />
                </div>
                <div class="col">
            <asp:Button ID="BtnCancelar" Text="CANCELAR" OnClick="BtnCancelar_Click" runat="server" CssClass="btn btn-danger" />
                 </div>
                 <asp:Label ID="LblMensaje" ForeColor="red" runat="server" Visible="false"></asp:Label>
                </div>    
            </div>
       </div>
</asp:Content>
