using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRMS.DAL;
using MRMS.Model.FlightSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightIsssueCommentsController : ControllerBase
    {
        private IGlobalRepository _globalRepository;
        private IGenericRepository<FlightIssueComment> _flightIssueCommentRepository;
        public FlightIsssueCommentsController(IGlobalRepository globalRepository)
        {
            this._globalRepository = globalRepository;
            this._flightIssueCommentRepository = _globalRepository.GetRepository<FlightIssueComment>();
        }
        // GET :
        [HttpGet]
        public IEnumerable<FlightIssueComment> GetFlightIssueComment()
        {
            return _flightIssueCommentRepository.GetAll();

        }
        //Insert:
        [HttpPost]
        public ActionResult PostFlightIssueComment(FlightIssueComment flightIssueComment)
        {
            _flightIssueCommentRepository.Insert(flightIssueComment);
            _globalRepository.Save();

            return Ok(flightIssueComment);
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult PutFlightIssueComment(int id, FlightIssueComment flightIssueComment)
        {
            if (id != flightIssueComment.FlightIssueCommentId)
            {
                return BadRequest();
            }
            _flightIssueCommentRepository.Update(flightIssueComment);
            try
            {
                _globalRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            return Ok(flightIssueComment);
        }
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteFlightIssueComment(int id)
        {
            var flightIssueComment = _flightIssueCommentRepository.Get(id);
            if (flightIssueComment == null)
            {
                return NotFound();
            }
            _flightIssueCommentRepository.Delete(flightIssueComment);

            _globalRepository.Save();
            return NoContent();
        }
    }
}
