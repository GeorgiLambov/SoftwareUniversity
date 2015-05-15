using System.ComponentModel.DataAnnotations;

namespace MountainsCodeFirst
{
    public class Peak
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Elevation { get; set; }

        public int MountainId { get; set; }

        public virtual Mountain Mountain { get; set; }
    }
}
