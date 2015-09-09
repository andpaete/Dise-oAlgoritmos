<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformeResultados.aspx.cs" Inherits="AnalisisAlgoritmos.Resultados.InformeResultados" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="548px" ProcessingMode="Remote" Width="870px" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <ServerReport ReportPath="/Algoritmos/Reporte" ReportServerUrl="http://desarrollo10/ReportServer_MSSQL2012" />
        </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
