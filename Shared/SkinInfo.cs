using System.Diagnostics.CodeAnalysis;

namespace BuffInspector;

public class Sticker
{
    public required int Id { get; init; }
    public required int Slot { get; init; }
    public required float Wear { get; init; }
    public required float OffsetX { get; init; }
    public required float OffsetY { get; init; }
    public required string Name { get; init; }

    [SetsRequiredMembers]
    public Sticker(int id, int slot, float wear, float offsetX, float offsetY, string name)
    {
        this.Id = id;
        this.Slot = slot;
        this.Wear = wear;
        this.OffsetX = offsetX;
        this.OffsetY = offsetY;
        this.Name = name;
    }

    public string ToWeaponPaintsDatabaseString()
    {
        return $"{this.Id};0;{this.OffsetX};{this.OffsetY};{this.Wear};1;0";
    }
}

public class SkinInfo
{
    public string Title { get; init; }
    public string? Img { get; init; }
    public string? Nametag { get; init; }
    public required int DefIndex { get; init; }
    public required int PaintIndex { get; init; }
    public required int PaintSeed { get; init; }
    public required float PaintWear { get; init; }

    public List<Sticker> Stickers { get; set; } = new List<Sticker>();

    [SetsRequiredMembers]
    public SkinInfo(string title, string? img, string? nametag, int defIndex, int paintIndex, int paintSeed, float wear)
    {
        this.Title = title;
        this.Img = img;
        this.Nametag = nametag;
        this.DefIndex = defIndex;
        this.PaintIndex = paintIndex;
        this.PaintSeed = paintSeed;
        this.PaintWear = wear;
    }

    public void SetSticker(Sticker sticker)
    {
        Stickers.RemoveAll((s) => s.Slot == sticker.Slot);
        Stickers.Add(sticker);
    }
    public List<Sticker> GetStickers()
    {
        return Stickers;
    }
}