using Avansight.Domain.ViewModels;
using System.Collections.Generic;

namespace Avansight.Service.Implimentation
{
    public interface IPatientService
    {
        List<PatientService> GetAll();
        void ProcessPatients(PatientViewModel patientViewModel);
    }
}