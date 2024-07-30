using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SAM.Core.Windows
{
    public class IdleTimer
    {
        [StructLayout(LayoutKind.Sequential)]
        struct LastInputInfo
        {
            public static readonly int SizeOf = Marshal.SizeOf(typeof(LastInputInfo));

            [MarshalAs(UnmanagedType.U4)]
            public uint Size;
            [MarshalAs(UnmanagedType.U4)]
            public uint Time;
        }

        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LastInputInfo LastInputInfo);

        private Timer timer = new Timer();
        private uint resetTime;

        public IdleTimer(int interval)
        {
            timer.Interval = interval;
            resetTime = 0;
        }

        public event System.EventHandler Tick;

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (IdleTime > timer.Interval)
                OnTick(EventArgs.Empty);
        }

        private void OnTick(EventArgs e)
        {
            if (Tick != null)
                Tick(null, e);
        }

        public int Interval
        {
            get
            {
                return timer.Interval;
            }
            set
            {
                timer.Interval = value;
            }
        }

        public int IdleTime
        {
            get
            {
                uint tickCount = (uint)Environment.TickCount;
                uint lastInputTime = LastInputTime;

                if (lastInputTime <= resetTime)
                {
                    return (int)(tickCount - resetTime);
                }
                else
                {
                    resetTime = 0;
                    return (int)(tickCount - lastInputTime);
                }
            }
        }

        public int AbsolutIdleTime
        {
            get
            {
                return (int)(Environment.TickCount - LastInputTime);
            }
        }

        public uint LastInputTime
        {
            get
            {
                LastInputInfo lastInputInfo = new LastInputInfo();
                lastInputInfo.Size = (uint)Marshal.SizeOf(lastInputInfo);
                lastInputInfo.Time = 0;
                GetLastInputInfo(ref lastInputInfo);

                return lastInputInfo.Time;
            }
        }

        public uint ResetTime
        {
            get
            {
                return resetTime;
            }
        }

        public void Reset()
        {
            resetTime = (uint)Environment.TickCount;
        }

        public void Stop()
        {
            resetTime = 0;
            timer.Tick -= Timer_Tick;
            timer.Enabled = false;
            timer.Stop();
        }

        public void Start()
        {
            resetTime = 0;
            timer.Tick -= Timer_Tick;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
            timer.Start();
        }

        public bool Enabled
        {
            get
            {
                return timer.Enabled;
            }
            set
            {
                timer.Enabled = value;
            }
        }

    }
}

