using System;
using System.Windows.Forms;


namespace SAM.Core.Windows
{
    public class WindowHandle : IWin32Window
    {
        IntPtr handle;

        public WindowHandle(IntPtr handle)
        {
            this.handle = handle;
        }

        public WindowHandle(System.Windows.Window window)
        {
            if(window != null)
            {
                handle = new System.Windows.Interop.WindowInteropHelper(window).Handle;
            }
        }

        public IntPtr Handle
        {
            get
            {
                return handle;
            }
        }
    }
}
