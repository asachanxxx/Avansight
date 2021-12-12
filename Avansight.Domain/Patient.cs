using Avansight.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avansight.Domain
{
    public class Patient
    {
        public int PatientId { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public int StudyId { get; set; }
        public int TreatmentId { get; set; }
    }
}
