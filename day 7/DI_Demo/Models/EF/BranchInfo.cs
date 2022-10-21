using System;
using System.Collections.Generic;

namespace DI_Demo.Models.EF
{
    public partial class BranchInfo
    {
        public BranchInfo()
        {
            AccountsInfos = new HashSet<AccountsInfo>();
        }

        public int BranchId { get; set; }
        public string? BranchName { get; set; }
        public string? BranchCity { get; set; }
        public string? BranchManager { get; set; }

        public virtual ICollection<AccountsInfo> AccountsInfos { get; set; }
    }
}
