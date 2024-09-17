﻿using Microsoft.AspNetCore.Mvc;
using Project.Filters.StudentFilters;
using Project.Interfaces.StudenstInterfaces;

namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentService _studentService;

        public StudentsController(ILogger<StudentsController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpPost("GetStudentsByGroup")]
        public async Task<IActionResult> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByGroupAsync(filter, cancellationToken);

            return Ok(students);
        }

        [HttpPost("GetStudentsByName")]
        public async Task<IActionResult> GetStudentsByName(StudentNameFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByNameAsync(filter, cancellationToken);

            return Ok(students);
        }

        [HttpPost("GetDeletedStudent")]
        public async Task<IActionResult> GetDeletedStudentsAsync(StudentDeleteFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetDeletedStudentsAsync(filter, cancellationToken);

            return Ok(students);
        }
    }
}
