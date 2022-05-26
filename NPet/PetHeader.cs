using System.Runtime.InteropServices;

namespace Petersilie.NPet;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct PetHeader
{
    /// <summary>
    /// Identifier. Always PET.
    /// </summary>
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
    public string Identifier;
    /// <summary>
    /// Format version. Always 1.
    /// </summary>
    public byte Version;
    /// <summary>
    /// Editor version in thousandths.
    /// </summary>
    public Int16 Editor;
    public Int16 Parameters;
    public Int32 Offset;
    public Int32 NumBlocks;
    [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public PetIndex[] IndexTable;
}