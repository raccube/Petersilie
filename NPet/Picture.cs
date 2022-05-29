using System.Runtime.InteropServices;

namespace Petersilie.NPet;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Picture
{
    public Int32 Width;
    public Int32 Height;
    [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
    public byte[] Data;
}