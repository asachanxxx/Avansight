using Avansight.Domain;
using Avansight.Domain.Enums;
using Avansight.Domain.Factories;
using Avansight.Domain.ViewModels;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avansight.Service.Implimentation
{
    public class PatientService : IPatientService
    {
        GenaricDataAccessService<Patient> _service;
        public PatientService(IConfiguration configuration)
        {
            _service = new GenaricDataAccessService<Patient>(configuration);
        }

        public List<Patient> GetAll(SubjectFilters subjectFilters)
        {

            /*TODO
             * Extract gender ALl , Male , FeMale parameters
             * Extract TreatmentCode ALl , .... 
             * And pass to the Parameters
            */

            ///Had passed mock parameters
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@StudyId", subjectFilters.StudyId);
            queryParameters.Add("@TreatmentCode", null);
            queryParameters.Add("@Age", subjectFilters.Age);
            queryParameters.Add("@Gender", null);
            return _service.Query<Patient>("[cts].[Sp_PatientGet]", queryParameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
        }
        public bool PatientsSet(List<Patient> patients)
        {
            var dataTable = DataTableFactory.GetPatientTable();
            foreach (var item in patients)
            {
                var row = dataTable.NewRow();
                row["PatientId"] = item.PatientId;
                row["Age"] = item.Age;
                row["Gender"] = item.Gender;
                row["StudyId"] = item.StudyId;
                row["TreatmentId"] = item.TreatmentId;
                dataTable.Rows.Add(row);
            }
            _service.Execute("[cts].[Sp_PatientSet]",new { Patients = dataTable.AsTableValuedParameter("[cts].[PatientTableType]") },commandType:System.Data.CommandType.StoredProcedure);
            return true;
        }

        public List<Patient> ProcessPatients(PatientViewModel patientViewModel)
        {
            List<Patient> globalPatients = new List<Patient>();

            decimal noOfMales = ((decimal)patientViewModel.MaleWight / (decimal)(patientViewModel.MaleWight + patientViewModel.FMaleWight)) * (decimal)patientViewModel.SampleSize;
            decimal malePer = (noOfMales / patientViewModel.SampleSize) * 100;
            var patientDic = patientViewModel.GetAgeList();
            foreach (var item in patientDic)
            {

                if (item.Value > 0)
                {
                    var patients = new List<Patient>();
                    var noomales = (malePer / 100) * item.Value;
                    var noofmales = item.Value - noomales;
                    var age = 0;
                    switch (item.Key)
                    {
                        case "Age2030":
                            age = new Random(2).Next(20, 30);
                            break;
                        case "Age3140":
                            age = new Random(2).Next(31, 40);
                            break;
                        case "Age4150":
                            age = new Random(2).Next(41, 50);
                            break;
                        case "Age5160":
                            age = new Random(2).Next(51, 60);
                            break;
                        case "Age6170":
                            age = new Random(2).Next(61, 70);
                            break;
                    }
                    for (int i = 0; i < noomales; i++)
                    {
                        patients.Add(new Patient
                        {
                            Age = age,
                            Gender = Domain.Enums.Gender.Male,
                            PatientId = 0,
                            StudyId = 1,
                            TreatmentId = 2
                        });
                    }
                    for (int i = 0; i < noofmales; i++)
                    {
                        patients.Add(new Patient
                        {
                            Age = age,
                            Gender = Domain.Enums.Gender.FeMale,
                            PatientId = 0,
                            StudyId = 1,
                            TreatmentId = 2
                        });
                    }
                    globalPatients.AddRange(patients);
                }

            }

            int counter = 0;
            foreach (var item in globalPatients)
            {
                if ((counter % 2) == 1)
                {
                    item.TreatmentId = 1;
                }
                else
                {
                    item.TreatmentId = 2;
                }
                counter++;
            }

            var p = globalPatients;
            return globalPatients;
        }
    }
}
