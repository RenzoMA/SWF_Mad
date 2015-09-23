using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MadScienceBL;

namespace MadScienceGUI
{
    public partial class frmConsultaDisponibilidadEspecialidad : Form
    {
        TipoFiestaBL servicioTipoFiesta = new TipoFiestaBL();
        FiestaBL servicioFiesta = new FiestaBL();
        TrabajadorBL servicioTrabajador = new TrabajadorBL();
        public frmConsultaDisponibilidadEspecialidad()
        {
            InitializeComponent();
        }

        private void frmConsultaDisponibilidadEspecialidad_Load(object sender, EventArgs e)
        {
            dgvDisponibles.AutoGenerateColumns = false;
            cboTipo.ValueMember = "codigo";
            cboTipo.DisplayMember = "nombre";
            cboTipo.DataSource = servicioTipoFiesta.ListarTodos();
           
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboFiesta.DataSource = servicioFiesta.ListarFiltrado(Convert.ToInt16(cboTipo.SelectedValue.ToString()));
            cboFiesta.DisplayMember = "nombre";
            cboFiesta.ValueMember = "codigo";
        }

        private void txtHoraInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(sender, e);
        }

        private void txtHoraFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumero(sender, e);
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

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtHoraFin.Text.Equals(String.Empty) || !txtHoraInicio.Text.Equals(String.Empty))
                {
                    DateTime fecha = dtpFecha.Value.Date;
                    Double horaInicio = Convert.ToDouble(txtHoraInicio.Text);
                    Double horaFin = Convert.ToDouble(txtHoraFin.Text);
                    int codigoFiesta = Convert.ToInt16(cboFiesta.SelectedValue.ToString());
                    int codigoReserva = 0;
                    servicioTrabajador = new TrabajadorBL();
                    dgvDisponibles.DataSource = servicioTrabajador.ListarTrabajadorAsignaciones(fecha, fecha.ToString("dddd").ToUpper(), horaInicio, horaFin, codigoFiesta, codigoReserva);
                }
                else
                {
                    MessageBox.Show("Debe completar los campos", "Aviso");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error!!! "+ex.Message);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void tsVerificarDia_Click(object sender, EventArgs e)
        {
            frmConsultaAsignaciones frm = new frmConsultaAsignaciones();
            frm.CodigoTrabajador = codigoTrabajador;
            frm.FechaCelebracion = fecha;
            frm.ShowDialog();
        }

        int codigoTrabajador;
        DateTime fecha;
        private void dgvDisponibles_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            fecha = dtpFecha.Value.Date;
            codigoTrabajador =  Convert.ToInt16(dgvDisponibles.Rows[e.RowIndex].Cells["codigo"].Value.ToString());
        }
    }
}
