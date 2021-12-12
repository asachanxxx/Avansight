using Avansight.Service.Implimentation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avansight._Web.Controllers
{
    public class StudyController : Controller
    {
        private readonly IStudyService _studyService;
        public StudyController(IStudyService studyService)
        {
            _studyService = studyService;
        }

        [HttpGet]
        [Route("Study/Index/{id}")]
        public IActionResult Index(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult StudySelector()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetStudies() 
        {
            return Json(_studyService.GetAll());
        }


    }
}
