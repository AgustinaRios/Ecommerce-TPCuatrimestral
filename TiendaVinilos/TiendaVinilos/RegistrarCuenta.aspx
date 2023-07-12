<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarCuenta.aspx.cs" Inherits="TiendaVinilos.RegistrarCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <div class="ContenedorPrincipal">
        <div class="container-Formularios"style="width: 600px; height: 400px; margin-top: 66px">
                <h4 style="color: #FFFFFF">Formulario Registro</h4>
             <div class="row"> 
               <div class="col">
                <asp:TextBox ID="TxtNombre" CssClass="controls" type="text" placeholder="Ingrese su Nombre"  runat="server"></asp:TextBox>
                </div>
                <div class="col">
                <asp:TextBox ID="TxtApellido" class="controls" type="text" placeholder="Ingrese su Apellido" aria-label="Ingrese Nombre" runat="server"></asp:TextBox>
                </div>
                 </div>
              <div class="row"> 
               <div class="col">
                <asp:TextBox ID="TxtDireccion" class="controls" type="text" placeholder="Ingrese su Direccion" aria-label="Ingrese Direccion" runat="server"></asp:TextBox>
                </div>
               <div class="col">
                <asp:TextBox ID="TxtLocalidad" class="controls" type="text" placeholder="Ingrese su Localidad" aria-label="Ingrese Localidad" runat="server"></asp:TextBox>
                </div>
                 </div>
               <div class="row"> 
               <div class="col">
                <asp:TextBox ID="TxtProvincia" class="controls" type="text" placeholder="Ingrese su Provincia" aria-label="Ingrese Provincia" runat="server"></asp:TextBox>
                </div>
               <div class="col">
                <asp:TextBox ID="TxtPais" Visible="false" class="controls" type="text" placeholder="Ingrese su Pais" aria-label="Ingrese Pais" ReadOnly="true" runat="server"></asp:TextBox>
               </div>
                 </div>
               <div class="row"> 
               <div class="col">
                <asp:TextBox ID="TxtEmail" class="controls" type="email" placeholder="Ingrese su Email" aria-label="Ingrese Nombre" runat="server"></asp:TextBox>
              </div>
               <div class="col">
                   <asp:TextBox ID="TxtPass" class="controls" MaxLength="8"  type="password" placeholder=" Entre 3 y 8 caracteres." aria-label="Ingrese Nombre" runat="server"></asp:TextBox>
                </div>
                    </div>
                
               <div class="row"> 
               <div class="col">
                <asp:Button ID="BtnAgregar" OnClick="BtnAgregar_Click" Text="Registrar" CssClass="btn btn-primary" runat="server" ToolTip="Click para darse de alta" />
                </div>
                <div class="col">
               <p><a href="Login.aspx">¿Ya tengo Cuenta?</a></p>
               </div>
               <div class="col">
               <asp:Button Text="Cancelar" CssClass="btn btn-danger" ID="btnCancelar" AutoPostBack="true" OnClick="btnCancelar_Click" runat="server" />
               </div>
                <asp:Label ID="LblMensaje" ForeColor="red" runat="server" Visible="false"></asp:Label>
               
                </div>
            </div>
        </div>



</asp:Content>
