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
using System.IO;

namespace MadScienceGUI
{
    public partial class frmManReserva : Form
    {

        TipoEventoBL servicioEvento = new TipoEventoBL();
        TiendaBL servicioTienda = new TiendaBL();
        ReservaBL servicioReserva = new ReservaBL();
        AsignacionBL servicioAsignacion = new AsignacionBL();
        public static string idTienda = "";

        public static BackgroundWorker back;

        public frmManReserva()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmManReservaCrea frm = new frmManReservaCrea();
            frm.ShowDialog();
            btnBuscar.PerformClick();
        }

        private void frmManReserva_Load(object sender, EventArgs e)
        {
            back = backgroundWorker1;
            dgvReservas.AutoGenerateColumns = false;
            cboEstado.SelectedIndex = 0;
            cboTipo.DisplayMember = "Nombre";
            cboTipo.ValueMember = "Codigo";
            cboTipo.DataSource = servicioEvento.ListarTodoOpciones();
            
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipo.SelectedIndex == 1)
            {
                cboTienda.Enabled = true;
                cboTienda.DataSource = servicioTienda.ListarTodoOpciones();
                cboTienda.DisplayMember = "nombre";
                cboTienda.ValueMember = "codigo";
            }
            else
            {
                cboTienda.DataSource = null;
                cboTienda.Enabled = false;
            }
        }

        private void cboTienda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            servicioReserva = new ReservaBL();
            String estado = "";
            switch (cboEstado.SelectedIndex)
            {
                case 0: estado = "T"; break;//Todos
                case 1: estado = "P"; break;//Pendiente
                case 2: estado = "A"; break;//Asignados
                case 3: estado = "E"; break;//En proceso
                case 4: estado = "O"; break;// Postergados
            }

            int codigoTienda = 0;
            if (cboTienda.Enabled == true)
            {
                codigoTienda = Convert.ToInt16(cboTienda.SelectedValue.ToString());
            }

            int tipoEvento = 0;
            if (cboTipo.SelectedIndex != 0)
            {
                tipoEvento = Convert.ToInt16(cboTipo.SelectedValue.ToString());
            }
            dgvReservas.DataSource = servicioReserva.ListadoReserva(dtpInicio.Value.Date, dtpFin.Value.Date, codigoTienda, estado, tipoEvento);
            gestionaResaltados(dgvReservas);
            lblCantidad.Text = "Total de registros: "+dgvReservas.Rows.Count.ToString();
        }
        private void gestionaResaltados(DataGridView visor)
        {
            for (int i = 0; i < visor.Rows.Count; i++)
            {
                for (int x = 0; x < visor.Columns.Count; x++)
                {
                    if (visor.Rows[i].Cells["ESTADO"].Value.ToString() == "PENDIENTE")
                    {
                        visor.Rows[i].Cells[x].Style.ForeColor = System.Drawing.Color.Blue;
                    }
                    if (visor.Rows[i].Cells["ESTADO"].Value.ToString() == "EN PROCESO")
                    {
                        visor.Rows[i].Cells[x].Style.ForeColor = System.Drawing.Color.Brown;
                    }
                    if (visor.Rows[i].Cells["ESTADO"].Value.ToString() == "POSTERGADO")
                    {
                        visor.Rows[i].Cells[x].Style.ForeColor = System.Drawing.Color.Purple;
                    }
                    if (visor.Rows[i].Cells["fiestaDoble"].Value.ToString() == "SI")
                    {
                        visor.Rows[i].Cells[x].Style.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
        private void dgvReservas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int codigo = Convert.ToInt16(dgvReservas.Rows[e.RowIndex].Cells["clCodigo"].Value.ToString());
                    frmManReservaActualiza frm = new frmManReservaActualiza();
                    frm.Codigo = codigo;
                    frm.ShowDialog();
                    servicioAsignacion.ActualizarReserva(codigo);
                    btnBuscar.PerformClick();

            }
            if (e.ColumnIndex == 1)
            {
                int codigo = Convert.ToInt16(dgvReservas.Rows[e.RowIndex].Cells["clCodigo"].Value.ToString());
                ReservaEntity rese = servicioReserva.Consultar(codigo);
                if (rese.Estado != "O")
                {
                    frmManReservaAsigna frm = new frmManReservaAsigna();
                    frm.Codigo = codigo;
                    frm.ShowDialog();
                    servicioAsignacion.ActualizarReserva(codigo);
                    btnBuscar.PerformClick();
                }
                else
                {
                    MessageBox.Show("La reserva esta postergada, no es posible ingresar", "Aviso");
                }

            }
            if (e.ColumnIndex == 2)
            {
                int codigo = Convert.ToInt16(dgvReservas.Rows[e.RowIndex].Cells["clCodigo"].Value.ToString());
                ReservaEntity rese = servicioReserva.Consultar(codigo);
                if (rese.FechaCelebracion >= DateTime.Now.Date.AddDays(-5))
                {
                    if (rese.Estado == "P")
                    {
                        DialogResult dialogo = MessageBox.Show("Se eliminara la reserva. ¿Desea continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogo == DialogResult.Yes)
                        {
                            DetalleReservaBL objDetalle = new DetalleReservaBL();
                            if (servicioReserva.Eliminar(codigo))
                            {
                                MessageBox.Show("Proceso realizado correctamente", "Aviso");
                                btnBuscar.PerformClick();
                            }
                            else
                            {
                                MessageBox.Show("Ha ocurrido un error", "Aviso");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Solo se pueden eliminar reservas con estado pendiente", "Aviso");
                    }
                }
                else
                {
                    MessageBox.Show("Solo se puede eliminar reservas de maximo 5 dias hacia atras", "Aviso");
                }

            }

        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
             try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Seleccione archivo";
                openFileDialog1.Multiselect = false;
                openFileDialog1.FileName = "";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                DialogResult resultado = openFileDialog1.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    fileName = openFileDialog1.FileName;
                    pictureBox1.Visible = true;
                    backgroundWorker1.RunWorkerAsync();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        String fileName;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            string file = fileName;
            string ext = Path.GetExtension(file);
            string name = Path.GetFileName(file);

            DataSet dts = servicioReserva.CargarArchivo(file, ext);
            frmSeleccionaTiendaImportacion objFrmSeleccion = new frmSeleccionaTiendaImportacion();
            objFrmSeleccion.ShowDialog();
            if (!idTienda.Equals(""))
            {
                TiendaEntity objTienda = servicioTienda.Consultar(Convert.ToInt16(idTienda));
                foreach (DataRow dtr in dts.Tables[0].Rows)
                {
 
                }
                String mensaje = servicioReserva.ValidarArchivo(dts, Sesion.UsuarioActual, objTienda);
                if (mensaje == "ok")
                {
                    idTienda = "";
                    MessageBox.Show("Proceso correcto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(mensaje, "Aviso");
                }
            }
          
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
        }
    }
}
