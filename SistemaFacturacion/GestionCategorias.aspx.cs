using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaFacturacion
{
    enum CRUD
    {
        Ninguna,
        Crear,
        Leer,
        Actualizar,
        Eliminar

    }

    public partial class GestionCategorias : System.Web.UI.Page
    {
        FACTURACIONEntities db = new FACTURACIONEntities();
        private static CRUD operacion = CRUD.Ninguna;

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarGvCategorias();
        }

        protected void lkbIdCategoria_Click(object sender, EventArgs e)
        {
            ///TODO: EXtraer un metodo para obtener el id del linkbutton
            operacion = CRUD.Actualizar;
            btnGuardar.Enabled = true;
            btnEliminar.Enabled = true;
            LinkButton lkb = (LinkButton)sender;
            int Id = Int32.Parse(lkb.Text);
            var cat = db.CATEGORIA.Find(Id);

            txtId.Text = Id.ToString();
            txtDescripcion.Text = cat.descripcion;
            ddlEstado.ClearSelection();
            ddlEstado.Items.FindByValue(cat.estado).Selected = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCambiosRealizados();

        }

        private void GuardarCambiosRealizados()
        {
            try
            {
                CATEGORIA categoria = new CATEGORIA();  

                switch (operacion)
                {
                    case CRUD.Ninguna:
                        break;
                    case CRUD.Crear:
                        categoria.descripcion = txtDescripcion.Text;
                        categoria.estado = ddlEstado.SelectedValue;
                        db.CATEGORIA.Add(categoria);
                        break;
                    case CRUD.Actualizar:
                        categoria = db.CATEGORIA.Find(Int32.Parse(txtId.Text));
                        categoria.descripcion = txtDescripcion.Text;
                        categoria.estado = ddlEstado.SelectedValue;
                        db.Entry(categoria).State = System.Data.EntityState.Modified;
                        break;
                    case CRUD.Eliminar:
                        categoria = db.CATEGORIA.Find(Int32.Parse(txtId.Text));
                        db.CATEGORIA.Remove(categoria);
                        break;
                    default:
                        break;
                }
                db.SaveChanges();
                LimpiarCampos();
                cargarGvCategorias();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                operacion = CRUD.Ninguna;
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
            cargarGvCategorias();
        }

        private void cargarGvCategorias()
        {
            gvCategorias.DataSource = db.CATEGORIA.ToList();
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
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            ddlEstado.SelectedIndex = 0;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }



    }
}