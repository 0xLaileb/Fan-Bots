using System;
using System.Runtime.InteropServices;

namespace LAUNCHER_FANBOT
{
    internal static class pInvokeProcessStart
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct STARTUPINFO
        {
            public int cb;
            private readonly string lpReserved;
            private readonly string lpDesktop;
            private readonly string lpTitle;
            private readonly int dwX;
            private readonly int dwY;
            private readonly int dwXSize;
            private readonly int dwYSize;
            private readonly int dwXCountChars;
            private readonly int dwYCountChars;
            private readonly int dwFillAttribute;
            public int dwFlags;
            public short wShowWindow;
            private readonly short cbReserved2;
            private readonly IntPtr lpReserved2;
            private readonly IntPtr hStdInput;
            private readonly IntPtr hStdOutput;
            private readonly IntPtr hStdError;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public int dwProcessId;
            public int dwThreadId;
        }

        [DllImport("kernel32.dll")]
        private static extern bool CreateProcess(
            string lpApplicationName,
            string lpCommandLine,
            IntPtr lpProcessAttributes,
            IntPtr lpThreadAttributes,
            bool bInheritHandles,
            uint dwCreationFlags,
            IntPtr lpEnvironment,
            string lpCurrentDirectory,
            [In] ref STARTUPINFO lpStartupInfo,
            out PROCESS_INFORMATION lpProcessInformation
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr hObject);

        private const int STARTF_USESHOWWINDOW = 1;

        public static void StartProcessNoActivate(string cmdLine, short sw)
        {
            STARTUPINFO si = new STARTUPINFO();
            si.cb = Marshal.SizeOf(si);
            si.dwFlags = STARTF_USESHOWWINDOW;
            si.wShowWindow = sw;

            CreateProcess(null, cmdLine, IntPtr.Zero, IntPtr.Zero, true,
                0, IntPtr.Zero, null, ref si, out PROCESS_INFORMATION pi);

            CloseHandle(pi.hProcess);
            CloseHandle(pi.hThread);
        }
    }
}