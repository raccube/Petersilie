namespace Petersilie.NPet;

[Flags]
public enum PetProgParams
{
    Children = 1,
    Next = 2,
    Exp = 4,
    Lock = 8,
    Off = 16,
    NoMove = 32,
    Internal = 64,
    OffDep = 128,
}