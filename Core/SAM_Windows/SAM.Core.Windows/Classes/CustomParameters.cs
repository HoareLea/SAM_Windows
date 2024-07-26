using System;
using System.Collections;
using System.ComponentModel;

namespace SAM.Core.Windows
{
    public class CustomParameters : CollectionBase, ICustomTypeDescriptor
    {
        public void Add(CustomParameter customParameter)
        {
            List.Add(customParameter);
        }

        public void Remove(string name)
        {
            foreach (CustomParameter customParameter in List)
            {
                if (customParameter?.Name == name)
                {
                    List.Remove(customParameter);
                    return;
                }
            }
        }

        public CustomParameter this[int index]
        {
            get
            {
                return (CustomParameter)List[index];
            }
            set
            {
                List[index] = (CustomParameter)value;
            }
        }

        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            PropertyDescriptor[] propertyDescriptors = new PropertyDescriptor[this.Count];
            for (int i = 0; i < Count; i++)
            {
                CustomParameter customParameter = (CustomParameter)this[i];
                propertyDescriptors[i] = new CustomParameterDescriptor(ref customParameter, attributes);
            }

            return new PropertyDescriptorCollection(propertyDescriptors);
        }

        public PropertyDescriptorCollection GetProperties()
        {

            return TypeDescriptor.GetProperties(this, true);

        }
        public object GetPropertyOwner(PropertyDescriptor propertyDescriptor)
        {
            return this;
        }

    }
}
