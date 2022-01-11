// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Utapoi.FreeType;

#if __IOS__
[Foundation.Preserve(AllMembers=true)]
#endif
internal static class FreeTypeResolver
{
    private const string freetype_library_name = "freetype";

    private const string windows_library_name = "freetype.dll";

    private const string linux_library_name = "libfreetype.so";

    private const string osx_library_name = "libfreetype.dylib";

    static FreeTypeResolver()
    {
        NativeLibrary.SetDllImportResolver(typeof(FreeTypeResolver).Assembly, LibraryResolver);
    }

    private static IntPtr LibraryResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
    {
        if (libraryName != freetype_library_name)
            return IntPtr.Zero;

        if (OperatingSystem.IsWindows())
            return ResolveWindows(libraryName);
        if (OperatingSystem.IsMacOS())
            return ResolveOSX(libraryName);
        if (OperatingSystem.IsLinux())
            return ResolveLinux(libraryName);

        throw new PlatformNotSupportedException($"{Environment.OSVersion}");

    }

    private static IntPtr ResolveWindows(string libraryName)
    {
        var paths = new[]
        {
            Path.Combine(AppContext.BaseDirectory, "runtimes", Environment.Is64BitOperatingSystem ? "win-x64" : "win-x86", "native", windows_library_name),
            Path.Combine(AppContext.BaseDirectory, Environment.Is64BitOperatingSystem ? "x64" : "x86", "native", windows_library_name),
            Path.Combine(AppContext.BaseDirectory, windows_library_name)
        };

        foreach (var path in paths)
        {
            if (NativeLibrary.TryLoad(path, out var handle))
                return handle;
        }

        return NativeLibrary.TryLoad(libraryName, typeof(FreeTypeResolver).Assembly,
            DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.UserDirectories | DllImportSearchPath.UseDllDirectoryForDependencies,
            out var fallbackHandle)
            ? fallbackHandle
            : throw new FileLoadException($"Failed to load freetype library {windows_library_name}");
    }

    private static IntPtr ResolveOSX(string libraryName)
    {
        var paths = new[]
        {
            Path.Combine(AppContext.BaseDirectory, "runtimes", "osx-x64", "native", osx_library_name),
            Path.Combine(AppContext.BaseDirectory, osx_library_name),
            Path.Combine("/usr/local/lib", osx_library_name),
            Path.Combine("/usr/lib", osx_library_name),
        };

        foreach (var path in paths)
        {
            if (NativeLibrary.TryLoad(path, out var handle))
                return handle;
        }

        return NativeLibrary.TryLoad(libraryName, typeof(FreeTypeResolver).Assembly,
            DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.UserDirectories | DllImportSearchPath.UseDllDirectoryForDependencies,
            out var fallbackHandle)
            ? fallbackHandle
            : throw new FileLoadException($"Failed to load freetype library {osx_library_name}");
    }

    private static IntPtr ResolveLinux(string libraryName)
    {
        var paths = new[]
        {
            Path.Combine(AppContext.BaseDirectory, "runtimes", "osx-x64", "native", linux_library_name),
            Path.Combine(AppContext.BaseDirectory, linux_library_name),
            Path.Combine("/usr/local/lib", linux_library_name),
            Path.Combine("/usr/lib", linux_library_name),
        };

        foreach (var path in paths)
        {
            if (NativeLibrary.TryLoad(path, out var handle))
                return handle;
        }

        return NativeLibrary.TryLoad(libraryName, typeof(FreeTypeResolver).Assembly,
            DllImportSearchPath.ApplicationDirectory | DllImportSearchPath.UserDirectories | DllImportSearchPath.UseDllDirectoryForDependencies,
            out var fallbackHandle)
            ? fallbackHandle
            : throw new FileLoadException($"Failed to load freetype library {linux_library_name}");
    }
}
