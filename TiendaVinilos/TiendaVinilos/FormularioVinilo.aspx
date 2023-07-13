<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioVinilo.aspx.cs" Inherits="TiendaVinilos.FormularioVinilo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


   <div class="ContenedorPrincipal">
              <div class="container-Formularios"style="width: 600px; height: 500px; margin-top: 20px">
                    <div class="row">
                   <asp:Label ID="Lbltitlulo" runat="server" ForeColor="White" Font-Size="Medium"></asp:Label>
                    </div>
                    <div class="col">
                    <div class="row">
                    <div class="col">
                    <asp:TextBox ID="TxtTitulo" runat="server" type="text" placeholder="Ingrese un Titulo" class="controls"></asp:TextBox>
                    </div>
                    <div class="col">
                     <asp:TextBox ID="TxtPrecio" class="controls" type="text" placeholder="Ingrese el Precio" runat="server"></asp:TextBox>
                    </div>
                    </div>
                    <div class="row">
                    <div class="col">                   
                    <asp:TextBox ID="TxtImgTapa" class="controls" type="text" placeholder="url  de la tapa" runat="server"></asp:TextBox>               
                    </div>
                    <div class="col">  
                    <asp:TextBox ID="TxtImgContraTapa" class="controls" type="text" placeholder="url de la  Contratapa" runat="server"></asp:TextBox>      
                    </div>
                    </div>
                    <div class="row"> 
                    <div class="col">  
                     <asp:TextBox ID="TxtFechaLanza" class ="controls" type="date"  runat="server" ></asp:TextBox> 
                     </div>
                    <div class="col">
                    <asp:Label ID="LblFecha" runat="server" Text="Fecha de Lanzamiento" ForeColor="White"></asp:Label>
                    </div>
                    </div>

                    <div class="row">
                    <div class="col">
                    <asp:DropDownList runat="server" ID="ddlArtista" class="controls" AutoPostBack="true" />
                    </div>
                    <div class="col">
                    <asp:Button ID="btnAgregarArtista" runat="server" OnClick="btnAgregarArtista_Click" Text="+" CssClass="btn btn-primary"/>  
                    <asp:Label Text="Agregar un Artista Nuevo" runat="server" ForeColor="White" Font-Size="Small"></asp:Label>
                    </div>
                    </div> 
                    <div class="row">
                    <div class="col">
                    <asp:DropDownList runat="server" ID="ddlGenero" CssClass="controls" AutoPostBack="true" />
                    </div>
                    <div class="col">
                     <asp:Button ID="btnAgregarGero" runat="server" OnClick="btnAgregarGenero_Click" Text="+" CssClass="btn btn-primary"/>
                     <asp:Label Text="Agregar un Genero Nuevo" runat="server" ForeColor="White" Font-Size="Small"></asp:Label>
                    </div>
                     </div>
                    <div class="row">
                    <div class="col">
                    <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="controls"/>
                    </div>
                    <div class="col">
                    <asp:Button ID="btnAgregarCategoria" runat="server" OnClick="btnAgregarCategoria_Click" Text="+" CssClass="btn btn-primary"/>
                    <asp:Label Text="Agregar una Categoria Nueva" runat="server" ForeColor="White" Font-Size="Small"></asp:Label>
                    </div>
                    <div class="row">
                    <div class="col">
                    <asp:Button ID="BtnAceptar" Text="Aceptar" OnClick="BtnAceptar_Click" runat="server" CssClass="btn btn-primary" ToolTip="Click para loguerte" />
                   </div>
                   <div class="col">
                    <asp:Button Text="Cancelar" CssClass="btn btn-danger" ID="btnCancelar" AutoPostBack="true" OnClick="btnCancelar_Click" runat="server" />
                   </div>
                   </div>
                    <asp:Label ID="LblMensaje" ForeColor="red" runat="server" Visible="false"></asp:Label>
                    <asp:RangeValidator ID="rvclass" runat="server" ControlToValidate="TxtPrecio"
                        ErrorMessage ="A surgido un error de carga , por favor corrobore los datos" MaximumValue="1000000"
                        MinimumValue="1" Type="Double" ForeColor="red">
                    </asp:RangeValidator>
      </div>
      </div>
    </div>
</div>

</asp:Content>
