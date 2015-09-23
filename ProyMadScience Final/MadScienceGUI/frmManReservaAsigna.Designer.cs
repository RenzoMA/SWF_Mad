namespace MadScienceGUI
{
    partial class frmManReservaAsigna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManReservaAsigna));
            this.dgvFiestas = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.Asignar = new System.Windows.Forms.DataGridViewImageColumn();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fiestaNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadAsignados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiestas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFiestas
            // 
            this.dgvFiestas.AllowUserToAddRows = false;
            this.dgvFiestas.AllowUserToDeleteRows = false;
            this.dgvFiestas.AllowUserToResizeColumns = false;
            this.dgvFiestas.AllowUserToResizeRows = false;
            this.dgvFiestas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiestas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar,
            this.Asignar,
            this.cod,
            this.fiestaNombre,
            this.CantidadAsignados});
            this.dgvFiestas.Location = new System.Drawing.Point(15, 43);
            this.dgvFiestas.Name = "dgvFiestas";
            this.dgvFiestas.ReadOnly = true;
            this.dgvFiestas.RowHeadersVisible = false;
            this.dgvFiestas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiestas.Size = new System.Drawing.Size(555, 277);
            this.dgvFiestas.TabIndex = 0;
            this.dgvFiestas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiestas_CellContentClick);
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Image = global::MadScienceGUI.Properties.Resources.remove;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Width = 50;
            // 
            // Asignar
            // 
            this.Asignar.HeaderText = "Asignar";
            this.Asignar.Image = global::MadScienceGUI.Properties.Resources.asign;
            this.Asignar.Name = "Asignar";
            this.Asignar.ReadOnly = true;
            this.Asignar.Width = 50;
            // 
            // cod
            // 
            this.cod.DataPropertyName = "Codigo";
            this.cod.HeaderText = "Codigo";
            this.cod.Name = "cod";
            this.cod.ReadOnly = true;
            // 
            // fiestaNombre
            // 
            this.fiestaNombre.DataPropertyName = "NombreFiesta";
            this.fiestaNombre.HeaderText = "Nombre";
            this.fiestaNombre.Name = "fiestaNombre";
            this.fiestaNombre.ReadOnly = true;
            this.fiestaNombre.Width = 250;
            // 
            // CantidadAsignados
            // 
            this.CantidadAsignados.DataPropertyName = "CantidadAsignados";
            this.CantidadAsignados.HeaderText = "Asignados";
            this.CantidadAsignados.Name = "CantidadAsignados";
            this.CantidadAsignados.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Listado de fiestas";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Eliminar";
            this.dataGridViewImageColumn1.Image = global::MadScienceGUI.Properties.Resources.remove;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "Asignar";
            this.dataGridViewImageColumn2.Image = global::MadScienceGUI.Properties.Resources.asign;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Width = 50;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Image = global::MadScienceGUI.Properties.Resources.ademas;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(485, 13);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(85, 26);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // frmManReservaAsigna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(582, 339);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvFiestas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmManReservaAsigna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignacion";
            this.Load += new System.EventHandler(this.frmManReservaAsigna_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiestas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFiestas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewImageColumn Eliminar;
        private System.Windows.Forms.DataGridViewImageColumn Asignar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn fiestaNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadAsignados;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
    }
}