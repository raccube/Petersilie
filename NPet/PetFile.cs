using System.Runtime.InteropServices;

namespace Petersilie.NPet;

public class PetFile
{
    private readonly byte[] Contents;
    public PetHeader header;

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
            return peHeader.ImageSectionHeaders.First(h => h.Name == ".petprg").ToArray();
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
            header = new PetHeader();
            var headerSize = Marshal.SizeOf(header);
            var headerPtr = Marshal.AllocHGlobal(headerSize);
            var headerData = reader.ReadBytes((int)headerSize);

            Marshal.Copy(headerData, 0, headerPtr, headerSize);
            header = Marshal.PtrToStructure<PetHeader>(headerPtr);
            Marshal.FreeHGlobal(headerPtr);
        }
    }
}