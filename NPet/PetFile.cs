using System.Runtime.InteropServices;

namespace Petersilie.NPet;

public class PetFile
{
    private readonly byte[] Contents;
    public PetHeader Header;

    public PetFile(string filePath)
    {
        Contents = GetSectionContents(File.ReadAllBytes(filePath));
        Parse();
    }

    private byte[] GetSectionContents(byte[] contents)
    {
        try
        {
            var peHeader = new PeNet.PeFile(contents);
            var section = peHeader.ImageSectionHeaders.First(h => h.Name == ".petprg");
            var start = Convert.ToInt32(section.PointerToRawData);
            var length = Convert.ToInt32(section.SizeOfRawData);
            return contents.Skip(start).Take(length).ToArray();
        }
        catch
        {
            // ignored
        }

        return contents;
    }

    private void Parse()
    {
        using (var reader = new BinaryReader(new MemoryStream(Contents, false)))
        {
            Header = new PetHeader();
            var headerSize = Marshal.SizeOf(Header);
            var headerPtr = Marshal.AllocHGlobal(headerSize);
            var headerData = reader.ReadBytes((int)headerSize);

            Marshal.Copy(headerData, 0, headerPtr, headerSize);
            Header = Marshal.PtrToStructure<PetHeader>(headerPtr);
            Marshal.FreeHGlobal(headerPtr);
        }
    }
}