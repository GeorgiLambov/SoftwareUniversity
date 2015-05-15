namespace NewsDB.Model
{
    using System.ComponentModel.DataAnnotations;

    public class News
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Content cannot be null.")]
        [MaxLength(512)]
        public string Content { get; set; }
    }
}
