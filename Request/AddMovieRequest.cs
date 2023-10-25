using System.ComponentModel.DataAnnotations;

namespace AssessmentBackendDeveloperXsis_Sukrian.Request
{
    public class AddMovieRequest
    {
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(50, ErrorMessage = "Title cannot exceed 50 characters")]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(1000, ErrorMessage = "Description cannot be over 1000 characters")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Rating is required")]
        public float Rating { get; set; }
        [MaxLength(500)]
        public string? Image { get; set; }
    }
}
