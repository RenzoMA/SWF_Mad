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
using System.Globalization;
using System.Threading;

namespace MadScienceGUI
{
    public partial class frmPagoFiesta : Form
    {
        TipoPagoBL objTipoPagoBL = new TipoPagoBL();
        FiestaEntity objFiesta = new FiestaEntity();
        FiestaBL objFiestaBL = new FiestaBL();
        PagoFiestaBL objPagoFiestaBL = new PagoFiestaBL();
        public frmPagoFiesta()
        {
            InitializeComponent();
        }
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public void Enlazar()
        {
            cboTipoPago.DataSource = objTipoPagoBL.ListarTodos();
            cboTipoPago.DisplayMember = "nombre";
            cboTipoPago.ValueMember = "codigo";
            objPagoFiestaBL = new PagoFiestaBL();
            dgvTipoPago.DataSource = objPagoFiestaBL.ListaPorFiesta(objFiesta.Codigo);
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtMonto.Text.Trim().Equals(String.Empty))
                {
                    PagoFiestaEntity objPagoFiesta = new PagoFiestaEntity();
                    objPagoFiesta.CodigoFiesta = objFiesta.Codigo;
                    objPagoFiesta.CodigoTipoPago = Convert.ToInt16(cboTipoPago.SelectedValue.ToString());
                    objPagoFiesta.Monto = Convert.ToDouble(txtMonto.Text);
                    if (objPagoFiestaBL.ValidarDuplicidad(objPagoFiesta))
                    {
                        if (!objPagoFiestaBL.Agregar(objPagoFiesta))
                        {
                            MessageBox.Show("Ha ocurrido un error", "Aviso");
                        }
                        Enlazar();
                        
                    }
                    else
                    {
                        MessageBox.Show("El tipo de pago ya fue agregado", "Aviso");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmPagoFiesta_Load(object sender, EventArgs e)
        {
            dgvTipoPago.AutoGenerateColumns = false;
            objFiesta = objFiestaBL.Consultar(codigo);
            Enlazar();
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void dgvTipoPago_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int codigoTipo = Convert.ToInt16(dgvTipoPago.Rows[e.RowIndex].Cells["codigoTipo"].Value.ToString());
                int codigoFiesta = objFiesta.Codigo;
                PagoFiestaEntity obj = new PagoFiestaEntity();
                obj.CodigoFiesta = codigoFiesta;
                obj.CodigoTipoPago = codigoTipo;
                if (objPagoFiestaBL.Eliminar(obj))
                {
                    Enlazar();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error", "Aviso");
                }

            }
        }
    }
}
