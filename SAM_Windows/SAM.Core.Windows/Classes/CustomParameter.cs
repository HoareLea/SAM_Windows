using SAM.Core.Attributes;
using System;
using System.Collections.Generic;

namespace SAM.Core.Windows
{
    public class CustomParameter
    {
        private IParameterData parameterData;
        private string category;
        private object value;

        public CustomParameter(IParameterData parameterData, object value)
        {
            this.parameterData = parameterData;
            this.value = value;
        }
        public CustomParameter(IParameterData parameterData, string category, object value)
        {
            this.parameterData = parameterData;
            this.value = value;
            this.category = category;
        }

        public CustomParameter(ParameterProperties parameterProperties, ParameterValue parameterValue, string category, object value)
        {
            parameterData = new ParameterData(parameterProperties, parameterValue);
            this.value = value;
            this.category = category;
        }

        public CustomParameter(string name, string description, AccessType accessType, ParameterValue parameterValue, string category, object value)
        {
            parameterData = new ParameterData(new ParameterProperties(name, description, accessType), parameterValue);
            this.value = value;
            this.category = category;
        }

        public IParameterData ParameterData
        {
            get
            {
                return parameterData;
            }
        }
        
        public string Name
        {
            get
            {
                return parameterData?.ParameterProperties?.Name;
            }
        }

        public string Description
        {
            get
            {
                return parameterData?.ParameterProperties?.Description;
            }
        }

        public object Value
        {
            get
            {
                if(value is double && double.IsNaN((double)value))
                {
                    return null;
                }
                
                return value;
            }
        }

        public bool SetValue(object value)
        {
            this.value = value;
            return true;
        }

        public string Category
        {
            get
            {
                return category;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                if (parameterData?.ParameterProperties == null)
                {
                    return false;
                }

                return parameterData.ParameterProperties.AccessType == AccessType.Read;
            }
        }

        public List<Type> ParameterTypes
        {
            get
            {
                ParameterValue parameterValue = parameterData?.ParameterValue;
                if (parameterValue != null)
                {
                    ParameterType parameterType = parameterValue.ParameterType;
                    switch (parameterType)
                    {
                        case ParameterType.Boolean:
                            return new List<Type>() { typeof(bool) };

                        case ParameterType.Color:
                            return new List<Type>() { typeof(System.Drawing.Color) };

                        case ParameterType.DateTime:
                            return new List<Type>() { typeof(DateTime) };

                        case ParameterType.Double:
                            return new List<Type>() { typeof(double) };

                        case ParameterType.Guid:
                            return new List<Type>() { typeof(Guid) };

                        case ParameterType.Integer:
                            return new List<Type>() { typeof(int) };

                        case ParameterType.String:
                            return new List<Type>() { typeof(string) };

                        case ParameterType.Undefined:
                            return new List<Type>() { typeof(object) };

                        case ParameterType.IJSAMObject:
                            if (parameterValue is SAMObjectParameterValue)
                            {
                                SAMObjectParameterValue sAMObjectParameterValue = (SAMObjectParameterValue)parameterValue;
                                List<Type> result = sAMObjectParameterValue.Types;
                                if (result != null)
                                {
                                    return result;
                                }
                            }
                            return new List<Type>() { typeof(IJSAMObject) };
                    }
                }

                if (value == null)
                {
                    return null;
                }

                return new List<Type>() { value.GetType() };
            }
        }
    }
}
