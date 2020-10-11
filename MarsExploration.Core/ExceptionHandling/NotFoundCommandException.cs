using System;
using System.Collections.Generic;
using System.Text;

namespace MarsExploration.Core.ExceptionHandling
{
    public class NotFoundCommandException : Exception
    {
        public NotFoundCommandException() : base("Not_Found_Command") { }
    }
}
