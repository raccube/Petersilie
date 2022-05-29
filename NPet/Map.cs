using System.Runtime.InteropServices;

namespace Petersilie.NPet;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Map
{
    public Int32 Width;
    public Int32 Height;
    public MapItem Data;
}
