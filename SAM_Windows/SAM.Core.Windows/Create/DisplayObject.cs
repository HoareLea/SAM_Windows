using System;

namespace SAM.Core.Windows
{
    public static partial class Create
    {
        public static DisplayObject DisplayObject<T>(T @object, Func<T, string> func)
        {
            if(@object == null)
            {
                return new DisplayObject(@object);
            }

            if(func == null)
            {
                return new DisplayObject(@object);
            }

            return new DisplayObject(@object, func.Invoke(@object));
        }
    }
}
