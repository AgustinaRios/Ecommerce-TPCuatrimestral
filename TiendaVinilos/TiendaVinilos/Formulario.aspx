﻿<%@ Page Title="Formulario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="TiendaVinilos.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="CuerpoRegistro">
        <div class="FormularioRegistro">
            <h4>
                <asp:Label ID="Lbltitlulo" runat="server" Text="Label"></asp:Label>

            </h4>
            <br />
            <h3>Titulo*</h3>
            <asp:TextBox ID="TxtTitulo" class="form-control" type="text" placeholder="Ingrese Titulo" runat="server"></asp:TextBox>
            <h3>Artista*</h3>
            <asp:TextBox ID="TxtArtista" class="form-control" type="text" placeholder="Ingrese Artista" runat="server"></asp:TextBox>
            <%//si chk se activa se pone en enable la lista de artistas y se activa el txtartistanuevo o btn nuevo artista pensarlo... %>
            <h3>Fecha Lanzamiento*</h3>
            <asp:TextBox ID="TxtFechaLanza" class="form-control" type="date" runat="server"></asp:TextBox>
            <h3>Imagen Tapa*</h3>
            <asp:TextBox ID="TxtImgTapa" class="form-control" type="text" placeholder="Ingrese url imagen tapa" runat="server"></asp:TextBox>
            <h3>Imagen ContraTapa*</h3>
            <asp:TextBox ID="TxtImgContraTapa" class="form-control" type="text" placeholder="Ingrese url imagen Contratapa" runat="server"></asp:TextBox>
            <h3>Precio*</h3>
            <asp:RangeValidator ID="rvclass" runat="server" ControlToValidate="TxtPrecio" 
            ErrorMessage="Solo numero positivos" MaximumValue="10000" 
            MinimumValue="1" Type="Double">
            </asp:RangeValidator>
            <asp:TextBox ID="TxtPrecio" class="form-control" type="text" placeholder="Ingrese Precio" runat="server" Text="1"></asp:TextBox>
            <h5>Campos Obligatorios(*)</h5>


            <h3>Genero</h3>
            <asp:DropDownList runat="server" ID="ddlGenero" CssClass="form-control-sm">
            </asp:DropDownList>

            <h3>Categoria</h3>
            <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-control-sm">
            </asp:DropDownList>


            <updatepanel>
                <contentemplate>
                    <br />
                    <div class="row justify-content-evenly">
                        <div class="col-4">
                            <asp:Button ID="BtnAceptar" Text="Aceptar" OnClick="BtnAceptar_Click" CssClass="btn btn-primary" runat="server" ToolTip="click para agregar un vinilo" />
                        </div>
                        <div class="col-4">
                            <asp:Button Text="Cancelar" CssClass="btn btn-danger" ID="btnCancelar" AutoPostBack="true" OnClick="btnCancelar_Click" runat="server" />
                        </div>
                    </div>
                    <br />
                    <asp:Label ID="LblMensaje" runat="server" Visible="false"></asp:Label>

                </contentemplate>
            </updatepanel>


        </div>
</asp:Content>
