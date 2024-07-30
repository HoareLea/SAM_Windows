using System;
using System.Windows.Forms;

namespace SAM.Core.Windows.Forms
{
    public partial class AddressAndLocationForm : Form
    {
        public AddressAndLocationForm(Address address, Location location)
        {
            InitializeComponent();

            AddressControl_Main.Address = address;
            LocationControl_Main.Location = location;
        }

        public Address Address
        {
            get
            {
                return AddressControl_Main.Address;
            }

            set
            {
                AddressControl_Main.Address = value;
            }
        }

        public Location Location
        {
            get
            {
                return LocationControl_Main.Location;
            }

            set
            {
                LocationControl_Main.Location = value;
            }
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Close();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }
    }
}
