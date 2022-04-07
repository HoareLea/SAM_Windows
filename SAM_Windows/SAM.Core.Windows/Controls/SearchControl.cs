using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SAM.Core.Windows
{
    public partial class SearchControl<T> : UserControl
    {
        private SearchWrapper searchWrapper;

        private Dictionary<string, T> dictionary;

        public MouseEventHandler MouseDoubleClick;

        public System.EventHandler SelectedIndexChanged;

        public SearchControl()
        {
            InitializeComponent();
        }

        public SearchControl(IEnumerable<T> items, Func<T, string> text, bool caseSensitive = false)
        {
            InitializeComponent();

            searchWrapper = new SearchWrapper(caseSensitive);
            if (items != null)
            {
                dictionary = new Dictionary<string, T>();
                foreach (T item in items)
                {
                    string value = text == null ? item.ToString() : text.Invoke(item);

                    if (searchWrapper.Add(value))
                    {
                        dictionary[value] = item;
                    }
                }
            }

            Search();
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

            if (searchWrapper == null)
            {
                return;
            }

            List<string> texts = null; ;
            if (string.IsNullOrEmpty(TextBox_Text.Text) || TextBox_Text.Text.Length < 3)
            {
                IEnumerable<string> texts_Temp = searchWrapper.Texts;
                if (texts_Temp != null)
                {
                    texts = new List<string>(texts_Temp);
                }
            }
            else
            {
                texts = searchWrapper.Search(TextBox_Text.Text, true);
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

        public List<T> SelectedItems
        {
            get
            {
                if (ListBox_Texts.SelectedItems == null)
                {
                    return null;
                }

                List<T> result = new List<T>();
                foreach (string text in ListBox_Texts.SelectedItems)
                {
                    if (dictionary.TryGetValue(text, out T item))
                    {
                        result.Add(item);
                    }
                }

                return result;
            }
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
    }
}
