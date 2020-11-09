<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportePlanesViewer.aspx.cs" Inherits="UI.Web.ReportePlanesViewer" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    
    <a href="ReportePlanesViewer.aspx">ReportePlanesViewer.aspx</a><CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" 
        Height="1202px" ReportSourceID="CrystalReportSource1" ToolbarImagesFolderUrl="" 
        ToolPanelWidth="200px" Width="1104px" />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="C:\Users\Gianluca\source\repos\genexyz\Tp2GrupoPagVanSam\Util\ReportePlanes.rpt">
        </Report>
    </CR:CrystalReportSource>
    
</asp:Content>
