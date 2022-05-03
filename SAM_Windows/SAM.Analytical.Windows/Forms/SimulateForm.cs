﻿using SAM.Weather;
using System;
using System.Windows.Forms;

namespace SAM.Analytical.Windows.Forms
{
    public partial class SimulateForm : Form
    {
        public SimulateForm()
        {
            InitializeComponent();
        }

        public SimulateForm(string projectName, string outputDirectory)
        {
            InitializeComponent();

            SimulateControl_Main.OutputDirectory = outputDirectory;
            SimulateControl_Main.ProjectName = projectName;
        }

        private void SimulateForm_Load(object sender, EventArgs e)
        {
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ProjectName))
            {
                MessageBox.Show("Provide project name");
                return;
            }

            if (string.IsNullOrWhiteSpace(OutputDirectory) || !System.IO.Directory.Exists(OutputDirectory))
            {
                MessageBox.Show("Given output directory does not exists. Please provide valid directory");
                return;
            }

            if(WeatherData == null)
            {
                MessageBox.Show("Provide Wether Data");
                return;
            }

            DialogResult = DialogResult.OK;

            Close();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        public string OutputDirectory
        {
            get
            {
                return SimulateControl_Main.OutputDirectory;
            }
        }

        public string ProjectName
        {
            get
            {
                return SimulateControl_Main.ProjectName;
            }
        }

        public WeatherData WeatherData
        {
            get
            {
                return SimulateControl_Main.WeatherData;
            }

            set
            {
                SimulateControl_Main.WeatherData = value;
            }
        }

        public bool UnmetHours
        {
            get
            {
                return SimulateControl_Main.UnmetHours;
            }
        }

        public SolarCalculationMethod SolarCalculationMethod
        {
            get
            {
                return SimulateControl_Main.SolarCalculationMethod;
            }
        }

        public bool UpdateConstructionLayersByPanelType
        {
            get
            {
                return SimulateControl_Main.UpdateConstructionLayersByPanelType;
            }
        }
    }
}
