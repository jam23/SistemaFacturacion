<%@ Page Theme="Estado" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GestionVendedores.aspx.cs" Inherits="SistemaFacturacion.Vendedores.GestionVendedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%Page.Header.Title = "Gestión de Vendedores"; %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-6">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>
                <asp:TextBox ID="txtId" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
        <div class="col-lg-6">
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Nombres"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6">
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Apellido 1"></asp:Label>
                <asp:TextBox ID="txtApellido1" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-lg-6">
            <div class="form-group">
                <asp:Label ID="Label5" runat="server" Text="Apellido 2"></asp:Label>
                <asp:TextBox ID="txtApellido2" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6">
            <div class="form-group">
                <asp:Label ID="Label6" runat="server" Text="Porcentaje Comisión"></asp:Label>
                <asp:TextBox ID="txtPorcentajeComision" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-lg-6">
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Estado"></asp:Label>
                <asp:DropDownList runat="server" ID="ddlEstado" SkinID="ddlEstado">
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6">
            <div class="form-group">
                <asp:Label ID="Label7" runat="server" Text="Nombre de Usuario"></asp:Label>
                <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-lg-6">
            <div class="form-group">
                <asp:Label ID="Label8" runat="server" Text="Contraseña"></asp:Label>
                <asp:TextBox ID="txtContraseña" runat="server" ReadOnly="true"></asp:TextBox>
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
            <asp:GridView ID="gvCategorias" runat="server"
                CssClass="table table-striped table-bordered table-hover dataTable no-footer" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Id">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lkb_Id" Text='<%#Bind("id")%>' OnClick="lkbId_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="nombres" HeaderText="Nombres" />
                    <asp:BoundField DataField="apellido" HeaderText="Apellidos" />
                    <asp:BoundField DataField="porcientoComision" HeaderText="Porcentaje Comisión" />
                    <asp:BoundField DataField="cantidadFacturas" HeaderText="Cantidad de Facturas" />
                    <asp:BoundField DataField="nombreUsuario" HeaderText="Nombre de Usuario" />
                    <asp:BoundField DataField="contraseña" HeaderText="Constraseña" />
                    <asp:BoundField DataField="estado" HeaderText="Estado" />

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
