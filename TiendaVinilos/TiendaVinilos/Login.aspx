<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TiendaVinilos.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     
      <div class="ContenedorPrincipal">
        <div class="container-Formularios">
             <div class="col-12">
                <h4 style="color: #FFFFFF">INGRESE SU CUENTA</h4>
                <label for="exampleFormControlInput1" class="form-label">Email</label>
                <asp:TextBox ID="TxtEmail" CssClass="form-control form-control-lg" type="Mail"  runat="server"></asp:TextBox>
                <label for="exampleFormControlInput1" class="form-label">Password</label>
                <asp:TextBox ID="TxtPass" CssClass="form-control form-control-lg" type="password"   runat="server"></asp:TextBox>
                <div id="passwordHelpBlock" class="form-text">
                Tu password deber ser entre 8 y 20 caracteres.
               </div>
                </div>
               <div class="row">
               <div class="col">
                <asp:Button ID="BtnAceptar" Text="Entrar" OnClick="BtnAceptar_Click" runat="server" CssClass="btn btn-primary" ToolTip="Click para loguerte" />
                </div>
                <div class="col">
                <asp:Button Text="Cancelar" CssClass="btn btn-danger" ID="btnCancelar" AutoPostBack="true" OnClick="btnCancelar_Click" runat="server" />
                </div>
                </div>
                <p><a href="RegistrarCuenta.aspx" aria-describedby="cxcxxcxc">Registrarme</a></p>
            </div>
        </div>




</asp:Content>
