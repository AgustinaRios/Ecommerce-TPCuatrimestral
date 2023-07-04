<%@ Page Title="Tienda de Vinilos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="TiendaVinilos.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align: center; margin-top: 50px; padding: 20px;
        background-image: url('https://cdn.pixabay.com/photo/2015/12/27/05/48/turntable-1109588_1280.jpg');
        background-repeat: no-repeat;
        background-size: cover;
        color: #fff;
        text-shadow: 1px 1px 2px rgba(0, 0, 0, 0.7);">
        <h2 style="font-size: 28px; color: #fff; margin-bottom: 10px;"><%: Title%>.</h2>
        <h3 style="font-size: 22px; margin-top: 20px; color: #fff;">Contactate con nosotros.</h3>
        <div style="margin-top: 30px;">
            <p style="font-size: 18px; color: #fff;">Lunes a Sábados 9 a 20 hs</p>
            <p style="font-size: 18px; color: #fff;">Santo Tomé 4749, Monte Castro, CABA, CP 1417</p>
            <p style="font-size: 18px; color: #fff;"><abbr title="Phone" style="font-weight: bold;">Whatsapp</abbr>: 11-6183-5128</p>
        </div>
        <div style="margin-top: 30px;">
            <address>
                <strong style="font-size: 18px; color: #fff;">Support:</strong> <a href="mailto:Support@example.com" style="font-size: 18px; color: #fff;">Support@example.com</a><br />
                <strong style="font-size: 18px; color: #fff;">Marketing:</strong> <a href="mailto:Marketing@example.com" style="font-size: 18px; color: #fff;">Marketing@example.com</a>
            </address>
        </div>
    </div>
</asp:Content>
