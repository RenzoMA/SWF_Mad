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
    public partial class frmManTipoEventoActualizar : Form
    {
        TipoEventoBL objTipoEventoBL = new TipoEventoBL();
        TipoEventoEntity objTipoEvento;

        public frmManTipoEventoActualizar()
        {
            InitializeComponent();
        }

        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!txtNombre.Text.ToUpper().Trim().Equals(String.Empty))
            {
                objTipoEvento.Nombre = txtNombre.Text.ToUpper().Trim();
                objTipoEvento.Estado = cboEstado.Text == "Activo" ? "A" : "I";
                if (objTipoEventoBL.Actualizar(objTipoEvento))
                {
                    MessageBox.Show("Proceso realizado correctamente", "Aviso");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error", "Aviso");
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un nombre", "Aviso");
            }
        }

        private void frmManTipoEventoActualizar_Load(object sender, EventArgs e)
        {
            objTipoEvento = objTipoEventoBL.Consultar(codigo);
            txtNombre.Text = objTipoEvento.Nombre;

            switch (objTipoEvento.Estado)
            {
                case "A": cboEstado.SelectedIndex = 0; break;
                case "I": cboEstado.SelectedIndex = 1; break;
            }
        }
    }
}
