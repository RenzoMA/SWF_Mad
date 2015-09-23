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
    public partial class frmManReservaAsignarTrabajador : Form
    {
        TipoPagoBL servicioTipoPago = new TipoPagoBL();
        TrabajadorBL servicioTrabajador = new TrabajadorBL();
        DetalleReservaBL servicioDetalle = new DetalleReservaBL();
        PagoFiestaEntity objPagoFiesta;
        PagoFiestaBL servicioPagoFiesta = new PagoFiestaBL();
        PagoFiestaEntity consultor = new PagoFiestaEntity();
        DetalleReservaEntity objDetalle;
        ReservaEntity objReserva;
        ReservaBL servicioReserva = new ReservaBL();
        AsignacionBL servicioAsignacion = new AsignacionBL();
        TipoMovilidadBL servicioMovilidad = new TipoMovilidadBL();
        TiendaBL servicioTienda = new TiendaBL();
        ZonaBL servicioZona = new ZonaBL();

        public frmManReservaAsignarTrabajador()
        {
            InitializeComponent();
        }
        private int codigoDetalle;

        public int CodigoDetalle
        {
            get { return codigoDetalle; }
            set { codigoDetalle = value; }
        }

        private int codigoReserva;

        public int CodigoReserva
        {
            get { return codigoReserva; }
            set { codigoReserva = value; }
        }

        private void frmManReservaAsignarTrabajador_Load(object sender, EventArgs e)
        {
            dgvAsignacion.AutoGenerateColumns = false;
            objReserva = servicioReserva.Consultar(codigoReserva);

            cboTipoPago.DisplayMember = "nombre";
            cboTipoPago.ValueMember = "codigo";
            objDetalle = servicioDetalle.Consultar(codigoDetalle);
            cboTipoPago.DataSource = servicioTipoPago.ListarParaAsignacion(objDetalle.CodigoFiesta);
            if (objReserva.CodigoTienda != null)
            {
                int? codigo = servicioTienda.Consultar((int)objReserva.CodigoTienda).CodigoZona;
                if (codigo != null)
                {
                    lblZona.Text = servicioZona.Consultar((int)codigo).Nombre;
                }
            }


            if (cboTipoPago.Items.Count != 0)
            {
                consultor.CodigoFiesta = objDetalle.CodigoFiesta;
                consultor.CodigoTipoPago = Convert.ToInt16(cboTipoPago.SelectedValue.ToString());

                objPagoFiesta = servicioPagoFiesta.Consultar(consultor);
                txtMonto.Text = objPagoFiesta.Monto.ToString();

               // cboTrabajador.DisplayMember = "nombreTrabajador";
               // cboTrabajador.ValueMember = "codigoTrabajador";
               // cboTrabajador.DataSource = servicioTrabajador.ListarTrabajadorAsignaciones(objReserva.FechaCelebracion, objReserva.FechaCelebracion.ToString("dddd").ToUpper(), objReserva.HoraInicio, objReserva.HoraFin, objDetalle.CodigoFiesta, objReserva.Codigo);
                Enlazar();
            }
            else
            {
                MessageBox.Show("No existen pagos asociados a esta fiesta", "Aviso");
            }

            cboMovilidad.DisplayMember = "des_nombre";
            cboMovilidad.ValueMember = "codigoMovilidad";
            cboMovilidad.DataSource = servicioMovilidad.listarTodos();
            
            if (cboMovilidad.Items.Count != 0)
            {
                
                txtMontoMovilidad.Text = servicioMovilidad.Consultar(Convert.ToInt16(cboMovilidad.SelectedValue.ToString())).Monto.ToString();

            }
            else
            {
                MessageBox.Show("No se han registrado movilidades", "Aviso");
            }
        }

        private void cboTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            consultor.CodigoFiesta = objDetalle.CodigoFiesta;
            consultor.CodigoTipoPago = Convert.ToInt16(cboTipoPago.SelectedValue.ToString());

            objPagoFiesta = servicioPagoFiesta.Consultar(consultor);
            txtMonto.Text = objPagoFiesta.Monto.ToString();
        }
        public void Enlazar()
        {
            servicioAsignacion = new AsignacionBL();
            dgvAsignacion.DataSource = servicioAsignacion.ListarAsignado(codigoDetalle);
            servicioTrabajador = new TrabajadorBL();
            cboTrabajador.DisplayMember = "nombreTrabajador";
            cboTrabajador.ValueMember = "codigoTrabajador";
            cboTrabajador.DataSource = servicioTrabajador.ListarTrabajadorAsignaciones(objReserva.FechaCelebracion, objReserva.FechaCelebracion.ToString("dddd").ToUpper(), objReserva.HoraInicio, objReserva.HoraFin, objDetalle.CodigoFiesta, objReserva.Codigo);
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (objReserva.FechaCelebracion >= DateTime.Now.Date.AddDays(-6))
            {
                if (cboTrabajador.SelectedIndex != -1)
                {
                    AsignacionEntity objAsignacion = new AsignacionEntity();
                    objAsignacion.CodigoDetalle = objDetalle.Codigo;
                    objAsignacion.CodigoTrabajador = Convert.ToInt16(cboTrabajador.SelectedValue.ToString());
                    objAsignacion.CodigoTipoPago = Convert.ToInt16(cboTipoPago.SelectedValue.ToString());
                    objAsignacion.Monto = Convert.ToDouble(txtMonto.Text);
                    objAsignacion.FechaReserva = objReserva.FechaCelebracion;
                    objAsignacion.FechaCreacion = DateTime.Now;
                    objAsignacion.UserCrea = Sesion.UsuarioActual.Login;
                    objAsignacion.HoraInicio = objReserva.HoraInicio;
                    objAsignacion.HoraFin = objReserva.HoraFin;
                    objAsignacion.CodigoReserva = objReserva.Codigo;
                    if (cbMovilidad.Checked)
                    {
                        objAsignacion.MontoMovilidad = Convert.ToDouble(txtMontoMovilidad.Text);
                        objAsignacion.TipoMovilidad = Convert.ToInt16(cboMovilidad.SelectedValue.ToString());
                    }
                    else
                    {
                        objAsignacion.MontoMovilidad = 0;
                        objAsignacion.TipoMovilidad = null;
                    }
                        
                    if (servicioAsignacion.Agregar(objAsignacion))
                    {
                        MessageBox.Show("Proceso realizado correctamente", "Aviso");
                        Enlazar();
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error", "Aviso");
                    }
                }
                else
                {
                    MessageBox.Show("No existen trabajadores disponibles", "Aviso");
                }
            }
            else
            {
                MessageBox.Show("Ya no se permite realizar cambios", "Aviso");
            }
            
        }

        private void dgvAsignacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (objReserva.FechaCelebracion >= DateTime.Now.Date)
                {
                    int codigo = Convert.ToInt16(dgvAsignacion.Rows[e.ColumnIndex].Cells["Codigo"].Value.ToString());
                    if (servicioAsignacion.Eliminar(codigo))
                    {
                        MessageBox.Show("Eliminado", "Aviso");
                        Enlazar();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error", "Aviso");
                    }
                }
                else
                {
                    MessageBox.Show("Ya no se permite realizar cambios", "Aviso");
                }

            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (cboTrabajador.SelectedIndex != -1)
            {
                frmConsultaAsignaciones frm = new frmConsultaAsignaciones();
                frm.FechaCelebracion = objReserva.FechaCelebracion;
                frm.CodigoTrabajador = Convert.ToInt16(cboTrabajador.SelectedValue.ToString());
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado un trabajador", "Aviso");
            }

        }



        private void cboMovilidad_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txtMontoMovilidad.Text = servicioMovilidad.Consultar(Convert.ToInt16(cboMovilidad.SelectedValue.ToString())).Monto.ToString();
        }

        private void cbMovilidad_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMovilidad.Checked)
            {
                groupBoxMovilidad.Visible = true;
            }
            else
            {
                groupBoxMovilidad.Visible = false;

            }
        }



    }
}
