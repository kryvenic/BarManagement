
namespace Practico3
{
    partial class PequenioFormulario
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
            this.LNyA = new System.Windows.Forms.Label();
            this.LNombre = new System.Windows.Forms.Label();
            this.LApellido = new System.Windows.Forms.Label();
            this.LDni = new System.Windows.Forms.Label();
            this.LModificar = new System.Windows.Forms.Label();
            this.TDni = new System.Windows.Forms.TextBox();
            this.TNombre = new System.Windows.Forms.TextBox();
            this.TApellido = new System.Windows.Forms.TextBox();
            this.BGuardar = new System.Windows.Forms.Button();
            this.BEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LNyA
            // 
            this.LNyA.AutoSize = true;
            this.LNyA.Location = new System.Drawing.Point(59, 37);
            this.LNyA.Name = "LNyA";
            this.LNyA.Size = new System.Drawing.Size(127, 17);
            this.LNyA.TabIndex = 0;
            this.LNyA.Text = "Nombre y Apellido:";
            this.LNyA.Click += new System.EventHandler(this.label1_Click);
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Location = new System.Drawing.Point(59, 174);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(62, 17);
            this.LNombre.TabIndex = 1;
            this.LNombre.Text = "Nombre:";
            // 
            // LApellido
            // 
            this.LApellido.AutoSize = true;
            this.LApellido.Location = new System.Drawing.Point(59, 128);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(62, 17);
            this.LApellido.TabIndex = 2;
            this.LApellido.Text = "Apellido:";
            // 
            // LDni
            // 
            this.LDni.AutoSize = true;
            this.LDni.Location = new System.Drawing.Point(59, 78);
            this.LDni.Name = "LDni";
            this.LDni.Size = new System.Drawing.Size(35, 17);
            this.LDni.TabIndex = 3;
            this.LDni.Text = "DNI:";
            // 
            // LModificar
            // 
            this.LModificar.AutoSize = true;
            this.LModificar.ForeColor = System.Drawing.Color.Red;
            this.LModificar.Location = new System.Drawing.Point(208, 37);
            this.LModificar.Name = "LModificar";
            this.LModificar.Size = new System.Drawing.Size(65, 17);
            this.LModificar.TabIndex = 4;
            this.LModificar.Tag = "TModificar";
            this.LModificar.Text = "modificar";
            this.LModificar.Click += new System.EventHandler(this.LModificar_Click);
            // 
            // TDni
            // 
            this.TDni.Location = new System.Drawing.Point(156, 76);
            this.TDni.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TDni.Name = "TDni";
            this.TDni.Size = new System.Drawing.Size(139, 22);
            this.TDni.TabIndex = 1;
            this.TDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TDni_KeyPress);
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(156, 171);
            this.TNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(139, 22);
            this.TNombre.TabIndex = 3;
            this.TNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TNombre_KeyPress);
            // 
            // TApellido
            // 
            this.TApellido.Location = new System.Drawing.Point(156, 126);
            this.TApellido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TApellido.Name = "TApellido";
            this.TApellido.Size = new System.Drawing.Size(139, 22);
            this.TApellido.TabIndex = 2;
            this.TApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TApellido_KeyPress);
            // 
            // BGuardar
            // 
            this.BGuardar.Location = new System.Drawing.Point(62, 235);
            this.BGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Size = new System.Drawing.Size(84, 37);
            this.BGuardar.TabIndex = 8;
            this.BGuardar.Text = "Guardar";
            this.BGuardar.UseVisualStyleBackColor = true;
            this.BGuardar.Click += new System.EventHandler(this.BGuardar_Click);
            // 
            // BEliminar
            // 
            this.BEliminar.Location = new System.Drawing.Point(178, 235);
            this.BEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BEliminar.Name = "BEliminar";
            this.BEliminar.Size = new System.Drawing.Size(84, 37);
            this.BEliminar.TabIndex = 9;
            this.BEliminar.Text = "Eliminar";
            this.BEliminar.UseVisualStyleBackColor = true;
            this.BEliminar.Click += new System.EventHandler(this.BEliminar_Click);
            // 
            // PequenioFormulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 320);
            this.Controls.Add(this.BEliminar);
            this.Controls.Add(this.BGuardar);
            this.Controls.Add(this.TApellido);
            this.Controls.Add(this.TNombre);
            this.Controls.Add(this.TDni);
            this.Controls.Add(this.LModificar);
            this.Controls.Add(this.LDni);
            this.Controls.Add(this.LApellido);
            this.Controls.Add(this.LNombre);
            this.Controls.Add(this.LNyA);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PequenioFormulario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Form1";
            this.Text = "Pequenio Formulario";
            this.Load += new System.EventHandler(this.PequenioFormulario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LNyA;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.Label LApellido;
        private System.Windows.Forms.Label LDni;
        private System.Windows.Forms.Label LModificar;
        private System.Windows.Forms.TextBox TDni;
        private System.Windows.Forms.TextBox TNombre;
        private System.Windows.Forms.TextBox TApellido;
        private System.Windows.Forms.Button BGuardar;
        private System.Windows.Forms.Button BEliminar;
    }
}

