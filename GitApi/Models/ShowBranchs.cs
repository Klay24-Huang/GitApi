using System;
using System.Collections.Generic;

namespace GitApi.Models
{
    public partial class ShowBranchs
    {
        public Guid ShowBranchId { get; set; }
        public Guid RemoteRepositoryId { get; set; }
        public string BranchName { get; set; }
    }
}
