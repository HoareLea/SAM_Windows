using SAM.Core;
using SAM.Core.Windows;
using SAM.Core.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Analytical.Windows
{
    public static partial class Query
    {
        public static AnalyticalModel Clean(this AnalyticalModel analyticalModel, IWin32Window owner = null) 
        {
            if(analyticalModel == null)
            {
                return null;
            }

            List<IJSAMObject> jSAMObjects = new List<IJSAMObject>();

            AdjacencyCluster adjacencyCluster = analyticalModel.AdjacencyCluster;

            ProfileLibrary profileLibrary = null;

            MaterialLibrary materialLibrary = null;

            using (ProgressForm simpleProgressForm = new ProgressForm("Collecting Data", 4))
            {
                simpleProgressForm.Update("Extracting Data");

                profileLibrary = analyticalModel.ProfileLibrary;

                List<Space> spaces = adjacencyCluster.GetSpaces();
                List<InternalCondition> internalConditions = adjacencyCluster?.GetInternalConditions(false, true)?.ToList();

                materialLibrary = analyticalModel.MaterialLibrary;

                List<Construction> constructions = adjacencyCluster?.GetConstructions();

                List<ApertureConstruction> apertureConstructions = adjacencyCluster?.GetApertureConstructions();

                List<Panel> panels = adjacencyCluster.GetPanels();

                simpleProgressForm.Update("Spaces");
                if (spaces != null)
                {
                    foreach (Space space in spaces)
                    {
                        InternalCondition internalCondition = space.InternalCondition;
                        if (internalCondition != null)
                        {
                            internalConditions?.RemoveAll(x => x.Name == internalCondition.Name);

                            IEnumerable<Profile> profiles = internalCondition.GetProfiles(profileLibrary);
                            if (profiles != null)
                            {
                                foreach (Profile profile in profiles)
                                {
                                    profileLibrary.Remove(profile);
                                }
                            }
                        }
                    }
                }

                simpleProgressForm.Update("Constructions");
                if (constructions != null)
                {
                    foreach (Construction construction in constructions)
                    {
                        List<IMaterial> materials = construction.Materials<IMaterial>(materialLibrary)?.ToList();
                        if (materials != null)
                        {
                            foreach (IMaterial material in materials)
                            {
                                materialLibrary.Remove(material);
                            }
                        }
                    }
                }

                simpleProgressForm.Update("Panels");
                if (panels != null)
                {
                    foreach (Panel panel in panels)
                    {
                        Construction construction = panel?.Construction;
                        if (construction != null)
                        {
                            constructions?.RemoveAll(x => x.Guid == construction.Guid);
                        }

                        List<Aperture> apertures = panel?.Apertures;
                        if (apertures != null)
                        {
                            foreach (Aperture aperture in apertures)
                            {
                                ApertureConstruction apertureConstruction = aperture.ApertureConstruction;
                                if (apertureConstruction != null)
                                {
                                    apertureConstructions?.RemoveAll(x => x.Guid == apertureConstruction.Guid);
                                }
                            }
                        }
                    }
                }

                profileLibrary?.GetProfiles()?.ForEach(x => jSAMObjects.Add(x));
                materialLibrary?.GetMaterials()?.ForEach(x => jSAMObjects.Add(x));
                constructions?.ForEach(x => jSAMObjects.Add(x));
                apertureConstructions?.ForEach(x => jSAMObjects.Add(x));
                internalConditions?.ForEach(x => jSAMObjects.Add(x));
            }

            if(jSAMObjects == null || jSAMObjects.Count == 0)
            {
                MessageBox.Show("Nothing to be cleaned.");
            }

            using (TreeViewForm<IJSAMObject> treeViewForm = new TreeViewForm<IJSAMObject>("Select Items", jSAMObjects, (IJSAMObject x) => (x as SAMObject)?.Name, (IJSAMObject x) => x.GetType().Name))
            {
                if(treeViewForm.ShowDialog(owner) != DialogResult.OK)
                {
                    return null;
                }

                jSAMObjects = treeViewForm.SelectedItems;
            }

            if (jSAMObjects == null || jSAMObjects.Count == 0)
            {
                return new AnalyticalModel(analyticalModel);
            }

            profileLibrary = analyticalModel.ProfileLibrary;
            materialLibrary = analyticalModel.MaterialLibrary;

            using (ProgressForm simpleProgressForm = new ProgressForm("Removing Elements", jSAMObjects.Count))
            {
                foreach (IJSAMObject jSAMObject in jSAMObjects)
                {
                    string name = (jSAMObject as SAMObject)?.Name;
                    name = string.IsNullOrWhiteSpace(name) ? "???" : name;

                    simpleProgressForm.Update(name);

                    if (jSAMObject is Profile)
                    {
                        profileLibrary.Remove((Profile)jSAMObject);
                    }

                    if (jSAMObject is Material)
                    {
                        materialLibrary.Remove((Material)jSAMObject);
                    }

                    SAMObject sAMObject = jSAMObject as SAMObject;
                    if (sAMObject != null)
                    {
                        adjacencyCluster.RemoveObject(sAMObject.GetType(), sAMObject.Guid);
                    }
                }
            }

            return new AnalyticalModel(analyticalModel, adjacencyCluster, materialLibrary, profileLibrary);
        }
    }
}