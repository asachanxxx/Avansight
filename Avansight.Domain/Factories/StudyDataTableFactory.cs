using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Avansight.Domain.Factories
{
    public class StudyDataTableFactory
    {
        public static DataTable GetStudyTable()
        {
            var table = new DataTable();
            table.Columns.AddRange(new[] {
                new DataColumn("StudyId", typeof(int)),
                 new DataColumn("StudyIdentifier", typeof(string)),
                  new DataColumn("StudyName", typeof(string)),
                   new DataColumn("ProjectNumber", typeof(string)),
                    new DataColumn("Type", typeof(string)),
            });
            return table;
        }

        public static DataTable GetTreatmentGroupTable()
        {
            var table = new DataTable();
            table.Columns.AddRange(new[] {
                new DataColumn("TreatmentId", typeof(int)),
                 new DataColumn("TreatmentCode", typeof(string)),
                  new DataColumn("TreatmentName", typeof(string)),
                   new DataColumn("TreatmentColor", typeof(string)),
            });
            return table;
        }

        public static DataTable GetPatientTable()
        {
            var table = new DataTable();
            table.Columns.AddRange(new[] {
                new DataColumn("PatientId", typeof(int)),
                new DataColumn("Age", typeof(int)),
                new DataColumn("Gender", typeof(int)),
                new DataColumn("StudyId", typeof(int)),
                new DataColumn("TreatmentId", typeof(int)),
            });
            return table;
        }
    }
}
