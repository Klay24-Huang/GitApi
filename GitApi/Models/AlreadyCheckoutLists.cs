using System;
using System.Collections.Generic;

namespace GitApi.Models
{
    public partial class AlreadyCheckoutLists
    {
        public Guid AlreadyCheckoutListId { get; set; }
        public int OrderBy { get; set; }
        public string RemoteUrl { get; set; }
        public string BranchName { get; set; }
        public DateTime Date { get; set; }
        public string FileName { get; set; }
        public string LasterVersionToUserCommitHashCode { get; set; }
        public string WithWichOldCommitHashCode { get; set; }
        public string CheckoutWordName { get; set; }
        public string ProjectName { get; set; }
    }
}
