using System.ComponentModel.DataAnnotations;

namespace AssessmentBackendDeveloperXsis_Sukrian.Request
{
    public class AddMovieRequest
    {
        [Required(ErrorMessage = "Title is required")]
        [MinLength(1, ErrorMessage = "Title cannot be empty")]
        [MaxLength(50, ErrorMessage = "Title cannot exceed 50 characters")]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Rating is required")]
        public float Rating { get; set; }
        [MaxLength(500, ErrorMessage = "Image Path too long")]
        public string? Image { get; set; }
    }
}
