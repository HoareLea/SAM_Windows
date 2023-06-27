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
            foreach (Type type in enumTypes)
            {
                if (type == null || !type.IsEnum)
                {
                    continue;
                }

                foreach (Enum @enum in Enum.GetValues(type))
                {
                    EnumParameterData enumParameterData = new EnumParameterData(@enum);
                    if (enumParameterData == null)
                    {
                        continue;
                    }

                    object value = sAMObject.GetValue(@enum);

                    result.Add(new CustomParameter(enumParameterData, @enum.GetType().Assembly.Name(), value));
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
                if (!Core.Query.IsValid(sAMObject.GetType(), @enum))
                {
                    continue;
                }

                EnumParameterData enumParameterData = new EnumParameterData(@enum);
                if (enumParameterData == null)
                {
                    continue;
                }

                object value = sAMObject.GetValue(@enum);

                string category = SAM.Core.Query.Category(@enum);
                if(string.IsNullOrWhiteSpace(category))
                {
                    category = @enum.GetType().Assembly.Name();
                }
                

                result.Add(new CustomParameter(enumParameterData, category, value));
            }

            return result;
        }
    }
}
