namespace MadScienceGUI
{
    partial class frmManReservaCrea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManReservaCrea));
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTienda = new System.Windows.Forms.ComboBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNiño = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFechaCelebracion = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtHoraInicio = new System.Windows.Forms.TextBox();
            this.txtHoraFin = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboTorta = new System.Windows.Forms.ComboBox();
            this.cboSabor = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtObsTorta = new System.Windows.Forms.TextBox();
            this.txtNroInvitados = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtObsGeneral = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbFiestas = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cboTipoFiesta = new System.Windows.Forms.ComboBox();
            this.dgvFiesta = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fiesta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarFiesta = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.cboFiesta = new System.Windows.Forms.ComboBox();
            this.gbFiestas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiesta)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo Evento:";
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(98, 17);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(198, 21);
            this.cboTipo.TabIndex = 1;
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            this.cboTipo.SelectionChangeCommitted += new System.EventHandler(this.cboTipo_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tienda:";
            // 
            // cboTienda
            // 
            this.cboTienda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTienda.Enabled = false;
            this.cboTienda.FormattingEnabled = true;
            this.cboTienda.Location = new System.Drawing.Point(98, 49);
            this.cboTienda.Name = "cboTienda";
            this.cboTienda.Size = new System.Drawing.Size(198, 21);
            this.cboTienda.TabIndex = 3;
            this.cboTienda.SelectedIndexChanged += new System.EventHandler(this.cboTienda_SelectedIndexChanged);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(98, 77);
            this.txtDireccion.MaxLength = 100;
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(198, 58);
            this.txtDireccion.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Direccion:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Niño:";
            // 
            // txtNiño
            // 
            this.txtNiño.Location = new System.Drawing.Point(98, 147);
            this.txtNiño.Name = "txtNiño";
            this.txtNiño.Size = new System.Drawing.Size(198, 20);
            this.txtNiño.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "F.Nacimiento";
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNac.Location = new System.Drawing.Point(96, 173);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaNac.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Telefono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(98, 199);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(198, 20);
            this.txtTelefono.TabIndex = 11;
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(96, 225);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(200, 20);
            this.txtCelular.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Celular:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 254);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(98, 251);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(198, 20);
            this.txtCliente.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 281);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "F. Celebracion:";
            // 
            // dtpFechaCelebracion
            // 
            this.dtpFechaCelebracion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCelebracion.Location = new System.Drawing.Point(98, 277);
            this.dtpFechaCelebracion.Name = "dtpFechaCelebracion";
            this.dtpFechaCelebracion.Size = new System.Drawing.Size(198, 20);
            this.dtpFechaCelebracion.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 310);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Inicio(24H):";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 336);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Fin(24H):";
            // 
            // txtHoraInicio
            // 
            this.txtHoraInicio.Location = new System.Drawing.Point(98, 307);
            this.txtHoraInicio.Name = "txtHoraInicio";
            this.txtHoraInicio.Size = new System.Drawing.Size(198, 20);
            this.txtHoraInicio.TabIndex = 20;
            this.txtHoraInicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHoraInicio_KeyPress);
            // 
            // txtHoraFin
            // 
            this.txtHoraFin.Location = new System.Drawing.Point(96, 333);
            this.txtHoraFin.Name = "txtHoraFin";
            this.txtHoraFin.Size = new System.Drawing.Size(198, 20);
            this.txtHoraFin.TabIndex = 21;
            this.txtHoraFin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHoraFin_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 364);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Torta:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 391);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Sabor:";
            // 
            // cboTorta
            // 
            this.cboTorta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTorta.FormattingEnabled = true;
            this.cboTorta.Location = new System.Drawing.Point(98, 361);
            this.cboTorta.Name = "cboTorta";
            this.cboTorta.Size = new System.Drawing.Size(196, 21);
            this.cboTorta.TabIndex = 24;
            this.cboTorta.SelectedIndexChanged += new System.EventHandler(this.cboTorta_SelectedIndexChanged);
            // 
            // cboSabor
            // 
            this.cboSabor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSabor.FormattingEnabled = true;
            this.cboSabor.Location = new System.Drawing.Point(98, 388);
            this.cboSabor.Name = "cboSabor";
            this.cboSabor.Size = new System.Drawing.Size(196, 21);
            this.cboSabor.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 418);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Obs Torta:";
            // 
            // txtObsTorta
            // 
            this.txtObsTorta.Location = new System.Drawing.Point(98, 415);
            this.txtObsTorta.MaxLength = 100;
            this.txtObsTorta.Multiline = true;
            this.txtObsTorta.Name = "txtObsTorta";
            this.txtObsTorta.Size = new System.Drawing.Size(198, 53);
            this.txtObsTorta.TabIndex = 27;
            // 
            // txtNroInvitados
            // 
            this.txtNroInvitados.Location = new System.Drawing.Point(98, 474);
            this.txtNroInvitados.Name = "txtNroInvitados";
            this.txtNroInvitados.Size = new System.Drawing.Size(200, 20);
            this.txtNroInvitados.TabIndex = 29;
            this.txtNroInvitados.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroInvitados_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 477);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "# Invitados";
            // 
            // txtObsGeneral
            // 
            this.txtObsGeneral.Location = new System.Drawing.Point(100, 500);
            this.txtObsGeneral.MaxLength = 100;
            this.txtObsGeneral.Multiline = true;
            this.txtObsGeneral.Name = "txtObsGeneral";
            this.txtObsGeneral.Size = new System.Drawing.Size(198, 53);
            this.txtObsGeneral.TabIndex = 31;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(14, 503);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 13);
            this.label16.TabIndex = 30;
            this.label16.Text = "Obs Generales:";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(269, 584);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 32;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(363, 584);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 33;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // gbFiestas
            // 
            this.gbFiestas.Controls.Add(this.label18);
            this.gbFiestas.Controls.Add(this.cboTipoFiesta);
            this.gbFiestas.Controls.Add(this.dgvFiesta);
            this.gbFiestas.Controls.Add(this.btnAgregarFiesta);
            this.gbFiestas.Controls.Add(this.label17);
            this.gbFiestas.Controls.Add(this.cboFiesta);
            this.gbFiestas.Location = new System.Drawing.Point(323, 12);
            this.gbFiestas.Name = "gbFiestas";
            this.gbFiestas.Size = new System.Drawing.Size(375, 456);
            this.gbFiestas.TabIndex = 34;
            this.gbFiestas.TabStop = false;
            this.gbFiestas.Text = "Fiestas";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 21);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 13);
            this.label18.TabIndex = 5;
            this.label18.Text = "Tipo:";
            // 
            // cboTipoFiesta
            // 
            this.cboTipoFiesta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoFiesta.FormattingEnabled = true;
            this.cboTipoFiesta.Location = new System.Drawing.Point(54, 18);
            this.cboTipoFiesta.Name = "cboTipoFiesta";
            this.cboTipoFiesta.Size = new System.Drawing.Size(151, 21);
            this.cboTipoFiesta.TabIndex = 4;
            this.cboTipoFiesta.SelectedIndexChanged += new System.EventHandler(this.cboTipoFiesta_SelectedIndexChanged);
            // 
            // dgvFiesta
            // 
            this.dgvFiesta.AllowUserToAddRows = false;
            this.dgvFiesta.AllowUserToDeleteRows = false;
            this.dgvFiesta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiesta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar,
            this.Codigo,
            this.Fiesta});
            this.dgvFiesta.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvFiesta.Location = new System.Drawing.Point(9, 100);
            this.dgvFiesta.Name = "dgvFiesta";
            this.dgvFiesta.ReadOnly = true;
            this.dgvFiesta.RowHeadersVisible = false;
            this.dgvFiesta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiesta.Size = new System.Drawing.Size(360, 280);
            this.dgvFiesta.TabIndex = 3;
            this.dgvFiesta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiesta_CellContentClick);
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
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 50;
            // 
            // Fiesta
            // 
            this.Fiesta.DataPropertyName = "Nombre";
            this.Fiesta.HeaderText = "Fiesta";
            this.Fiesta.Name = "Fiesta";
            this.Fiesta.ReadOnly = true;
            this.Fiesta.Width = 250;
            // 
            // btnAgregarFiesta
            // 
            this.btnAgregarFiesta.Image = global::MadScienceGUI.Properties.Resources.ademas;
            this.btnAgregarFiesta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarFiesta.Location = new System.Drawing.Point(211, 43);
            this.btnAgregarFiesta.Name = "btnAgregarFiesta";
            this.btnAgregarFiesta.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarFiesta.TabIndex = 2;
            this.btnAgregarFiesta.Text = "Agregar";
            this.btnAgregarFiesta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarFiesta.UseVisualStyleBackColor = true;
            this.btnAgregarFiesta.Click += new System.EventHandler(this.btnAgregarFiesta_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 48);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "Fiestas:";
            // 
            // cboFiesta
            // 
            this.cboFiesta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiesta.FormattingEnabled = true;
            this.cboFiesta.Location = new System.Drawing.Point(54, 45);
            this.cboFiesta.Name = "cboFiesta";
            this.cboFiesta.Size = new System.Drawing.Size(151, 21);
            this.cboFiesta.TabIndex = 0;
            // 
            // frmManReservaCrea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(718, 619);
            this.Controls.Add(this.gbFiestas);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.txtObsGeneral);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtNroInvitados);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtObsTorta);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cboSabor);
            this.Controls.Add(this.cboTorta);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtHoraFin);
            this.Controls.Add(this.txtHoraInicio);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpFechaCelebracion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCelular);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpFechaNac);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNiño);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.cboTienda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmManReservaCrea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Reserva";
            this.Load += new System.EventHandler(this.frmManReservaCrea_Load);
            this.gbFiestas.ResumeLayout(false);
            this.gbFiestas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiesta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTienda;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNiño;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpFechaCelebracion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtHoraInicio;
        private System.Windows.Forms.TextBox txtHoraFin;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboTorta;
        private System.Windows.Forms.ComboBox cboSabor;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtObsTorta;
        private System.Windows.Forms.TextBox txtNroInvitados;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtObsGeneral;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox gbFiestas;
        private System.Windows.Forms.DataGridView dgvFiesta;
        private System.Windows.Forms.Button btnAgregarFiesta;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cboFiesta;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cboTipoFiesta;
        private System.Windows.Forms.DataGridViewImageColumn Eliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fiesta;
    }
}