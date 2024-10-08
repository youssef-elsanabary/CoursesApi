using System.ComponentModel.DataAnnotations;

namespace Courses.Models
{
    public class Course
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Crs_name { get; set; }
        [MaxLength(150)]
        public string? Crs_desc { get;  set;}
        public int? Duration { get; set; }
    }
}
