using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MarsExploration.Entities.Enum
{
    public enum LocationEnum
    {
        [Display(Name = "North")]
        N,
        [Display(Name = "South")]
        S,
        [Display(Name = "East")]
        E,
        [Display(Name = "West")]
        W
    }


}
