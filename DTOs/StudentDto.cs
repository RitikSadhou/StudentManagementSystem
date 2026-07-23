using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.DTOs
{
    public class StudentDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public int Age { get; set; }

        public string Course { get; set; }
    }
}
