using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRMS.DAL;
using MRMS.Model.ForwardingSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForwardingIssuesController : ControllerBase
    {
        private IGlobalRepository _globalRepository;
        private IGenericRepository<ForwardingIssue> _forwardingIssueRepository;
        public ForwardingIssuesController(IGlobalRepository globalRepository)
        {
            this._globalRepository = globalRepository;
            this._forwardingIssueRepository = _globalRepository.GetRepository<ForwardingIssue>();
        }
        // GET :
        [HttpGet]
        public IEnumerable<ForwardingIssue> GetForwardingIssue()
        {
            return _forwardingIssueRepository.GetAll();

        }
        //Insert:
        [HttpPost]
        public ActionResult PostForwardignIssue(ForwardingIssue forwardingIssue)
        {
            _forwardingIssueRepository.Insert(forwardingIssue);
            _globalRepository.Save();

            return Ok(forwardingIssue);
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult PutForwardingIssue(int id, ForwardingIssue forwardingIssue)
        {
            if (id != forwardingIssue.ForwardingIssueId)
            {
                return BadRequest();
            }
            _forwardingIssueRepository.Update(forwardingIssue);
            try
            {
                _globalRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            return Ok(forwardingIssue);
        }
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteForwardingIssue(int id)
        {
            var forwardingIssue = _forwardingIssueRepository.Get(id);
            if (forwardingIssue == null)
            {
                return NotFound();
            }
            _forwardingIssueRepository.Delete(forwardingIssue);

            _globalRepository.Save();
            return NoContent();
        }
    }
}
