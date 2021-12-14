using Avansight.Domain.Enums;
using Avansight.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Avansight.Domain.Extensions;
using System.ComponentModel.DataAnnotations;
using Avansight._Web.Helpers;
using Avansight.Service.Implimentation;

namespace Avansight._Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vm = new PatientViewModel();
            ViewBag.enums = GenaralHelpers.GetDisplayNames( new AgeGroups());
            return View(new PatientViewModel());
        }
        [HttpPost]
        public IActionResult Index(PatientViewModel patientViewModel)
        {
            _patientService.ProcessPatients(patientViewModel);
            ViewBag.enums = GenaralHelpers.GetDisplayNames(new AgeGroups());
            return View();
        }

      
    }
}
