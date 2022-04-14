using firstproject.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstproject.data.viewModels
{
    public class CustomActionResultVM
    {
        public Exception Exception { get; set; }

        public publisher Publisher { get; set; }
    }
}
