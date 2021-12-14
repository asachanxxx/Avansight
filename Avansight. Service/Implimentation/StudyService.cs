using Avansight.Domain;
using Avansight.Service;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avansight.Service.Implimentation
{
    public class StudyService : IStudyService
    {
        GenaricDataAccessService<Study> _service;
        public StudyService(IConfiguration configuration)
        {
            _service = new GenaricDataAccessService<Study>(configuration);
        }

        public List<Study> GetAll()
        {
            return _service.Query<Study>("SELECT * from [cts].[Study]", null, commandType: System.Data.CommandType.Text).ToList();
        }
        public Study GetStudy(int id)
        {
            return _service.QuerySingle("SELECT * from [cts].[Study] where [StudyId] = @StudyId", new { StudyId  = id }, commandType: System.Data.CommandType.Text);
        }
    }
}
