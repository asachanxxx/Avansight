using Avansight.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avansight.Domain.ViewModels
{
    public class PatientViewModel
    {
        public int SampleSize { get; set; }
        public int MaleWight { get; set; }
        public int FMaleWight { get; set; }
        public int Age2030 { get; set; }
        public int Age3140 { get; set; }
        public int Age4150 { get; set; }
        public int Age5160 { get; set; }
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
