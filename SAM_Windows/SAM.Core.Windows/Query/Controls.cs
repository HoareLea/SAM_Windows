using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Core.Windows
{
    public static partial class Query
    {
        public static List<T> Controls<T>(this Form form) where T : Control
        {
            List<Control> controls = Controls(form);
            if (controls == null)
                return null;

            return controls.FindAll(x => x is T).Cast<T>().ToList();

        }
        
        public static List<Control> Controls(this Form form)
        {
            Control.ControlCollection controls = form?.Controls;
            if (controls == null)
                return null;

            List<Control> result = new List<Control>();
            foreach (Control control in controls)
                Controls(control, ref result);

            return result;
        }

        public static List<T> Controls<T>(this Control control, string text, TextComparisonType textComparisonType, bool caseSensitive = true) where T : Control
        {
            if(control == null)
            {
                return null;
            }

            List<T> controls = new List<T>();
            Controls<T>(control, ref controls);

            List<T> result = new List<T>();
            if(controls == null || controls.Count == 0)
            {
                return result;
            }

            foreach(T t in controls)
            {
                if(Core.Query.Compare(t.Name, text, textComparisonType, caseSensitive))
                {
                    result.Add(t);
                }
            }

            return result;
        }

        private static void Controls<T>(Control control, ref List<T> controls) where T : Control
        {
            if (controls == null)
                controls = new List<T>();

            Control.ControlCollection controls_Temp = control?.Controls;
            if (controls_Temp == null || controls_Temp.Count == 0)
                return;

            foreach (Control control_Temp in controls_Temp)
            {
                Controls(control_Temp, ref controls);

                T t = control_Temp as T;
                if (t == null)
                {
                    continue;
                }

                controls.Add(t);
            }
        }
    }
}