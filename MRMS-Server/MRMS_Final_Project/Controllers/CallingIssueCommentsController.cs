using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRMS.DAL;
using MRMS.Model.CallingSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallingIssueCommentsController : ControllerBase
    {
        private IGlobalRepository _globalRepository;
        private IGenericRepository<CallingIssueComment> _callingIssueCommentRepository;

        public CallingIssueCommentsController(IGlobalRepository globalRepository)
        {
            this._globalRepository = globalRepository;
            this._callingIssueCommentRepository = _globalRepository.GetRepository<CallingIssueComment>();
        }

        // GET:
        [HttpGet]
        public IEnumerable<CallingIssueComment> GetCallingIssueComment()
        {
            return _callingIssueCommentRepository.GetAll();
        }

        //Insert:
        [HttpPost]
        public ActionResult PostCallingIssueComment(CallingIssueComment callingIssueComment)
        {
            _callingIssueCommentRepository.Insert(callingIssueComment);
            _globalRepository.Save();
            return Ok(callingIssueComment);
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult PutCallingIssueComment(int id, CallingIssueComment callingIssueComment)
        {
            if (id != callingIssueComment.CallingIssueCommentId)
            {
                return BadRequest();
            }

            _callingIssueCommentRepository.Update(callingIssueComment);

            try
            {
                _globalRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok(callingIssueComment);
        }

        // DELETE: 
        [HttpDelete("{id}")]
        public IActionResult DeleteCallingIssueComment(int id)
        {
            var CallingIssueComment = _callingIssueCommentRepository.Get(id);
            if (CallingIssueComment == null)
            {
                return NotFound();
            }
            _callingIssueCommentRepository.Delete(CallingIssueComment);
            _globalRepository.Save();
            return NoContent();
        }
    }
}
