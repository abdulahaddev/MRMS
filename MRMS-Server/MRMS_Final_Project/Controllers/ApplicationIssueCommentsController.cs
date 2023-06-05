using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRMS.DAL;
using MRMS.Model.ApplicantSection;
using MRMS.Model.ApplicationSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationIssueCommentsController : ControllerBase
    {
        private IGlobalRepository _globalRepository;
        private IGenericRepository<ApplicationIssueComment> _applicationIssueCommentRepository;
        public ApplicationIssueCommentsController(IGlobalRepository globalRepository)
        {
            this._globalRepository = globalRepository;
            this._applicationIssueCommentRepository = _globalRepository.GetRepository<ApplicationIssueComment>();
        }
        // GET :
        [HttpGet]
        public IEnumerable<ApplicationIssueComment> GetApplicationIssueComments()
        {
            return _applicationIssueCommentRepository.GetAll();

        }
        //Insert:
        [HttpPost]
        public ActionResult PostApplicantIssueComment(ApplicationIssueComment applicationIssueComment)
        {
            _applicationIssueCommentRepository.Insert(applicationIssueComment);
            _globalRepository.Save();
            return Ok(applicationIssueComment);
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult PutApplicationIssueComment(int id, ApplicationIssueComment applicationIssueComment)
        {
            if (id != applicationIssueComment.ApplicationIssueCommentId)
            {
                return BadRequest();
            }
            _applicationIssueCommentRepository.Update(applicationIssueComment);
            try
            {
                _globalRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            return Ok(applicationIssueComment);
        }
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteApplicationIssueComment(int id)
        {
            var applicationIssueComment = _applicationIssueCommentRepository.Get(id);
            if (applicationIssueComment== null)
            {
                return NotFound();
            }
            _applicationIssueCommentRepository.Delete(applicationIssueComment);

            _globalRepository.Save();
            return NoContent();
        }

    }
}
