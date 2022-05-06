using SAM.Core;
using SAM.Core.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Analytical.Windows
{
    public static partial class Query
    {
        public static AnalyticalModel AddMissingObjects(AnalyticalModel analyticalModel, IEnumerable<string> paths, out List<IJSAMObject> jSAMObejcts, IWin32Window owner = null)
        {
            jSAMObejcts = null;

            if (analyticalModel == null)
            {
                return null;
            }

            if (paths == null || paths.Count() == 0)
            {
                return new AnalyticalModel(analyticalModel);
            }

            List<string> names_InternalCondition = null;
            List<string> names_Material = null;
            Dictionary<ProfileType, List<string>> dictionary_ProfileName = null;

            using (SimpleProgressForm simpleProgressForm = new SimpleProgressForm("Collecting Data", string.Empty, 3))
            {
                simpleProgressForm.Increment("Internal Conditions");
                names_InternalCondition = analyticalModel.MissingInternalConditionsNames();

                simpleProgressForm.Increment("Materials");
                names_Material = analyticalModel.MissingMaterialsNames();

                simpleProgressForm.Increment("Profiles");
                dictionary_ProfileName = analyticalModel.MissingProfileNameDictionary();
            }

            names_InternalCondition = names_InternalCondition == null || names_InternalCondition.Count == 0 ? null : names_InternalCondition;
            names_Material = names_Material == null || names_Material.Count == 0 ? null : names_Material;
            dictionary_ProfileName = dictionary_ProfileName == null || dictionary_ProfileName.Count == 0 ? null : dictionary_ProfileName;

            if (names_InternalCondition == null && names_Material == null && dictionary_ProfileName == null)
            {
                MessageBox.Show("Nothing to be added");
                return null;
            }

            AdjacencyCluster adjacencyCluster = analyticalModel.AdjacencyCluster;
            MaterialLibrary materialLibrary = analyticalModel.MaterialLibrary;
            ProfileLibrary profileLibrary = analyticalModel.ProfileLibrary;

            jSAMObejcts = new List<IJSAMObject>();

            using (SimpleProgressForm simpleProgressForm = new SimpleProgressForm("Processing Data", string.Empty, 5))
            {
                simpleProgressForm.Increment("Paths");

                HashSet<string> paths_Temp = new HashSet<string>();
                foreach (string path in paths)
                {
                    if (System.IO.File.Exists(path))
                    {
                        paths_Temp.Add(path);
                    }

                    if (System.IO.Directory.Exists(path))
                    {
                        string[] paths_Temp_Temp = System.IO.Directory.GetFiles(path, "*.*");
                        if (paths_Temp_Temp != null && paths_Temp_Temp.Length != 0)
                        {
                            foreach (string path_Temp in paths_Temp_Temp)
                            {
                                paths_Temp.Add(path_Temp);
                            }
                        }
                    }
                }

                simpleProgressForm.Increment("Extracting Objects");

                List<Tuple<string, IJSAMObject>> jSAMObjects_Temp = new List<Tuple<string, IJSAMObject>>();
                foreach (string path in paths_Temp)
                {
                    try
                    {
                        Import<IJSAMObject>(path, out List<IJSAMObject> jSAMObjects_Temp_Temp, null, false, owner);
                        if (jSAMObjects_Temp_Temp != null)
                        {
                            jSAMObjects_Temp.AddRange(jSAMObjects_Temp_Temp.ConvertAll(x => new Tuple<string, IJSAMObject>(path, x)));
                        }
                    }
                    catch
                    {

                    }
                }

                simpleProgressForm.Increment("Internal Conditions");
                if (names_InternalCondition != null && names_InternalCondition.Count != 0)
                {
                    List<InternalCondition> internalConditions = jSAMObjects_Temp.FindAll(x => x.Item2 is InternalCondition).ConvertAll(x => (InternalCondition)x.Item2);
                    if (internalConditions != null)
                    {
                        foreach (string name in names_InternalCondition)
                        {
                            InternalCondition internalCondition = internalConditions.Find(x => x?.Name == name);
                            if (internalCondition != null)
                            {
                                if (adjacencyCluster.AddObject(internalCondition))
                                {
                                    jSAMObejcts.Add(internalCondition);
                                }
                            }
                        }
                    }
                }

                simpleProgressForm.Increment("Materials");
                if (names_Material != null && names_Material.Count != 0)
                {
                    List<IMaterial> materials = jSAMObjects_Temp.FindAll(x => x.Item2 is IMaterial).ConvertAll(x => (IMaterial)x.Item2);
                    if (materials != null && materials.Count != 0)
                    {
                        foreach (string name in names_Material)
                        {
                            IMaterial material = materials.Find(x => x?.Name == name);
                            if (material != null)
                            {
                                if (materialLibrary.Add(material))
                                {
                                    jSAMObejcts.Add(material);
                                }
                            }
                        }
                    }
                }

                simpleProgressForm.Increment("Profiles");
                if (dictionary_ProfileName != null && dictionary_ProfileName.Count != 0)
                {
                    List<Profile> profiles = jSAMObjects_Temp.FindAll(x => x.Item2 is Profile).ConvertAll(x => (Profile)x.Item2);
                    if (profiles != null && profiles.Count != 0)
                    {
                        ProfileLibrary profileLibrary_Temp = new ProfileLibrary("Temp ProfileLibrary", profiles);
                        foreach (KeyValuePair<ProfileType, List<string>> keyValuePair in dictionary_ProfileName)
                        {
                            foreach (string name in keyValuePair.Value)
                            {
                                if (string.IsNullOrEmpty(name))
                                {
                                    continue;
                                }

                                Profile profile = profileLibrary_Temp.GetProfile(name, keyValuePair.Key, false);
                                if (profile == null)
                                {
                                    profile = profileLibrary_Temp.GetProfile(name, keyValuePair.Key, true);
                                }

                                if (profile != null)
                                {
                                    if (profileLibrary.Add(profile))
                                    {
                                        jSAMObejcts.Add(profile);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return new AnalyticalModel(analyticalModel, adjacencyCluster, materialLibrary, profileLibrary);
        }
    }
}