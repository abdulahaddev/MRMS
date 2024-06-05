using Microsoft.EntityFrameworkCore;
using MRMS.Model.AgencySection;
using MRMS.Model.ApplicantSection;
using MRMS.Model.ApplicationSection;
using MRMS.Model.Authentication;
using MRMS.Model.CallingSection;
using MRMS.Model.CommonSection;
using MRMS.Model.DemandSection;
using MRMS.Model.EmployeeSection;
using MRMS.Model.FlightSection;
using MRMS.Model.ForwardingSection;
using MRMS.Model.MedicalSection;
using MRMS.Model.RejectSection;
using MRMS.Model.VisaSection;

namespace MRMS.DAL.Context
{
    public class MRMSDBContext : DbContext
    {
        public MRMSDBContext(DbContextOptions<MRMSDBContext> options) : base(options) { }

        public DbSet<Agent> Agents { get; set; } = default!;
        public DbSet<Company> Companies { get; set; } = default!;
        public DbSet<Country> Countries { get; set; } = default!;

        public DbSet<Applicant> Applicants { get; set; } = default!;
        public DbSet<ApplicantFile> ApplicantFiles { get; set; } = default!;
        public DbSet<ApplicantIssue> ApplicantIssues { get; set; } = default!;

        public DbSet<Agency> Agencies { get; set; } = default!;
        public DbSet<AgencySyndicate> AgencySyndicates { get; set; } = default!;

        public DbSet<Designation> Designations { get; set; } = default!;
        public DbSet<Employee> Employees { get; set; } = default!;
        public DbSet<EmployeeFile> EmployeeFiles { get; set; } = default!;

        //public DbSet<File> Files { get; set; } = default!;
        //public DbSet<FileTransfer> FileTransfers { get; set; } = default!;
        public DbSet<FileType> FileType { get; set; } = default!;

        //public DbSet<Issue> Issues { get; set; } = default!;
        //public DbSet<IssueComment> IssueComments { get; set; } = default!;

        public DbSet<Demand> Demands { get; set; } = default!;
        public DbSet<Trade> Trades { get; set; } = default!;
        public DbSet<DemandFile> DemandFiles { get; set; } = default!;
        public DbSet<DemandIssue> DemandIssues { get; set; } = default!;

        public DbSet<MedicalCenter> MedicalCenters { get; set; } = default!;
        public DbSet<MedicalFile> MedicalFiles { get; set; } = default!;
        public DbSet<MedicalIssue> MedicalIssues { get; set; } = default!;
        public DbSet<MedicalRecord> MedicalRecords { get; set; } = default!;

        public DbSet<Application> Applications { get; set; } = default!;
        public DbSet<ApplicationFile> ApplicationFiles { get; set; } = default!;
        public DbSet<ApplicationFileTransfer> ApplicationFileTransfers { get; set; } = default!;
        public DbSet<ApplicationIssue> ApplicationIssues { get; set; } = default!;

        public DbSet<Calling> Callings { get; set; } = default!;
        public DbSet<CallingFile> CallingFiles { get; set; } = default!;
        public DbSet<CallingIssue> CallingIssues { get; set; } = default!;

        public DbSet<Forwarding> Forwardings { get; set; } = default!;
        public DbSet<ForwardingFile> ForwardingFiles { get; set; } = default!;
        public DbSet<ForwardingFileTransfer> ForwardingFileTransfers { get; set; } = default!;
        public DbSet<ForwardingIssue> ForwardingIssues { get; set; } = default!;
        public DbSet<BMET> BMETs { get; set; } = default!;
        public DbSet<TrainingCentre> TrainingCentres { get; set; } = default!;
        public DbSet<Training> Trainings { get; set; } = default!;
        public DbSet<FingerPrint> FingerPrints { get; set; } = default!;

        public DbSet<Visa> Visas { get; set; } = default!;
        public DbSet<VisaFile> VisaFiles { get; set; } = default!;
        public DbSet<VisaFileTransfer> VisaFileTransfers { get; set; } = default!;
        public DbSet<VisaIssue> VisaIssues { get; set; } = default!;

        public DbSet<Flight> Flights { get; set; } = default!;
        public DbSet<FlightFile> FlightFiles { get; set; } = default!;
        public DbSet<FlightIssue> FlightIssues { get; set; } = default!;

        public DbSet<RejectedApplicant> RejectedApplicants { get; set; } = default!;

        public DbSet<User> Users { get; set; } = default!;
    }
}
