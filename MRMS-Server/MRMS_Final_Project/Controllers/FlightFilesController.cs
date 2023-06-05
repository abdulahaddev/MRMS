using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRMS.DAL;
using MRMS.Model.FlightSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightFilesController : ControllerBase
    {
        private IGlobalRepository _globalRepository;
        private IGenericRepository<FlightFile> _flightFileRepository;
        public FlightFilesController(IGlobalRepository globalRepository)
        {
            this._globalRepository = globalRepository;
            this._flightFileRepository = _globalRepository.GetRepository<FlightFile>();
        }
        // GET :
        [HttpGet]
        public IEnumerable<FlightFile> GetFlightFile()
        {
            return _flightFileRepository.GetAll();

        }
        //Insert:
        [HttpPost]
        public ActionResult PostFlightFile(FlightFile flightFile)
        {
            _flightFileRepository.Insert(flightFile);
            _globalRepository.Save();
           
            return Ok(flightFile);
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult PutFlightFile(int id, FlightFile flightFile)
        {
            if (id != flightFile.FlightFileId)
            {
                return BadRequest();
            }
            _flightFileRepository.Update(flightFile);
            try
            {
                _globalRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            return Ok(flightFile);
        }
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteFlightFile(int id)
        {
            var flightFile = _flightFileRepository.Get(id);
            if (flightFile == null)
            {
                return NotFound();
            }
            _flightFileRepository.Delete(flightFile);

            _globalRepository.Save();
            return NoContent();
        }
    }
}
