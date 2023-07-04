<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioVinilo.aspx.cs" Inherits="TiendaVinilos.FormularioVinilo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="CuerpoRegistro">

        <div class="FormularioRegistro ">
            <asp:Label ID="Lbltitlulo" runat="server" Font-Size="Smaller"></asp:Label>
            <div>

                <asp:TextBox ID="TxtTitulo" runat="server" type="text" placeholder="Ingrese un Titulo" class="controls"></asp:TextBox>
                <asp:DropDownList runat="server" ID="ddlArtista" class="form-control" AutoPostBack="true" />

                <div class="form-inline">
                    <asp:TextBox ID="TxtImgTapa" class="controls" type="text" placeholder="url de la imagen de la tapa" runat="server"></asp:TextBox>
                    <asp:TextBox ID="TxtImgContraTapa" class="controls" type="text" placeholder="url de la imagen de la Contratapa" runat="server"></asp:TextBox>
                </div>
                <asp:TextBox ID="TxtPrecio" class="controls" type="text" placeholder="Ingrese el Precio" runat="server"></asp:TextBox>
                <asp:Label ID="LblFecha" runat="server" Text="Lanzamiento" Font-Size="Small"></asp:Label>
                <asp:TextBox ID="TxtFechaLanza" class="form-control" type="date" runat="server"></asp:TextBox>
                <div class="form-inline">
                    <asp:DropDownList runat="server" ID="ddlGenero" CssClass="form-control">
                    </asp:DropDownList>

                    <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-control">
                    </asp:DropDownList>
                </div>
            </div>

            <updatepanel>
                <contentemplate>
                    <br />

                    <asp:Button ID="BtnAceptar" Text="Aceptar" OnClick="BtnAceptar_Click" runat="server" CssClass="btn btn-primary" ToolTip="Click para loguerte" />
                    <asp:Button Text="Cancelar" CssClass="btn btn-danger" ID="btnCancelar" AutoPostBack="true" OnClick="btnCancelar_Click" runat="server" />
                    <div>
                        <asp:Label ID="LblMensaje" runat="server" Visible="false"></asp:Label>
                    </div>
                    <asp:RangeValidator ID="rvclass" runat="server" ControlToValidate="TxtPrecio"
                        ErrorMessage="Solo numero positivos" MaximumValue="10000"
                        MinimumValue="1" Type="Double">
                    </asp:RangeValidator>
        </div>
    </div>



</asp:Content>
