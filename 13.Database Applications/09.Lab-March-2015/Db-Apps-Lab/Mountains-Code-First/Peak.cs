namespace Mountains_Code_First
{
    using System.ComponentModel.DataAnnotations;

    public class Peak
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Elevation { get; set; }
        
        // Foright Key
        public virtual Mountain Mountain { get; set; }
        public int MountainId { get; set; }
    }
}