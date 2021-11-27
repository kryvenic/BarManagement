
namespace InfoBAR
{
    partial class ReporteVentas
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
            this.chkTodas = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateHasta = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateDesde = new System.Windows.Forms.DateTimePicker();
            this.chkPeriodo = new System.Windows.Forms.CheckBox();
            this.dateFecha = new System.Windows.Forms.DateTimePicker();
            this.chkFecha = new System.Windows.Forms.CheckBox();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.chkTipo = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picError = new FontAwesome.Sharp.IconPictureBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnDetalle = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblRecaudado = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnGraficoPorTipo = new System.Windows.Forms.Button();
            this.btnGraficoPeriodo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            this.SuspendLayout();
            // 
            // chkTodas
            // 
            this.chkTodas.AutoSize = true;
            this.chkTodas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.chkTodas.Location = new System.Drawing.Point(26, 172);
            this.chkTodas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkTodas.Name = "chkTodas";
            this.chkTodas.Size = new System.Drawing.Size(164, 24);
            this.chkTodas.TabIndex = 21;
            this.chkTodas.Text = "Todas Las Ventas";
            this.chkTodas.UseVisualStyleBackColor = true;
            this.chkTodas.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateHasta);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateDesde);
            this.groupBox1.Controls.Add(this.chkPeriodo);
            this.groupBox1.Controls.Add(this.chkTodas);
            this.groupBox1.Controls.Add(this.dateFecha);
            this.groupBox1.Controls.Add(this.chkFecha);
            this.groupBox1.Controls.Add(this.cboTipo);
            this.groupBox1.Controls.Add(this.chkTipo);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.groupBox1.Location = new System.Drawing.Point(14, 41);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(758, 206);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // dateHasta
            // 
            this.dateHasta.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dateHasta.Location = new System.Drawing.Point(536, 124);
            this.dateHasta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateHasta.Name = "dateHasta";
            this.dateHasta.Size = new System.Drawing.Size(202, 26);
            this.dateHasta.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(460, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "hasta";
            // 
            // dateDesde
            // 
            this.dateDesde.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dateDesde.Location = new System.Drawing.Point(233, 122);
            this.dateDesde.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateDesde.Name = "dateDesde";
            this.dateDesde.Size = new System.Drawing.Size(220, 26);
            this.dateDesde.TabIndex = 11;
            // 
            // chkPeriodo
            // 
            this.chkPeriodo.AutoSize = true;
            this.chkPeriodo.Location = new System.Drawing.Point(26, 122);
            this.chkPeriodo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkPeriodo.Name = "chkPeriodo";
            this.chkPeriodo.Size = new System.Drawing.Size(89, 24);
            this.chkPeriodo.TabIndex = 10;
            this.chkPeriodo.Text = "Período";
            this.chkPeriodo.UseVisualStyleBackColor = true;
            this.chkPeriodo.CheckedChanged += new System.EventHandler(this.chkPeriodo_CheckedChanged);
            // 
            // dateFecha
            // 
            this.dateFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateFecha.Location = new System.Drawing.Point(233, 72);
            this.dateFecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.Size = new System.Drawing.Size(506, 26);
            this.dateFecha.TabIndex = 4;
            this.dateFecha.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // chkFecha
            // 
            this.chkFecha.AutoSize = true;
            this.chkFecha.Location = new System.Drawing.Point(26, 72);
            this.chkFecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkFecha.Name = "chkFecha";
            this.chkFecha.Size = new System.Drawing.Size(80, 24);
            this.chkFecha.TabIndex = 2;
            this.chkFecha.Text = "Fecha";
            this.chkFecha.UseVisualStyleBackColor = true;
            this.chkFecha.CheckedChanged += new System.EventHandler(this.chkFecha_CheckedChanged);
            // 
            // cboTipo
            // 
            this.cboTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Efectivo",
            "Debito"});
            this.cboTipo.Location = new System.Drawing.Point(233, 25);
            this.cboTipo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(506, 28);
            this.cboTipo.TabIndex = 1;
            // 
            // chkTipo
            // 
            this.chkTipo.AutoSize = true;
            this.chkTipo.Location = new System.Drawing.Point(26, 29);
            this.chkTipo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkTipo.Name = "chkTipo";
            this.chkTipo.Size = new System.Drawing.Size(106, 24);
            this.chkTipo.TabIndex = 0;
            this.chkTipo.Text = "Tipo Pago";
            this.chkTipo.UseVisualStyleBackColor = true;
            this.chkTipo.CheckedChanged += new System.EventHandler(this.chkTipo_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Tipo,
            this.Mesa,
            this.Nombre,
            this.Usuario,
            this.Fecha});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(14, 254);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1094, 372);
            this.dataGridView1.TabIndex = 23;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Pago";
            this.Tipo.MinimumWidth = 6;
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // Mesa
            // 
            this.Mesa.HeaderText = "Mesa";
            this.Mesa.MinimumWidth = 6;
            this.Mesa.Name = "Mesa";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Total";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.MinimumWidth = 6;
            this.Usuario.Name = "Usuario";
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.MinimumWidth = 6;
            this.Fecha.Name = "Fecha";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(129)))));
            this.panel1.Controls.Add(this.picError);
            this.panel1.Controls.Add(this.lblError);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1123, 34);
            this.panel1.TabIndex = 20;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // picError
            // 
            this.picError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(129)))));
            this.picError.ErrorImage = null;
            this.picError.ForeColor = System.Drawing.SystemColors.ControlText;
            this.picError.IconChar = FontAwesome.Sharp.IconChar.None;
            this.picError.IconColor = System.Drawing.SystemColors.ControlText;
            this.picError.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.picError.IconSize = 28;
            this.picError.InitialImage = null;
            this.picError.Location = new System.Drawing.Point(298, 2);
            this.picError.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picError.Name = "picError";
            this.picError.Size = new System.Drawing.Size(28, 28);
            this.picError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picError.TabIndex = 1;
            this.picError.TabStop = false;
            // 
            // lblError
            // 
            this.lblError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblError.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblError.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblError.Location = new System.Drawing.Point(332, 7);
            this.lblError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(456, 24);
            this.lblError.TabIndex = 0;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDetalle
            // 
            this.btnDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(167)))));
            this.btnDetalle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.btnDetalle.Location = new System.Drawing.Point(862, 634);
            this.btnDetalle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(247, 43);
            this.btnDetalle.TabIndex = 26;
            this.btnDetalle.Text = "Detalle De Venta";
            this.btnDetalle.UseVisualStyleBackColor = false;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.CausesValidation = false;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.lblTotal.Location = new System.Drawing.Point(8, 649);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(253, 37);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Total Recaudado : ";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblRecaudado
            // 
            this.lblRecaudado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecaudado.CausesValidation = false;
            this.lblRecaudado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecaudado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.lblRecaudado.Location = new System.Drawing.Point(269, 649);
            this.lblRecaudado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecaudado.Name = "lblRecaudado";
            this.lblRecaudado.Size = new System.Drawing.Size(226, 37);
            this.lblRecaudado.TabIndex = 28;
            this.lblRecaudado.Text = "0.00";
            this.lblRecaudado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(167)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.button2.Image = global::InfoBAR.Properties.Resources.chart;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(804, 194);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(305, 43);
            this.button2.TabIndex = 30;
            this.button2.Text = "Grafico Todas";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnGraficoPorTipo
            // 
            this.btnGraficoPorTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGraficoPorTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(167)))));
            this.btnGraficoPorTipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGraficoPorTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGraficoPorTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraficoPorTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.btnGraficoPorTipo.Image = global::InfoBAR.Properties.Resources.chart;
            this.btnGraficoPorTipo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGraficoPorTipo.Location = new System.Drawing.Point(804, 66);
            this.btnGraficoPorTipo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGraficoPorTipo.Name = "btnGraficoPorTipo";
            this.btnGraficoPorTipo.Size = new System.Drawing.Size(305, 43);
            this.btnGraficoPorTipo.TabIndex = 29;
            this.btnGraficoPorTipo.Text = "Grafico Por Tipo";
            this.btnGraficoPorTipo.UseVisualStyleBackColor = false;
            this.btnGraficoPorTipo.Click += new System.EventHandler(this.btnGraficoPorTipo_Click);
            // 
            // btnGraficoPeriodo
            // 
            this.btnGraficoPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGraficoPeriodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(167)))));
            this.btnGraficoPeriodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGraficoPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGraficoPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraficoPeriodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.btnGraficoPeriodo.Image = global::InfoBAR.Properties.Resources.chart;
            this.btnGraficoPeriodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGraficoPeriodo.Location = new System.Drawing.Point(804, 131);
            this.btnGraficoPeriodo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGraficoPeriodo.Name = "btnGraficoPeriodo";
            this.btnGraficoPeriodo.Size = new System.Drawing.Size(305, 43);
            this.btnGraficoPeriodo.TabIndex = 27;
            this.btnGraficoPeriodo.Text = "Grafico Por Periodo";
            this.btnGraficoPeriodo.UseVisualStyleBackColor = false;
            this.btnGraficoPeriodo.Click += new System.EventHandler(this.btnGrafico_Click);
            // 
            // ReporteVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(91)))));
            this.ClientSize = new System.Drawing.Size(1123, 683);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnGraficoPorTipo);
            this.Controls.Add(this.lblRecaudado);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnGraficoPeriodo);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ReporteVentas";
            this.Text = "ReporteVentas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkTodas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkFecha;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.CheckBox chkTipo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateFecha;
        private System.Windows.Forms.DateTimePicker dateHasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateDesde;
        private System.Windows.Forms.CheckBox chkPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.Button btnGraficoPeriodo;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblRecaudado;
        private System.Windows.Forms.Button btnGraficoPorTipo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblError;
        private FontAwesome.Sharp.IconPictureBox picError;
    }
}