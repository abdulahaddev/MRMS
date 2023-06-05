using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MRMS.DAL;
using MRMS.Model.ApplicantSection;
using MRMS.Model.DemandSection;
using MRMS.Model.ViewModels;

namespace MRMS_Final_Project.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantsController : ControllerBase
    {
        private IGlobalRepository _globalRepository;
        private IGenericRepository<Applicant> _applicantRepository;
        private readonly IWebHostEnvironment _env;

        public ApplicantsController(IGlobalRepository globalRepository, IWebHostEnvironment env)
        {
            this._globalRepository = globalRepository;
            this._applicantRepository = _globalRepository.GetRepository<Applicant>();
            _env = env;
        }

        // GET:
        [HttpGet]
        public IEnumerable<Applicant> GetApplicants()
        {
            return _applicantRepository.GetAll();
        }
        //GetbyId
        [HttpGet("{applicantId}")]
        public ActionResult<Applicant> GetApplicantByApplicantId(int applicantId)
        {
            Applicant applicant = _applicantRepository.Get(applicantId);
            if (applicant is not null)
            {
                return applicant;
            }
            return NotFound();
        }

        // Insert: 
        [HttpPost]
        public ActionResult ApplicantPost([FromForm] ApplicantVM applicantVM)
        {
            if (applicantVM == null)
            {
                return NotFound();
            }
            try
            {
                Applicant applicant = new Applicant()
                {
                    ApplicantId= applicantVM.ApplicantId,
                    PasssportNo = applicantVM.PasssportNo,
                    PassportExpiry = applicantVM.PassportExpiry,
                    AgentId = applicantVM.AgentId,
                    Name = applicantVM.Name,
                    FathersName = applicantVM.FathersName,
                    MothersName = applicantVM.MothersName,
                    Spouse = applicantVM.Spouse,
                    PresentAddress = applicantVM.PresentAddress,
                    PermanentAddress = applicantVM.PermanentAddress,
                    DateOfBrith = applicantVM.DateOfBrith,
                    PhoneNumber = applicantVM.PhoneNumber,
                    NID = applicantVM.NID,
                    BirthCertificateNo = applicantVM.BirthCertificateNo,
                    Email = applicantVM.Email,
                    Nationality = applicantVM.Nationality,
                    Height = applicantVM.Height,
                    Weight = applicantVM.Weight,
                    JobExperience = applicantVM.JobExperience,
                    Gender = applicantVM.Gender,
                    Religion = applicantVM.Religion,
                    MaritalStatus = applicantVM.MaritalStatus,
                    Education = applicantVM.Education
                };
                if (applicantVM.Picture != null)
                {
                    string path = _env.WebRootPath + "\\Uploads\\";
                    string ext = Path.GetExtension(applicantVM.PictureFile.FileName);
                    string f = Guid.NewGuid() + ext;
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using FileStream fileStream = System.IO.File.Create(path + f);
                    applicantVM.PictureFile.CopyTo(fileStream);
                    fileStream.Flush();
                    applicant.Picture = f;
                    fileStream.Close();
                }

                _applicantRepository.Insert(applicant);
                _globalRepository.Save();
                return Ok(applicant);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        // Update: 
        [HttpPut]
        public ActionResult ApplicantEdit([FromForm] ApplicantVM applicantVM)
        {
            if (applicantVM == null)
            {
                return NotFound();
            }
            try
            {
                Applicant applicant = new Applicant()
                {
                    ApplicantId = applicantVM.ApplicantId,
                    PasssportNo = applicantVM.PasssportNo,
                    PassportExpiry = applicantVM.PassportExpiry,
                    AgentId = applicantVM.AgentId,
                    Name = applicantVM.Name,
                    FathersName = applicantVM.FathersName,
                    MothersName = applicantVM.MothersName,
                    Spouse = applicantVM.Spouse,
                    PresentAddress = applicantVM.PresentAddress,
                    PermanentAddress = applicantVM.PermanentAddress,
                    DateOfBrith = applicantVM.DateOfBrith,
                    PhoneNumber = applicantVM.PhoneNumber,
                    NID = applicantVM.NID,
                    BirthCertificateNo = applicantVM.BirthCertificateNo,
                    Email = applicantVM.Email,
                    Nationality = applicantVM.Nationality,
                    Height = applicantVM.Height,
                    Weight = applicantVM.Weight,
                    JobExperience = applicantVM.JobExperience,
                    Gender = applicantVM.Gender,
                    Religion = applicantVM.Religion,
                    MaritalStatus = applicantVM.MaritalStatus,
                    Education = applicantVM.Education
                };
                if(applicantVM.PictureFile!= null)
                {
                    string path = _env.WebRootPath + "\\Uploads\\";
                    string ext = Path.GetExtension(applicantVM.PictureFile.FileName);
                    string f = Guid.NewGuid() + ext;
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using FileStream fileStream = System.IO.File.Create(path + f);
                    applicantVM.PictureFile.CopyTo(fileStream);
                    fileStream.Flush();
                    applicant.Picture = f;
                    fileStream.Close();
                }

                _applicantRepository.Update(applicant);
                _globalRepository.Save();
                return Ok(applicant);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        // DELETE: 
        [HttpDelete("{id}")]
        public ActionResult DeleteApplicant(int id)
        {
            var applicant = _applicantRepository.Get(id);
            if (applicant == null)
            {
                return NotFound();
            }
            _applicantRepository.Delete(applicant);
            _globalRepository.Save();
            return NoContent();
        }


    }
}
