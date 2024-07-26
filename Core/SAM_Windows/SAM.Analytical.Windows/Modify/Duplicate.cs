using SAM.Analytical.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Analytical.Windows
{
    public static partial class Modify
    {
        public static InternalCondition Duplicate(this AnalyticalModel analyticalModel, InternalCondition internalCondition, IWin32Window owner = null)
        {
            if(analyticalModel == null || internalCondition == null)
            {
                return null;
            }

            ProfileLibrary profileLibrary = analyticalModel.ProfileLibrary;

            AdjacencyCluster adjacencyCluster = analyticalModel.AdjacencyCluster;

            List<InternalCondition> internalConditions = adjacencyCluster.GetInternalConditions(false, true)?.ToList();

            string name = (string.IsNullOrWhiteSpace(internalCondition.Name) ? string.Empty : internalCondition.Name).Trim();
            string name_Temp = name;
            int index = 1;
            while (internalConditions?.Find(x => x.Name == name_Temp) != null)
            {
                name_Temp = string.Format("{0} {1}", name, index.ToString());
                index++;
            }
            name = name_Temp;

            internalCondition = new InternalCondition(name, System.Guid.NewGuid(), internalCondition);
            if (internalCondition == null)
            {
                MessageBox.Show("InternalCondition cannot be duplicated");
                return null;
            }

            using (InternalConditionForm internalConditionForm = new InternalConditionForm(internalCondition, profileLibrary, adjacencyCluster))
            {
                internalConditionForm.UseColors = false;
                if (internalConditionForm.ShowDialog(owner) != DialogResult.OK)
                {
                    return null;
                }

                internalCondition = internalConditionForm.InternalCondition;
            }

            if (internalCondition == null)
            {
                return null;
            }

            return internalCondition;
        }

    }
}