using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRMS.DAL;
using MRMS.Model.CallingSection;
using MRMS.Model.FlightSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private IGlobalRepository _globalRepository;
        private IGenericRepository<Flight> _flightRepository;
        public FlightsController(IGlobalRepository globalRepository)
        {
            this._globalRepository = globalRepository;
            this._flightRepository = _globalRepository.GetRepository<Flight>();
        }
        // GET :
        [HttpGet]
        public IEnumerable<Flight> GetFlight()
        {
            return _flightRepository.GetAll();

        }
        //Insert:
        [HttpPost]
        public ActionResult PostFlight(Flight flight)
        {
            _flightRepository.Insert(flight);
            _globalRepository.Save();
            //try
            //{
            //    _globalRepository.Save();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            return Ok(flight);
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult PutFlight(int id, Flight flight)
        {
            if (id != flight.FlightId)
            {
                return BadRequest();
            }
            _flightRepository.Update(flight);
            try
            {
                _globalRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            return Ok(flight);
        }
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteFlight(int id)
        {
            var flight = _flightRepository.Get(id);
            if (flight == null)
            {
                return NotFound();
            }
            _flightRepository.Delete(flight);

            _globalRepository.Save();
            return NoContent();
        }
    }
}
