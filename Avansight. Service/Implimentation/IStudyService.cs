using Avansight.Domain;
using Avansight.Domain.ViewModels;
using System.Collections.Generic;
using System.Data;

namespace Avansight.Service.Implimentation
{
    public interface IStudyService
    {
        List<Study> GetAll();
        Study GetStudy(int id);
        bool ImportStudyData(DataSet studyImportVM, string Identifire);
    }
}