﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarCuenta.aspx.cs" Inherits="TiendaVinilos.RegistrarCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="CuerpoRegistro">


        <div class="CuerpoRegistro">
            <div class="FormularioRegistro">
                <h4>Formulario Registro</h4>

                <asp:TextBox ID="TxtNombre" class="controls" type="text" placeholder="Ingrese su Nombre" aria-label="Ingrese Nombre" runat="server"></asp:TextBox>
                <asp:TextBox ID="TxtApellido" class="controls" type="text" placeholder="Ingrese su Apellido" aria-label="Ingrese Nombre" runat="server"></asp:TextBox>
                <asp:TextBox ID="TxtEmail" class="controls" type="email" placeholder="Ingrese su Email" aria-label="Ingrese Nombre" runat="server"></asp:TextBox>
                <asp:TextBox ID="TxtDireccion" class="controls" type="text" placeholder="Ingrese su Direccion" aria-label="Ingrese Direccion" runat="server"></asp:TextBox>
                <div class="form-inline">
                    <asp:TextBox ID="TxtLocalidad" class="controls" type="text" placeholder="Ingrese su Localidad" aria-label="Ingrese Localidad" runat="server"></asp:TextBox>
                    <asp:TextBox ID="TxtProvincia" class="controls" type="text" placeholder="Ingrese su Provincia" aria-label="Ingrese Provincia" runat="server"></asp:TextBox>
                </div>
              
                <asp:TextBox ID="TxtPass" class="controls" MaxLength="8" type="password" placeholder="Ingrese su Contraseña 6 caracteres max" aria-label="Ingrese Nombre" runat="server"></asp:TextBox>
                <asp:Button ID="BtnAgregar" OnClick="BtnAgregar_Click" Text="Registrar" CssClass="btn btn-primary" runat="server" ToolTip="Click para darse de alta" />
                <asp:Button Text="Cancelar" CssClass="btn btn-danger" ID="btnCancelar" AutoPostBack="true" OnClick="btnCancelar_Click" runat="server" />
                <div>

                    <asp:Label ID="LblMensaje" runat="server" Visible="false"></asp:Label>
                </div>
                <p><a href="Login.aspx">¿Ya tengo Cuenta?</a></p>
            </div>
        </div>

    </div>


</asp:Content>
