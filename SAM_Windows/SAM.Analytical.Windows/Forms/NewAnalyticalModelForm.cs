using SAM.Core;
using System;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Forms
{
    public partial class NewAnalyticalModelForm : Form
    {
        private string templatesDirectory;

        public NewAnalyticalModelForm(string analyticalModelName = null, string templatesDirectory = null)
        {
            InitializeComponent();

            TextBoxControl_ProjectName.SetValue(analyticalModelName);

            this.templatesDirectory = string.IsNullOrEmpty(templatesDirectory) ? Core.Query.TemplatesDirectory<AnalyticalModel>() : templatesDirectory;
        }

        private void NewAnalyticalModelForm_Load(object sender, EventArgs e)
        {
            string none = null;

            ComboBoxControl_Template.Add(none, "<none>");

            ComboBoxControl_Template.SetSelectedItem(none);
            if (!string.IsNullOrWhiteSpace(templatesDirectory) && System.IO.Directory.Exists(templatesDirectory))
            {
                string[] paths = System.IO.Directory.GetFiles(templatesDirectory);
                if(paths != null && paths.Length != 0)
                {
                    foreach(string path in paths)
                    {
                        ComboBoxControl_Template.Add(path, System.IO.Path.GetFileNameWithoutExtension(path));
                    }
                }
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

        public AnalyticalModel GetAnalyticalModel()
        {
            AnalyticalModel result = new AnalyticalModel(Guid.NewGuid(), TextBoxControl_ProjectName.GetValue<string>());

            string fileName = ComboBoxControl_Template.GetSelectedItem<string>();
            if(string.IsNullOrEmpty(fileName) || string.IsNullOrWhiteSpace(templatesDirectory))
            {
                return result;
            }

            if(!System.IO.Directory.Exists(templatesDirectory))
            {
                return result;
            }

            string path = System.IO.Path.Combine(templatesDirectory, fileName);
            if(!System.IO.File.Exists(path))
            {
                return result;
            }

            return result.Import<IJSAMObject>(path, false, this);
        }


    }
}
