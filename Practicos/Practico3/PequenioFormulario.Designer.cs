
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
            this.LNyA.Location = new System.Drawing.Point(66, 46);
            this.LNyA.Name = "LNyA";
            this.LNyA.Size = new System.Drawing.Size(140, 20);
            this.LNyA.TabIndex = 0;
            this.LNyA.Text = "Nombre y Apellido:";
            this.LNyA.Click += new System.EventHandler(this.label1_Click);
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Location = new System.Drawing.Point(66, 217);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(104, 30);
            this.LNombre.TabIndex = 1;
            this.LNombre.Text = "Nombre:";
            // 
            // LApellido
            // 
            this.LApellido.AutoSize = true;
            this.LApellido.Location = new System.Drawing.Point(66, 160);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(104, 30);
            this.LApellido.TabIndex = 2;
            this.LApellido.Text = "Apellido:";
            // 
            // LDni
            // 
            this.LDni.AutoSize = true;
            this.LDni.Location = new System.Drawing.Point(66, 98);
            this.LDni.Name = "LDni";
            this.LDni.Size = new System.Drawing.Size(62, 30);
            this.LDni.TabIndex = 3;
            this.LDni.Text = "DNI:";
            // 
            // LModificar
            // 
            this.LModificar.AutoSize = true;
            this.LModificar.ForeColor = System.Drawing.Color.Red;
            this.LModificar.Location = new System.Drawing.Point(234, 46);
            this.LModificar.Name = "LModificar";
            this.LModificar.Size = new System.Drawing.Size(73, 20);
            this.LModificar.TabIndex = 4;
            this.LModificar.Text = "modificar";
            this.LModificar.Click += new System.EventHandler(this.LModificar_Click);
            // 
            // TDni
            // 
            this.TDni.Location = new System.Drawing.Point(175, 95);
            this.TDni.Name = "TDni";
            this.TDni.Size = new System.Drawing.Size(156, 26);
            this.TDni.TabIndex = 5;
            // 
            // TNombre
            // 
            this.TNombre.Location = new System.Drawing.Point(175, 214);
            this.TNombre.Name = "TNombre";
            this.TNombre.Size = new System.Drawing.Size(156, 26);
            this.TNombre.TabIndex = 6;
            // 
            // TApellido
            // 
            this.TApellido.Location = new System.Drawing.Point(175, 157);
            this.TApellido.Name = "TApellido";
            this.TApellido.Size = new System.Drawing.Size(156, 26);
            this.TApellido.TabIndex = 7;
            // 
            // BGuardar
            // 
            this.BGuardar.Location = new System.Drawing.Point(70, 294);
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Size = new System.Drawing.Size(94, 28);
            this.BGuardar.TabIndex = 8;
            this.BGuardar.Text = "Guardar";
            this.BGuardar.UseVisualStyleBackColor = true;
            // 
            // BEliminar
            // 
            this.BEliminar.Location = new System.Drawing.Point(200, 294);
            this.BEliminar.Name = "BEliminar";
            this.BEliminar.Size = new System.Drawing.Size(95, 28);
            this.BEliminar.TabIndex = 9;
            this.BEliminar.Text = "Eliminar";
            this.BEliminar.UseVisualStyleBackColor = true;
            // 
            // PequenioFormulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 400);
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
            this.Name = "PequenioFormulario";
            this.Text = "Pequenio Formulario";
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

