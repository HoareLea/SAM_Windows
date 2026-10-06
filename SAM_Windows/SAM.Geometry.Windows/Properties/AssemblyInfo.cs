// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using System.Runtime.Versioning;

// GenerateAssemblyInfo is false for this net8.0-windows project and it had no
// hand-written AssemblyInfo.cs at all, so the SDK never emitted its usual
// implicit [assembly: SupportedOSPlatform("windows...")]. Without it, the
// CA1416 platform-compatibility analyzer cannot tell this assembly is
// Windows-only and flags every WinForms/WPF API call site as "reachable on
// all platforms" - this project's actual runtime constraint has not changed,
// only the analyzer's visibility into it.
[assembly: SupportedOSPlatform("windows")]
