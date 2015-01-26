namespace MusicShopManager
{
    using System;
    using System.Globalization;
    using System.Threading;
    using MusicShopManager.Engine;

    public class MusicShopManagerProgram
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            MusicShopEngine.Instance.Start();
        }
    }
}
