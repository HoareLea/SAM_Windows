using System;
using System.Runtime.InteropServices;


namespace SAM.Core.Windows
{
    /// <summary>
    /// Inspired by: https://pinvoke.net/default.aspx/kernel32/SetThreadExecutionState.html
    /// </summary>
    public static class ThreadExecutionHandler 
    {
        [FlagsAttribute]
        private enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001
            // Legacy flag, should not be used.
            // ES_USER_PRESENT = 0x00000004
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="esFlags"></param>
        /// <returns>the return value is the EXECUTION_STATE that was set.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static private extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        public static void PreventMonitorPowerdown()
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS);
        }
        public static void AllowMonitorPowerdown()
        {
            //There is no need to store the state you set, Windows remembers it for you. Just set it back to ES_CONTINUOUS when you don't want it anymore.
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
        }

        public static void PreventSleep()
        {
            // Prevent Idle-to-Sleep (monitor not affected) (see note above)
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_AWAYMODE_REQUIRED);
        }

        public static void KeepSystemAwake()
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_SYSTEM_REQUIRED);
        }
    }
}
