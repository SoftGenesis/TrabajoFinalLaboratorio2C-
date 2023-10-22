namespace FinalGenesisLab2
{
    partial class frmListaBar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblPromedio = new System.Windows.Forms.Label();
            this.lblDeudaTotal = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEx = new System.Windows.Forms.Button();
            this.btnIm = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.dgvL = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbBarrio = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.prtVe = new System.Windows.Forms.PrintDialog();
            this.prtDoc = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.dgvL)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPromedio
            // 
            this.lblPromedio.BackColor = System.Drawing.Color.Transparent;
            this.lblPromedio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPromedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPromedio.Location = new System.Drawing.Point(809, 553);
            this.lblPromedio.Name = "lblPromedio";
            this.lblPromedio.Size = new System.Drawing.Size(184, 33);
            this.lblPromedio.TabIndex = 35;
            this.lblPromedio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDeudaTotal
            // 
            this.lblDeudaTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblDeudaTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDeudaTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblDeudaTotal.Location = new System.Drawing.Point(809, 392);
            this.lblDeudaTotal.Name = "lblDeudaTotal";
            this.lblDeudaTotal.Size = new System.Drawing.Size(184, 28);
            this.lblDeudaTotal.TabIndex = 34;
            this.lblDeudaTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCantidad
            // 
            this.lblCantidad.BackColor = System.Drawing.Color.Transparent;
            this.lblCantidad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblCantidad.Location = new System.Drawing.Point(809, 151);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(184, 33);
            this.lblCantidad.TabIndex = 33;
            this.lblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(804, 496);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 33);
            this.label4.TabIndex = 32;
            this.label4.Text = "Deuda Promedio";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(809, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 33);
            this.label3.TabIndex = 31;
            this.label3.Text = "Total de Deuda";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(809, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 33);
            this.label2.TabIndex = 30;
            this.label2.Text = "Cantidad de Socios";
            // 
            // btnEx
            // 
            this.btnEx.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnEx.FlatAppearance.BorderSize = 10;
            this.btnEx.Location = new System.Drawing.Point(13, 697);
            this.btnEx.Name = "btnEx";
            this.btnEx.Size = new System.Drawing.Size(124, 50);
            this.btnEx.TabIndex = 27;
            this.btnEx.Text = "Exportar";
            this.btnEx.UseVisualStyleBackColor = true;
            this.btnEx.Click += new System.EventHandler(this.btnEx_Click);
            // 
            // btnIm
            // 
            this.btnIm.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnIm.FlatAppearance.BorderSize = 10;
            this.btnIm.Location = new System.Drawing.Point(652, 697);
            this.btnIm.Name = "btnIm";
            this.btnIm.Size = new System.Drawing.Size(124, 50);
            this.btnIm.TabIndex = 26;
            this.btnIm.Text = "Imprimir";
            this.btnIm.UseVisualStyleBackColor = true;
            this.btnIm.Click += new System.EventHandler(this.btnIm_Click);
            // 
            // btnListar
            // 
            this.btnListar.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnListar.FlatAppearance.BorderSize = 10;
            this.btnListar.Location = new System.Drawing.Point(334, 697);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(124, 50);
            this.btnListar.TabIndex = 25;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // dgvL
            // 
            this.dgvL.BackgroundColor = System.Drawing.Color.MistyRose;
            this.dgvL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column3});
            this.dgvL.GridColor = System.Drawing.Color.MistyRose;
            this.dgvL.Location = new System.Drawing.Point(13, 52);
            this.dgvL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvL.Name = "dgvL";
            this.dgvL.RowHeadersWidth = 51;
            this.dgvL.RowTemplate.Height = 24;
            this.dgvL.Size = new System.Drawing.Size(763, 588);
            this.dgvL.TabIndex = 24;
            // 
            // Column1
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Column1.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column1.HeaderText = "Id del Socio";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Column2.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column2.HeaderText = "Nombre";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column5
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Column5.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column5.HeaderText = "Actividad";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 180;
            // 
            // Column3
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Column3.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column3.HeaderText = "Deuda";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // cmbBarrio
            // 
            this.cmbBarrio.FormattingEnabled = true;
            this.cmbBarrio.Location = new System.Drawing.Point(343, 11);
            this.cmbBarrio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbBarrio.Name = "cmbBarrio";
            this.cmbBarrio.Size = new System.Drawing.Size(323, 33);
            this.cmbBarrio.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(103, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 33);
            this.label1.TabIndex = 36;
            this.label1.Text = "Seleccione Barrio";
            // 
            // prtVe
            // 
            this.prtVe.UseEXDialog = true;
            // 
            // prtDoc
            // 
            this.prtDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prtDoc_PrintPage);
            // 
            // frmListaBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.BackgroundImage = global::FinalGenesisLab2.Properties.Resources.flor_sola;
            this.ClientSize = new System.Drawing.Size(1011, 758);
            this.Controls.Add(this.cmbBarrio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPromedio);
            this.Controls.Add(this.lblDeudaTotal);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEx);
            this.Controls.Add(this.btnIm);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.dgvL);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmListaBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Socios según Barrio";
            this.Load += new System.EventHandler(this.frmListaBar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPromedio;
        private System.Windows.Forms.Label lblDeudaTotal;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEx;
        private System.Windows.Forms.Button btnIm;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.DataGridView dgvL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ComboBox cmbBarrio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PrintDialog prtVe;
        private System.Drawing.Printing.PrintDocument prtDoc;
    }
}