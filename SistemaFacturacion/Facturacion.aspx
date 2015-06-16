﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Facturacion.aspx.cs" Inherits="SistemaFacturacion.Facturacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%Page.Header.Title = "Facturación de Artículos"; %>

    <script type="text/javascript">
        //$(document).ready(function () {
        //    var articulos = $('.dataTableArticulos');
        //    var Clientes = $('.dataTableClientes');
        //    articulos.dataTable();
        //    Clientes.dataTable();

        //});
        function OpenArticulosModal() {
            $('#ArticulosModal').modal();
        }
        $(document).ready(function () {

        });
    </script>
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
            <asp:Panel ID="pnlDatosCliente" runat="server" Visible="false" Enabled="false">
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="Label8" runat="server" Text="Nombre Comercial"></asp:Label>
                            <asp:TextBox ID="txtNombreComercial" runat="server"></asp:TextBox>
                            <asp:HiddenField ID="hdfIdCliente" runat="server"></asp:HiddenField>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="Label9" runat="server" Text="Razón Social"></asp:Label>
                            <asp:TextBox ID="txtRazonSocial" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="Label10" runat="server" Text="RNC/Cédula"></asp:Label>
                            <asp:TextBox ID="txtCedRNC" MaxLength="11" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="Label11" runat="server" Text="Cuenta Contable"></asp:Label>
                            <asp:TextBox ID="txtCuentaContable" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="Label12" runat="server" Text="Correo Electrónico"></asp:Label>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="Label13" runat="server" Text="Telefono"></asp:Label>
                            <asp:TextBox ID="txtTelefono" MaxLength="10" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

            </asp:Panel>
            <asp:Panel ID="pnlGvCliente" runat="server" Visible="true">
                <asp:GridView ID="gvDatosClientes" runat="server"
                    CssClass="table table-striped table-bordered table-hover dataTable no-footer" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:LinkButton ID="lkbIdCliente" runat="server" Text='<%# Bind("id") %>' OnClick="lkbIdCliente"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="nombreComercial" HeaderText="Nombre Comercial" />
                        <asp:BoundField DataField="razonSocial" HeaderText="Razon Social" />
                        <asp:BoundField DataField="RNC_CED" HeaderText="RNC/Cédula" />
                        <asp:BoundField DataField="telefono" HeaderText="Telefono" />
                        <asp:BoundField DataField="email" HeaderText="Correo Electrónico" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <asp:Button ID="btnEspecificarCliente" runat="server" CssClass="btn btn-primary" Text="Especificar Cliente" OnClick="btnEspecificarCliente_Click" />
            <asp:Button ID="btnCancelaCliente" runat="server" CssClass="btn btn-warning" Text="Limpiar" OnClick="btnCancelaCliente_Click" />
        </div>
    </div>


    <div class="panel panel-default">
        <%--Articulos--%>
        <div class="panel-heading">
            Articulos
        </div>
        <div class="panel-body">
            <%--<asp:Panel ID="pnlDatosArticulos" runat="server" Visible="false">
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
            </asp:Panel>--%>

            <asp:Panel runat="server" ID="pnlGvArticulos" Visible="true">
                <asp:GridView ID="gvDatosArticulos" runat="server" AutoGenerateColumns="False"
                    CssClass="table table-striped table-bordered table-hover dataTable no-footer" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:LinkButton ID="lkbIdArticulo"  runat="server" Text='<%# Bind("id") %>' OnClick="lkbIdArticulo_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                        <asp:BoundField DataField="categoria" HeaderText="Categoria" />
                        <asp:BoundField DataField="precioUnitario" HeaderText="Precio Unitario" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
           <%-- <div class="row form-inline">
                <div class="col-lg-8">
                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" Text="Cantidad Articulos:"></asp:Label>
                        <asp:TextBox runat="server" ID="txtCantidadArticulo"></asp:TextBox>
                        <asp:Button ID="btnAgregarArticulo" runat="server" Text="Agregar Articulo" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>--%>
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
    
    <!-- Modal -->
    <div class="modal fade" id="ArticulosModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Agregar Artículo</h4>
                </div>
                <div class="modal-body">
                    <asp:Panel ID="pnlDatosArticulos" runat="server" Visible="true">
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="Label3" runat="server" Text="Id"></asp:Label>
                                    <asp:TextBox ID="txtIdArticulo" runat="server" ReadOnly="true"></asp:TextBox>
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
                <div class="modal-footer">
                    <asp:Button ID="btnCerrarArticuloModal" runat="server" Text="Cerrar" data-dismiss="modal" class="btn btn-default" />
                    <asp:Button ID="btnAgregarArticuloModal" runat="server" class="btn btn-primary" Text="Agregar" />

                </div>
            </div>
        </div>
    </div>
</asp:Content>

