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
    public partial class frmRptPagoMovilidad : Form
    {
        AsignacionBL asiginacionBL;
        public frmRptPagoMovilidad()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpInicio.Value.Date;
            DateTime fechaFin = dtpFin.Value.Date.Add(TimeSpan.Parse("23:59:59"));
            asiginacionBL = new AsignacionBL();

            try
            {
                reportViewer1.ProcessingMode = ProcessingMode.Local;

                reportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource Reporte = new ReportDataSource("DataSet1", asiginacionBL.ReportePagoMovilidad(fechaInicio, fechaFin));

                reportViewer1.LocalReport.DataSources.Add(Reporte);

                reportViewer1.LocalReport.ReportEmbeddedResource = "MadScienceGUI.reportPagoMovilidad.rdlc";

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
    }
}
