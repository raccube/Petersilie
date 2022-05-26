using System.Runtime.InteropServices;

namespace Petersilie.NPet;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct PetIndex
{
    public Int32 Length;
    public Int32 NumItems;
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
    public string Name;
    public Int32 Version;
    public Int32 Extra2;
    public Int32 Extra3;
    public Int32 Extra4;
}