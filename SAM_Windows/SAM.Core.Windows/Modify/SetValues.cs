using System.Collections.Generic;
using System.Linq;

namespace SAM.Core.Windows
{
    public static partial class Modify
    {
        public static List<CustomParameter> SetValues(this SAMObject sAMObject, CustomParameters customParameters)
        {
            return SetValues(sAMObject, customParameters?.Cast<CustomParameter>());
        }

        public static List<CustomParameter> SetValues(this SAMObject sAMObject, IEnumerable<CustomParameter> customParameters)
        {
            if(sAMObject == null || customParameters == null)
            {
                return null;
            }

            if(customParameters.Count() == 0)
            {
                return null;
            }

            List<CustomParameter> result = new List<CustomParameter>();
            foreach(CustomParameter customParameter in customParameters)
            {
                if(sAMObject.SetValue(customParameter))
                {
                    result.Add(customParameter);
                }
            }

            return result;
        }

    }
}