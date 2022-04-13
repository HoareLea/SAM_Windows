﻿using SAM.Core;
using SAM.Core.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SAM.Analytical.Windows
{
    public static partial class Query
    {
        public static List<T> Import<T>(out List<IJSAMObject> jSAMObjects, Func<T, bool> func = null, IWin32Window owner = null) where T: IJSAMObject
        {
            jSAMObjects = null;

            string path = null;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                string directory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SAM");
                if (System.IO.Directory.Exists(directory))
                {
                    openFileDialog.InitialDirectory = directory;
                }

                openFileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog(owner) != DialogResult.OK)
                {
                    return null;
                }
                path = openFileDialog.FileName;
            }

            if (string.IsNullOrWhiteSpace(path) || !System.IO.File.Exists(path))
            {
                return null;
            }

            List<IJSAMObject> jSAMObjects_Open = new List<IJSAMObject>();

            try
            {
                jSAMObjects_Open = Core.Convert.ToSAM<IJSAMObject>(path);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Cannot open file specified");
                return null;
            }

            if (jSAMObjects_Open == null || jSAMObjects_Open.Count == 0)
            {
                MessageBox.Show("No objects to import");
                return null;
            }

            List<Tuple<string, string, T>> tuples_All = new List<Tuple<string, string, T>>();
            jSAMObjects = new List<IJSAMObject>();
            foreach (IJSAMObject jSAMObject in jSAMObjects_Open)
            {
                if (jSAMObject == null)
                {
                    continue;
                }

                AdjacencyCluster adjacencyCluster = null;

                if(jSAMObject is AdjacencyCluster)
                {
                    adjacencyCluster = (AdjacencyCluster)jSAMObject;
                }
                else if(jSAMObject is AnalyticalModel)
                {
                    AnalyticalModel analyticalModel = (AnalyticalModel)jSAMObject;

                    List<IMaterial> materials = analyticalModel.MaterialLibrary?.GetMaterials();
                    if (materials != null)
                    {
                        foreach (IMaterial material in materials)
                        {
                            if (material is T)
                            {
                                tuples_All.Add(new Tuple<string, string, T>(typeof(Material).Name, material.Name, (T)material));
                            }

                            jSAMObjects.Add(material);
                        }
                    }

                    List<Profile> profiles_Temp = analyticalModel.ProfileLibrary?.GetProfiles();
                    if (profiles_Temp != null)
                    {
                        foreach (Profile profile in profiles_Temp)
                        {
                            if (profile is T)
                            {
                                tuples_All.Add(new Tuple<string, string, T>(typeof(Profile).Name, profile.Name, (T)(object)profile));
                            }

                            jSAMObjects.Add(profile);
                        }
                    }

                    adjacencyCluster = analyticalModel.AdjacencyCluster;
                }

                if(adjacencyCluster != null)
                {
                    List<Construction> constructions_Temp = adjacencyCluster.GetConstructions();
                    if (constructions_Temp != null)
                    {
                        foreach (Construction construction in constructions_Temp)
                        {
                            if (construction is T)
                            {
                                tuples_All.Add(new Tuple<string, string, T>(typeof(Construction).Name, construction.Name, (T)(object)construction));
                            }

                            jSAMObjects.Add(construction);
                        }
                    }

                    IEnumerable<InternalCondition> internalConditions = adjacencyCluster.GetInternalConditions(false, true);
                    if (internalConditions != null)
                    {
                        foreach (InternalCondition internalCondition in internalConditions)
                        {
                            if (internalCondition is T)
                            {
                                tuples_All.Add(new Tuple<string, string, T>(typeof(InternalCondition).Name, internalCondition.Name, (T)(object)internalCondition));
                            }

                            jSAMObjects.Add(internalCondition);
                        }
                    }
                }

                if (jSAMObject is MaterialLibrary)
                {
                    List<IMaterial> materials = ((MaterialLibrary)jSAMObject).GetMaterials();
                    if (materials != null)
                    {
                        foreach (IMaterial material in materials)
                        {
                            if (material is T)
                            {
                                tuples_All.Add(new Tuple<string, string, T>(typeof(Material).Name, material.Name, (T)material));
                            }

                            jSAMObjects.Add(material);
                        }
                    }

                }
                else if (jSAMObject is ConstructionLibrary)
                {
                    List<Construction> constructions_Temp = ((ConstructionLibrary)jSAMObject).GetConstructions();
                    if (constructions_Temp != null)
                    {
                        foreach (Construction construction in constructions_Temp)
                        {
                            if (construction is T)
                            {
                                tuples_All.Add(new Tuple<string, string, T>(typeof(Construction).Name, construction.Name, (T)(object)construction));
                            }

                            jSAMObjects.Add(construction);
                        }
                    }

                }
                else if (jSAMObject is ProfileLibrary)
                {
                    List<Profile> profiles_Temp = ((ProfileLibrary)jSAMObject).GetProfiles();
                    if (profiles_Temp != null)
                    {
                        foreach (Profile profile in profiles_Temp)
                        {
                            if (profile is T)
                            {
                                tuples_All.Add(new Tuple<string, string, T>(typeof(Profile).Name, profile.Name, (T)(object)profile));
                            }

                            jSAMObjects.Add(profile);
                        }
                    }

                }
                else if (jSAMObject is ApertureConstructionLibrary)
                {
                    List<ApertureConstruction> apertureConstructions_Temp = ((ApertureConstructionLibrary)jSAMObject).GetApertureConstructions();
                    if (apertureConstructions_Temp != null)
                    {
                        foreach (ApertureConstruction apertureConstruction in apertureConstructions_Temp)
                        {
                            if (apertureConstruction is T)
                            {
                                tuples_All.Add(new Tuple<string, string, T>(typeof(ApertureConstruction).Name, apertureConstruction.Name, (T)(object)apertureConstruction));
                            }

                            jSAMObjects.Add(apertureConstruction);
                        }
                    }

                }
                else if (jSAMObject is InternalConditionLibrary)
                {
                    List<InternalCondition> internalConditions_Temp = ((InternalConditionLibrary)jSAMObject).GetInternalConditions();
                    if (internalConditions_Temp != null)
                    {
                        foreach (InternalCondition internalCondition in internalConditions_Temp)
                        {
                            if (internalCondition is T)
                            {
                                tuples_All.Add(new Tuple<string, string, T>(typeof(InternalCondition).Name, internalCondition.Name, (T)(object)internalCondition));
                            }

                            jSAMObjects.Add(internalCondition);
                        }
                    }

                }
                else if (jSAMObject is T)
                {
                    jSAMObjects.Add(jSAMObject);

                    if (jSAMObject is IMaterial)
                    {
                        tuples_All.Add(new Tuple<string, string, T>(typeof(Material).Name, ((IMaterial)jSAMObject).Name, (T)jSAMObject));
                    }
                    else if (jSAMObject is Construction)
                    {
                        tuples_All.Add(new Tuple<string, string, T>(typeof(Construction).Name, ((Construction)jSAMObject).Name, (T)jSAMObject));
                    }
                    else if (jSAMObject is ApertureConstruction)
                    {
                        tuples_All.Add(new Tuple<string, string, T>(typeof(ApertureConstruction).Name, ((ApertureConstruction)jSAMObject).Name, (T)jSAMObject));
                    }
                    else if (jSAMObject is Profile)
                    {
                        tuples_All.Add(new Tuple<string, string, T>(typeof(Profile).Name, ((Profile)jSAMObject).Name, (T)jSAMObject));
                    }
                    else if (jSAMObject is InternalCondition)
                    {
                        tuples_All.Add(new Tuple<string, string, T>(typeof(InternalCondition).Name, ((InternalCondition)jSAMObject).Name, (T)jSAMObject));
                    }
                    else if (jSAMObject is SAMObject)
                    {
                        tuples_All.Add(new Tuple<string, string, T>(jSAMObject.GetType().Name, ((SAMObject)jSAMObject).Name, (T)jSAMObject));
                    }
                }
            }

            if (func != null && tuples_All != null)
            {
                for (int i = tuples_All.Count - 1; i >= 0; i--)
                {
                    if (!func.Invoke(tuples_All[i].Item3))
                    {
                        tuples_All.RemoveAt(i);
                    }
                }
            }

            if (tuples_All == null || tuples_All.Count == 0)
            {
                MessageBox.Show("No objects to import");
                return null;
            }

            HashSet<string> groups = new HashSet<string>();
            tuples_All.ForEach(x => groups.Add(x.Item1));

            List<Tuple<string, string, T>> tuples_Selected = null;
            using (TreeViewForm<Tuple<string, string, T>> treeViewForm = new TreeViewForm<Tuple<string, string, T>>("Select Objects", tuples_All, (Tuple<string, string, T> x) => x.Item2, (Tuple<string, string, T> x) => x.Item1))
            {
                if (groups.Count < 2)
                {
                    treeViewForm.ExpandAll();
                }

                if (treeViewForm.ShowDialog(owner) != DialogResult.OK)
                {
                    return null;
                }

                tuples_Selected = treeViewForm?.SelectedItems;
            }

            if (tuples_Selected == null || tuples_Selected.Count == 0)
            {
                return null;
            }

            return tuples_Selected.ConvertAll(x => x.Item3);
        }

        public static List<T> Import<T>(Func<T, bool> func = null, IWin32Window owner = null) where T :IJSAMObject
        {
            return Import(out List<IJSAMObject> jSAMObjects, func, owner);
        }
        
        public static AnalyticalModel Import<T>(this AnalyticalModel analyticalModel, Func<T, bool> func = null, IWin32Window owner = null) where T: IJSAMObject
        {
            List<T> jSAMObjects = Import(out List<IJSAMObject> jSAMObjects_All,  func, owner);
            if(jSAMObjects == null)
            {
                return null;
            }

            AdjacencyCluster adjacencyCluster = analyticalModel.AdjacencyCluster;
            if(adjacencyCluster == null)
            {
                adjacencyCluster = new AdjacencyCluster();
            }

            List<Construction> constructions = new List<Construction>();
            List<ApertureConstruction> apertureConstructions = new List<ApertureConstruction>();
            List<InternalCondition> internalConditions = new List<InternalCondition>();
            foreach (T jSAMObject in jSAMObjects)
            {
                if(jSAMObject == null)
                {
                    continue;
                }

                if (jSAMObject is IMaterial)
                {
                    analyticalModel.AddMaterial((IMaterial)jSAMObject);
                }
                else if (jSAMObject is Profile)
                {
                    analyticalModel.AddProfile((Profile)(object)jSAMObject);
                }
                else if (jSAMObject is Construction)
                {
                    constructions.Add((Construction)(object)jSAMObject);
                }
                else if (jSAMObject is ApertureConstruction)
                {
                    apertureConstructions.Add((ApertureConstruction)(object)jSAMObject);
                }
                else if(jSAMObject is InternalCondition)
                {
                    internalConditions.Add((InternalCondition)(object)jSAMObject);
                }
            }

            if (constructions != null && constructions.Count != 0)
            {
                adjacencyCluster.UpdateConstructions(constructions);
            }

            if (apertureConstructions != null && apertureConstructions.Count != 0)
            {
                adjacencyCluster.UpdateApertureConstructions(apertureConstructions);
            }

            if (apertureConstructions != null || constructions != null)
            {
                HashSet<string> names = new HashSet<string>();

                if (constructions != null)
                {
                    foreach (Construction construction in constructions)
                    {
                        List<ConstructionLayer> constructionLayers = construction?.ConstructionLayers;
                        if (constructionLayers != null)
                        {
                            foreach (ConstructionLayer constructionLayer in constructionLayers)
                            {
                                names.Add(constructionLayer.Name);
                            }
                        }
                    }
                }

                if (apertureConstructions != null)
                {
                    foreach (ApertureConstruction apertureConstruction in apertureConstructions)
                    {
                        List<ConstructionLayer> constructionLayers = null;

                        constructionLayers = apertureConstruction?.PaneConstructionLayers;
                        if (constructionLayers != null)
                        {
                            foreach (ConstructionLayer constructionLayer in constructionLayers)
                            {
                                names.Add(constructionLayer.Name);
                            }
                        }

                        constructionLayers = apertureConstruction?.FrameConstructionLayers;
                        if (constructionLayers != null)
                        {
                            foreach (ConstructionLayer constructionLayer in constructionLayers)
                            {
                                names.Add(constructionLayer.Name);
                            }
                        }
                    }
                }

                List<IMaterial> materials = jSAMObjects_All?.FindAll(x => x is IMaterial).ConvertAll(x => (IMaterial)x);
                if (materials != null && materials.Count != 0)
                {
                    MaterialLibrary materialLibrary = analyticalModel.MaterialLibrary;

                    HashSet<string> names_Missing = new HashSet<string>();
                    foreach (string name in names)
                    {
                        if (materialLibrary?.GetMaterial(name) == null)
                        {
                            names_Missing.Add(name);
                        }
                    }

                    if (names_Missing != null && names_Missing.Count != 0)
                    {
                        DialogResult dialogResult = MessageBox.Show(owner, "Try to import missing materials?", "Materials", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            foreach (string name in names_Missing)
                            {
                                IMaterial material = materials.Find(x => x.Name == name);
                                if (material != null)
                                {
                                    analyticalModel.AddMaterial(material);
                                }
                            }
                        }
                    }
                }
            }

            if(internalConditions != null)
            {
                ProfileLibrary profileLibrary = analyticalModel.ProfileLibrary;

                List<Profile> profiles = jSAMObjects_All?.FindAll(x => x is Profile).ConvertAll(x => (Profile)x);

                Dictionary<ProfileType, HashSet<string>> dictionary_Profile = new Dictionary<ProfileType, HashSet<string>>();
                foreach(InternalCondition internalCondition in internalConditions)
                {
                    adjacencyCluster.AddObject(internalCondition);

                    if(profiles != null && profiles.Count != 0)
                    {
                        IEnumerable<ProfileType> profileTypes = internalCondition.GetProfileTypes();
                        if (profileTypes != null)
                        {
                            foreach (ProfileType profileType in profileTypes)
                            {
                                string name = internalCondition.GetProfileName(profileType);
                                if (string.IsNullOrEmpty(name))
                                {
                                    continue;
                                }

                                Profile profile = internalCondition.GetProfile(profileType, profileLibrary);
                                if (profile != null)
                                {
                                    continue;
                                }

                                if (!dictionary_Profile.TryGetValue(profileType, out HashSet<string> names))
                                {
                                    names = new HashSet<string>();
                                    dictionary_Profile[profileType] = names;
                                }

                                names.Add(name);

                            }
                        }
                    }
                }

                if(dictionary_Profile != null && dictionary_Profile.Count != 0)
                {
                    DialogResult dialogResult = MessageBox.Show(owner, "Try to import missing profiles?", "Profiles", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        foreach(KeyValuePair<ProfileType, HashSet<string>> keyValuePair in dictionary_Profile)
                        {
                            foreach(string name in keyValuePair.Value)
                            {
                                Profile profile = Analytical.Query.Profile(profiles, name, keyValuePair.Key, true);
                                if(profile != null)
                                {
                                    analyticalModel.AddProfile(profile);
                                }
                            }
                        }
                    }
                }
            }

            analyticalModel = new AnalyticalModel(analyticalModel);

            return new AnalyticalModel(analyticalModel, adjacencyCluster);
        }

        public static AnalyticalModel Import(this AnalyticalModel analyticalModel, IWin32Window owner = null)
        {
            return Import<IJSAMObject>(analyticalModel, null, owner);
        }

        public static AnalyticalModel Import<T>(this AnalyticalModel analyticalModel, IWin32Window owner = null) where T: IJSAMObject
        {
            return Import(analyticalModel, (IJSAMObject x) => x is T, owner);
        }
    }
}