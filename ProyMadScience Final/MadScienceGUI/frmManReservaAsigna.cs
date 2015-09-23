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
    public partial class frmManReservaAsigna : Form
    {
        DetalleReservaBL servicioDetalle = new DetalleReservaBL();
        AsignacionBL servicioAsignacion = new AsignacionBL();
        ReservaBL servicioReserva = new ReservaBL();
        ReservaEntity objReserva;
        public frmManReservaAsigna()
        {
            InitializeComponent();
        }
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private void frmManReservaAsigna_Load(object sender, EventArgs e)
        {
            dgvFiestas.AutoGenerateColumns = false;
            objReserva= servicioReserva.Consultar(codigo);
            Enlazar();
            
        }
        public void Enlazar()
        {
            servicioDetalle = new DetalleReservaBL();
            dgvFiestas.DataSource = servicioDetalle.ListarPorReserva(codigo);
        }

        private void dgvFiestas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (objReserva.FechaCelebracion >= DateTime.Now.Date.AddDays(-6))
                {
                    DialogResult dialogo = MessageBox.Show("¿Seguro de eliminar? \n Se eliminara toda asignacion para esta fiesta", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogo == DialogResult.Yes)
                    {
                        int cod = Convert.ToInt16(dgvFiestas.Rows[e.RowIndex].Cells["cod"].Value.ToString());
                        DetalleReservaEntity obj = new DetalleReservaEntity();
                        obj.Codigo = cod;
                        if (servicioAsignacion.EliminarPorDetalle(cod))
                        {
                            if (servicioDetalle.Eliminar(obj))
                            {
                                MessageBox.Show("Eliminado correctamente", "Aviso");
                                Enlazar();
                            }
                            else
                            {
                                MessageBox.Show("Error mortal", "Aviso");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error", "Aviso");
                            Enlazar();
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Pasada la fecha de la reserva no es posible realizar modificaciones", "Aviso");
                }
            }
            if (e.ColumnIndex == 1)
            {
                frmManReservaAsignarTrabajador frm = new frmManReservaAsignarTrabajador();
                frm.CodigoDetalle = Convert.ToInt16(dgvFiestas.Rows[e.RowIndex].Cells["cod"].Value.ToString());
                frm.CodigoReserva = codigo;
                frm.ShowDialog();
                Enlazar();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmManReservaAgregaFiesta frm = new frmManReservaAgregaFiesta();
            frm.CodigoReserva = codigo;
            frm.CodigoTipoEvento = objReserva.CodigoTipoEvento;
            frm.ShowDialog();
            Enlazar();
        }

    }
}
