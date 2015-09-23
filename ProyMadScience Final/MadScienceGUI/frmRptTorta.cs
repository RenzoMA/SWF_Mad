using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MadScienceBL;

namespace MadScienceGUI
{
    public partial class frmRptTorta : Form
    {
        public frmRptTorta()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = dtpInicio.Value.Date;
                DateTime fechaFin = dtpFin.Value.Date.Add(TimeSpan.Parse("23:59:59"));
                ReservaBL reservaBL = new ReservaBL();

                reportViewer1.ProcessingMode = ProcessingMode.Local;

                reportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource Reporte = new ReportDataSource("dataReserva", reservaBL.ReporteTorta(fechaInicio,fechaFin));

                reportViewer1.LocalReport.DataSources.Add(Reporte);

                reportViewer1.LocalReport.ReportEmbeddedResource = "MadScienceGUI.reportTorta.rdlc";

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
