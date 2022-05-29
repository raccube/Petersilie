using System.Runtime.InteropServices;

namespace Petersilie.NPet;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct MapItem
{
    /// <summary>
    /// Original type: CIcon
    /// TODO: Recreate this.
    /// </summary>
    public Int32 Icon;
    public Int32 Parameters;
}