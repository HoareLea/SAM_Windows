using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SAM.Core.Windows.Forms
{
    public partial class SearchForm<T> : Form
    {
        
        public SearchForm()
        {
            InitializeComponent();
        }

        public SearchForm(string name, IEnumerable<T> items, Func<T, string> text, bool caseSensitive = false)
        {
            InitializeComponent();

            SearchControl_Main.SearchObjectWrapper = Core.Create.SearchObjectWrapper(items, text, caseSensitive);

            Text = name;
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        public string SearchText
        {
            get
            {
                return SearchControl_Main.SearchText;
            }
            set
            {
                SearchControl_Main.SearchText = value;
            }
        }

        public SelectionMode SelectionMode
        {
            get
            {
                return SearchControl_Main.SelectionMode;
            }

            set
            {
                SearchControl_Main.SelectionMode = value;
            }
        }

        public List<T> SelectedItems
        {
            get
            {
                return SearchControl_Main.GetSelectedItems<T>();
            }
        }

        private void SearchControl_Main_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SearchControl_Main.SelectedItems != null && SearchControl_Main.SelectedItems.Count != 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void SearchForm_Shown(object sender, EventArgs e)
        {
            SearchControl_Main.Focus();
        }
    }
}
