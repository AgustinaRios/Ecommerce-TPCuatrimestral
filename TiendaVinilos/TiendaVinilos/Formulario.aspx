<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="TiendaVinilos.Formulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>


<body>
    
        <div class="CuerpoRegistro">
            <div class="FormularioRegistro">
                <asp:Label ID="Lbltitlulo" runat="server" Text="Label"></asp:Label>
                <div>

                    <label for="TxtTitulo">Titulo</label>
                    <asp:TextBox ID="TxtTitulo" runat="server" type="text" placeholder="Ingrese Titulo" class="controls"></asp:TextBox>
                    <label for="TxtArtista">Artista</label>
                    <asp:TextBox ID="TxtArtista" class="controls" type="text" aria-label="Apellido" runat="server"></asp:TextBox>
                    <label for="TxtFechaLanza">Fecha Lanzamiento</label>
                    <asp:TextBox ID="TxtFechaLanza" class="form-control" type="date" runat="server"></asp:TextBox>
                    <label for="TxtImgTapa">Imagen Tapa</label>
                    <asp:TextBox ID="TxtImgTapa" class="controls" type="text" placeholder="Ingrese url imagen tapa" runat="server"></asp:TextBox>
                    <label for="TxtImgContraTapa">Imagen Contratapa</label>
                    <asp:TextBox ID="TxtImgContraTapa" class="controls" type="text" placeholder="Ingrese url imagen Contratapa" runat="server"></asp:TextBox>
                    <label for="TxtPrecio">Precio</label>
                    <asp:RangeValidator ID="rvclass" runat="server" ControlToValidate="TxtPrecio"
                        ErrorMessage="Solo numero positivos" MaximumValue="10000"
                        MinimumValue="1" Type="Double">
                    </asp:RangeValidator>
                    <asp:TextBox ID="TxtPrecio" class="controls" type="text" placeholder="Ingrese Precio" runat="server" Text="1"></asp:TextBox>


                    <label for="ddlGenero">Genero</label>
                    <asp:DropDownList runat="server" ID="ddlGenero" CssClass="form-control-sm">
                    </asp:DropDownList>
                    <div>
                        <label for="ddlCategoria">Categoria</label>

                        <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-control-sm">
                        </asp:DropDownList>
                    </div>


                </div>

                <updatepanel>
                    <contentemplate>
                        <br />

                       <asp:Button ID="BtnAceptar" Text="Aceptar" OnClick="BtnAceptar_Click" runat="server" CssClass="btn btn-primary" ToolTip="Click para loguerte" />
                        <asp:Button Text="Cancelar" CssClass="btn btn-outline-info" ID="btnCancelar" AutoPostBack="true" OnClick="btnCancelar_Click" runat="server" />
                        <div>
                            <asp:Label ID="LblMensaje" runat="server" Visible="false"></asp:Label>
                        </div>
            </div>
        </div>
  
</body>
</html>

</asp:Content>
