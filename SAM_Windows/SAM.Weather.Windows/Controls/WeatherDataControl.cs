using SAM.Core.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SAM.Weather.Windows.Controls
{
    public partial class WeatherDataControl : UserControl
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        private WeatherData weatherData;
        private HashSet<Enum> enums;

        public WeatherDataControl()
        {
            InitializeComponent();
        }

        private void Chart_Main_Click(object sender, EventArgs e)
        {

        }

        private void LoadWeatherData(WeatherData weatherData)
        {
            TextBox_Name.Text = null;
            TextBox_Guid.Text = null;

            TextBox_Name.Text = weatherData?.Name;
            TextBox_Guid.Text = weatherData?.Guid.ToString();

            LoadParameters();

            TabControl_Main.TabPages.Clear();

            if(weatherData == null)
            {
                foreach (WeatherDataType weatherDataType in Enum.GetValues(typeof(WeatherDataType)))
                {
                    string name = Core.Query.Description(weatherDataType);

                    TabPage tabPage = new TabPage(name);

                    TabControl_Main.TabPages.Add(tabPage);
                }

                return;
            }

            Dictionary<DateTime, Dictionary<WeatherDataType, double>> dictionary_Values = new Dictionary<DateTime, Dictionary<WeatherDataType, double>>();
            List<WeatherDataType> weatherDataTypes = new List<WeatherDataType>();
            foreach (WeatherDataType weatherDataType in Enum.GetValues(typeof(WeatherDataType)))
            {
                if(weatherDataType == WeatherDataType.Undefined)
                {
                    continue;
                }

                Dictionary<DateTime, double> dictionary = Query.Values(weatherData, weatherDataType);
                if(dictionary == null || dictionary.Count == 0)
                {
                    continue;
                }

                string name = Core.Query.Description(weatherDataType);

                TabPage tabPage = new TabPage(name);

                TabControl_Main.TabPages.Add(tabPage);

                Chart chart = new Chart();

                tabPage.Controls.Add(chart);

                chart.Dock = DockStyle.Fill;

                ChartArea chartArea = chart.ChartAreas.Add(chart.ChartAreas.NextUniqueName());

                Series series = chart.Series.Add(name);
                series.ChartType = SeriesChartType.Line;
                series.ChartArea = chartArea.Name;

                System.Drawing.Color color = Query.Color(weatherDataType);
                if(color != System.Drawing.Color.Empty)
                {
                    series.Color = color;
                }

                weatherDataTypes.Add(weatherDataType);
                foreach (KeyValuePair<DateTime, double> keyValuePair in dictionary)
                {
                    series.Points.AddXY(keyValuePair.Key, keyValuePair.Value);

                    if(!dictionary_Values.TryGetValue(keyValuePair.Key, out Dictionary<WeatherDataType, double> values))
                    {
                        values = new Dictionary<WeatherDataType, double>();
                        dictionary_Values[keyValuePair.Key] = values;
                    }

                    values[weatherDataType] = keyValuePair.Value;
                }
            }

            DataGridView_Main.Columns.Clear();

            SendMessage(DataGridView_Main.Handle, WM_SETREDRAW, false, 0);

            DataGridView_Main.Columns.Add("Date", "Date");

            foreach (WeatherDataType weatherDataType in weatherDataTypes)
            {
                DataGridView_Main.Columns.Add(weatherDataType.ToString(), Core.Query.Description(weatherDataType));
            }

            foreach(KeyValuePair<DateTime, Dictionary<WeatherDataType, double>> keyValuePair_DateTime in dictionary_Values)
            {
                int index = DataGridView_Main.Rows.Add();

                DataGridView_Main.Rows[index].Cells["Date"].Value = keyValuePair_DateTime.Key.ToString("yyyy-MM-dd HH:mm");

                foreach (KeyValuePair<WeatherDataType, double> keyValuePair_WeatherDataType in keyValuePair_DateTime.Value)
                {
                    DataGridView_Main.Rows[index].Cells[keyValuePair_WeatherDataType.Key.ToString()].Value = keyValuePair_WeatherDataType.Value;
                }
            }

            SendMessage(DataGridView_Main.Handle, WM_SETREDRAW, true, 0);
            DataGridView_Main.Refresh();
        }

        private void LoadParameters()
        {
            PropertyGrid_Main.SelectedObject = null;

            CustomParameters customParameters = Core.Windows.Create.CustomParameters(weatherData, enums?.ToArray());

            PropertyGrid_Main.SelectedObject = customParameters;
        }

        public List<Enum> Enums
        {
            get
            {
                return enums?.ToList();
            }
            set
            {
                enums = null;

                if (value != null)
                {
                    enums = new HashSet<Enum>();
                    foreach (Enum @enum in value)
                    {
                        enums.Add(@enum);
                    }
                }

                LoadParameters();
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public WeatherData WeatherData
        {
            get
            {
                if(weatherData == null)
                {
                    return null;
                }

                WeatherData result = new WeatherData(weatherData);

                CustomParameters customParameters = PropertyGrid_Main.SelectedObject as CustomParameters;

                result.SetValues(customParameters);

                return result;
            }

            set
            {
                weatherData = value;
                LoadWeatherData(weatherData);
            }
        }
    }
}
