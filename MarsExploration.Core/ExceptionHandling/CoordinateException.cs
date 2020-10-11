using System;
using System.Collections.Generic;
using System.Text;

namespace MarsExploration.Core.ExceptionHandling
{
 
    public class CoordinateException : Exception
    {
        public CoordinateException() : base("Coordinate_Out_bounds") { }
    }
}
