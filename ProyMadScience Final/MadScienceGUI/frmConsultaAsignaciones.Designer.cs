namespace MadScienceGUI
{
    partial class frmConsultaAsignaciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaAsignaciones));
            this.dgvConsultaAsignaciones = new System.Windows.Forms.DataGridView();
            this.nombreTrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreFiesta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreTienda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaAsignaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConsultaAsignaciones
            // 
            this.dgvConsultaAsignaciones.AllowUserToAddRows = false;
            this.dgvConsultaAsignaciones.AllowUserToDeleteRows = false;
            this.dgvConsultaAsignaciones.AllowUserToResizeColumns = false;
            this.dgvConsultaAsignaciones.AllowUserToResizeRows = false;
            this.dgvConsultaAsignaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultaAsignaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreTrabajador,
            this.nombreFiesta,
            this.nombreTienda,
            this.horaInicio,
            this.horaFin});
            this.dgvConsultaAsignaciones.Location = new System.Drawing.Point(12, 39);
            this.dgvConsultaAsignaciones.Name = "dgvConsultaAsignaciones";
            this.dgvConsultaAsignaciones.ReadOnly = true;
            this.dgvConsultaAsignaciones.RowHeadersVisible = false;
            this.dgvConsultaAsignaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsultaAsignaciones.Size = new System.Drawing.Size(750, 178);
            this.dgvConsultaAsignaciones.TabIndex = 0;
            // 
            // nombreTrabajador
            // 
            this.nombreTrabajador.DataPropertyName = "nombreTrabajador";
            this.nombreTrabajador.HeaderText = "Trabajador";
            this.nombreTrabajador.Name = "nombreTrabajador";
            this.nombreTrabajador.ReadOnly = true;
            this.nombreTrabajador.Width = 180;
            // 
            // nombreFiesta
            // 
            this.nombreFiesta.DataPropertyName = "nombreFiesta";
            this.nombreFiesta.HeaderText = "Fiesta";
            this.nombreFiesta.Name = "nombreFiesta";
            this.nombreFiesta.ReadOnly = true;
            this.nombreFiesta.Width = 180;
            // 
            // nombreTienda
            // 
            this.nombreTienda.DataPropertyName = "nombreTienda";
            this.nombreTienda.HeaderText = "Tienda";
            this.nombreTienda.Name = "nombreTienda";
            this.nombreTienda.ReadOnly = true;
            this.nombreTienda.Width = 180;
            // 
            // horaInicio
            // 
            this.horaInicio.DataPropertyName = "horaInicio";
            this.horaInicio.HeaderText = "Hora Inicio";
            this.horaInicio.Name = "horaInicio";
            this.horaInicio.ReadOnly = true;
            // 
            // horaFin
            // 
            this.horaFin.DataPropertyName = "horaFin";
            this.horaFin.HeaderText = "Hora fin";
            this.horaFin.Name = "horaFin";
            this.horaFin.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(58, 9);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(0, 13);
            this.lblFecha.TabIndex = 2;
            // 
            // frmConsultaAsignaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(773, 229);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvConsultaAsignaciones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmConsultaAsignaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Asignaciones";
            this.Load += new System.EventHandler(this.frmConsultaAsignaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaAsignaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConsultaAsignaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreTrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreFiesta;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreTienda;
        private System.Windows.Forms.DataGridViewTextBoxColumn horaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn horaFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFecha;
    }
}