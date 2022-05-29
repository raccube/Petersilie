using System.Runtime.InteropServices;

namespace Petersilie.NPet;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct IconData
{
    public Int32 Refer;
    public Int32 Params;
    public IntPtr HIcon;
    public IntPtr HCursor;
    public Int32 Reserved;
    public IntPtr Data;
}