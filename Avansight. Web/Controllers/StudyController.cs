using Avansight.Domain;
using Avansight.Service;
using Avansight.Service.Implimentation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Avansight._Web.Controllers
{
    public class StudyController : Controller
    {
        private readonly IStudyService _studyService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StudyController(IStudyService studyService, IWebHostEnvironment webHostEnvironment)
        {
            _studyService = studyService;
            _webHostEnvironment = webHostEnvironment;
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

        public IActionResult OnPostMyUploader(IFormFile MyUploader)
        {
            if (MyUploader != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "mediaUpload");
                string filePath = Path.Combine(uploadsFolder, MyUploader.FileName);
                if (System.IO.File.Exists(filePath)) {
                    return new ObjectResult(new { status = "fail" });
                }
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    MyUploader.CopyTo(fileStream);
                }

                var dataset = HelperService.ReadExcelToDataSet(filePath);
                _studyService.ImportStudyData(dataset, Path.GetFileNameWithoutExtension(MyUploader.FileName));
                return new ObjectResult(new { status = "success" });
            }
            return new ObjectResult(new { status = "fail" });

        }

    }
}
