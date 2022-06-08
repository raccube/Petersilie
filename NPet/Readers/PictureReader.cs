namespace Petersilie.NPet.Readers;

public class PictureReader
{
    public Picture[] ReadAll(BinaryReader reader, int numItems)
    {
        var collected = new Picture[numItems];
        for (var i = 0; i < numItems; i++)
        {
            collected[i] = Read(reader);
        }

        return collected;
    }

    public Picture Read(BinaryReader reader)
    {
        Int32 w, h;
        return new Picture
        {
            Width = w = reader.ReadInt32(),
            Height = h = reader.ReadInt32(),
            Data = reader.ReadBytes(w * h)
        };
    }
}