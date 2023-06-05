using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRMS.DAL;
using MRMS.Model.FlightSection;
using MRMS.Model.ForwardingSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BMETController : ControllerBase
    {
        private IGlobalRepository _globalRepository;
        private IGenericRepository<BMET> _BMETRepository;
        public BMETController(IGlobalRepository globalRepository)
        {
            this._globalRepository = globalRepository;
            this._BMETRepository = _globalRepository.GetRepository<BMET>();
        }
        // GET :
        [HttpGet]
        public IEnumerable<BMET> GetBMET()
        {
            return _BMETRepository.GetAll();

        }
        //Insert:
        [HttpPost]
        public ActionResult PostBMET(BMET bmet)
        {
            _BMETRepository.Insert(bmet);
            _globalRepository.Save();

            return Ok(bmet);
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult PutBMET(int id, BMET bmet)
        {
            if (id != bmet.BMETId)
            {
                return BadRequest();
            }
            _BMETRepository.Update(bmet);
            try
            {
                _globalRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            return Ok(bmet);
        }
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteBMET(int id)
        {
            var bmet = _BMETRepository.Get(id);
            if (bmet == null)
            {
                return NotFound();
            }
            _BMETRepository.Delete(bmet);

            _globalRepository.Save();
            return NoContent();
        }
    }
}
