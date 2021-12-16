using Avansight.Domain;
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
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Study/{StudyId}")]
        public IActionResult Index(int StudyId)
        {
            HttpContext.Session.SetObjectAsJson("studyObject", _studyService.GetStudy(StudyId));
            var sessionStudy = HttpContext.Session.GetObjectFromJson<Study>("studyObject");
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
