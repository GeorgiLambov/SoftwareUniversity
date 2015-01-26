namespace MusicShopManager.Interfaces
{
    using System;
    using MusicShopManager.Models;

    public interface IAcousticGuitar : IGuitar
    {
        bool CaseIncluded { get; }

        StringMaterial StringMaterial { get; }
    }
}
