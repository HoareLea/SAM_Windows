using System;
using System.Collections.Generic;

namespace SAM.Analytical.Windows
{
    public static partial class Query
    {
        public static List<Enum> CategoryEnums(bool inculdeUndefined = false)
        {
            List<Enum> result = new List<Enum>();
            foreach (ProfileType profileType in Enum.GetValues(typeof(ProfileType)))
            {
                if (!inculdeUndefined && profileType == ProfileType.Undefined)
                {
                    continue;
                }

                result.Add(profileType);
            }

            foreach (ProfileGroup profileGroup in Enum.GetValues(typeof(ProfileGroup)))
            {
                if (!inculdeUndefined && profileGroup == ProfileGroup.Undefined)
                {
                    continue;
                }

                result.Add(profileGroup);
            }

            return result;
        }
    }
}