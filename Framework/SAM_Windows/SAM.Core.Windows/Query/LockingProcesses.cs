using System.Collections.Generic;
using System.Diagnostics;

namespace SAM.Core.Windows
{
    public static partial class Query
    {
        public static List<Process> LockingProcesses(string path)
        {
            if(string.IsNullOrEmpty(path) || !System.IO.File.Exists(path))
            {
                return null;
            }

            return FileLockWrapper.GetProcesses(path);
        }

    }
}