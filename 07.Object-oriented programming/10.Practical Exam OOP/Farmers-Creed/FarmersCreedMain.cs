namespace FarmersCreed
{
    using System;
    using FarmersCreed.Simulator;

    class FarmersCreedMain
    {
        static void Main()
        {
            FarmSimulator simulator = new ExtendedFarmSimulator();
            simulator.Run();
        }
    }
}
