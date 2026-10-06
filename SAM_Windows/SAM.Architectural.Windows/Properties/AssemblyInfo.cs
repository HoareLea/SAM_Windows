// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// GenerateAssemblyInfo is false (this file supplies attributes by hand), so the
// SDK never emits its usual implicit [assembly: SupportedOSPlatform("windows...")]
// for this net8.0-windows project. Without it, the CA1416 platform-compatibility
// analyzer cannot tell this assembly is Windows-only and flags every WinForms/WPF
// API call site as "reachable on all platforms" - this project's actual runtime
// constraint has not changed, only the analyzer's visibility into it.
[assembly: SupportedOSPlatform("windows")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("5a1b6423-f181-400a-a27f-1b5a73c2704d")]
