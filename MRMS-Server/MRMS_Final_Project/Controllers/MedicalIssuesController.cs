using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRMS.DAL;
using MRMS.Model.MedicalSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalIssuesController : ControllerBase
    {
        private IGlobalRepository _globalRepo;
        private IGenericRepository<MedicalIssue> _medicalIssueRepo;

        public MedicalIssuesController(IGlobalRepository globalRepository)
        {
            this._globalRepo = globalRepository;
            this._medicalIssueRepo = _globalRepo.GetRepository<MedicalIssue>();
        }



        [HttpGet]
        public IEnumerable<MedicalIssue> GetMedicalIssue()
        {
            return _medicalIssueRepo.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<MedicalIssue> GetMedicalIssueById(int id)
        {
            try
            {
                MedicalIssue medicalIssue = _medicalIssueRepo.Get(id);
                return medicalIssue;
            }
            catch (Exception ex)
            {

                BadRequest(ex.Message);
            }
            return Ok();
        }
        // Insert

        [HttpPost]
        public ActionResult PostMedicalIssue(MedicalIssue medicalIssue)
        {
            try
            {
                _medicalIssueRepo.Insert(medicalIssue);
                _globalRepo.Save();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(medicalIssue);
        }
        // Update

        [HttpPut("{id}")]
        public IActionResult PutMedicalIssue(MedicalIssue medicalIssue)
        {


            try
            {
                if (medicalIssue.MedicalIssueId == 0)
                {
                    return NotFound();
                }
                _medicalIssueRepo.Update(medicalIssue);
                _globalRepo.Save();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(medicalIssue);
        }

        //Delete

        [HttpDelete("{id}")]
        public IActionResult DeleteMedicalIssue(int id)
        {
            MedicalIssue medicalIssue = _medicalIssueRepo.Get(id);
            try
            {
                if (medicalIssue == null)
                {
                    return NotFound();
                }
                _medicalIssueRepo.Delete(medicalIssue);
                _globalRepo.Save();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(medicalIssue);
        }
    }
}
