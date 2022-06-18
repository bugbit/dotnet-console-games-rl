using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DotnetConsoleGamesRL.Native
{
    internal class UnmanagedLibrary
    {
        private IntPtr _handle;

        [DllImport("libc")]
        static extern int uname(IntPtr buf);

        public UnmanagedLibrary(IntPtr _handle) => this._handle = _handle;

        public TDelegate GetNativeMethodDelegate<TDelegate>(string method)
        {
            if (!NativeLibrary.TryGetExport(_handle, method, out var address))
                return default(TDelegate);

            return Marshal.GetDelegateForFunctionPointer<TDelegate>(address);
        }

        public static UnmanagedLibrary Create
        (
            string[] libnameswindows,
            string[] libnamelsinux,
            string[] libnamesmacos
        )
        {
            var platform = Environment.OSVersion.Platform;
            var libnames = platform switch
            {
                PlatformID.Win32NT or PlatformID.Win32S or PlatformID.Win32S => libnameswindows,
                PlatformID.Unix => (GetUname() == "Darwin") ? libnamesmacos : libnamelsinux,
                _ => new string[0]
            };

            foreach (var libname in libnames)
            {
                if (NativeLibrary.TryLoad(libname, out var _libHandle))
                    return new UnmanagedLibrary(_libHandle);
            }

            return new UnmanagedLibrary(IntPtr.Zero);
        }

        static string GetUname()
        {
            var buffer = Marshal.AllocHGlobal(8192);
            try
            {
                if (uname(buffer) == 0)
                {
                    return Marshal.PtrToStringAnsi(buffer);
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                if (buffer != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(buffer);
                }
            }
        }
    }
}