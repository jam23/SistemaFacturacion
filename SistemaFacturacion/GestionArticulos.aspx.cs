using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaFacturacion
{
    public partial class GestionArticulos : System.Web.UI.Page
    {
        FACTURACIONEntities db = new FACTURACIONEntities();
        private static CRUD operacion = CRUD.Ninguna;
        SweetAlert message = new SweetAlert(showCancelButton: false);


        protected void Page_Load(object sender, EventArgs e)
        {
            ///TODO: Arreglar los nombre de las columnas del grid;
            if (!IsPostBack)
            {
                cargarGridView();
                cargarddlCategoria();
            }

        }

        protected void lkbId_Click(object sender, EventArgs e)
        {
            ///TODO: EXtraer un metodo para obtener el id del linkbutton
            operacion = CRUD.Actualizar;
            btnCrear.Enabled = false;
            btnGuardar.Enabled = true;
            btnEliminar.Enabled = true;
            LinkButton lkb = (LinkButton)sender;
            int Id = Int32.Parse(lkb.Text);
            var item = db.ARTICULOS.Find(Id);

            txtId.Text = Id.ToString();
            txtDescripcion.Text = item.descripcion;
            txtCostoUnitario.Text = item.costoUnitario.ToString();
            txtPrecioUnitario.Text = item.precioUnitario.ToString();
            txtStock.Text = item.stock.ToString();
            ddlEstado.ClearSelection();
            ddlEstado.Items.FindByValue(item.estado).Selected = true;
            ddlCategoria.ClearSelection();
            ddlCategoria.Items.FindByValue(item.idCategoria.ToString()).Selected = true;

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCambiosRealizados();
        }

        private void GuardarCambiosRealizados()
        {

            if (ValidarCampos())
            {
                try
                {
                    ARTICULOS item = new ARTICULOS();

                    switch (operacion)
                    {
                        case CRUD.Crear:

                            item.descripcion = txtDescripcion.Text;
                            item.costoUnitario = Int32.Parse(txtCostoUnitario.Text);
                            item.precioUnitario = Int32.Parse(txtPrecioUnitario.Text);
                            item.stock = Int32.Parse(txtStock.Text);
                            item.idCategoria = Int32.Parse(ddlCategoria.SelectedValue);
                            item.estado = ddlEstado.SelectedValue;

                            db.ARTICULOS.Add(item);
                            break;
                        case CRUD.Actualizar:
                            item = db.ARTICULOS.Find(Int32.Parse(txtId.Text));
                            item.descripcion = txtDescripcion.Text;
                            item.costoUnitario = Int32.Parse(txtCostoUnitario.Text);
                            item.precioUnitario = Int32.Parse(txtPrecioUnitario.Text);
                            item.stock = Int32.Parse(txtStock.Text);
                            item.idCategoria = Int32.Parse(ddlCategoria.SelectedValue);
                            item.estado = ddlEstado.SelectedValue;
                            db.Entry(item).State = System.Data.EntityState.Modified;
                            break;
                        case CRUD.Eliminar:
                            item = db.ARTICULOS.Find(Int32.Parse(txtId.Text));
                            db.ARTICULOS.Remove(item);
                            break;
                        default:
                            break;
                    }
                    db.SaveChanges();
                    LimpiarCampos();
                    cargarGridView();
                    message.title = "Operación Realizada.";
                    message.type = "success";
                }
                catch (Exception ex)
                {
                    message.title = "Ocurrio algún problema, favor de verificar.";
                    if (ex.InnerException.InnerException.Message.Contains("UNIQUE"))
                    {
                        message.title += "Ya existe un Articulo con esta descripcion.";
                    }

                    message.type = "error";
                    return; ///TODO: Verificar esto
                    throw;
                }
                finally
                {
                    this.ShowMessage(message);
                }



            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            operacion = CRUD.Crear;
            btnGuardar.Enabled = true;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            operacion = CRUD.Eliminar;
            GuardarCambiosRealizados();
            cargarGridView();
        }

        private void cargarGridView()
        {
            gvArticulos.DataSource = (from a in db.ARTICULOS
                                       select new { a.id, a.descripcion, idCategoria = a.CATEGORIA.descripcion, a.costoUnitario, a.estado, a.precioUnitario, a.stock }).ToList();
            gvArticulos.DataBind();
        }

        private void cargarddlCategoria()
        {
            ddlCategoria.DataSource = (from c in db.CATEGORIA
                                       where c.estado == "A"
                                       select new { c.id, c.descripcion }).OrderBy(a => a.descripcion).ToList();
            ddlCategoria.DataTextField = "descripcion";
            ddlCategoria.DataValueField = "id";
            ddlCategoria.DataBind();
        }

        /// <summary>
        /// Metodo para reiniciar todos los controles a sus estados iniciales.
        /// </summary>
        private void LimpiarCampos()
        {
            operacion = CRUD.Ninguna;
            txtId.Text = String.Empty;

            txtDescripcion.Text = String.Empty;
            txtCostoUnitario.Text = String.Empty;
            txtPrecioUnitario.Text = String.Empty;
            txtStock.Text = String.Empty;

            ddlCategoria.SelectedIndex = 0;


            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCrear.Enabled = true;
            ddlEstado.SelectedIndex = 0;
        }

        private bool ValidarCampos()
        {
            int stock = 0;

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                message.title = "El campo Descripcion es obligatorio.";
                message.type = "warning";
                this.ShowMessage(message);
                return false;
            }
            else if (String.IsNullOrEmpty(txtCostoUnitario.Text) || (!Int32.TryParse(txtCostoUnitario.Text, out stock)))
            {
                message.title = "El campo Costo Unitario es obligatorio.";
                message.type = "warning";
                this.ShowMessage(message);
                return false;
            }
            else if (String.IsNullOrEmpty(txtPrecioUnitario.Text) || (!Int32.TryParse(txtPrecioUnitario.Text, out stock)))
            {
                message.title = "El campo Precio Unitario es obligatorio.";
                message.type = "warning";
                this.ShowMessage(message);
                return false;
            }
            else if (!Int32.TryParse(txtStock.Text, out stock))
            {
                message.title = "Verificar el stock, datos incorrectos.";
                message.type = "warning";
                this.ShowMessage(message);
                return false;
            }

            return true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}