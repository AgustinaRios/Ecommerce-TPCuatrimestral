<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TiendaVinilos.MiPerfil" %>

<asp:Content ID="MiPerfil" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4 mb-4 p-3 d-flex justify-content-center">
        <div class="card p-4">
            
                
                <h3>Nombre</h3>
                <asp:TextBox ID="TxtNombre" class="form-control" type="text" runat="server"></asp:TextBox>
                <h3>Apellido</h3>
                <asp:TextBox ID="TxtApellido" class="form-control" type="text" runat="server"></asp:TextBox>
                <h3>Correo</h3>
                <asp:TextBox ID="TxtEmail" class="form-control" type="mail" runat="server"></asp:TextBox>


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
    </div>



</asp:Content>
