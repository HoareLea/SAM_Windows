using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Weather.Windows.Forms
{
    public partial class WeatherDataForm : Form
    {
        Core.Windows.Forms.MarqueeProgressForm marqueeProgressForm;

        public WeatherDataForm()
        {
            InitializeComponent();
        }

        public WeatherDataForm(WeatherData weatherData, IEnumerable<Enum> enums)
        {
            InitializeComponent();

            WeatherDataControl_Main.WeatherData = weatherData;
            WeatherDataControl_Main.Enums = enums?.ToList();

            marqueeProgressForm = new Core.Windows.Forms.MarqueeProgressForm("Loading Data");
            marqueeProgressForm.Show();
        }

        public WeatherData WeatherData
        {
            get
            {
                return WeatherDataControl_Main.WeatherData;
            }

            set
            {
                WeatherDataControl_Main.WeatherData = value;
            }
        }

        private void Button_OK_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Close();
        }

        private void Button_Cancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void WeatherDataForm_Shown(object sender, EventArgs e)
        {
            marqueeProgressForm?.Close();
        }
    }
}
