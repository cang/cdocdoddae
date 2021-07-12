namespace DDANavigator.Controls
{
    partial class ctrlChartView2
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.msChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.msChart)).BeginInit();
            this.SuspendLayout();
            // 
            // msChart
            // 
            chartArea1.AxisX.Interval = 1;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.Minimum = 0;
            chartArea1.AxisX.Title = "X";
            chartArea1.AxisX2.Interval = 1;
            chartArea1.AxisX2.Minimum = 1;
            chartArea1.AxisY.MajorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.AcrossAxis;
            chartArea1.AxisY.Minimum = 0;
            chartArea1.AxisY2.Minimum = 0;
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "chArea";
            this.msChart.ChartAreas.Add(chartArea1);
            this.msChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BorderColor = System.Drawing.Color.Black;
            legend1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "chLegend";
            this.msChart.Legends.Add(legend1);
            this.msChart.Location = new System.Drawing.Point(0, 0);
            this.msChart.Name = "msChart";
            this.msChart.Size = new System.Drawing.Size(723, 416);
            this.msChart.TabIndex = 1;
            this.msChart.Text = "chart1";
            title1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.Blue;
            title1.Name = "chTitle";
            this.msChart.Titles.Add(title1);
            // 
            // ctrlChartView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.msChart);
            this.Name = "ctrlChartView2";
            this.Size = new System.Drawing.Size(723, 416);
            ((System.ComponentModel.ISupportInitialize)(this.msChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart msChart;
    }
}
