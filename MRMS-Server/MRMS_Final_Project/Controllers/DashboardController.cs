using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRMS.DAL;
using MRMS.DAL.Context;
using MRMS.Model.ApplicantSection;
using MRMS.Model.DemandSection;
using MRMS.Model.ViewModels;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly MRMSDBContext _mRMSDB;

        public DashboardController(MRMSDBContext mRMSDB)
        {
            _mRMSDB = mRMSDB;
        }

        [HttpGet]
        public async Task<ActionResult<DashboardDTO>> GetDashboardData()
        {
            var data = await Task.Run(() => new DashboardDTO
            {
                DemandName="Total Demand :",
                TotalDemand = _mRMSDB.Demands.Count(),
                TradeName="Total Trade :",
                TotalTrade = _mRMSDB.Trades.Count(),
                AgencyName="Total Agency :",
                TotalAgency=_mRMSDB.Agencies.Count(),
                ApplicantName="Total Applicant :",
                TotalApplicant=_mRMSDB.Applicants.Count(),
                AgentName="Total Agent :",
                TotalAgent=_mRMSDB.Agents.Count()
            });

            return data;
        }

    }
}
