using SAM.Analytical.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Analytical.Windows
{
    public static partial class Modify
    {
        public static Profile SelectProfile(this ProfileLibrary profileLibrary, ProfileType profileType, IWin32Window owner = null)
        {
            return SelectProfile(profileLibrary, (Enum)profileType, owner);
        }

        public static Profile SelectProfile(this ProfileLibrary profileLibrary, ProfileGroup profileGroup, IWin32Window owner = null)
        {
            return SelectProfile(profileLibrary, (Enum)profileGroup, owner);
        }

        private static Profile SelectProfile(this ProfileLibrary profileLibrary, Enum type, IWin32Window owner = null)
        {
            if(profileLibrary == null)
            {
                return null;
            }

            Profile result = null;
            using (ProfileLibraryForm profileLibraryForm = new ProfileLibraryForm(profileLibrary))
            {
                profileLibraryForm.Type = type;
                profileLibraryForm.TypeEnabled = false;
                if(profileLibraryForm.ShowDialog(owner) != DialogResult.OK)
                {
                    return null;
                }

                profileLibrary.RemoveAll();
                List<Profile> profiles = profileLibraryForm.ProfileLibrary?.GetProfiles();
                profiles?.ForEach(x => profileLibrary.Add(x));

                result = profileLibraryForm.GetProfiles(true)?.FirstOrDefault();
            }

            return result;

        }
    }
}