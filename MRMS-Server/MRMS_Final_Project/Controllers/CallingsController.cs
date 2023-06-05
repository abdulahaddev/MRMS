using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRMS.DAL;
using MRMS.Model.ApplicationSection;
using MRMS.Model.CallingSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallingsController : ControllerBase
    {
        private IGlobalRepository _globalRepository;
        private IGenericRepository<Calling> _callingRepository;
        public CallingsController(IGlobalRepository globalRepository)
        {
            this._globalRepository = globalRepository;
            this._callingRepository = _globalRepository.GetRepository<Calling>();
        }
        // GET :
        [HttpGet]
        public IEnumerable<Calling> GetCalling()
        {
            return _callingRepository.GetAll();

        }
        //Insert:
        [HttpPost]
        public ActionResult PostCalling(Calling calling)
        {
            _callingRepository.Insert(calling);
            _globalRepository.Save();
            //try
            //{
            //    _globalRepository.Save();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            return Ok(calling);
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult PutCalling(int id, Calling calling)
        {
            if (id != calling.CallingId)
            {
                return BadRequest();
            }
            _callingRepository.Update(calling);
            try
            {
                _globalRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            return Ok(calling);
        }
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteCalling(int id)
        {
            var calling = _callingRepository.Get(id);
            if (calling == null)
            {
                return NotFound();
            }
            _callingRepository.Delete(calling);

            _globalRepository.Save();
            return NoContent();
        }
    }
}
