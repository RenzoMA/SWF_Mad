namespace MadScienceGUI
{
    partial class frmManReservaAsignarTrabajador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManReservaAsignarTrabajador));
            this.label1 = new System.Windows.Forms.Label();
            this.cboTrabajador = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTipoPago = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.cbMovilidad = new System.Windows.Forms.CheckBox();
            this.groupBoxMovilidad = new System.Windows.Forms.GroupBox();
            this.txtMontoMovilidad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboMovilidad = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblZona = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblHorario = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvConsultaAsignaciones = new System.Windows.Forms.DataGridView();
            this.nombreTienda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreFiesta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvAsignacion = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreTrabajador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoMovilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreTipoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxMovilidad.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaAsignaciones)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignacion)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Trabajador:";
            // 
            // cboTrabajador
            // 
            this.cboTrabajador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrabajador.FormattingEnabled = true;
            this.cboTrabajador.Location = new System.Drawing.Point(93, 72);
            this.cboTrabajador.Name = "cboTrabajador";
            this.cboTrabajador.Size = new System.Drawing.Size(385, 21);
            this.cboTrabajador.TabIndex = 2;
            this.cboTrabajador.SelectedIndexChanged += new System.EventHandler(this.cboTrabajador_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tipo pago:";
            // 
            // cboTipoPago
            // 
            this.cboTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPago.FormattingEnabled = true;
            this.cboTipoPago.Location = new System.Drawing.Point(93, 98);
            this.cboTipoPago.Name = "cboTipoPago";
            this.cboTipoPago.Size = new System.Drawing.Size(385, 21);
            this.cboTipoPago.TabIndex = 4;
            this.cboTipoPago.SelectedIndexChanged += new System.EventHandler(this.cboTipoPago_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Monto:";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(93, 124);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            this.txtMonto.Size = new System.Drawing.Size(385, 20);
            this.txtMonto.TabIndex = 6;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(1007, 12);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 8;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Visible = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // cbMovilidad
            // 
            this.cbMovilidad.AutoSize = true;
            this.cbMovilidad.Location = new System.Drawing.Point(93, 150);
            this.cbMovilidad.Name = "cbMovilidad";
            this.cbMovilidad.Size = new System.Drawing.Size(83, 17);
            this.cbMovilidad.TabIndex = 15;
            this.cbMovilidad.Text = "¿Movilidad?";
            this.cbMovilidad.UseVisualStyleBackColor = true;
            this.cbMovilidad.CheckedChanged += new System.EventHandler(this.cbMovilidad_CheckedChanged);
            // 
            // groupBoxMovilidad
            // 
            this.groupBoxMovilidad.Controls.Add(this.txtMontoMovilidad);
            this.groupBoxMovilidad.Controls.Add(this.label5);
            this.groupBoxMovilidad.Controls.Add(this.cboMovilidad);
            this.groupBoxMovilidad.Controls.Add(this.label4);
            this.groupBoxMovilidad.Location = new System.Drawing.Point(191, 150);
            this.groupBoxMovilidad.Name = "groupBoxMovilidad";
            this.groupBoxMovilidad.Size = new System.Drawing.Size(287, 77);
            this.groupBoxMovilidad.TabIndex = 16;
            this.groupBoxMovilidad.TabStop = false;
            this.groupBoxMovilidad.Text = "Movilidad";
            this.groupBoxMovilidad.Visible = false;
            // 
            // txtMontoMovilidad
            // 
            this.txtMontoMovilidad.Location = new System.Drawing.Point(93, 46);
            this.txtMontoMovilidad.Name = "txtMontoMovilidad";
            this.txtMontoMovilidad.ReadOnly = true;
            this.txtMontoMovilidad.Size = new System.Drawing.Size(166, 20);
            this.txtMontoMovilidad.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "S/.";
            // 
            // cboMovilidad
            // 
            this.cboMovilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMovilidad.FormattingEnabled = true;
            this.cboMovilidad.Location = new System.Drawing.Point(93, 19);
            this.cboMovilidad.Name = "cboMovilidad";
            this.cboMovilidad.Size = new System.Drawing.Size(166, 21);
            this.cboMovilidad.TabIndex = 16;
            this.cboMovilidad.SelectedIndexChanged += new System.EventHandler(this.cboMovilidad_SelectedIndexChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tipo:";
            // 
            // lblZona
            // 
            this.lblZona.AutoSize = true;
            this.lblZona.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZona.Location = new System.Drawing.Point(10, 12);
            this.lblZona.Name = "lblZona";
            this.lblZona.Size = new System.Drawing.Size(58, 24);
            this.lblZona.TabIndex = 17;
            this.lblZona.Text = "Zona";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Eliminar";
            this.dataGridViewImageColumn1.Image = global::MadScienceGUI.Properties.Resources.remove;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::MadScienceGUI.Properties.Resources.ademas;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(403, 233);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Horario:";
            // 
            // lblHorario
            // 
            this.lblHorario.AutoSize = true;
            this.lblHorario.Location = new System.Drawing.Point(90, 46);
            this.lblHorario.Name = "lblHorario";
            this.lblHorario.Size = new System.Drawing.Size(0, 13);
            this.lblHorario.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvConsultaAsignaciones);
            this.groupBox1.Location = new System.Drawing.Point(484, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(598, 155);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fiestas en el dia del trabajador seleccionado";
            // 
            // dgvConsultaAsignaciones
            // 
            this.dgvConsultaAsignaciones.AllowUserToAddRows = false;
            this.dgvConsultaAsignaciones.AllowUserToDeleteRows = false;
            this.dgvConsultaAsignaciones.AllowUserToResizeColumns = false;
            this.dgvConsultaAsignaciones.AllowUserToResizeRows = false;
            this.dgvConsultaAsignaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultaAsignaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreTienda,
            this.horaInicio,
            this.horaFin,
            this.nombreFiesta});
            this.dgvConsultaAsignaciones.Location = new System.Drawing.Point(16, 22);
            this.dgvConsultaAsignaciones.Name = "dgvConsultaAsignaciones";
            this.dgvConsultaAsignaciones.ReadOnly = true;
            this.dgvConsultaAsignaciones.RowHeadersVisible = false;
            this.dgvConsultaAsignaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsultaAsignaciones.Size = new System.Drawing.Size(564, 118);
            this.dgvConsultaAsignaciones.TabIndex = 22;
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
            // nombreFiesta
            // 
            this.nombreFiesta.DataPropertyName = "nombreFiesta";
            this.nombreFiesta.HeaderText = "Fiesta";
            this.nombreFiesta.Name = "nombreFiesta";
            this.nombreFiesta.ReadOnly = true;
            this.nombreFiesta.Width = 180;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvAsignacion);
            this.groupBox2.Location = new System.Drawing.Point(14, 262);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1068, 215);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trabajadores asignados:";
            // 
            // dgvAsignacion
            // 
            this.dgvAsignacion.AllowUserToAddRows = false;
            this.dgvAsignacion.AllowUserToDeleteRows = false;
            this.dgvAsignacion.AllowUserToResizeColumns = false;
            this.dgvAsignacion.AllowUserToResizeRows = false;
            this.dgvAsignacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsignacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar,
            this.Codigo,
            this.nombreTrabajador,
            this.monto,
            this.montoMovilidad,
            this.nombreTipoPago,
            this.fechaCreacion});
            this.dgvAsignacion.Location = new System.Drawing.Point(79, 31);
            this.dgvAsignacion.Name = "dgvAsignacion";
            this.dgvAsignacion.ReadOnly = true;
            this.dgvAsignacion.RowHeadersVisible = false;
            this.dgvAsignacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsignacion.Size = new System.Drawing.Size(787, 167);
            this.dgvAsignacion.TabIndex = 23;
            this.dgvAsignacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAsignacion_CellContentClick_1);
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Image = global::MadScienceGUI.Properties.Resources.remove;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Width = 50;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 50;
            // 
            // nombreTrabajador
            // 
            this.nombreTrabajador.DataPropertyName = "nombreTrabajador";
            this.nombreTrabajador.HeaderText = "Trabajador";
            this.nombreTrabajador.Name = "nombreTrabajador";
            this.nombreTrabajador.ReadOnly = true;
            this.nombreTrabajador.Width = 200;
            // 
            // monto
            // 
            this.monto.DataPropertyName = "monto";
            this.monto.HeaderText = "Monto";
            this.monto.Name = "monto";
            this.monto.ReadOnly = true;
            // 
            // montoMovilidad
            // 
            this.montoMovilidad.DataPropertyName = "MontoMovilidad";
            this.montoMovilidad.HeaderText = "Movilidad";
            this.montoMovilidad.Name = "montoMovilidad";
            this.montoMovilidad.ReadOnly = true;
            this.montoMovilidad.Width = 70;
            // 
            // nombreTipoPago
            // 
            this.nombreTipoPago.DataPropertyName = "nombreTipoPago";
            this.nombreTipoPago.HeaderText = "Tipo";
            this.nombreTipoPago.Name = "nombreTipoPago";
            this.nombreTipoPago.ReadOnly = true;
            this.nombreTipoPago.Width = 150;
            // 
            // fechaCreacion
            // 
            this.fechaCreacion.DataPropertyName = "fechaCreacion";
            this.fechaCreacion.HeaderText = "Fecha Creacion";
            this.fechaCreacion.Name = "fechaCreacion";
            this.fechaCreacion.ReadOnly = true;
            this.fechaCreacion.Width = 150;
            // 
            // frmManReservaAsignarTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 498);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblHorario);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblZona);
            this.Controls.Add(this.groupBoxMovilidad);
            this.Controls.Add(this.cbMovilidad);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTipoPago);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboTrabajador);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmManReservaAsignarTrabajador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignar Trabajador";
            this.Load += new System.EventHandler(this.frmManReservaAsignarTrabajador_Load);
            this.groupBoxMovilidad.ResumeLayout(false);
            this.groupBoxMovilidad.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaAsignaciones)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTrabajador;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTipoPago;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.CheckBox cbMovilidad;
        private System.Windows.Forms.GroupBox groupBoxMovilidad;
        private System.Windows.Forms.TextBox txtMontoMovilidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboMovilidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblZona;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblHorario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvConsultaAsignaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreTienda;
        private System.Windows.Forms.DataGridViewTextBoxColumn horaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn horaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreFiesta;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvAsignacion;
        private System.Windows.Forms.DataGridViewImageColumn Eliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreTrabajador;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoMovilidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreTipoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCreacion;
    }
}