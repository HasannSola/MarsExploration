using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MarsExploration.Entities.Enum
{
    public enum CommandEnum
    {
        [Display(Name = "Left")]
        L,
        [Display(Name = "Right")]
        R,
        [Display(Name = "CurrentLocation")]
        M,
        [Display(Name = "FirstLocation")]
        F
    }
}
