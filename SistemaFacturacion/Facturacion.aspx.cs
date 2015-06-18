using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaFacturacion
{
    public partial class Facturacion : System.Web.UI.Page
    {
        FACTURACIONEntities db = new FACTURACIONEntities();
        private static CRUD operacion = CRUD.Ninguna;
        SweetAlert message = new SweetAlert(showCancelButton: false, title: "");
        private static Dictionary<int, int> ArticulosFacturados = new Dictionary<int, int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if (!IsPostBack)
            {
                var vendedor = db.VENDEDORES.First(a => a.nombreUsuario.Equals(User.Identity.Name));
                hdfIdVendedor.Value = vendedor.id.ToString();
                txtVendedor.Text = string.Format("{0} {1} {2}", vendedor.nombres, vendedor.apellido1, vendedor.apellido2);
                ClienteSeleccionado(null);
                cargarGridArticulos(); //TODO: ELIMINAR
                cargarCondicionPago();
                ArticulosFacturados.Clear(); ///TODO: Mover para el metodo ClearAll
                

            }
            RealizarCalculos();

        }

        private void cargarCondicionPago()
        {
            ddlCondicionPago.DataSource = (from p in db.CONDICIONESPAGO
                                           where p.estado.Equals("A")
                                           select new { p.id, p.descripcion }
                                           ).ToList();

            ddlCondicionPago.DataTextField = "descripcion";
            ddlCondicionPago.DataValueField = "id";
            ddlCondicionPago.DataBind(); ddlCondicionPago.Items.Insert(0, new ListItem("", ""));
        }

        #region Cliente

        private void LimpiarCamposClientes()
        {
            hdfIdCliente.Value = String.Empty;
            txtNombreComercial.Text = String.Empty;
            txtRazonSocial.Text = String.Empty;
            txtCedRNC.Text = String.Empty;
            txtCuentaContable.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            txtEmail.Text = String.Empty;
            ClienteSeleccionado(null);
        }

        //Obtner todos los clientes y llenar el grid.
        private void cargarGridDatosClientes()
        {
            gvDatosClientes.DataSource = (from c in db.CLIENTES
                                          where c.estado.Equals("A")
                                          select new
                                          {
                                              c.id,
                                              c.nombreComercial,
                                              c.razonSocial,
                                              c.RNC_CED,
                                              c.telefono,
                                              c.estado,
                                              c.email,
                                              c.cuentaContable
                                          }
                                         ).ToList();
            gvDatosClientes.DataBind();
        }

        //Cargar el grid de clientes y habilitar sección para seleccionar al cliente que se le va hacer la facturación.
        protected void btnEspecificarCliente_Click(object sender, EventArgs e)
        {
            cargarGridDatosClientes();
            ClienteSeleccionado(false);
        }

        //Despues de seleccionar el cliente, llenar los datos del cliente en los controles correspondientes.
        protected void lkbIdCliente(object sender, EventArgs e)
        {
            LinkButton lkb = (LinkButton)sender;
            int Id = 0;
            if (int.TryParse(lkb.Text, out Id))
            {
                var item = db.CLIENTES.Find(Id);
                if (item == null)
                {
                    message.text = "El cliente seleccionado no existe, favor de verificar!!";
                    this.ShowMessage(message);
                    return;
                }
                hdfIdCliente.Value = Id.ToString();
                txtNombreComercial.Text = item.nombreComercial;
                txtRazonSocial.Text = item.razonSocial;
                txtCedRNC.Text = item.RNC_CED;
                txtCuentaContable.Text = item.cuentaContable;
                txtTelefono.Text = item.telefono;
                txtEmail.Text = item.email;
                ClienteSeleccionado(true);
            }
            else
            {
                message.text = "El Id del cliente seleccionado no existe, favor de verificar!!";
                this.ShowMessage(message);
            }

        }

        /// <summary>
        /// Específicar los controles que se habilitarán si se selecciona o no un cliente.
        /// </summary>
        /// <param name="seleccionado">null: No especificado,true: Ya seleccionado, false: No seleccionado</param>
        private void ClienteSeleccionado(bool? seleccionado)
        {
            if (seleccionado == null)
            {
                pnlDatosCliente.Visible = false;
                pnlGvCliente.Visible = false;
                btnEspecificarCliente.Visible = true;
                btnCancelaCliente.Visible = false;
            }
            else if (seleccionado == true)
            {
                pnlDatosCliente.Visible = true;
                pnlGvCliente.Visible = false;
                btnEspecificarCliente.Visible = false;
                btnCancelaCliente.Visible = true;
            }
            else if (seleccionado == false)
            {
                pnlDatosCliente.Visible = false;
                pnlGvCliente.Visible = true;
                btnEspecificarCliente.Visible = false;
                btnCancelaCliente.Visible = true;
            }
        }

        protected void btnCancelaCliente_Click(object sender, EventArgs e)
        {
            LimpiarCamposClientes();
        }
        #endregion

        #region Articulos

        private void cargarGridArticulos()
        {
            gvDatosArticulos.DataSource = (from a in db.ARTICULOS
                                           where a.estado.Equals("A")
                                           select new
                                           {
                                               a.id,
                                               a.descripcion,
                                               categoria = a.CATEGORIA.descripcion,
                                               a.precioUnitario
                                           }
                                         ).ToList();
            gvDatosArticulos.DataBind();
        }

        protected void lkbIdArticulo_Click(object sender, EventArgs e)
        {
            LinkButton lkb = (LinkButton)sender;
            int Id = 0;
            if (int.TryParse(lkb.Text, out Id))
            {
                var item = db.ARTICULOS.Find(Id);
                if (item == null)
                {
                    message.text = "El artículo seleccionado no existe, favor de verificar!!";
                    this.ShowMessage(message);
                    return;
                }

                txtIdArticulo.Text = Id.ToString();
                txtDescripcion.Text = item.descripcion;
                txtPrecioUnitario.Text = item.precioUnitario.ToString();
                txtCantidadArticulos.Text = string.Empty;
                pnlDatosArticulos.Visible = true;
                MostrarModalArticulo();
            }
            else
            {
                message.text = "El Id de artículo especificado no existe, favor de verificar!!";
                this.ShowMessage(message);
            }
        }

        private void LimpiarCampoArticulos()
        {
            txtDescripcion.Text = string.Empty;
            txtIdArticulo.Text = string.Empty;
            txtCantidadArticulos.Text = string.Empty;
            txtPrecioUnitario.Text = string.Empty;
        }

        protected void btnCerrarArticuloModal_Click(object sender, EventArgs e)
        {
            LimpiarCampoArticulos();
            OcultarModalArticulo();
        }

        private void OcultarModalArticulo()
        {
            this.EjecutarJS("CerrarArticulosModal();");
        }

        private void MostrarModalArticulo()
        {
            this.EjecutarJS("AbrirArticulosModal();");
        }

        protected void btnAgregarArticuloModal_Click(object sender, EventArgs e)
        {
            if (ValidarArticuloFacturar())
            {
                AgregarArticulo(int.Parse(txtIdArticulo.Text), int.Parse(txtCantidadArticulos.Text));
                RealizarCalculos();
            }
            else
            {
                MostrarModalArticulo();
            }
        }

        private void AgregarArticulo(int IdArticulo, int CantidadArticuloFacturar)
        {
            var articulo = db.ARTICULOS.Find(IdArticulo);
            pnlArticulosFacturados.Visible = true;

            if (ArticulosFacturados.ContainsKey(articulo.id))
            {
                ArticulosFacturados[articulo.id] += CantidadArticuloFacturar;
            }
            else
            {
                ArticulosFacturados.Add(articulo.id, CantidadArticuloFacturar);
            }
            articulo.stock -= CantidadArticuloFacturar;
            db.SaveChanges();
            CargarGridArticulosFacturados();
        }

        private void RemoverArticulo(int IdArticulo)
        {
            var articulo = db.ARTICULOS.Find(IdArticulo);
            if (ArticulosFacturados.ContainsKey(articulo.id))
            {
                articulo.stock += ArticulosFacturados[articulo.id];
                ArticulosFacturados.Remove(articulo.id);
            }

            db.SaveChanges();
            CargarGridArticulosFacturados();

        }

        private void CargarGridArticulosFacturados()
        {
            var dsArticulosFacturados = (from af in ArticulosFacturados
                                         from a in db.ARTICULOS
                                         where a.id == af.Key
                                         select new
                                         {
                                             a.id,
                                             a.descripcion,
                                             categoria = a.CATEGORIA.descripcion,
                                             a.precioUnitario,
                                             cantidadArticulo = af.Value,
                                             importe = a.precioUnitario * af.Value
                                         });


            gvArticulosFacturados.DataSource = dsArticulosFacturados.ToList();
            gvArticulosFacturados.DataBind();


        }

        private bool ValidarArticuloFacturar()
        {
            bool valido = true;
            int NumeroValido = 0;

            if (string.IsNullOrEmpty(txtIdArticulo.Text) || !int.TryParse(txtIdArticulo.Text, out NumeroValido))
            {
                message.text = "El artículo especificado no es valido, favor de verificar !!";
                valido = false;
            }
            else if (db.ARTICULOS.Find(NumeroValido) == null)
            {
                message.text = "El artículo especificado no existe, favor de verificar !!";
                valido = false;
            }
            else if (string.IsNullOrEmpty(txtCantidadArticulos.Text))
            {
                message.text = "Debe especificar la cantidad que va a facturar de este artículo.";
                valido = false;
            }
            else if (!int.TryParse(txtCantidadArticulos.Text, out NumeroValido) || NumeroValido <= 0)
            {
                message.text = "La cantidad insertada no es valida, favor de verificar!!!";
                valido = false;
            }


            int ArticuloStock = db.ARTICULOS.Find(int.Parse(txtIdArticulo.Text)).stock;
            if (NumeroValido > ArticuloStock)
            {
                message.text = string.Format("La cantidad de artículos insertada no esta dísponible solo hay {0} en existencia, favor de verificar!!!", ArticuloStock);
                valido = false;
            }

            if (!valido) { this.ShowMessage(message); }

            return valido;
        }

        protected void lkbRemoverArticuloFacturado_Click(object sender, EventArgs e)
        {
            LinkButton lkb = (LinkButton)sender;
            int Id = 0;
            if (int.TryParse(lkb.ToolTip, out Id))
            {
                var item = db.ARTICULOS.Find(Id);
                if (item == null)
                {
                    message.text = "El artículo que esta intentando remover no existe, favor de verificar!!";
                    this.ShowMessage(message);
                    return;
                }

                RemoverArticulo(Id);
                RealizarCalculos();
                if (ArticulosFacturados.Count() <= 0)
                {
                    pnlArticulosFacturados.Visible = false;
                }
            }
            else
            {
                message.text = "El artículo que esta intentando remover no existe, favor de verificar!!";
                this.ShowMessage(message);
            }


        }


        private void RealizarCalculos()
        {
            float totalBruto = float.Parse(txtTotalBruto.Text);
            float PorcentajeDescuento = float.Parse(txtPorcentajeDescuento.Text);
            float PorcentajeITBIS = float.Parse(txtPorcentajeITBIS.Text);

            var dsArticulosFacturados = (from af in ArticulosFacturados
                                         from a in db.ARTICULOS
                                         where a.id == af.Key
                                         select new
                                         {
                                             a.id,
                                             a.descripcion,
                                             categoria = a.CATEGORIA.descripcion,
                                             a.precioUnitario,
                                             cantidadArticulo = af.Value,
                                             importe = a.precioUnitario * af.Value
                                         });


            #region Bruto
            txtTotalBruto.Text = dsArticulosFacturados.Sum(a => a.importe).ToString();
            totalBruto = int.Parse(txtTotalBruto.Text);
            #endregion

            #region Descuento
            txtDescuento.Text = (totalBruto * (PorcentajeDescuento / 100)).ToString();
            #endregion

            #region ITBIS
            txtITBIS.Text = (totalBruto * (PorcentajeITBIS / 100)).ToString();
            #endregion

            #region Total
            txtTotalNeto.Text = (totalBruto - (totalBruto * (PorcentajeDescuento / 100)) + (totalBruto * (PorcentajeITBIS / 100))).ToString(); ;
            #endregion
        }
        #endregion

        #region Facturar

        protected void btnCancelarFactura_Click(object sender, EventArgs e)
        {
            LimpiarCamposFactura();
        }

        private void LimpiarCamposFactura()
        {
            LimpiarCampoArticulos();
            LimpiarCamposClientes();
            txtVendedor.Text = string.Empty;
            hdfIdVendedor.Value = string.Empty;
            ddlCondicionPago.SelectedIndex = 0;
            txtComentario.Text = string.Empty;
            txtPorcentajeDescuento.Text = "0";
            txtPorcentajeITBIS.Text = "18";
            LimpiarArticulosFacturados();
            RealizarCalculos();
            CargarGridArticulosFacturados();
            pnlArticulosFacturados.Visible = false;

        }

        private void LimpiarArticulosFacturados()
        {
            foreach (var item in ArticulosFacturados)
            {
                if (ArticulosFacturados.ContainsKey(item.Key))
                {
                    db.ARTICULOS.Find(item.Key).stock += ArticulosFacturados[item.Key];
                }
            }
            ArticulosFacturados.Clear();
            db.SaveChanges();
        }

        private bool ValidatarDatosFactura()
        {
            message.type = "warning";
            bool valido = true;
            if (String.IsNullOrEmpty(hdfIdVendedor.Value)) //User.Identity.IsAuthenticated
            {
                valido = false;
                message.text = "Debe Identificarse como un Vendedor valido, favor de verificar!!";
            }
            else if (ddlCondicionPago.SelectedIndex == 0)
            {
                valido = false;
                message.text = "Debe especificar La Condición de Pago, favor de verificar!!";
                ddlCondicionPago.Focus();
            }
            else if (string.IsNullOrEmpty(txtComentario.Text))
            {
                valido = false;
                message.text = "El campo Comentario es requerido, favor de verificar!!";
            }
            else if (String.IsNullOrEmpty(hdfIdCliente.Value))
            {
                valido = false;
                message.text = "Debe especificar un Cliente válido, favor de verificar!!";
            }
            else if (ArticulosFacturados.Count <= 0)
            {
                valido = false;
                message.text = "No hay artículos facturados, favor de verificar!!";
            }

            if (!valido) this.ShowMessage(message);


            return valido;
        }

        protected void btnGuardarFacturar_Click(object sender, EventArgs e)
        {
            if (ValidatarDatosFactura())
            {
                try
                {
                    using (TransactionScope trans = new TransactionScope())
                    {   
                        FACTURAS factura = new FACTURAS();
                        DETALLE_FACTURA detalleFactura = new DETALLE_FACTURA();

                        factura.comentario = txtComentario.Text;
                        factura.fechaRegistro = DateTime.Now;
                        factura.idCondicionPago = int.Parse(ddlCondicionPago.SelectedValue);
                        factura.idVendedor = int.Parse(hdfIdVendedor.Value);
                        factura.idCliente = int.Parse(hdfIdCliente.Value);
                        factura.PorcentajeDescuento = int.Parse(string.IsNullOrEmpty(txtPorcentajeDescuento.Text) ? "0" : txtPorcentajeDescuento.Text);
                        factura.ITBIS = int.Parse(string.IsNullOrEmpty(txtPorcentajeITBIS.Text) ? "0" : txtPorcentajeITBIS.Text);
                        db.FACTURAS.Add(factura);

                        foreach (var articuloFacturado in ArticulosFacturados)
                        {
                            detalleFactura.idArticulo = articuloFacturado.Key;
                            detalleFactura.idFactura = factura.id;
                            detalleFactura.precioUnitario = db.ARTICULOS.Find(articuloFacturado.Key).precioUnitario;
                            detalleFactura.cantidad = articuloFacturado.Value;
                            db.DETALLE_FACTURA.Add(detalleFactura);
                        }

                        db.SaveChanges();
                        LimpiarCamposFactura();
                        trans.Complete();
                        message.type = "success";
                        message.text = string.Format("Factura registrada. No. {0}", factura.id);
                        this.ShowMessage(message);


                    }

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {

                }
            }
        }

        #endregion





    }
}