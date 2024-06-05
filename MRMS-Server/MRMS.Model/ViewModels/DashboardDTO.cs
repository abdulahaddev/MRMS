using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRMS.Model.ViewModels
{
    public class DashboardDTO
    {
        public string? DemandName { get; set; }
        public int? TotalDemand { get; set; }
        public string? TradeName { get; set; }
        public int? TotalTrade { get; set; }
        public string? AgencyName { get; set; }
        public int? TotalAgency { get; set; }
        public string? ApplicantName { get; set; }
        public int? TotalApplicant { get; set; }
        public string? AgentName { get; set; }
        public int? TotalAgent { get; set; }
    }
}
