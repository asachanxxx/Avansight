using Avansight.Domain;
using Avansight.Domain.ViewModels;
using System.Collections.Generic;

namespace Avansight.Service.Implimentation
{
    public interface IPatientService
    {
        List<PatientService> GetAll();
        List<Patient> ProcessPatients(PatientViewModel patientViewModel);
        bool PatientsSet(List<Patient> patients);
    }
}