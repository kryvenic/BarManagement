
namespace InfoBAR
{
    partial class RegistrarPago
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
            this.btnDetalle = new System.Windows.Forms.Button();
            this.chkTodas = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateFecha = new System.Windows.Forms.DateTimePicker();
            this.btnPago = new System.Windows.Forms.Button();
            this.chkFecha = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDetalle
            // 
            this.btnDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(167)))));
            this.btnDetalle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.btnDetalle.Location = new System.Drawing.Point(811, 101);
            this.btnDetalle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(150, 43);
            this.btnDetalle.TabIndex = 30;
            this.btnDetalle.Text = "Detalle";
            this.btnDetalle.UseVisualStyleBackColor = false;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // chkTodas
            // 
            this.chkTodas.AutoSize = true;
            this.chkTodas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.chkTodas.Location = new System.Drawing.Point(25, 113);
            this.chkTodas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkTodas.Name = "chkTodas";
            this.chkTodas.Size = new System.Drawing.Size(219, 24);
            this.chkTodas.TabIndex = 27;
            this.chkTodas.Text = "Todos los Pedidos Activos";
            this.chkTodas.UseVisualStyleBackColor = true;
            this.chkTodas.CheckedChanged += new System.EventHandler(this.chkTodas_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateFecha);
            this.groupBox1.Controls.Add(this.btnPago);
            this.groupBox1.Controls.Add(this.chkFecha);
            this.groupBox1.Controls.Add(this.btnDetalle);
            this.groupBox1.Controls.Add(this.chkTodas);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.groupBox1.Location = new System.Drawing.Point(36, 101);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(982, 162);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // dateFecha
            // 
            this.dateFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateFecha.Location = new System.Drawing.Point(355, 34);
            this.dateFecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.Size = new System.Drawing.Size(605, 26);
            this.dateFecha.TabIndex = 4;
            // 
            // btnPago
            // 
            this.btnPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(167)))));
            this.btnPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.btnPago.Location = new System.Drawing.Point(583, 101);
            this.btnPago.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPago.Name = "btnPago";
            this.btnPago.Size = new System.Drawing.Size(197, 43);
            this.btnPago.TabIndex = 31;
            this.btnPago.Text = "Registrar Pago";
            this.btnPago.UseVisualStyleBackColor = false;
            this.btnPago.Click += new System.EventHandler(this.btnPago_Click);
            // 
            // chkFecha
            // 
            this.chkFecha.AutoSize = true;
            this.chkFecha.Location = new System.Drawing.Point(25, 34);
            this.chkFecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkFecha.Name = "chkFecha";
            this.chkFecha.Size = new System.Drawing.Size(80, 24);
            this.chkFecha.TabIndex = 2;
            this.chkFecha.Text = "Fecha";
            this.chkFecha.UseVisualStyleBackColor = true;
            this.chkFecha.CheckedChanged += new System.EventHandler(this.chkFecha_CheckedChanged_1);
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
            this.Pago,
            this.Mesa,
            this.Nombre,
            this.Usuario,
            this.Fecha});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(36, 271);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(982, 356);
            this.dataGridView1.TabIndex = 28;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Pago
            // 
            this.Pago.HeaderText = "Pago";
            this.Pago.MinimumWidth = 6;
            this.Pago.Name = "Pago";
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
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1050, 71);
            this.panel1.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.CausesValidation = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.label1.Location = new System.Drawing.Point(250, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(517, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registrar Pago";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblError
            // 
            this.lblError.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.CausesValidation = false;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblError.Location = new System.Drawing.Point(36, 631);
            this.lblError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(982, 26);
            this.lblError.TabIndex = 1;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // RegistrarPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(91)))));
            this.ClientSize = new System.Drawing.Size(1050, 658);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RegistrarPago";
            this.Text = "RegistrarPago";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.CheckBox chkTodas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateFecha;
        private System.Windows.Forms.CheckBox chkFecha;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPago;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.Label lblError;
    }
}