using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MadScienceBL;
using MadScienceBE;

namespace MadScienceGUI
{
    public partial class frmManReservaCrea : Form
    {
        TipoEventoBL servicioTipoEvento = new TipoEventoBL();
        TiendaBL servicioTienda = new TiendaBL();
        TortaBL servicioTorta = new TortaBL();
        SaborBL servicioSabor = new SaborBL();
        TipoFiestaBL servicioTipoFiesta = new TipoFiestaBL();
        FiestaBL servicioFiesta = new FiestaBL();
        List<FiestaEntity> lFiesta = new List<FiestaEntity>();
        ReservaEntity objReserva;
        ReservaBL servicioReserva = new ReservaBL();
        DetalleReservaBL servicioDetalle = new DetalleReservaBL();

        public frmManReservaCrea()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManReservaCrea_Load(object sender, EventArgs e)
        {
            dgvFiesta.AutoGenerateColumns = false;
            cboTipo.DisplayMember = "nombre";
            cboTipo.ValueMember = "codigo";
            cboTipo.DataSource = servicioTipoEvento.ListarTodo();

            cboTipoFiesta.DisplayMember = "nombre";
            cboTipoFiesta.ValueMember = "codigo";
            cboTipoFiesta.DataSource = servicioTipoFiesta.ListarTodos();

            dtpFechaNac.Value = DateTime.Now.Date.AddYears(-8);
            
            cboTorta.DisplayMember = "nombre";
            cboTorta.ValueMember = "codigo";
            cboTorta.DataSource = servicioTorta.ListarTodoSelectivo();
            
        }
        private void ValidarNumero(object sender, KeyPressEventArgs e){

            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Contains('.'))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == '.' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
        }
         
        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipo.SelectedIndex == 0)
            {
                cboTienda.Enabled = true;
                cboTienda.DisplayMember = "nombre";
                cboTienda.ValueMember = "codigo";
                cboTienda.DataSource = servicioTienda.ListarTodos();
               // MostrarFiesta();
                
            }
            else
            {
                txtDireccion.Text = "";
                cboTienda.Enabled = false;
                cboTienda.DataSource = null;
             //   MostrarFiesta();
            }
        }

        private void cboTienda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTienda.Enabled == true)
            {
                txtDireccion.Text = servicioTienda.Consultar(Convert.ToInt16(cboTienda.SelectedValue.ToString())).Direccion;
            }
        }

        private void cboTorta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTorta.SelectedIndex > 0)
            {
                cboSabor.Enabled = true;
                cboSabor.DisplayMember = "nombre";
                cboSabor.ValueMember = "codigo";
                cboSabor.DataSource = servicioSabor.ListarTodo();
            }
            else
            {
                cboSabor.Enabled = false;
                cboSabor.DataSource = null;
            }
        }

        private void txtHoraInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(sender, e);
        }

        private void txtHoraFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(sender, e);
        }

        private void cboTipoFiesta_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarFiesta();
           
        }

        public void MostrarFiesta()
        {
            cboFiesta.DisplayMember = "nombre";
            cboFiesta.ValueMember = "codigo";
            int codigoTipoEvento = Convert.ToInt16(cboTipo.SelectedValue.ToString());
            int codigoTipoFiesta = Convert.ToInt16(cboTipoFiesta.SelectedValue.ToString());
            cboFiesta.DataSource = servicioFiesta.ListarEventoAndTipo(codigoTipoEvento, codigoTipoFiesta);
        }

        private void btnAgregarFiesta_Click(object sender, EventArgs e)
        {
            if (cboFiesta.SelectedIndex != -1)
            {
                dgvFiesta.DataSource = null;
                FiestaEntity obj = servicioFiesta.Consultar(Convert.ToInt16(cboFiesta.SelectedValue.ToString()));
                lFiesta.Add(obj);
                dgvFiesta.DataSource = lFiesta;
            }

        }

        private void cboTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MostrarFiesta();
        }

        private void dgvFiesta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgvFiesta.DataSource = null;
                int indice = e.RowIndex;
                lFiesta.RemoveAt(indice);
                dgvFiesta.DataSource = lFiesta;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (dtpFechaCelebracion.Value.Date >= DateTime.Now.Date.AddDays(-6))
            {
                if (lFiesta.Count > 0)
                {
                    if (!txtHoraFin.Text.Equals(String.Empty) | !txtHoraInicio.Text.Equals(String.Empty) || !txtNroInvitados.Text.Equals(String.Empty))
                    {
                        objReserva = new ReservaEntity();
                        objReserva.Celular = txtCelular.Text.Trim();
                        if (cboTienda.SelectedIndex == -1)
                        {
                            objReserva.CodigoTienda = null;
                        }
                        else
                        {
                            objReserva.CodigoTienda = Convert.ToInt16(cboTienda.SelectedValue.ToString());
                        }
                        objReserva.NombreCliente = txtCliente.Text.ToUpper().Trim();
                        objReserva.NombreNiño = txtNiño.Text.ToUpper().Trim();
                        objReserva.CodigoTipoEvento = Convert.ToInt16(cboTipo.SelectedValue.ToString());
                        objReserva.CodigoUsuario = Sesion.UsuarioActual.Codigo;
                        objReserva.Direccion = txtDireccion.Text.ToUpper().Trim();
                        objReserva.Estado = "P";
                        objReserva.FechaCelebracion = dtpFechaCelebracion.Value.Date;
                        objReserva.FechaNacimiento = dtpFechaNac.Value.Date;
                        objReserva.HoraFin = Convert.ToDouble(txtHoraFin.Text);
                        objReserva.HoraInicio = Convert.ToDouble(txtHoraInicio.Text);

                        try
                        {
                            objReserva.Invitados = Convert.ToInt16(txtNroInvitados.Text);
                        }
                        catch {
                            objReserva.Invitados = 0;
                        }
                        if (cboTorta.SelectedIndex != 0)
                        {
                            objReserva.ModeloTorta = cboTorta.Text;
                            objReserva.SaborTorta = cboSabor.Text;
                        }
                        else
                        {
                            objReserva.ModeloTorta = null;
                            objReserva.SaborTorta = null;
                        }
                        objReserva.ObsTorta = txtObsTorta.Text.ToUpper().Trim();
                        objReserva.ObsGeneral = txtObsGeneral.Text.ToUpper().Trim();
                        objReserva.Telefono = txtTelefono.Text;
                        objReserva.UsuarioCrea = Sesion.UsuarioActual.Nombre + " " + Sesion.UsuarioActual.ApePat;
                        objReserva.FechaCrea = DateTime.Now;


                        

                        int codigoReserva = servicioReserva.Insertar(objReserva);
                        if (codigoReserva != 0)
                        {
                            List<DetalleReservaEntity> lDetalle = new List<DetalleReservaEntity>();
                            foreach (FiestaEntity obj in lFiesta)
                            {
                                DetalleReservaEntity deta = new DetalleReservaEntity();
                                deta.CodigoFiesta = obj.Codigo;
                                deta.FechaCreacion = DateTime.Now;
                                deta.Usuario = Sesion.UsuarioActual.Login;
                                deta.CodigoReserva = codigoReserva;
                                deta.FactCuenta = obj.Cuenta;
                                deta.FactPrecio = obj.Precio;
                                

                                if (cboTienda.SelectedIndex != -1)
                                {
                                    TiendaEntity objTienda = servicioTienda.Consultar(Convert.ToInt16(cboTienda.SelectedValue.ToString()));
                                    deta.FactCliente = objTienda.CebeTienda;
                                    deta.FactNomCli = objTienda.Nombre;
                                }
                                else
                                {
                                    deta.FactCliente = cboTipo.Text.ToUpper().Trim();
                                    deta.FactNomCli = txtCliente.Text.ToUpper().Trim();
                                }



                                lDetalle.Add(deta);
                            }
                            if (servicioDetalle.Agregar(lDetalle))
                            {
                                MessageBox.Show("Proceso realizado correctamente", "Aviso");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("ERROR FATAL EN LA APLICACION", "ERROR MORTAL");
                            }


                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error", "Aviso");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar la hora de inicio y fin obligatoriamente", "Aviso");
                    }
                }
                else
                {
                    MessageBox.Show("Debe agregar al menos una fiesta", "Aviso");
                }

            }
            else
            {
                MessageBox.Show("La fecha de celebracion no puede ser menor a la fecha actual", "Aviso");
            }
           
        }

        private void txtNroInvitados_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(sender, e);
        }
    }
}
