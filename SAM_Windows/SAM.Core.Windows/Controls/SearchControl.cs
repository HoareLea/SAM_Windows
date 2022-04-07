using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SAM.Core.Windows
{
    public partial class SearchControl : UserControl
    {
        private SearchObjectWrapper searchObjectWrapper;

        public MouseEventHandler MouseDoubleClick;

        public System.EventHandler SelectedIndexChanged;

        public SearchControl()
        {
            InitializeComponent();
        }

        public SearchControl(IEnumerable<object> items, Func<object, string> text, bool caseSensitive = false)
        {
            InitializeComponent();

            searchObjectWrapper = new SearchObjectWrapper(items, text, caseSensitive);

            Search();
        }

        public SearchObjectWrapper SearchObjectWrapper
        {
            get
            {
                return searchObjectWrapper;
            }
            set
            {
                searchObjectWrapper = value;
                Search();
            }
        }

        private void Search()
        {

            List<string> selectedTexts = null;
            if (ListBox_Texts.SelectedItems != null && ListBox_Texts.SelectedItems.Count != 0)
            {
                selectedTexts = new List<string>();
                foreach (string selectedText in ListBox_Texts.SelectedItems)
                {
                    selectedTexts.Add(selectedText);
                }
            }

            ListBox_Texts.Items.Clear();

            if (searchObjectWrapper == null)
            {
                return;
            }

            List<string> texts = null;
            if (string.IsNullOrEmpty(TextBox_Text.Text) || TextBox_Text.Text.Length < 3)
            {
                IEnumerable<string> texts_Temp = searchObjectWrapper.Texts;
                if (texts_Temp != null)
                {
                    texts = new List<string>(texts_Temp);
                }
            }
            else
            {
                texts = searchObjectWrapper.SearchTexts(TextBox_Text.Text, true);
            }

            if (texts == null || texts.Count == 0)
            {
                return;
            }

            foreach (string text in texts)
            {
                ListBox_Texts.Items.Add(text);
            }

            if (selectedTexts != null && selectedTexts.Count != 0)
            {
                foreach (string selectedText in selectedTexts)
                {
                    ListBox_Texts.SelectedItems.Add(selectedText);
                }
            }
        }

        public string SearchText
        {
            get
            {
                return TextBox_Text.Text;
            }
            set
            {
                TextBox_Text.Text = value;
                TextBox_Text.SelectAll();
            }
        }

        public SelectionMode SelectionMode
        {
            get
            {
                return ListBox_Texts.SelectionMode;
            }

            set
            {
                ListBox_Texts.SelectionMode = value;
            }
        }

        public List<object> SelectedItems
        {
            get
            {
                if (ListBox_Texts.SelectedItems == null)
                {
                    return null;
                }

                List<object> result = new List<object>();
                foreach (string text in ListBox_Texts.SelectedItems)
                {
                    object item = searchObjectWrapper.GetItem<object>(text);
                    if (item != null)
                    {
                        result.Add(item);
                    }
                }

                return result;
            }
        }

        public List<T> GetSelectedItems<T>()
        {
            List<object> selectedItems = SelectedItems;
            if(selectedItems == null)
            {
                return null;
            }

            return selectedItems.FindAll(x => x is T).ConvertAll(x => (T)x);
        }

        private void ListBox_Texts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MouseEventHandler mouseEventHandler = MouseDoubleClick;
            if (mouseEventHandler != null)
            {
                mouseEventHandler(this, e);
            }
        }

        private void TextBox_Text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && ListBox_Texts.Items != null && ListBox_Texts.Items.Count > 0)
            {
                ListBox_Texts.Focus();
            }
        }

        private void ListBox_Texts_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.EventHandler eventHandler = SelectedIndexChanged;
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }

        private void TextBox_Text_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
