namespace BugTracker.RestServices.Models
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    public class NewBugBindingModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}