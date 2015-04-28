namespace BlogSystem.WebServices.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ShortUserDataModel
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
    }
}