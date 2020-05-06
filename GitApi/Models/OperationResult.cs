using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitApi.Models
{
    public class OperationResult
    {
        public bool IsSuccessful { get; set; }

        public object Result { get; set; }
        public string ErrorMessage { get; set; }

    }
}
