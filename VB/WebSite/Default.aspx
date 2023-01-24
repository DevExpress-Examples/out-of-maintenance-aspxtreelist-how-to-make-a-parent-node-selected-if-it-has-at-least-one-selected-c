﻿<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title> How to select a parent node if it has at least one child node selected</title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<dx:ASPxTreeList ID="treeList" runat="server" KeyFieldName="EmployeeID" ParentFieldName="ReportsTo" DataSourceID="SqlDataSource1"
				OnDataBound="treeList_DataBound" OnSelectionChanged="treeList_SelectionChanged">
				<SettingsSelection Enabled="true" />
				<SettingsBehavior ProcessSelectionChangedOnServer="true" />
			</dx:ASPxTreeList>
		</div>
		<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyNorthwind %>"
			SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [Title], [TitleOfCourtesy], [City], [Address], [ReportsTo] FROM [Employees]"></asp:SqlDataSource>
	</form>
</body>
</html>