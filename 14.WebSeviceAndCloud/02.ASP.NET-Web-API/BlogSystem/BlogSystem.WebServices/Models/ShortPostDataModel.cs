namespace BlogSystem.WebServices.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ShortPostDataModel
    {
        [Display(Name = "Id")]
        public int? Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }
    }
}