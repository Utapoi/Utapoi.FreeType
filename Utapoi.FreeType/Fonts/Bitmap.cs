// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System.Runtime.InteropServices;
using Utapoi.FreeType.Internal;

namespace Utapoi.FreeType.Fonts;

public class Bitmap : IDisposable
{
    private bool IsDisposed { get; set; }

    private FTBitmap InternalBitmap { get; }

    private readonly int _left;

    private readonly int _top;

    internal Bitmap(FTBitmap bitmap, int left, int top)
    {
        InternalBitmap = bitmap;
        _left = left;
        _top = top;
    }

    ~Bitmap()
    {
        ReleaseUnmanagedResources();
    }

    #region Properties

    public IntPtr RawBuffer
    {
        get
        {
            if (IsDisposed)
                throw new ObjectDisposedException(nameof(RawBuffer), "Cannot access a disposed object.");

            return InternalBitmap.Buffer;
        }
    }

    public Span<byte> Buffer
    {
        get
        {
            if (IsDisposed)
                throw new ObjectDisposedException(nameof(Buffer), "Cannot access a disposed object.");

            var data = new byte[InternalBitmap.Rows * InternalBitmap.Pitch];
            Marshal.Copy(InternalBitmap.Buffer, data, 0, data.Length);

            return data;
        }
    }

    public uint Width
    {
        get
        {
            if (IsDisposed)
                throw new ObjectDisposedException(nameof(Width), "Cannot access a disposed object.");

            return InternalBitmap.Width;
        }
    }

    public uint Height
    {
        get
        {
            if (IsDisposed)
                throw new ObjectDisposedException(nameof(Height), "Cannot access a disposed object.");

            return InternalBitmap.Rows;
        }
    }

    public uint Rows
    {
        get
        {
            if (IsDisposed)
                throw new ObjectDisposedException(nameof(Rows), "Cannot access a disposed object.");

            return InternalBitmap.Rows;
        }
    }

    public int Left
    {
        get
        {
            if (IsDisposed)
                throw new ObjectDisposedException(nameof(Left), "Cannot access a disposed object.");

            return _left;
        }
    }

    public int Top
    {
        get
        {
            if (IsDisposed)
                throw new ObjectDisposedException(nameof(Top), "Cannot access a disposed object.");

            return _top;
        }
    }

    #endregion


    public void Dispose()
    {
        ReleaseUnmanagedResources();
        GC.SuppressFinalize(this);
        IsDisposed = true;
    }

    private void ReleaseUnmanagedResources()
    {
        // TODO release unmanaged resources here
    }
}
