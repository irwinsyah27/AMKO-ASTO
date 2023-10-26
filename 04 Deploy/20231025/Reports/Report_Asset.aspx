<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report_Asset.aspx.cs" Inherits="AMKO.Reports.ReportAsset" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SMIS</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="Report_AssetViewer" runat="server" Font-Names="Verdana"
                Font-Size="8pt" Height="100%" InteractiveDeviceInfos="(Collection)" PageCountMode="Actual"
                ProcessingMode="Remote" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" 
                ShowPromptAreaButton="false" PromptAreaCollapsed="true" Width="100%" CssClass="panelReport">
            </rsweb:ReportViewer> 
        </div>
    </form>
</body>
</html>
