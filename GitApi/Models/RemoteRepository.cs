using System;
using System.Collections.Generic;

namespace GitApi.Models
{
    public partial class RemoteRepository
    {
        public Guid RemoteRepositoryId { get; set; }
        public string ServerPath { get; set; }
        public string RemoteRepositoryUrl { get; set; }
    }
}
