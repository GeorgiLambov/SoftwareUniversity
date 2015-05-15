namespace Import_Mountains_From_JSON
{
    class MountainDTO
    {
        public MountainDTO()
        {
            this.Peaks = new PeakDTO[0];
            this.Countries = new string[0];
        }
        public string MountainName { get; set; }

        public PeakDTO[] Peaks { get; set; }

        public string[] Countries { get; set; }
    }
}
