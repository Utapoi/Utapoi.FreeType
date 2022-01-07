// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System.Runtime.InteropServices;
using Utapoi.FreeType.Models;

namespace Utapoi.FreeType;

public sealed class FreeTypeInvoke
{
    private const string free_type_dll = "freetype";

    [DllImport(free_type_dll, EntryPoint = "FT_Init_FreeType", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public static extern Error FT_Init_FreeType(out IntPtr library);

    [DllImport(free_type_dll, EntryPoint = "FT_Done_FreeType", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public static extern Error FT_Done_FreeType(IntPtr library);

    [DllImport(free_type_dll, EntryPoint = "FT_Library_Version", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public static extern void FT_Library_Version(IntPtr library, out int major, out int minor, out int patch);

    [DllImport(free_type_dll, EntryPoint = "FT_New_Face", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern Error FT_New_Face(IntPtr library, string path, int faceIndex, out IntPtr face);

    [DllImport(free_type_dll, EntryPoint = "FT_New_Memory_Face", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public static extern Error FT_New_Memory_Face(IntPtr library, IntPtr fileBase, int fileSize, int faceIndex, out IntPtr face);

    [DllImport(free_type_dll, EntryPoint = "FT_Open_Face", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public static extern Error FT_Open_Face(IntPtr library, IntPtr parameters, int faceIndex, out IntPtr face);

    [DllImport(free_type_dll, EntryPoint = "FT_Attach_File", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern Error FT_Attach_File(IntPtr face, string path);

    [DllImport(free_type_dll, EntryPoint = "FT_Attach_Stream", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public static extern Error FT_Attach_Stream(IntPtr face, IntPtr parameters);

    [DllImport(free_type_dll, EntryPoint = "FT_Reference_Face", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public static extern Error FT_Reference_Face(IntPtr face);

    [DllImport(free_type_dll, EntryPoint = "FT_Done_Face", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public static extern Error FT_Done_Face(IntPtr face);
}
