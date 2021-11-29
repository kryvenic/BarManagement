
namespace InfoBAR
{
    partial class GraficoTodas
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnGrafico = new System.Windows.Forms.Button();
            this.btnMostrartipo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(12, 54);
            this.chart1.Name = "chart1";
            this.chart1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chart1.Size = new System.Drawing.Size(1128, 480);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // btnGrafico
            // 
            this.btnGrafico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(167)))));
            this.btnGrafico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGrafico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrafico.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrafico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.btnGrafico.Location = new System.Drawing.Point(12, 12);
            this.btnGrafico.Name = "btnGrafico";
            this.btnGrafico.Size = new System.Drawing.Size(295, 36);
            this.btnGrafico.TabIndex = 28;
            this.btnGrafico.Text = "Mostrar Todas Las Ventas";
            this.btnGrafico.UseVisualStyleBackColor = false;
            this.btnGrafico.Click += new System.EventHandler(this.btnGrafico_Click);
            // 
            // btnMostrartipo
            // 
            this.btnMostrartipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(167)))));
            this.btnMostrartipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrartipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrartipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrartipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.btnMostrartipo.Location = new System.Drawing.Point(313, 12);
            this.btnMostrartipo.Name = "btnMostrartipo";
            this.btnMostrartipo.Size = new System.Drawing.Size(295, 36);
            this.btnMostrartipo.TabIndex = 29;
            this.btnMostrartipo.Text = "Mostrar Con Tipo De Pago";
            this.btnMostrartipo.UseVisualStyleBackColor = false;
            this.btnMostrartipo.Click += new System.EventHandler(this.btnMostrartipo_Click);
            // 
            // GraficoTodas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 546);
            this.Controls.Add(this.btnMostrartipo);
            this.Controls.Add(this.btnGrafico);
            this.Controls.Add(this.chart1);
            this.Name = "GraficoTodas";
            this.Text = "Reporte De Todas Las Ventas";
            this.Load += new System.EventHandler(this.ReporteGraficos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnGrafico;
        private System.Windows.Forms.Button btnMostrartipo;
    }
}