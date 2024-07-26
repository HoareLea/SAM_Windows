using System.Collections.Generic;
using System.Windows.Forms;

namespace SAM.Analytical.Windows
{
    public static partial class Query
    {
        public static DialogResult JsonForm<T>(this IEnumerable<T> jSAMObjects, IWin32Window win32Window, KeyEventArgs keyEventArgs, Keys keys = Keys.F12) where T: Core.IJSAMObject
        {
            if(keyEventArgs == null || jSAMObjects == null)
            {
                return DialogResult.Abort;
            }

            if (keyEventArgs.KeyCode != keys)
            {
                return DialogResult.Abort;
            }


            DialogResult result = DialogResult.Abort;
            using (Core.Windows.Forms.JsonForm<T> jsonForm = new Core.Windows.Forms.JsonForm<T>(jSAMObjects))
            {
                result = jsonForm.ShowDialog(win32Window);
            }

            return result;
        }

        public static DialogResult JsonForm<T>(this T jSAMObject, IWin32Window win32Window, KeyEventArgs keyEventArgs, Keys keys = Keys.F12) where T : Core.IJSAMObject
        {
            if(jSAMObject == null)
            {
                return DialogResult.Abort;
            }

            return JsonForm(new T[] { jSAMObject }, win32Window, keyEventArgs, keys);
        }
    }
}