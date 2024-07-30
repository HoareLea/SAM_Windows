using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace SAM.Core.Windows
{
    public partial class ComboBoxControl : UserControl
    {
        public System.EventHandler SelectedIndexChanged;

        public ComboBoxControl()
        {
            InitializeComponent();

            ComboBox_Main.DisplayMember = "Text";
            ComboBox_Main.ValueMember = "Object";
        }

        [Description("Description for value"), Category("Data")]
        public string Description
        {
            get
            {
                return Label_Description.Text;
            }

            set
            {
                Label_Description.Text = value;
            }
        }

        public void AddRange<T>(IEnumerable<T> items, Func<T, string> text = null)
        {
            if (items == null)
            {
                return;
            }

            foreach (T item in items)
            {
                string value_text = text == null ? item.ToString() : text?.Invoke(item);
                if (value_text == null)
                {
                    continue;
                }

                ComboBox_Main.Items.Add(new { Object = item, Text = value_text });
            }
        }

        public void Add(object item, string text)
        {
            ComboBox_Main.Items.Add(new { Object = item, Text = text });
        }

        public void AddEnums(Type type)
        {
            if(type == null || !type.IsEnum)
            {
                return;
            }

            List<Enum> @enums = new List<Enum>();
            foreach (Enum @enum in Enum.GetValues(type))
            {
                @enums.Add(@enum);
            }

            AddRange(enums, (Enum x) => Core.Query.Description(x));
        }

        public T GetSelectedItem<T>()
        {
            if (ComboBox_Main?.SelectedItem == null)
            {
                return default;
            }

            return (ComboBox_Main.SelectedItem as dynamic).Object;
        }

        public bool SetSelectedItem<T>(T item)
        {
            if(ComboBox_Main.Items == null)
            {
                return false;
            }

            foreach(dynamic @dynamic in ComboBox_Main.Items)
            {
                if (@dynamic.Object == item)
                {
                    ComboBox_Main.SelectedItem = @dynamic;
                    return true;
                }
            }

            return false;
        }

        public List<T> GetItems<T>()
        {
            if(ComboBox_Main.Items == null)
            {
                return null;
            }

            List<T> result = new List<T>();
            foreach (dynamic @dynamic in ComboBox_Main.Items)
            {
                if (@dynamic.Object is T)
                {
                    result.Add((T)dynamic.Object);
                }
            }

            return result;
        }

        public void ClearItems()
        {
            ComboBox_Main.Items.Clear();
        }

        private void ComboBox_Main_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.EventHandler eventHandler = SelectedIndexChanged;
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }
    }
}
