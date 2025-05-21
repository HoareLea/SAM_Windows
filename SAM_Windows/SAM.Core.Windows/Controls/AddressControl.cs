using System;
using System.Windows.Forms;

namespace SAM.Core.Windows
{
    public partial class AddressControl : UserControl
    {
        public AddressControl()
        {
            InitializeComponent();
        }

        public AddressControl(Address address)
        {
            InitializeComponent();

            Address = address;
        }

        public Address Address
        {
            get
            {
                return new Address(TextBox_Street.Text, TextBox_City.Text, TextBox_PostalCode.Text, GetCountryCode());
            }
            set
            {
                if(ComboBox_Country.Items == null || ComboBox_Country.Items.Count == 0)
                {
                    LoadCountries();
                }

                TextBox_Street.Text = null;
                TextBox_City.Text = null;
                TextBox_PostalCode.Text = null;
                ComboBox_Country.Text = string.Empty;

                if (value != null)
                {
                    TextBox_Street.Text = value.Street;
                    TextBox_City.Text = value.City;
                    TextBox_PostalCode.Text = value.PostalCode;
                    ComboBox_Country.Text = value.CountryCode == CountryCode.Undefined ? string.Empty : Core.Query.Description(value.CountryCode);
                }
            }
        }

        private CountryCode GetCountryCode()
        {
            if(string.IsNullOrWhiteSpace(ComboBox_Country.Text))
            {
                return CountryCode.Undefined;
            }

            return Core.Query.Enum<CountryCode>(ComboBox_Country.Text);
        }

        private void AddressControl_Load(object sender, EventArgs e)
        {
            Address address = Address;
            
            LoadCountries();

            Address = address;
        }

        private void LoadCountries()
        {
            ComboBox_Country.Items.Clear();

            ComboBox_Country.Items.Add(string.Empty);
            foreach (CountryCode countryCode in Enum.GetValues(typeof(CountryCode)))
            {
                if (countryCode == CountryCode.Undefined)
                {
                    continue;
                }

                ComboBox_Country.Items.Add(Core.Query.Description(countryCode));
            }
        }
    }
}
