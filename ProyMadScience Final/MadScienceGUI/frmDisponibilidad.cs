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
    public partial class frmDisponibilidad : Form
    {
        TrabajadorBL objTrabajadorBL = new TrabajadorBL(); 
        TrabajadorEntity objTrabajador;
        HorarioBL objHorarioBL = new HorarioBL();
        DisponibilidadBL objDisponibilidadBL = new DisponibilidadBL();
        public frmDisponibilidad()
        {
            InitializeComponent();
        }
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private void frmDisponibilidad_Load(object sender, EventArgs e)
        {
            cboDia.SelectedIndex = 0;
            objTrabajador = objTrabajadorBL.Consultar(codigo);
            lblNombre.Text = objTrabajador.Nombre;
            Enlazar();


        }
        private void cboDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboHorario.DataSource = objHorarioBL.ListarPorDia(cboDia.Text);
            cboHorario.DisplayMember = "HorarioCompleto";
            cboHorario.ValueMember = "codigo";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int dia = cboDia.SelectedIndex + 1;
            int codigoHorario = Convert.ToInt32(cboHorario.SelectedValue.ToString());
            
            DisponibilidadEntity objDisponibilidad = new DisponibilidadEntity();
            objDisponibilidad.CodigoTrabajador=objTrabajador.Codigo;
            objDisponibilidad.CodigoHorario = codigoHorario;
            objDisponibilidad.FechaCreacion = DateTime.Now;
            objDisponibilidad.UsuarioCreacion = Sesion.UsuarioActual.Login;
            if (objDisponibilidadBL.ValidarDuplicidad(objDisponibilidad))
            {
                if (!objDisponibilidadBL.Agregar(objDisponibilidad))
                {
                    MessageBox.Show("Ha ocurrido un error, verifique los datos", "Aviso");
                }
                Enlazar();
            }
            else
            {
                MessageBox.Show("El horario ya ha sido ingresado", "Aviso");
            }
            
        }
        public void Enlazar()
        {
            lstLunes.DataSource = objDisponibilidadBL.ListarPorTrabajadorDia(objTrabajador.Codigo, "LUNES");
            lstLunes.DisplayMember = "Horario";
            lstLunes.ValueMember = "CodigoHorario";
            lstMartes.DataSource = objDisponibilidadBL.ListarPorTrabajadorDia(objTrabajador.Codigo, "MARTES");
            lstMartes.DisplayMember = "Horario";
            lstMartes.ValueMember = "CodigoHorario";
            lstMiercoles.DataSource = objDisponibilidadBL.ListarPorTrabajadorDia(objTrabajador.Codigo, "MIÉRCOLES");
            lstMiercoles.DisplayMember = "Horario";
            lstMiercoles.ValueMember = "CodigoHorario";
            lstJueves.DataSource = objDisponibilidadBL.ListarPorTrabajadorDia(objTrabajador.Codigo, "JUEVES");
            lstJueves.DisplayMember = "Horario";
            lstJueves.ValueMember = "CodigoHorario";
            lstViernes.DataSource = objDisponibilidadBL.ListarPorTrabajadorDia(objTrabajador.Codigo, "VIERNES");
            lstViernes.DisplayMember = "Horario";
            lstViernes.ValueMember = "CodigoHorario";
            lstSabado.DataSource = objDisponibilidadBL.ListarPorTrabajadorDia(objTrabajador.Codigo, "SÁBADO");
            lstSabado.DisplayMember = "Horario";
            lstSabado.ValueMember = "CodigoHorario";
            lstDomingo.DataSource = objDisponibilidadBL.ListarPorTrabajadorDia(objTrabajador.Codigo, "DOMINGO");
            lstDomingo.DisplayMember = "Horario";
            lstDomingo.ValueMember = "CodigoHorario";
        }

        public void EliminarEntrada(int codigoHorario, int codigoTrabajador)
        {
            DisponibilidadEntity objDispo = new DisponibilidadEntity();
            objDispo.CodigoHorario = codigoHorario;
            objDispo.CodigoTrabajador = codigoTrabajador;
            if (!objDisponibilidadBL.Eliminar(objDispo))
            {
                MessageBox.Show("Ha ocurrido un error", "Aviso");
            }
            Enlazar();
        }

        private void btnEliminarLunes_Click(object sender, EventArgs e)
        {
            if (lstLunes.SelectedItems.Count > 0)
            {
                int codigo = Convert.ToInt32(lstLunes.SelectedValue.ToString());
                EliminarEntrada(codigo, objTrabajador.Codigo);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lstMartes.SelectedItems.Count > 0)
            {
                int codigo = Convert.ToInt32(lstMartes.SelectedValue.ToString());
                EliminarEntrada(codigo, objTrabajador.Codigo);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lstMiercoles.SelectedItems.Count > 0)
            {
                int codigo = Convert.ToInt32(lstMiercoles.SelectedValue.ToString());
                EliminarEntrada(codigo, objTrabajador.Codigo);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lstJueves.SelectedItems.Count > 0)
            {
                int codigo = Convert.ToInt32(lstJueves.SelectedValue.ToString());
                EliminarEntrada(codigo, objTrabajador.Codigo);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lstViernes.SelectedItems.Count > 0)
            {
                int codigo = Convert.ToInt32(lstViernes.SelectedValue.ToString());
                EliminarEntrada(codigo, objTrabajador.Codigo);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lstSabado.SelectedItems.Count > 0)
            {
                int codigo = Convert.ToInt32(lstSabado.SelectedValue.ToString());
                EliminarEntrada(codigo, objTrabajador.Codigo);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (lstDomingo.SelectedItems.Count > 0)
            {
                int codigo = Convert.ToInt32(lstDomingo.SelectedValue.ToString());
                EliminarEntrada(codigo, objTrabajador.Codigo);
            }
        }


    }
}
