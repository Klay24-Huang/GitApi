using System;
using System.Collections.Generic;

namespace GitApi.Models
{
    public partial class CheckOutRecords
    {
        public Guid CheckOutRecordId { get; set; }
        public int OrderBy { get; set; }
        public string ProjectName { get; set; }
        public string BranchName { get; set; }
        public DateTime Date { get; set; }
        public string LasterVersionToUserCommitHashCode { get; set; }
        public string RemoteUrl { get; set; }
        public string WithWichOldCommitHashCode { get; set; }
    }
}
