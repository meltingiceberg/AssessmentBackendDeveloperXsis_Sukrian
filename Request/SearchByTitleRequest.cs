using System.ComponentModel.DataAnnotations;

namespace AssessmentBackendDeveloperXsis_Sukrian.Request
{
    public class SearchByTitleRequest
    {
        [Required]
        public string Title { get; set; } = null!;
    }
}
