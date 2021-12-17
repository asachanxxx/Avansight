using Avansight.Domain.Enums;
using Avansight.Domain.ViewModels;
using Avansight.Service.Implimentation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avansight._Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartDataController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public ChartDataController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost]
        [Route("get-patient")]
        [AllowAnonymous]
        public IActionResult GetPatient(SubjectFilters subjectFilters)
        {
            var transform = _patientService.GetAll(subjectFilters);
            var results = from p in transform
                          group p by p.Gender into g
                          select new { Gender = ((Gender)g.Key).ToString(), Count = g.Count() };

            return Ok(results);
        }

    }
}
