namespace MusicShopManager.Interfaces
{
    using System;

    public interface IElectricGuitar : IGuitar
    {
        int NumberOfAdapters { get; }

        int NumberOfFrets { get; }
    }
}
