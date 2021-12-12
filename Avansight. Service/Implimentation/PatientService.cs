using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avansight.Service.Implimentation
{
    public class PatientService : IPatientService
    {
        GenaricDataAccessService<PatientService> _service;
        public PatientService(IConfiguration configuration)
        {
            _service = new GenaricDataAccessService<PatientService>(configuration);
        }

        public List<PatientService> GetAll()
        {
            return _service.Query<PatientService>("", null, commandType: System.Data.CommandType.StoredProcedure).ToList();
        }
    }
}
