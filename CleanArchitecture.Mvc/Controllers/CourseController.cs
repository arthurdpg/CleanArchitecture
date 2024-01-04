using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Mvc.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private ICourseService _courseService;
        public CourseController(ICourseService courseService) 
        {
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            var viewModel = _courseService.GetCourses();

            return View(viewModel);
        }
    }
}
