<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AnalisisAlgoritmos.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        #centrar{
            width:70%;
            height:auto;
            margin: 10px auto;
        }
    </style>
</head>

<body>
    <div id="centrar">
        <form id="form1" runat="server">
            <asp:scriptmanager id="sm" runat="server"></asp:scriptmanager>
        <div>
            <label id="lbln" runat="server">Numero de enteros</label><br />
            <asp:DropDownList ID="ddlRango" runat="server"></asp:DropDownList><br />

            <label for="fuCarga" runat="server" id="lblCarga">Seleccione el archivo a cargar</label><br />
            <asp:fileupload runat="server" ID="fuCarga" ></asp:fileupload>&nbsp;&nbsp;&nbsp;
            <asp:Button runat="server" ID="btnCargar" Text="Cargar" OnClick="btnCargar_Click" />
        </div>
        <asp:validationsummary runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary>
        </form>
    </div>
</body>

</html>
