using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaFacturacion.Vendedores
{
    public partial class GestionVendedores : System.Web.UI.Page
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
            var item = db.VENDEDORES.Find(Id);

            txtId.Text = Id.ToString();
            txtNombre.Text = item.nombres;
            txtApellido1.Text = item.apellido1;
            txtApellido2.Text = item.apellido2;
            txtPorcentajeComision.Text = item.porcientoComision.ToString();
            ddlEstado.ClearSelection();
            ddlEstado.Items.FindByValue(item.estado).Selected = true;
            txtNombreUsuario.Text = item.nombreUsuario;
            txtNombreUsuario.Enabled = false;
            txtContraseña.Text = item.contraseña;

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
                    VENDEDORES item = new VENDEDORES();

                    switch (operacion)
                    {
                        case CRUD.Crear:

                            item.nombres = txtNombre.Text;
                            item.apellido1 = txtApellido1.Text;
                            item.apellido2 = txtApellido2.Text;
                            item.porcientoComision = Int32.Parse(txtPorcentajeComision.Text);
                            item.nombreUsuario = txtNombreUsuario.Text;
                            item.contraseña = Utilidades.PasswordEncode("contrasena01");
                            item.estado = ddlEstado.SelectedValue;

                            db.VENDEDORES.Add(item);
                            break;
                        case CRUD.Actualizar:
                            item = db.VENDEDORES.Find(Int32.Parse(txtId.Text));
                            item.nombres = txtNombre.Text;
                            item.apellido1 = txtApellido1.Text;
                            item.apellido2 = txtApellido2.Text;
                            item.porcientoComision = Int32.Parse(txtPorcentajeComision.Text);
                            item.estado = ddlEstado.SelectedValue;
                            db.Entry(item).State = System.Data.EntityState.Modified;
                            break;
                        case CRUD.Eliminar:
                            item = db.VENDEDORES.Find(Int32.Parse(txtId.Text));
                            db.VENDEDORES.Remove(item);
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
                        message.title += "Ya existe un Vendedor con este nombre de usuario.";
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
            txtContraseña.Text = "constrasena01";
            txtContraseña.Enabled = false;
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
            gvCategorias.DataSource = (from v in db.VENDEDORES
                                       select new {v.id,v.nombres, apellido = v.apellido1 + " " + v.apellido2,v.porcientoComision,v.nombreUsuario,v.contraseña,v.estado,cantidadFacturas = v.FACTURAS.Count }).ToList();
            gvCategorias.DataBind();
        }

        /// <summary>
        /// Metodo para reiniciar todos los controles a sus estados iniciales.
        /// </summary>
        private void LimpiarCampos()
        {
            operacion = CRUD.Ninguna;
            txtId.Text = String.Empty;
            txtId.Text = String.Empty;
            txtNombre.Text = String.Empty;
            txtApellido1.Text = String.Empty;
            txtApellido2.Text = String.Empty;
            txtPorcentajeComision.Text = String.Empty;
            txtNombreUsuario.Text = String.Empty;
            txtNombreUsuario.Enabled = true;
            txtContraseña.Text = String.Empty;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCrear.Enabled = true;
            ddlEstado.SelectedIndex = 0;
        }

        private bool ValidarCampos()
        {
            float porcentaje = 0;

            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                message.title = "El campo Nombre es obligatorio.";
                message.type = "warning";
                this.ShowMessage(message);
                return false;
            }
            else if (String.IsNullOrEmpty(txtApellido1.Text))
            {
                message.title = "El campo Apellido 1 es obligatorio.";
                message.type = "warning";
                this.ShowMessage(message);
                return false;
            }
            else if (String.IsNullOrEmpty(txtNombreUsuario.Text))
            {
                message.title = "El campo Nombre de Usuario es obligatorio.";
                message.type = "warning";
                this.ShowMessage(message);
                return false;
            }
            else if (!float.TryParse(txtPorcentajeComision.Text, out porcentaje))
            {
                message.title = "Verificar el Porcentaje de Comisión, datos incorrectos.";
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