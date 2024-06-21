using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ApplicationExceptions
{
    public class PasteException : Exception
    {
        public PasteException(string? message) : base(message)
        {
        }
    }
}
