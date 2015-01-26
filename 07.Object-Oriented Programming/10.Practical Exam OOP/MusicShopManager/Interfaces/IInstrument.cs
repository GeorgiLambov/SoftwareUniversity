namespace MusicShopManager.Interfaces
{
    using System;

    public interface IInstrument : IArticle
    {
       string Color { get; }

       bool IsElectronic { get; }
    }
}
