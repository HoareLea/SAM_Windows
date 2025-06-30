using System;
using System.Windows.Forms;


namespace SAM.Core.Windows
{
    public class DisplayObject
    {
        private string text = null;
        private object @object = default;

        public DisplayObject(object @object)
        {
            this.@object = @object;
            text = @object?.ToString();
        }
        
        public DisplayObject(object @object, string text)
        {
            this.@object = @object;
            this.text = text;
        }

        public object Object
        {
            get
            {
                return @object;
            }
        }

        public T GetObject<T>()
        {
            if (@object is T)
            {
                return (T)@object;
            }

            return default;
        }

        public override string ToString()
        {
            return text == null ? string.Empty : text;
        }

    }
}
