using System;
using System.ComponentModel;
using System.Linq;

namespace SAM.Core.Windows
{
    public class CustomParameterDescriptor : PropertyDescriptor
    {
        private CustomParameter customParameter;

        public CustomParameterDescriptor(ref CustomParameter customParameter, Attribute[] attrs)
            : base(customParameter?.Name, attrs)
        {
            this.customParameter = customParameter;
        }

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override Type ComponentType
        {
            get
            {
                return null;
            }
        }

        public override object GetValue(object component)
        {
            return customParameter?.Value;
        }

        public override string Description
        {
            get
            {
                return customParameter?.Description;
            }
        }

        public override string Category
        {
            get
            {

                string result = customParameter?.Category;
                if(result == null)
                {
                    result = string.Empty;
                }

                return result;
            }
        }

        public override string DisplayName
        {
            get
            {
                return customParameter?.Name;
            }

        }

        public override bool IsReadOnly
        {
            get
            {
                return customParameter.IsReadOnly;
            }
        }

        public override void ResetValue(object component)
        {
            
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }

        public override void SetValue(object component, object value)
        {
            customParameter?.SetValue(value);
        }

        public override Type PropertyType
        {
            get
            {
                return customParameter.ParameterTypes?.FirstOrDefault();
            }
        }
    }
}
