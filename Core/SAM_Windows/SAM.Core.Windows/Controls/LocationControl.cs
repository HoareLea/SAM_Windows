using System;
using System.Windows.Forms;

namespace SAM.Core.Windows
{
    public partial class LocationControl : UserControl
    {
        public LocationControl()
        {
            InitializeComponent();
        }

        public LocationControl(Location location)
        {
            InitializeComponent();

            Location = location;

        }

        public Location Location
        {
            get
            {
                Core.Query.TryConvert(TextBox_Longitude.Text, out double longitude);
                Core.Query.TryConvert(TextBox_Latitude.Text, out double latitude);
                Core.Query.TryConvert(TextBox_Elevation.Text, out double elevation);

                return new Location(null, longitude, latitude, elevation);
            }
            set
            {
                TextBox_Longitude.Text = null;
                TextBox_Latitude.Text = null;
                TextBox_Elevation.Text = null;

                if (value != null)
                {
                    TextBox_Longitude.Text = value.Longitude.ToString();
                    TextBox_Latitude.Text = value.Latitude.ToString();
                    TextBox_Elevation.Text = value.Elevation.ToString();
                }
            }
        }

        private void LocationControl_Load(object sender, EventArgs e)
        {
            TextBox_Longitude.KeyPress += new KeyPressEventHandler(EventHandler.ControlText_NumberOnly);
            TextBox_Latitude.KeyPress += new KeyPressEventHandler(EventHandler.ControlText_NumberOnly);
            TextBox_Elevation.KeyPress += new KeyPressEventHandler(EventHandler.ControlText_NumberOnly);
        }
    }
}
