<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteTiempoCpu.aspx.cs" Inherits="AnalisisAlgoritmos.ReporteTiempoCpu" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    hola
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="619px" Width="612px" Font-Names="Verdana" Font-Size="8pt" ProcessingMode="Remote" style="margin-right: 0px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <ServerReport ReportServerUrl="http://apaez/Reports_SVRDB01/Pages/Folder.aspx" />
        </rsweb:ReportViewer>
 
    </div>
    </form>
</body>
</html>
