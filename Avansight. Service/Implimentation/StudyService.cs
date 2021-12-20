using Avansight.Domain;
using Avansight.Domain.Factories;
using Avansight.Domain.ViewModels;
using Avansight.Service;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
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
            return _service.QuerySingle("SELECT * from [cts].[Study] where [StudyId] = @StudyId", new { StudyId = id }, commandType: System.Data.CommandType.Text);
        }

        public bool ImportStudyData(DataSet studyImportVM,string Identifire)
        {
            var studyTable = DataTableFactory.GetStudyTable();
            var treatmentTable = DataTableFactory.GetTreatmentGroupTable();

            var strow = studyTable.NewRow();
            strow["StudyId"] = 0;
            strow["StudyIdentifier"] = Identifire;
            foreach (DataRow item in studyImportVM.Tables[0].Rows)
            {
                switch (item.ItemArray[0].ToString()) {
                    case "StudyName":
                        strow["StudyName"] = item.ItemArray[1];
                        break;
                    case "Project Number":
                        strow["ProjectNumber"] = item.ItemArray[1];
                        break;
                    case "Type":
                        strow["Type"] = item.ItemArray[1];
                        break;
                }
            }
            studyTable.Rows.Add(strow);

            bool firstrow = true;
            foreach (DataRow item in studyImportVM.Tables[1].Rows)
            {
                if (!firstrow)
                {
                    var sttrow = treatmentTable.NewRow();
                    sttrow["TreatmentId"] = 0;
                    sttrow["TreatmentCode"] = item.ItemArray[1];
                    sttrow["TreatmentName"] = item.ItemArray[0];
                    sttrow["TreatmentColor"] = item.ItemArray[2];
                    treatmentTable.Rows.Add(sttrow);
                }
                else {
                    firstrow = false;
                }
            }

            _service.Execute("[cts].[StudyImport]", new { Study = studyTable.AsTableValuedParameter("[cts].[StudyTableType]") , TreatmentGroups = treatmentTable.AsTableValuedParameter("[cts].[TreatmentGroupTableType]") }, commandType: System.Data.CommandType.StoredProcedure);

            return true;
        }
    }
}
