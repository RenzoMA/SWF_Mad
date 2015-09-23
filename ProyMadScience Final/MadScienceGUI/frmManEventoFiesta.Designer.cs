namespace MadScienceGUI
{
    partial class frmManEventoFiesta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManEventoFiesta));
            this.lblFiesta = new System.Windows.Forms.Label();
            this.dgvEventoFiesta = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.codigoTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTipoEvento = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventoFiesta)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFiesta
            // 
            this.lblFiesta.AutoSize = true;
            this.lblFiesta.Location = new System.Drawing.Point(12, 18);
            this.lblFiesta.Name = "lblFiesta";
            this.lblFiesta.Size = new System.Drawing.Size(0, 13);
            this.lblFiesta.TabIndex = 3;
            // 
            // dgvEventoFiesta
            // 
            this.dgvEventoFiesta.AllowUserToAddRows = false;
            this.dgvEventoFiesta.AllowUserToDeleteRows = false;
            this.dgvEventoFiesta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventoFiesta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.codigoTipo,
            this.nombreTipo,
            this.FechaCreacion});
            this.dgvEventoFiesta.Location = new System.Drawing.Point(12, 109);
            this.dgvEventoFiesta.Name = "dgvEventoFiesta";
            this.dgvEventoFiesta.ReadOnly = true;
            this.dgvEventoFiesta.RowHeadersVisible = false;
            this.dgvEventoFiesta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEventoFiesta.Size = new System.Drawing.Size(482, 189);
            this.dgvEventoFiesta.TabIndex = 4;
            this.dgvEventoFiesta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEventoFiesta_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Eliminar";
            this.Column1.Image = global::MadScienceGUI.Properties.Resources.remove;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // codigoTipo
            // 
            this.codigoTipo.DataPropertyName = "CodigoTipoEvento";
            this.codigoTipo.HeaderText = "Codigo";
            this.codigoTipo.Name = "codigoTipo";
            this.codigoTipo.ReadOnly = true;
            this.codigoTipo.Width = 50;
            // 
            // nombreTipo
            // 
            this.nombreTipo.DataPropertyName = "NombreEvento";
            this.nombreTipo.HeaderText = "Nombre";
            this.nombreTipo.Name = "nombreTipo";
            this.nombreTipo.ReadOnly = true;
            this.nombreTipo.Width = 180;
            // 
            // FechaCreacion
            // 
            this.FechaCreacion.DataPropertyName = "FechaCreacion";
            this.FechaCreacion.HeaderText = "Fecha Creacion";
            this.FechaCreacion.Name = "FechaCreacion";
            this.FechaCreacion.ReadOnly = true;
            this.FechaCreacion.Width = 180;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Disponible en:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tipo:";
            // 
            // cboTipoEvento
            // 
            this.cboTipoEvento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoEvento.FormattingEnabled = true;
            this.cboTipoEvento.Location = new System.Drawing.Point(59, 57);
            this.cboTipoEvento.Name = "cboTipoEvento";
            this.cboTipoEvento.Size = new System.Drawing.Size(166, 21);
            this.cboTipoEvento.TabIndex = 7;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::MadScienceGUI.Properties.Resources.ademas;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(231, 55);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Fiesta:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(59, 28);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(166, 20);
            this.txtNombre.TabIndex = 10;
            // 
            // frmManEventoFiesta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(510, 310);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.cboTipoEvento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvEventoFiesta);
            this.Controls.Add(this.lblFiesta);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmManEventoFiesta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evento/Fiesta";
            this.Load += new System.EventHandler(this.frmManEventoFiesta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventoFiesta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFiesta;
        private System.Windows.Forms.DataGridView dgvEventoFiesta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTipoEvento;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCreacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;

    }
}