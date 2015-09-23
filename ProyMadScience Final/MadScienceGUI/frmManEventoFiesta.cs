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
    public partial class frmManEventoFiesta : Form
    {
        TipoEventoBL objTipo = new TipoEventoBL();
        PagoFiestaBL objPagoFiestaBL = new PagoFiestaBL();
        FiestaEventoBL objFiestaEventoBL = new FiestaEventoBL();
        FiestaBL objFiestaBL = new FiestaBL();
        FiestaEntity objFiesta;
        public frmManEventoFiesta()
        {
            InitializeComponent();
        }

        private void frmManEventoFiesta_Load(object sender, EventArgs e)
        {
            dgvEventoFiesta.AutoGenerateColumns = false;
            objFiesta = objFiestaBL.Consultar(codigo);
            List<TipoEventoEntity> lista = objTipo.ListarTodo();
            cboTipoEvento.DataSource = lista;
            cboTipoEvento.DisplayMember = "Nombre";
            cboTipoEvento.ValueMember = "Codigo";
            txtNombre.Text = objFiesta.Nombre;
            Enlazar();
        }

        public void Enlazar()
        {
            objFiestaEventoBL = new FiestaEventoBL();
            dgvEventoFiesta.DataSource = objFiestaEventoBL.ListarPorFiesta(objFiesta.Codigo);

        }
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int codigoEvento = Convert.ToInt16(cboTipoEvento.SelectedValue.ToString());
            int codigoFiesta = objFiesta.Codigo;
            DateTime fecha = DateTime.Now;
            FiestaEventoEntity objFiestaEvento = new FiestaEventoEntity();
            objFiestaEvento.CodigoFiesta = codigoFiesta;
            objFiestaEvento.CodigoTipoEvento = codigoEvento;
            objFiestaEvento.FechaCreacion = fecha;
            if (objFiestaEventoBL.ValidarDuplicidad(objFiestaEvento))
            {
                if (!objFiestaEventoBL.Agregar(objFiestaEvento))
                {
                    MessageBox.Show("Ha ocurrido un error", "Aviso");
                }
                Enlazar();
            }
            else
            {
                MessageBox.Show("El tipo indicado ya fue agregado", "Aviso");
            }
        }

        private void dgvEventoFiesta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int codigoTipoEvento = Convert.ToInt16(dgvEventoFiesta.Rows[e.RowIndex].Cells["codigoTipo"].Value.ToString());
                int codigoFiesta = objFiesta.Codigo;
                FiestaEventoEntity obj = new FiestaEventoEntity();
                obj.CodigoFiesta = codigoFiesta;
                obj.CodigoTipoEvento = codigoTipoEvento;
                if (!objFiestaEventoBL.Eliminar(obj))
                {
                    MessageBox.Show("Ha ocurrido un error", "Aviso");
                }
                Enlazar();
            }
        }

    }
}
