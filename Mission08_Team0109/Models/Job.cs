using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0109.Models
{
    public class Job
    {
        [Key]
        [Required]
        public int JobId { get; set; }
        [Required]
        public string JobName { get; set; }
        public string? DueDate { get; set; }
        [Required]
        public int Quadrant { get; set; }
        public string? CategoryName { get; set; }
        public bool? Completed { get; set; }

    }
}
