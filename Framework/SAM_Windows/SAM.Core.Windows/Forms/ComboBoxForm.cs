using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Core.Windows.Forms
{
    public partial class ComboBoxForm<T> : Form
    {
        public ComboBoxForm()
        {
            InitializeComponent();
        }

        public ComboBoxForm(string name)
        {
            InitializeComponent();

            Text = name;
            if (typeof(T).IsEnum)
            {
                List<Enum> @enums = new List<Enum>();
                foreach(Enum @enum in Enum.GetValues(typeof(T)))
                {
                    @enums.Add(@enum);
                }

                AddRange(enums.Cast<T>(), (T x) => Core.Query.Description((Enum)(object)x));
            }
        }

        public ComboBoxForm(string name, IEnumerable<T> items)
        {
            InitializeComponent();

            Text = name;
            AddRange(items);
        }

        public ComboBoxForm(string name, IEnumerable<T> items, Func<T, string> text)
        {
            InitializeComponent();

            Text = name;
            AddRange(items, text);
        }

        public ComboBoxForm(string name, IEnumerable<T> items, Func<T, string> text, T selectedItem)
        {
            InitializeComponent();

            Text = name;
            AddRange(items, text, selectedItem);
        }

        private void AddRange(IEnumerable<T> items, Func<T, string> text = null, T selectedItem = default)
        {
            if(items == null)
            {
                return;
            }

            ComboBoxControl_Main.AddRange(items, text);

            ComboBoxControl_Main.SetSelectedItem(selectedItem);
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

        public T SelectedItem
        {
            get
            {
                return ComboBoxControl_Main.GetSelectedItem<T>();
            }

            set
            {
                ComboBoxControl_Main.SetSelectedItem(value);
            }
        }

        public string Description
        {
            get
            {
                return ComboBoxControl_Main.Description;
            }

            set
            {
                ComboBoxControl_Main.Description = value;
            }
        }
    }
}
