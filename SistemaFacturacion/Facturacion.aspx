<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Facturacion.aspx.cs" Inherits="SistemaFacturacion.Facturacion.Facturacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%Page.Header.Title = "Facturación de Artículos"; %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-6">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>
                <asp:TextBox ID="txtId" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6">
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Condición de Pago"></asp:Label>
                <asp:DropDownList ID="ddlCondicionPago" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6">
            <div class="form-group">
                <asp:Label ID="Label6" runat="server" Text="Vendedor"></asp:Label>
                <asp:TextBox ID="txtVendedor" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="panel panel-default">
        <%--Cliente--%>
        <div class="panel-heading">
            Cliente
        </div>
        <div class="panel-body">
            <asp:Panel ID="pnlDatosCliente" runat="server" Visible="false">
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="Id"></asp:Label>
                            <asp:TextBox ID="TextBox3" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="Label8" runat="server" Text="Nombre Comercial"></asp:Label>
                            <asp:TextBox ID="txtNombreComercial" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="Label9" runat="server" Text="Razón Social"></asp:Label>
                            <asp:TextBox ID="txtRazonSocial" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="Label10" runat="server" Text="RNC/Cédula"></asp:Label>
                            <asp:TextBox ID="txtCedRNC" MaxLength="11" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="Label11" runat="server" Text="Cuenta Contable"></asp:Label>
                            <asp:TextBox ID="txtCuentaContable" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="Label12" runat="server" Text="Correo Electrónico"></asp:Label>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="Label13" runat="server" Text="Telefono"></asp:Label>
                            <asp:TextBox ID="txtTelefono" MaxLength="10" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel ID="pnlGvCliente" runat="server" Visible="false">
                <asp:GridView ID="gvDatosClientes" runat="server"
                    CssClass="table table-striped table-bordered table-hover dataTable no-footer" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:LinkButton ID="lkbId" runat="server" Text='<%# Bind("id") %>' OnClick="lkbId_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="nombreComercial" HeaderText="Nombre Comercial" />
                        <asp:BoundField DataField="razonSocial" HeaderText="Razon Social" />
                        <asp:BoundField DataField="RNC_CED" HeaderText="RNC/Cédula" />
                        <asp:BoundField DataField="telefono" HeaderText="Telefono" />
                        <asp:BoundField DataField="email" HeaderText="Correo Electrónico" />
                        <asp:BoundField DataField="estado" HeaderText="Estado" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>

        </div>
    </div>


    <div class="panel panel-default">
        <%--Articulos--%>
        <div class="panel-heading">
            Articulos
        </div>
        <div class="panel-body">
            
            <asp:Panel ID="pnlDatosArticulos" runat="server" >
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="Label3" runat="server" Text="Id"></asp:Label>
                            <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="Label7" runat="server" Text="Descripción"></asp:Label>
                            <asp:TextBox ID="txtDescripcion" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">  
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="Label15" runat="server" Text="Precio Unitario"></asp:Label>
                            <asp:TextBox ID="txtPrecioUnitario" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                     <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="Label14" runat="server" Text="Cantidad"></asp:Label>
                            <asp:TextBox ID="txtCantidadArticulos" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            
               

            </asp:Panel>

        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="form-group">
                <asp:Label ID="Label5" runat="server" Text="Comentario"></asp:Label>
                <asp:TextBox ID="txtComentario" runat="server" TextMode="MultiLine"></asp:TextBox>
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
            <asp:GridView ID="gvClientes" runat="server"
                CssClass="table table-striped table-bordered table-hover dataTable no-footer" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:LinkButton ID="lkbId" runat="server" Text='<%# Bind("id") %>' OnClick="lkbId_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="nombreComercial" HeaderText="Nombre Comercial" />
                    <asp:BoundField DataField="razonSocial" HeaderText="Razon Social" />
                    <asp:BoundField DataField="RNC_CED" HeaderText="RNC/Cédula" />
                    <asp:BoundField DataField="telefono" HeaderText="Telefono" />
                    <asp:BoundField DataField="email" HeaderText="Correo Electrónico" />
                    <asp:BoundField DataField="estado" HeaderText="Estado" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

