using System.Runtime.InteropServices;

namespace Petersilie.NPet;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct PetProgram
{
    public PetProgParams Parameters;
    public Int32 RefBlock;
    public Int32 RefIndex;
    public Int32 DataBlock;
    public Int32 DataIndex;
    public Int32 Icon;
    public Int32 Name;
    public Int32 Func;
}