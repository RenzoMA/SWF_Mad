using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MadScienceBL;
using Microsoft.Reporting.WinForms;

namespace MadScienceGUI
{
    public partial class frmRptDetalleFiestaTienda : Form
    {
        TiendaBL tiendaBL = new TiendaBL();
        ReservaBL reservaBL;
        public frmRptDetalleFiestaTienda()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpInicio.Value.Date;
            DateTime fechaFin = dtpFin.Value.Date.Add(TimeSpan.Parse("23:59:59"));
            int codigoTienda = Convert.ToInt16(cboTienda.SelectedValue.ToString());
            reservaBL = new ReservaBL();

            try
            {
                reportViewer1.ProcessingMode = ProcessingMode.Local;

                reportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource Reporte = new ReportDataSource("dateFiestaTienda", reservaBL.ReporteTiendaDetalle(fechaInicio, fechaFin, codigoTienda));

                reportViewer1.LocalReport.DataSources.Add(Reporte);

                reportViewer1.LocalReport.ReportEmbeddedResource = "MadScienceGUI.reportTiendaDetalle.rdlc";

                List<ReportParameter> parametros = new List<ReportParameter>();
                parametros.Add(new ReportParameter("FechaInicio", "" + fechaInicio));
                parametros.Add(new ReportParameter("FechaFin", "" + fechaFin));
                //Añado parametros al reportviewer
                this.reportViewer1.LocalReport.SetParameters(parametros);


                reportViewer1.RefreshReport();

                reportViewer1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmRptDetalleFiestaTienda_Load(object sender, EventArgs e)
        {
            cboTienda.DataSource = tiendaBL.ListarTodoOpciones();
            cboTienda.DisplayMember = "nombre";
            cboTienda.ValueMember = "codigo";

            this.reportViewer1.RefreshReport();
        }
    }
}
