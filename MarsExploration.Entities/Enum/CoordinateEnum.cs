using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MarsExploration.Entities.Enum
{
    public enum CoordinateEnum
    {
        [Display(Name = "Left")]
        L,
        [Display(Name = "Right")]
        R,
        [Display(Name = "CurrentLocation")]
        M
    }
}
