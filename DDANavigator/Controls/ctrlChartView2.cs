using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SiGlaz.Utility;
using SiGlaz.Common.DDA;
using SiGlaz.Common.DDA.Basic;
using SiGlaz.Common.DDA.Recipe;

namespace DDANavigator.Controls
{
    public partial class ctrlChartView2 : UserControl
    {
        #region Members

        #endregion

        #region Constructor
        public ctrlChartView2()
        {
            InitializeComponent();
        }
        #endregion

        #region UI Command
        public void ClearChart()
        {
            msChart.Series.Clear();
        }

        private Series AddSeries(string seriesName, Color color, SeriesChartType chartType, MarkerStyle markerStyle, bool isShowLegend, bool isPrimaryAxis, string[] categoryValues, double[] dataValues)
        {
            Series series = new Series(seriesName);
            msChart.Series.Add(series);
            series.ChartArea = msChart.ChartAreas[0].Name;
            series.ChartType = chartType;
            series.Color = color;

            if (chartType == SeriesChartType.Line)
            {
                if (markerStyle != MarkerStyle.None)
                {
                    series.MarkerStyle = MarkerStyle.Diamond;
                    series.MarkerSize = 14;
                }

                series.BorderWidth = 2;
            }

            string categoryTitle = msChart.ChartAreas[0].AxisX.Title;
            string dataTitle = msChart.ChartAreas[0].AxisY.Title;

            if (!isPrimaryAxis)
            {
                series.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                dataTitle = msChart.ChartAreas[0].AxisY2.Title;
            }

            series.IsVisibleInLegend = isShowLegend;
            series.Legend = msChart.Legends[0].Name;

            for (int i = 0; i < categoryValues.Length; i++)
            {
                DataPoint p = new DataPoint(i + 1, dataValues[i]);
                p.AxisLabel = categoryValues[i];

                if (isPrimaryAxis)
                {
                    p.ToolTip = string.Format("{0}: {1}; {2}: {3}", categoryTitle,
                    categoryValues[i], dataTitle, dataValues[i]);
                }
                else
                {
                    p.LabelFormat = "0.00%";
                    p.IsValueShownAsLabel = true;
                    p.ToolTip = string.Format("{0}: {1}; {2}: {3}", categoryTitle,
                    categoryValues[i], dataTitle, dataValues[i].ToString("0.00%"));
                }

                series.Points.Add(p);
            }

            return series;
        }

        private void SetAxisFont()
        {
            Font font = new Font("Arial", 10, FontStyle.Bold);
            msChart.ChartAreas[0].AxisX.TitleFont = font;
            msChart.ChartAreas[0].AxisY.TitleFont = font;
        }



        public void CreateSignatureParetoChart(WebServiceProxy.SingleLayerProxy.ChartResult result)
        {
            try
            {
                //Clear Chart
                msChart.Series.Clear();

                //Set Chart Title
                msChart.Titles[0].Text = result.ChartTitle;
                SetAxisFont();

                int maxDisk = result.MaxDisk;
                double maxYield = result.MaxYield;

                //Set Primary Category Axis Caption
                msChart.ChartAreas[0].AxisX.Title = result.CategoryTitle;
                msChart.ChartAreas[0].AxisX.Minimum = 0;
                
                //Set Primary Data Axis Caption
                msChart.ChartAreas[0].AxisY.Title = result.DataTitle;
                msChart.ChartAreas[0].AxisY.Minimum = 0;
                msChart.ChartAreas[0].AxisY.Maximum = maxDisk;
                msChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                msChart.ChartAreas[0].AxisY.MajorTickMark.TickMarkStyle = TickMarkStyle.OutsideArea;

                //Set Secondary Data Axis Caption
                msChart.ChartAreas[0].AxisY2.Title = result.DataTitle2;
                Font font = new Font("Arial", 10, FontStyle.Bold);
                msChart.ChartAreas[0].AxisY2.TitleFont = font;
                msChart.ChartAreas[0].AxisY2.Minimum = 0;
                msChart.ChartAreas[0].AxisY2.Maximum = maxYield;
                msChart.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
                msChart.ChartAreas[0].AxisY2.LabelStyle.Format = "0.00%";

                //Add Primary Series
                SeriesChartType chartType = SeriesChartType.Column;
                MarkerStyle markerStyle = MarkerStyle.None;
                string seriesName = result.DataTitle;
                AddSeries(seriesName, Color.Blue, chartType, markerStyle, false, true, result.LabelValues, result.DataValues);

                //Add Secondary Series
                chartType = SeriesChartType.Line;
                markerStyle = MarkerStyle.Diamond;
                seriesName = result.DataTitle2;
                AddSeries(seriesName, Color.Red, chartType, markerStyle, false, false, result.LabelValues, result.DataValues2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
        }
        #endregion
    }
}
