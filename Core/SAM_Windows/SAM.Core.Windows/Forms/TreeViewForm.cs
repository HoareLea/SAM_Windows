using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SAM.Core.Windows.Forms
{
    public partial class TreeViewForm<T> : Form
    {
        public TreeViewForm()
        {
            InitializeComponent();
        }

        public TreeViewForm(string name, IEnumerable<T> items)
        {
            InitializeComponent();

            Text = name;
            TreeViewControl_Main.AddRange(items);
        }

        public TreeViewForm(string name, IEnumerable<T> items, Func<T, string> text)
        {
            InitializeComponent();

            Text = name;
            TreeViewControl_Main.AddRange(items, text, null);
        }

        public TreeViewForm(string name, IEnumerable<T> items, Func<T, string> text, Func<T, string> group)
        {
            InitializeComponent();

            Text = name;
            TreeViewControl_Main.AddRange(items, text, group);
        }

        public TreeViewForm(string name, IEnumerable<T> items, Func<T, string> text, Func<T, string> group, Func<T, bool> @checked)
        {
            InitializeComponent();

            Text = name;
            TreeViewControl_Main.AddRange(items, text, group, @checked);
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

        public List<T> SelectedItems
        {
            get
            {
                return TreeViewControl_Main.GetSelectedItems<T>();
            }
        }

        public void ExpandAll()
        {

            TreeViewControl_Main.ExpandAll();
        }

        public void CollapseAll()
        {
            TreeViewControl_Main.CollapseAll();
        }
    }
}
