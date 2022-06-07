using System.Runtime.InteropServices;

namespace Petersilie.NPet;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct ProgramParameters
{
    /// <summary>
    /// Parent Element Index.
    /// -1 = Root
    /// </summary>
    public Int32 Parent;
    public Int32 Items;
    /// <summary>
    /// Data Index.
    /// -1 = None
    /// </summary>
    public Int32 Data;
    /// <summary>
    /// Index List.
    /// -1 = None
    /// </summary>
    public Int32 List;
    public Int32 Local;
    public Int32 LocalList;
    public Int32 FunctionIndex;
    /// <summary>
    /// Unknown.
    /// </summary>
    public Int32 Res;
}