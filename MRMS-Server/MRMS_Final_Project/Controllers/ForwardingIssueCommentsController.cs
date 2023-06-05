using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRMS.DAL;
using MRMS.Model.ForwardingSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForwardingIssueCommentsController : ControllerBase
    {
        private IGlobalRepository _globalRepository;
        private IGenericRepository<ForwardingIssueComment> _forwardingIssueCommentRepository;
        public ForwardingIssueCommentsController(IGlobalRepository globalRepository)
        {
            this._globalRepository = globalRepository;
            this._forwardingIssueCommentRepository = _globalRepository.GetRepository<ForwardingIssueComment>();
        }
        // GET :
        [HttpGet]
        public IEnumerable<ForwardingIssueComment> GetForwardingIssueComment()
        {
            return _forwardingIssueCommentRepository.GetAll();

        }
        //Insert:
        [HttpPost]
        public ActionResult PostForwardignIssueComment(ForwardingIssueComment forwardingIssueComment)
        {
            _forwardingIssueCommentRepository.Insert(forwardingIssueComment);
            _globalRepository.Save();

            return Ok(forwardingIssueComment);
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult PutForwardingIssueComment(int id, ForwardingIssueComment forwardingIssueComment)
        {
            if (id != forwardingIssueComment.ForwardingIssueCommentId)
            {
                return BadRequest();
            }
            _forwardingIssueCommentRepository.Update(forwardingIssueComment);
            try
            {
                _globalRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            return Ok(forwardingIssueComment);
        }
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteForwardingIssueComment(int id)
        {
            var forwardingIssueComment = _forwardingIssueCommentRepository.Get(id);
            if (forwardingIssueComment == null)
            {
                return NotFound();
            }
            _forwardingIssueCommentRepository.Delete(forwardingIssueComment);

            _globalRepository.Save();
            return NoContent();
        }
    }
}
