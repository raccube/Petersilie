using System.Runtime.InteropServices;

namespace Petersilie.NPet;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public class Text
{
    public Int32 LanguageId;
    public Int32 CodePage;
}