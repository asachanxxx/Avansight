using Avansight.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avansight.Domain.ViewModels
{
    public class SubjectFilters
    {
        public int StudyId { get; set; }
        public List<string> TreatmentCode { get; set; }
        public string Age { get; set; }
        public List<string> Gender { get; set; }
    }
}
