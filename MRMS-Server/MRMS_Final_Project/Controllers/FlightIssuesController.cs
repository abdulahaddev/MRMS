using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRMS.DAL;
using MRMS.Model.FlightSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightIssuesController : ControllerBase
    {
        private IGlobalRepository _globalRepository;
        private IGenericRepository<FlightIssue> _flightIssueRepository;
        public FlightIssuesController(IGlobalRepository globalRepository)
        {
            this._globalRepository = globalRepository;
            this._flightIssueRepository = _globalRepository.GetRepository<FlightIssue>();
        }
        // GET :
        [HttpGet]
        public IEnumerable<FlightIssue> GetFlightIssue()
        {
            return _flightIssueRepository.GetAll();

        }
        //Insert:
        [HttpPost]
        public ActionResult PostFlightIssue(FlightIssue flightIssue)
        {
            _flightIssueRepository.Insert(flightIssue);
            _globalRepository.Save();

            return Ok(flightIssue);
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult PutFlightIssue(int id, FlightIssue flightIssue)
        {
            if (id != flightIssue.FlightIssueId)
            {
                return BadRequest();
            }
            _flightIssueRepository.Update(flightIssue);
            try
            {
                _globalRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            return Ok(flightIssue);
        }
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteFlightIssue(int id)
        {
            var flightIssue = _flightIssueRepository.Get(id);
            if (flightIssue == null)
            {
                return NotFound();
            }
            _flightIssueRepository.Delete(flightIssue);

            _globalRepository.Save();
            return NoContent();
        }
    }
}
