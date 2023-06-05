using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRMS.DAL;
using MRMS.Model.AgencySection;
using MRMS.Model.ApplicantSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantIssueCommentsController : ControllerBase
    {
        private IGlobalRepository _globalRepository;
        private IGenericRepository<ApplicantIssueComment> _applicantIssueCommentRepository;

        public ApplicantIssueCommentsController(IGlobalRepository globalRepository)
        {
            this._globalRepository = globalRepository;
            this._applicantIssueCommentRepository = _globalRepository.GetRepository<ApplicantIssueComment>();
        }

        // GET:
        [HttpGet]
        public IEnumerable<ApplicantIssueComment> GetApplicantFiles()
        {
            return _applicantIssueCommentRepository.GetAll();
        }

        //Insert:
        [HttpPost]
        public ActionResult PostApplicantIssueComment(ApplicantIssueComment applicantIssueComment)
        {
            _applicantIssueCommentRepository.Insert(applicantIssueComment);
            _globalRepository.Save();
            return Ok(applicantIssueComment);
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult PutApplicantIssueComment(int id, ApplicantIssueComment applicantIssueComment)
        {
            if (id != applicantIssueComment.ApplicantIssueCommentId)
            {
                return BadRequest();
            }

            _applicantIssueCommentRepository.Update(applicantIssueComment);

            try
            {
                _globalRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok(applicantIssueComment);
        }

        // DELETE: 
        [HttpDelete("{id}")]
        public IActionResult DeleteApplicantIssueComment(int id)
        {
            var applicantIssueComment = _applicantIssueCommentRepository.Get(id);
            if (applicantIssueComment == null)
            {
                return NotFound();
            }
            _applicantIssueCommentRepository.Delete(applicantIssueComment);
            _globalRepository.Save();
            return NoContent();
        }
    }
}
