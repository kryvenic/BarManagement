
namespace InfoBAR
{
    partial class GraficoPorPeriodo
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnGrafico = new System.Windows.Forms.Button();
            this.dateHasta = new System.Windows.Forms.DateTimePicker();
            this.dateDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 75);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Efectivo";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Debito";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1128, 459);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // btnGrafico
            // 
            this.btnGrafico.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnGrafico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(167)))));
            this.btnGrafico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGrafico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrafico.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrafico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.btnGrafico.Location = new System.Drawing.Point(12, 12);
            this.btnGrafico.Name = "btnGrafico";
            this.btnGrafico.Size = new System.Drawing.Size(231, 36);
            this.btnGrafico.TabIndex = 28;
            this.btnGrafico.Text = "Calcular Por Periodo";
            this.btnGrafico.UseVisualStyleBackColor = false;
            this.btnGrafico.Click += new System.EventHandler(this.btnGrafico_Click);
            // 
            // dateHasta
            // 
            this.dateHasta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateHasta.Location = new System.Drawing.Point(588, 18);
            this.dateHasta.Name = "dateHasta";
            this.dateHasta.Size = new System.Drawing.Size(169, 22);
            this.dateHasta.TabIndex = 30;
            // 
            // dateDesde
            // 
            this.dateDesde.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateDesde.Location = new System.Drawing.Point(299, 18);
            this.dateDesde.Name = "dateDesde";
            this.dateDesde.Size = new System.Drawing.Size(184, 22);
            this.dateDesde.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(516, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "Hasta";
            // 
            // GraficoPorPeriodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 546);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateHasta);
            this.Controls.Add(this.dateDesde);
            this.Controls.Add(this.btnGrafico);
            this.Controls.Add(this.chart1);
            this.Name = "GraficoPorPeriodo";
            this.Text = "Reporte Por Periodo";
            this.Load += new System.EventHandler(this.ReporteGraficos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnGrafico;
        private System.Windows.Forms.DateTimePicker dateHasta;
        private System.Windows.Forms.DateTimePicker dateDesde;
        private System.Windows.Forms.Label label1;
    }
}