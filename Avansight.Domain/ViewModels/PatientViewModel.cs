using Avansight.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Avansight.Domain.ViewModels
{
    public class PatientViewModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "Value of SampleSize must bigger than {1}")]
        [Display(Name = "Sample Size")]
        public int SampleSize { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Value of MaleWight must bigger than {1}")]
        [Display(Name = "Male Wight")]
        public int MaleWight { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Value of FMaleWight must bigger than {1}")]
        [Display(Name = "FMale Wight")]
        public int FMaleWight { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Value of Age 20-30 must bigger than {1}")]
        public int Age2030 { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Value of Age 31-40 must bigger than {1}")]
        public int Age3140 { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Value of Age 41-50 must bigger than {1}")]
        public int Age4150 { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Value of Age 51-60 must bigger than {1}")]
        public int Age5160 { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Value of Age 61 70 must bigger than {1}")]
        public int Age6170 { get; set; }
        public AgeGroups AgeGroup { get; set; }
        public Dictionary<string,int> GetAgeList() {
            return new Dictionary<string, int>
            {
                {"Age2030" , Age2030 },
                {"Age3140" , Age3140 },
                {"Age4150" , Age4150 },
                {"Age5160" , Age5160 },
                {"Age6170" , Age6170 },
            };
        }
    }
}
