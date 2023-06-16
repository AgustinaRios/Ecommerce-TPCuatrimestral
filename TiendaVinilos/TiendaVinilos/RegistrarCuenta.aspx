<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarCuenta.aspx.cs" Inherits="TiendaVinilos.RegistrarCuenta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <div class="bodyformulario">
      <div class="formulario">
      <h4>Formulario Registro</h4>
      <asp:TextBox ID="TxtNombre" class="controls" type="text" placeholder="Ingrese su Nombre"  aria-label="Ingrese Nombre" runat="server" ></asp:TextBox>
      <asp:TextBox ID="TxtApellido" class="controls" type="text" placeholder="Ingrese su Apellido" aria-label="Ingrese Nombre" runat="server" ></asp:TextBox>
      <asp:TextBox ID="TxtEmail" class="controls" type="email"  placeholder="Ingrese su Email" aria-label="Ingrese Nombre" runat="server" ></asp:TextBox>
      <asp:TextBox ID="TxtPass" class="controls" MaxLength="8" type="password" placeholder="Ingrese su Contraseña 8 caracteres max" aria-label="Ingrese Nombre" runat="server"></asp:TextBox>
      
    <p>Estoy de acuerdo con <a href="#">Terminos y Condiciones</a></p>
    <asp:Button ID="BtnAgregar" Text="Registrar" runat="server" />

    <p><a href="Login.aspx">¿Ya tengo Cuenta?</a></p>
         </div>
        </div>
    </form>
</body>
</html>
