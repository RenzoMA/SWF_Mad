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
    public partial class frmEspecialidad : Form
    {
        TipoFiestaBL objTipoFiestaBL = new TipoFiestaBL();
        TrabajadorBL objTrabajadorBL = new TrabajadorBL();
        TrabajadorEntity objTrabajador;
        FiestaBL objFiestaBL = new FiestaBL();
        EspecialidadBL objEspecialidadBL = new EspecialidadBL();


        public frmEspecialidad()
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
            objEspecialidadBL = new EspecialidadBL();
            dgvEspecialidad.DataSource = objEspecialidadBL.ListarPorTrabajador(objTrabajador.Codigo);
        }
        private void frmEspecialidad_Load(object sender, EventArgs e)
        {
            dgvEspecialidad.AutoGenerateColumns = false;
            objTrabajador = objTrabajadorBL.Consultar(codigo);
            lblNombre.Text = objTrabajador.Nombre;
            cboTipo.DisplayMember = "Nombre";
            cboTipo.ValueMember = "Codigo";
            cboTipo.DataSource = objTipoFiestaBL.ListarTodos();
            Enlazar();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int codigoFiesta = Convert.ToInt32(cboFiesta.SelectedValue.ToString());
            int codigoTrabajador = objTrabajador.Codigo;
            EspecialidadEntity objEspecialidad = new EspecialidadEntity();
            objEspecialidad.CodigoFiesta = codigoFiesta;
            objEspecialidad.CodigoTrabajador = codigoTrabajador;
            objEspecialidad.FechaCreacion = DateTime.Now;
            objEspecialidad.UsuarioCreacion = Sesion.UsuarioActual.Login;
            if (objEspecialidadBL.Validar(objEspecialidad))
            {
                if (objEspecialidadBL.Agregar(objEspecialidad))
                {
                    Enlazar();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error, verifique", "Aviso");
                }
            }
            else
            {
                MessageBox.Show("No es posible ingresar registros duplicados", "Aviso");
            }


        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboFiesta.DataSource = objFiestaBL.ListarFiltrado(Convert.ToInt32(cboTipo.SelectedValue.ToString()));
            cboFiesta.DisplayMember = "Nombre";
            cboFiesta.ValueMember = "Codigo";
        }

        private void dgvEspecialidad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int codigo=Convert.ToInt32(dgvEspecialidad.SelectedRows[0].Cells["CodigoFiesta"].Value.ToString());
                EspecialidadEntity objEspecialidad = new EspecialidadEntity();
                objEspecialidad.CodigoFiesta=codigo;
                objEspecialidad.CodigoTrabajador = objTrabajador.Codigo;
                if (!objEspecialidadBL.Eliminar(objEspecialidad))
                {
                    MessageBox.Show("Ocurrio un error", "Aviso");
                }
                Enlazar();
            }
        }

    }
}
