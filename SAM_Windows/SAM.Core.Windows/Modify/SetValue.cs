namespace SAM.Core.Windows
{
    public static partial class Modify
    {
        public static bool SetValue(this SAMObject sAMObject, CustomParameter customParameter)
        {
            if(sAMObject == null || customParameter == null)
            {
                return false;
            }

            EnumParameterData enumParameterData = customParameter?.ParameterData as EnumParameterData;
            if (enumParameterData == null)
            {
                return false;
            }

            if(customParameter.Value == null)
            {
                return sAMObject.RemoveValue(enumParameterData.Enum);
            }

            return sAMObject.SetValue(enumParameterData.Enum, customParameter.Value);
        }

    }
}