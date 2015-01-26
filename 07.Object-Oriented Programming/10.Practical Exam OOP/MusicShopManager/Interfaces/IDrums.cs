namespace MusicShopManager.Interfaces
{
    using System;

    public interface IDrums : IInstrument
    {
        int Width { get; }

        int Height { get; }
    }
}
