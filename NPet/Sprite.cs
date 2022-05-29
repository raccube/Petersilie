using System.Runtime.InteropServices;

namespace Petersilie.NPet;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Sprite
{
    public Int32 Phase;
    public Int32 Direction;
    /// <summary>
    /// Unknown, likely for animation timing.
    /// TODO: Figure out what this is for.
    /// </summary>
    public Int32 Klid;
    public Int16 Width;
    public Int16 Height;
    public Int32 Delay;
    public Int32 Level;
    public Double Step;
    [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
    public byte[] Data;
}