﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaFacturacion
{
    public partial class GestionClientes : System.Web.UI.Page
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
            var item = db.CLIENTES.Find(Id);

            txtId.Text = Id.ToString();
            txtNombreComercial.Text = item.nombreComercial;
            txtRazonSocial.Text = item.razonSocial;
            txtCedRNC.Text = item.RNC_CED;
            txtCuentaContable.Text = item.cuentaContable;
            txtTelefono.Text = item.telefono;
            txtEmail.Text = item.email;
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
                    CLIENTES item = new CLIENTES();

                    switch (operacion)
                    {
                        case CRUD.Crear:
                            
                            item.nombreComercial = txtNombreComercial.Text;
                            item.razonSocial = txtRazonSocial.Text;
                            item.RNC_CED = txtCedRNC.Text;
                            item.cuentaContable = txtCuentaContable.Text;
                            item.telefono = txtTelefono.Text;
                            item.email = txtEmail.Text;
                            item.estado = ddlEstado.SelectedValue;

                            db.CLIENTES.Add(item);

                            break;
                        case CRUD.Actualizar:

                            item = db.CLIENTES.Find(Int32.Parse(txtId.Text));
                            item.nombreComercial = txtNombreComercial.Text;
                            item.razonSocial = txtRazonSocial.Text;
                            item.RNC_CED = txtCedRNC.Text;
                            item.cuentaContable = txtCuentaContable.Text;
                            item.telefono = txtTelefono.Text;
                            item.email = txtEmail.Text;
                            item.estado = ddlEstado.SelectedValue;
                            db.Entry(item).State = System.Data.EntityState.Modified;

                            break;
                        case CRUD.Eliminar:

                            item = db.CLIENTES.Find(Int32.Parse(txtId.Text));
                            db.CLIENTES.Remove(item);

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
                    
                    message.type = "error";
                    if (ex.InnerException.InnerException.Message.Contains("UQ_CEDRNC"))
                    {
                        message.title += "Ya existe un Cliente con este RNC/Cédula.";
                    }
                    else if (ex.InnerException.InnerException.Message.Contains("UQ_EMAIL"))
                    {
                        message.title += "Ya existe un Cliente con este Correo Electrónico.";
                    }
                    this.ShowMessage(message);
                    return;
                    throw;
                }
                finally
                {                   
                    
                }
                LimpiarCampos();
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
            gvClientes.DataSource = (from c in db.CLIENTES
                                     select new {
                                         c.id,
                                         c.nombreComercial,
                                         c.razonSocial,
                                         c.RNC_CED,
                                         c.telefono ,
                                         c.estado,
                                         c.email,
                                         c.cuentaContable                                                
                                     }
                                         ).ToList();
            gvClientes.DataBind();
        }

        /// <summary>
        /// Metodo para reiniciar todos los controles a sus estados iniciales.
        /// </summary>
        private void LimpiarCampos()
        {
            operacion = CRUD.Ninguna;
            txtId.Text = String.Empty;
            txtId.Text = String.Empty;
            txtNombreComercial.Text = String.Empty;
            txtRazonSocial.Text = String.Empty;
            txtCedRNC.Text = String.Empty;
            txtCuentaContable.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            txtEmail.Text = String.Empty;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCrear.Enabled = true;
            ddlEstado.SelectedIndex = 0;
        }

        private bool ValidarCampos()
        {
            if (String.IsNullOrEmpty(txtNombreComercial.Text))
            {
                message.title = "El campo Nombre Comercial es obligatorio.";
                message.type = "warning";
                this.ShowMessage(message);
                return false;
            }
            else if (String.IsNullOrEmpty(txtRazonSocial.Text))
            {
                message.title = "El campo Nombre Comercial es obligatorio."; //"Verificar el Campo Cantidad de Días, datos incorrectos o está vacío.";
                message.type = "warning";
                this.ShowMessage(message);
                return false;
            }
            else if (String.IsNullOrEmpty(txtCedRNC.Text))
            {
                message.title = "El campo RNC/Cédula es obligatorio.";
                message.type = "warning";
                this.ShowMessage(message);
                return false;
            }
            else if (String.IsNullOrEmpty(txtCuentaContable.Text))
            {
                message.title = "El campo  Cuenta Contable es obligatorio.";
                message.type = "warning";
                this.ShowMessage(message);
                return false;
            }
            else if (String.IsNullOrEmpty(txtTelefono.Text))
            {
                message.title = "El campo  Telefono es obligatorio.";
                message.type = "warning";
                this.ShowMessage(message);
                return false;
            }
            else if (String.IsNullOrEmpty(txtEmail.Text))
            {
                message.title = "El campo  Correo Electrónico es obligatorio.";
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