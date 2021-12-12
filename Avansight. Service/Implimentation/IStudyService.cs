using Avansight.Domain;
using System.Collections.Generic;

namespace Avansight.Service.Implimentation
{
    public interface IStudyService
    {
        List<Study> GetAll();
    }
}