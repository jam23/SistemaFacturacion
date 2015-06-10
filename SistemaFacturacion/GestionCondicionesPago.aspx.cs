using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaFacturacion
{
    public partial class GestionCondicionesPago : System.Web.UI.Page
    {
        FACTURACIONEntities db = new FACTURACIONEntities();
        private static CRUD operacion = CRUD.Ninguna;
        SweetAlert message = new SweetAlert(showCancelButton: false);


        protected void Page_Load(object sender, EventArgs e)
        {
            ///TODO: Arreglar los nombre de las columnas del grid;
            cargarGridView();
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
            var item  = db.CONDICIONESPAGO.Find(Id);

            txtId.Text = Id.ToString();
            txtDescripcion.Text = item.descripcion;
            txtCantidadDias.Text = item.cantidadDias.ToString();
            ddlEstado.ClearSelection();
            ddlEstado.Items.FindByValue(item.estado).Selected = true;
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
                    CONDICIONESPAGO item = new CONDICIONESPAGO();

                    switch (operacion)
                    {
                        case CRUD.Crear:
                            item.descripcion = txtDescripcion.Text;
                            item.estado = ddlEstado.SelectedValue;
                            item.cantidadDias = Int32.Parse(txtCantidadDias.Text);
                            db.CONDICIONESPAGO.Add(item);
                            break;
                        case CRUD.Actualizar:
                            item = db.CONDICIONESPAGO.Find(Int32.Parse(txtId.Text));
                            item.descripcion = txtDescripcion.Text;
                            item.cantidadDias = Int32.Parse(txtCantidadDias.Text);
                            item.estado = ddlEstado.SelectedValue;
                            db.Entry(item).State = System.Data.EntityState.Modified;
                            break;
                        case CRUD.Eliminar:
                            item = db.CONDICIONESPAGO.Find(Int32.Parse(txtId.Text));
                            db.CONDICIONESPAGO.Remove(item);
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
                catch (Exception)
                {
                    message.title = "Ocurrio algún problema, favor de verificar.";
                    message.type = "error";
                    throw;
                }
                finally
                {
                    operacion = CRUD.Ninguna;
                }

                this.ShowMessage(message);
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
            gvCategorias.DataSource = db.CONDICIONESPAGO.ToList();
            gvCategorias.DataBind();
        }

        /// <summary>
        /// Metodo para reiniciar todos los controles a sus estados iniciales.
        /// </summary>
        private void LimpiarCampos()
        {
            operacion = CRUD.Ninguna;
            txtId.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            txtCantidadDias.Text = String.Empty;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCrear.Enabled = true;
            ddlEstado.SelectedIndex = 0;
        }

        private bool ValidarCampos()
        {
            int cantDias = 0;
            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                message.title = "El campo Descripción es obligatorio.";
                message.type = "warning";
                this.ShowMessage(message);
                return false;
            }
            else if(String.IsNullOrEmpty(txtCantidadDias.Text) || !Int32.TryParse(txtCantidadDias.Text,out cantDias))
            {
                message.title = "Verificar el Campo Cantidad de Días, datos incorrectos o está vacío.";
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