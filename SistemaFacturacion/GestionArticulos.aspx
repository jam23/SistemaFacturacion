<%@ Page Theme="Estado" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GestionArticulos.aspx.cs" Inherits="SistemaFacturacion.GestionArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%Page.Header.Title = "Gestión de Articulos"; %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-6">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>
                <asp:TextBox ID="txtId" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
        <%--    </div>
    <div class="row">--%>
        <div class="col-lg-6">
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Descripción"></asp:Label>
                <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6">
            <div class="form-group">
                <asp:Label ID="Label6" runat="server" Text="Costo Unitario"></asp:Label>
                <asp:TextBox ID="txtCostoUnitario" runat="server"></asp:TextBox>
            </div>
        </div>

        <%--    </div>
    <div class="row">--%>
        <div class="col-lg-6">
            <div class="form-group">
                <asp:Label ID="Label7" runat="server" Text="Precio Unitario"></asp:Label>
                <asp:TextBox ID="txtPrecioUnitario" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6">
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Stock"></asp:Label>
                <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
            </div>
        </div>
        <%--    </div>
      <div class="row">--%>
        <div class="col-lg-6">
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Estado"></asp:Label>
                <asp:DropDownList ID="ddlEstado" SkinID="ddlEstado" runat="server"></asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6">
            <div class="form-group">
                <asp:Label ID="Label8" runat="server" Text="Categoria"></asp:Label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6">
            <div class="form-group">
                <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-primary" OnClick="btnCrear_Click" />
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" Enabled="false" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" Enabled="false" OnClick="btnEliminar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-warning" OnClick="btnCancelar_Click" />
            </div>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-body">
            <asp:GridView ID="gvArticulos" runat="server" AutoGenerateColumns="False"
                CssClass="table table-striped table-bordered table-hover dataTable no-footer">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:LinkButton ID="lkbId" runat="server" Text='<%# Bind("id") %>' OnClick="lkbId_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                    <asp:BoundField DataField="idCategoria" HeaderText="Categoria" />
                    <asp:BoundField DataField="costoUnitario" HeaderText="Costo Unitario" />
                    <asp:BoundField DataField="precioUnitario" HeaderText="Precio Unitario" />
                    <asp:BoundField DataField="stock" HeaderText="Stock" />
                    <asp:BoundField DataField="estado" HeaderText="Estado" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
