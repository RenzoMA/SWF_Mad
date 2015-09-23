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
    public partial class frmManReservaActualiza : Form
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
        AsignacionBL servicioAsignacion = new AsignacionBL();

        public frmManReservaActualiza()
        {
            InitializeComponent();
        }
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private void ValidarNumero(object sender, KeyPressEventArgs e)
        {

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

        private void txtHoraInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(sender, e);
        }

        private void txtHoraFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(sender, e);
        }

        private void txtNroInvitados_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(sender, e);
        }

        private void frmManReservaActualiza_Load(object sender, EventArgs e)
        {

            objReserva = servicioReserva.Consultar(codigo);
            if (objReserva.Estado == "O")
            {
                btnPostergar.Enabled = false;
                btnHabilitar.Enabled = true;
            }
            else
            {
                btnPostergar.Enabled = true;
                btnHabilitar.Enabled = false;
            }
            fechaReservaInicial = objReserva.FechaCelebracion;
            horaInicioInicial = objReserva.HoraInicio;
            horaFinInicial = objReserva.HoraFin;
            

            cboTipo.DisplayMember = "nombre";
            cboTipo.ValueMember = "codigo";
            cboTipo.DataSource = servicioTipoEvento.ListarTodo();
            cboTipo.SelectedValue = objReserva.CodigoTipoEvento;

            if (objReserva.CodigoTienda != null)
            {
                cboTienda.Enabled = true;
                cboTienda.DisplayMember = "nombre";
                cboTienda.ValueMember = "codigo";
                cboTienda.DataSource = servicioTienda.ListarTodos();
                cboTienda.SelectedValue = objReserva.CodigoTienda;
            }

            txtDireccion.Text = objReserva.Direccion;
            txtNiño.Text = objReserva.NombreNiño;
            dtpFechaCelebracion.Value = objReserva.FechaCelebracion;
            dtpFechaNac.Value = Convert.ToDateTime(objReserva.FechaNacimiento);
            txtTelefono.Text = objReserva.Telefono;
            txtCelular.Text = objReserva.Celular;
            txtCliente.Text = objReserva.NombreCliente;
            txtHoraInicio.Text = objReserva.HoraInicio.ToString();
            txtHoraFin.Text = objReserva.HoraFin.ToString();

            cboTorta.DisplayMember = "nombre";
            cboTorta.ValueMember = "codigo";
            cboTorta.DataSource = servicioTorta.ListarTodoSelectivo();

            if (objReserva.ModeloTorta == null || objReserva.ModeloTorta == "")
            {
                cboTorta.SelectedValue = 0;
            }
            else
            {
                cboTorta.Text = objReserva.ModeloTorta.ToString();
            }

            cboSabor.DisplayMember = "nombre";
            cboSabor.ValueMember = "codigo";
            cboSabor.DataSource = servicioSabor.ListarTodo();
            if (objReserva.SaborTorta == null || objReserva.ModeloTorta == "")
            {
                cboSabor.DataSource = null;
                cboSabor.Enabled = false;
            }
            else
            {
                cboSabor.Enabled = true;
                cboSabor.Text = objReserva.SaborTorta;
            }
            txtObsGeneral.Text = objReserva.ObsGeneral;
            txtObsTorta.Text = objReserva.ObsTorta;
            txtNroInvitados.Text = objReserva.Invitados.ToString();

        }

        private void gbFiestas_Enter(object sender, EventArgs e)
        {

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
        DateTime fechaReservaInicial;
        Double horaInicioInicial;
        Double horaFinInicial;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (fechaReservaInicial >= DateTime.Now.Date.AddDays(-6))
            {
                if (!txtHoraFin.Text.Equals(String.Empty) | !txtHoraInicio.Text.Equals(String.Empty) || !txtNroInvitados.Text.Equals(String.Empty))
                {
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
                    objReserva.FechaCelebracion = dtpFechaCelebracion.Value.Date;
                    objReserva.FechaNacimiento = dtpFechaNac.Value.Date;
                    objReserva.HoraFin = Convert.ToDouble(txtHoraFin.Text);
                    objReserva.HoraInicio = Convert.ToDouble(txtHoraInicio.Text);
                    objReserva.Invitados = Convert.ToInt16(txtNroInvitados.Text);
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
                    if (objReserva.FechaCelebracion != fechaReservaInicial || objReserva.HoraInicio != horaInicioInicial || objReserva.HoraFin != horaFinInicial)
                    {
                        DialogResult result = MessageBox.Show("Se eliminara toda asignacion registrada previamente", "Confirmacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.OK)
                        {
                            objReserva.Estado = "P";
                            if (servicioReserva.Actualizar(objReserva) && servicioAsignacion.EliminarPorReserva(objReserva.Codigo))
                            {
                                MessageBox.Show("Proceso realizado correctamente", "Aviso");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Ha ocurrido un error mortal", "Aviso");
                            }
                        }
                        else
                        {

                        }

                    }
                    else
                    {
                        if (servicioReserva.Actualizar(objReserva))
                        {
                            MessageBox.Show("Proceso realizado correctamente", "Aviso");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error", "Aviso");
                        }
                    }


                }
                else
                {
                    MessageBox.Show("Complete los campos requeridos", "Aviso");
                }
            }
            else
            {
                MessageBox.Show("No es posible actualizar una reserva pasada", "Aviso");
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboTienda_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cboTienda_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtDireccion.Text = servicioTienda.Consultar(Convert.ToInt16(cboTienda.SelectedValue.ToString())).Direccion;
        }

        private void cboTorta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboTorta.SelectedIndex == 0)
            {
                cboSabor.Enabled = false;
                cboSabor.DataSource = null;
            }
            else
            {
                cboSabor.Enabled = true;
                cboSabor.DisplayMember = "nombre";
                cboSabor.ValueMember = "codigo";
                cboSabor.DataSource = servicioSabor.ListarTodo();
                
            }
        }

        private void btnPostergar_Click(object sender, EventArgs e)
        {
            DialogResult dialogo = MessageBox.Show("¿Seguro de postergar la reserva?", "Aviso",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (fechaReservaInicial >= DateTime.Now.Date.AddDays(-6))
            {
                if (dialogo == DialogResult.Yes)
                {
                    objReserva.Estado = "O";
                    servicioReserva.Actualizar(objReserva);
                    servicioAsignacion.EliminarPorReserva(objReserva.Codigo);
                    MessageBox.Show("Proceso realizado correctamente", "Aviso");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("No puede postergar una reserva anterior al dia actual", "Aviso");
            }

        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            DialogResult dialogo = MessageBox.Show("¿Seguro de habilitar la reserva?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogo == DialogResult.Yes)
            {
                objReserva.Estado = "P";
                servicioReserva.Actualizar(objReserva);
                servicioAsignacion.EliminarPorReserva(objReserva.Codigo);
                MessageBox.Show("Proceso realizado correctamente, vuelva a ingresar", "Aviso");
                this.Close();
            }
        }
    }
}
