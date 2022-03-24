using System;

namespace SAM.Core.Windows
{
    public static partial class Create
    {
        public static CustomParameters CustomParameters(this SAMObject sAMObject, params Type[] enumTypes)
        {
            if (sAMObject == null || enumTypes == null)
            {
                return null;
            }

            CustomParameters result = new CustomParameters();
            foreach(Type type in enumTypes)
            {
                if(type == null || !type.IsEnum)
                {
                    continue;
                }

                foreach(Enum @enum in Enum.GetValues(type))
                {
                    ParameterData parameterData = Core.Create.ParameterData(@enum);
                    if (parameterData == null)
                    {
                        continue;
                    }

                    object value = sAMObject.GetValue(@enum);

                    result.Add(new CustomParameter(parameterData, value));
                }
            }

            return result;
        }

        public static CustomParameters CustomParameters(this SAMObject sAMObject, params Enum[] enums)
        {
            if(sAMObject == null || enums == null)
            {
                return null;
            }

            CustomParameters result = new CustomParameters();
            foreach(Enum @enum in enums)
            {
                ParameterData parameterData = Core.Create.ParameterData(@enum);
                if(parameterData == null)
                {
                    continue;
                }

                object value = sAMObject.GetValue(@enum);

                result.Add(new CustomParameter(parameterData, value));
            }

            return result;
        }
    }
}
