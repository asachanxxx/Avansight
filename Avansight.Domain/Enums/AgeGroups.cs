using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Avansight.Domain.Enums
{
    public enum AgeGroups
    {
        [Display(Name = "(21-30)")]
        AgeGroup1 = 1,
        [Display(Name = "(31-40)")]
        AgeGroup2 = 2,
        [Display(Name = "(41-50)")]
        AgeGroup3 = 3,
        [Display(Name = "(51-60)")]
        AgeGroup4 = 4,
        [Display(Name = "(61-70)")]
        AgeGroup5 = 5
    }
}
