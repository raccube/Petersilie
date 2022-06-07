using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Petersilie.NPet;

public class PetFile
{
    private readonly byte[] Contents;
    public PetHeader Header;
    public List<PetProgram> Programs;
    public List<Text> Texts;
    public List<Picture> Pictures;
    public List<Map> Maps;
    public List<Sprite> Sprites;

    public PetFile(string filePath)
    {
        Contents = GetPetPrgSectionContents(File.ReadAllBytes(filePath));
        Programs = new List<PetProgram>();
        Texts = new List<Text>();
        Pictures = new List<Picture>();
        Maps = new List<Map>();
        Sprites = new List<Sprite>();
        Parse();
    }

    private byte[] GetPetPrgSectionContents(byte[] contents)
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
        using var reader = new BinaryReader(new MemoryStream(Contents, false));
        Header = new PetHeader();
        var headerSize = Marshal.SizeOf(Header);
        var headerPtr = Marshal.AllocHGlobal(headerSize);
        var headerData = reader.ReadBytes(headerSize);

        Marshal.Copy(headerData, 0, headerPtr, headerSize);
        Header = Marshal.PtrToStructure<PetHeader>(headerPtr);
        Marshal.FreeHGlobal(headerPtr);

        reader.BaseStream.Seek(Header.Offset, SeekOrigin.Begin);
        foreach (var petIndex in Header.IndexTable)
        {
            var indexType = GetSectionType(petIndex.Name);
            if (indexType == null) continue;

            for (var i = 0; i < petIndex.NumItems; i++)
            {
                var indexSize = Marshal.SizeOf(indexType);
                var indexPtr = Marshal.AllocHGlobal(indexSize);
                var indexData = reader.ReadBytes(indexSize);

                Marshal.Copy(indexData, 0, indexPtr, indexSize);
                var index = Marshal.PtrToStructure(indexPtr, indexType);
                Marshal.FreeHGlobal(indexPtr);
                Grab(index);
            }
        }
    }

    public void Grab(Object obj)
    {
        if (obj is PetProgram program)
        {
            Programs.Add(program);
        }
        else if (obj is Text text)
        {
            Texts.Add(text);
        }
        else if (obj is Picture picture)
        {
            Pictures.Add(picture);
        }
        else if (obj is Map map)
        {
            Maps.Add(map);
        }
        else if (obj is Sprite sprite)
        {
            Sprites.Add(sprite);
        }
    }

    private static Type? GetSectionType(string indexName)
    {
        switch (indexName)
        {
            // case "IMPORT  ":
            // case "CLASS   ":
            // case "GLOBAL  ":
            // case "LOCAL   ":
            // case "STRUC   ":
            // case "REAL    ":
            // case "BOOL    ":
            // case "BACKGRND":
            // case "SOUND   ":
            // case "MUSIC   ":
            // case "PALETTE ":
            //     break;
            case "PROGRAM ":
                return typeof(PetProgram);
            case "TEXT    ":
                return typeof(Text);
            case "PICTURE ":
                return typeof(Picture);
            case "MAP     ":
                return typeof(Map);
            case "SPRITE  ":
                return typeof(Sprite);
            default:
                Debug.WriteLine($"Unhandled section type: {indexName}");
                break;
        }

        return null;
    }
}