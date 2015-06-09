<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionCategorias.aspx.cs" Inherits="SistemaFacturacion.GestionCategorias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:EntityDataSource ID="CategoriasDataSource" runat="server" AutoSort="False" ConnectionString="name=FACTURACIONEntities" DefaultContainerName="FACTURACIONEntities" EnableFlattening="False" EntitySetName="CATEGORIA" EntityTypeFilter="CATEGORIA" OrderBy="" Select="it.[id], it.[descripcion], it.[estado]">
        </asp:EntityDataSource>
        <asp:GridView ID="gvCategorias" AutoGenerateColumns="true" runat="server" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1">           
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
