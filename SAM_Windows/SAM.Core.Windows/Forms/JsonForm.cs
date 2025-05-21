using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SAM.Core.Windows.Forms
{
    public partial class JsonForm<T> : Form where T : IJSAMObject
    {
        private List<T> jSAMObjects;

        public JsonForm()
        {
            InitializeComponent();
        }

        public JsonForm(T jSAMObject)
        {
            if (jSAMObject != null)
            {
                jSAMObjects = new List<T>() { jSAMObject };

            }

            InitializeComponent();
        }

        public JsonForm(IEnumerable<T> jSAMObjects)
        {
            if (jSAMObjects != null)
            {
                this.jSAMObjects = new List<T>(jSAMObjects);
            }

            InitializeComponent();
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            if(jSAMObjects == null)
            {
                return;
            }

            string path = null;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                path = saveFileDialog.FileName;
            }

            if(string.IsNullOrWhiteSpace(path))
            {
                return;
            }

            Core.Convert.ToFile(jSAMObjects, path);
        }

        private void Button_Close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void JsonForm_Load(object sender, EventArgs e)
        {
            if(jSAMObjects == null)
            {
                return;
            }

            string text = Core.Convert.ToString(jSAMObjects?.ConvertAll(x => x as IJSAMObject));

            RichTextBox_Main.Text = text;
        }

        private void Button_Copy_Click(object sender, EventArgs e)
        {
            string text = Core.Convert.ToString(jSAMObjects?.ConvertAll(x => x as IJSAMObject));
            if(text == null)
            {
                text = string.Empty;
            }

            Clipboard.SetText(text);
        }
    }
}
