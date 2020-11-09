<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UI.Web.Home" %>
<%@ Register Src="~/WebUserControl1.ascx" TagPrefix="uc1" TagName="Home1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <uc1:Home1 runat="server" id="Home1"/> 
</asp:Content>
