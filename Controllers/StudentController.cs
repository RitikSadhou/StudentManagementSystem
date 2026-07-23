using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentController> _logger;    
        public StudentController(IStudentService studentService, ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        // GET: api/student
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllAsync();

            return Ok(new
            {
                Success = true,
                Message = "Students fetched successfully.",
                Data = students
            });

        }

        // GET: api/student/5
        [HttpGet("Get-Student/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentService.GetByIdAsync(id);

            if (student == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Message = "Student not found."
                });
            }

            return Ok(new
            {
                Success = true,
                Data = student
            });
        }

        // POST: api/student
        [HttpPost("Add-Student")]
        public async Task<IActionResult> AddStudent(StudentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = await _studentService.AddAsync(dto);

            _logger.LogInformation( "Student created. Email: {Email}", dto.Email); 

            return CreatedAtAction(nameof(GetStudentById),
                new { id = student.Id },
                new
                {
                    Success = true,
                    Message = "Student created successfully.",
                    Data = student
                });
        }

        // PUT: api/student/5
        [HttpPut("Update-Student/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = await _studentService.UpdateAsync(id, dto);

            if (student == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Message = "Student not found."
                });
            }

            _logger.LogInformation("Student updated. Id: {Id}",id);
            return Ok(new
            {
                Success = true,
                Message = "Student updated successfully.",
                Data = student
            });
        }

        // DELETE: api/student/5
        [HttpDelete("Delete-Student/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var deleted = await _studentService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    Success = false,
                    Message = "Student not found."
                });
            }
            _logger.LogInformation( "Student deleted. Id: {Id}", id);
            return Ok(new
            {
                Success = true,
                Message = "Student deleted successfully."
            });
        }
    }
}
