// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System.Runtime.InteropServices;
using Utapoi.FreeType.Enums;

namespace Utapoi.FreeType;

internal static class FreeTypeInvoke
{
    private const string free_type_dll = "freetype";

    #region Library

    [DllImport(free_type_dll, EntryPoint = "FT_Init_FreeType", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    internal static extern Error FT_Init_FreeType(out IntPtr library);

    [DllImport(free_type_dll, EntryPoint = "FT_Done_FreeType", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    internal static extern Error FT_Done_FreeType(IntPtr library);

    [DllImport(free_type_dll, EntryPoint = "FT_Library_Version", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    internal static extern void FT_Library_Version(IntPtr library, out int major, out int minor, out int patch);

    #endregion

    #region Font Face

    [DllImport(free_type_dll, EntryPoint = "FT_New_Face", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    internal static extern Error FT_New_Face(IntPtr library, string path, long faceIndex, out IntPtr face);

    [DllImport(free_type_dll, EntryPoint = "FT_Open_Face", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    internal static extern Error FT_Open_Face(IntPtr library, IntPtr parameters, int faceIndex, out IntPtr face);

    [DllImport(free_type_dll, EntryPoint = "FT_New_Memory_Face", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    internal static extern Error FT_New_Memory_Face(IntPtr library, IntPtr fileBase, int fileSize, int faceIndex, out IntPtr face);

    [DllImport(free_type_dll, EntryPoint = "FT_Reference_Face", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    internal static extern Error FT_Reference_Face(IntPtr face);

    [DllImport(free_type_dll, EntryPoint = "FT_Done_Face", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    internal static extern Error FT_Done_Face(IntPtr face);

    [DllImport(free_type_dll, EntryPoint = "FT_Set_Char_Size", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    internal static extern Error FT_Set_Char_Size(IntPtr face, long width, long height, uint horizontalResolution, uint verticalResolution);

    [DllImport(free_type_dll, EntryPoint = "FT_Get_Char_Index", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    internal static extern uint FT_Get_Char_Index(IntPtr face, uint charCode);

    #endregion

    [DllImport(free_type_dll, EntryPoint = "FT_Attach_File", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    internal static extern Error FT_Attach_File(IntPtr face, string path);

    [DllImport(free_type_dll, EntryPoint = "FT_Attach_Stream", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    internal static extern Error FT_Attach_Stream(IntPtr face, IntPtr parameters);

    [DllImport(free_type_dll, EntryPoint = "FT_Select_Size", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    internal static extern Error FT_Select_Size(IntPtr face, int strikeSize);

    [DllImport(free_type_dll, EntryPoint = "FT_Request_Size", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    internal static extern Error FT_Request_Size(IntPtr face, IntPtr request);

    #region Glyph

    [DllImport(free_type_dll, EntryPoint = "FT_Load_Glyph", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    internal static extern Error FT_Load_Glyph(IntPtr face, uint glyphIndex, int loadFlags);

    [DllImport(free_type_dll, EntryPoint = "FT_Load_Char", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    internal static extern Error FT_Load_Char(IntPtr face, uint charCode, int loadFlags);

    [DllImport(free_type_dll, EntryPoint = "FT_Done_Glyph", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    internal static extern void FT_Done_Glyph(IntPtr glyph);

    [DllImport(free_type_dll, EntryPoint = "FT_Get_Glyph_Name", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    internal static extern Error FT_Get_Glyph_Name(IntPtr face, uint glyphIndex, IntPtr buffer, uint bufferMax);

    [DllImport(free_type_dll, EntryPoint = "FT_Get_Glyph", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    internal static extern Error FT_Get_Glyph(IntPtr glyphSlot, out IntPtr glyph);

    [DllImport(free_type_dll, EntryPoint = "FT_Render_Glyph", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    internal static extern Error FT_Render_Glyph(IntPtr glyph, int flags);

    #endregion
}
