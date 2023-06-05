using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRMS.DAL;
using MRMS.Model.MedicalSection;
using MRMS.Model.RejectSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RejectedApplicantsController : ControllerBase
    {
        private IGlobalRepository _globalRepo;
        private IGenericRepository<RejectedApplicant> _rejectedApplicantRepo;

        public RejectedApplicantsController(IGlobalRepository globalRepository)
        {
            this._globalRepo = globalRepository;
            this._rejectedApplicantRepo = _globalRepo.GetRepository<RejectedApplicant>();
        }



        [HttpGet]
        public IEnumerable<RejectedApplicant> GetRejectedApplicants()
        {
            return _rejectedApplicantRepo.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<RejectedApplicant> GetRejectedApplicantById(int id)
        {
            try
            {
                RejectedApplicant rejectedApplicant = _rejectedApplicantRepo.Get(id);
                return rejectedApplicant;
            }
            catch (Exception ex)
            {

                BadRequest(ex.Message);
            }
            return Ok();
        }
        // Insert

        [HttpPost]
        public ActionResult PostRejectedApplicant(RejectedApplicant rejectedApplicant)
        {
            try
            {
                _rejectedApplicantRepo.Insert(rejectedApplicant);
                _globalRepo.Save();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(rejectedApplicant);
        }
        // Update

        [HttpPut("{id}")]
        public IActionResult PutrejectedApplicant(RejectedApplicant rejectedApplicant)
        {


            try
            {
                if (rejectedApplicant.RejectedApplicantId == 0)
                {
                    return NotFound();
                }
                _rejectedApplicantRepo.Update(rejectedApplicant);
                _globalRepo.Save();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(rejectedApplicant);
        }

        //Delete

        [HttpDelete("{id}")]
        public IActionResult DeleteRejectedApplicant(int id)
        {
            RejectedApplicant rejectedApplicant = _rejectedApplicantRepo.Get(id);
            try
            {
                if (rejectedApplicant == null)
                {
                    return NotFound();
                }
                _rejectedApplicantRepo.Delete(rejectedApplicant);
                _globalRepo.Save();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(rejectedApplicant);
        }
    }
}
