using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRMS.DAL;
using MRMS.Model.ApplicantSection;
using MRMS.Model.CallingSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallingIssuesController : ControllerBase
    {
        private IGlobalRepository _globalRepository;
        private IGenericRepository<CallingIssue> _callingIssueRepository;

        public CallingIssuesController(IGlobalRepository globalRepository)
        {
            this._globalRepository = globalRepository;
            this._callingIssueRepository = _globalRepository.GetRepository<CallingIssue>();
        }

        // GET:
        [HttpGet]
        public IEnumerable<CallingIssue> GetCallingIssue()
        {
            return _callingIssueRepository.GetAll();
        }

        //Insert:
        [HttpPost]
        public ActionResult PostCallingIssue(CallingIssue callingIssue)
        {
            _callingIssueRepository.Insert(callingIssue);
            _globalRepository.Save();
            return Ok(callingIssue);
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult PutCallingIssue(int id, CallingIssue callingIssue)
        {
            if (id != callingIssue.CallingIssueId)
            {
                return BadRequest();
            }

            _callingIssueRepository.Update(callingIssue);

            try
            {
                _globalRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok(callingIssue);
        }

        // DELETE: 
        [HttpDelete("{id}")]
        public IActionResult DeleteCallingIssue(int id)
        {
            var CallingIssue = _callingIssueRepository.Get(id);
            if (CallingIssue == null)
            {
                return NotFound();
            }
            _callingIssueRepository.Delete(CallingIssue);
            _globalRepository.Save();
            return NoContent();
        }
    }
}
