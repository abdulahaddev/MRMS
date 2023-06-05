using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRMS.DAL;
using MRMS.Model.ForwardingSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForwardingsController : ControllerBase
    {
        private IGlobalRepository _globalRepository;
        private IGenericRepository<Forwarding> _forwardingRepository;
        public ForwardingsController(IGlobalRepository globalRepository)
        {
            this._globalRepository = globalRepository;
            this._forwardingRepository = _globalRepository.GetRepository<Forwarding>();
        }
        // GET :
        [HttpGet]
        public IEnumerable<Forwarding> GetForwarding()
        {
            return _forwardingRepository.GetAll();

        }
        //Insert:
        [HttpPost]
        public ActionResult PostForwardign(Forwarding forwarding)
        {
            _forwardingRepository.Insert(forwarding);
            _globalRepository.Save();

            return Ok(forwarding);
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult PutForwarding(int id, Forwarding forwarding)
        {
            if (id != forwarding.ForwardingId)
            {
                return BadRequest();
            }
            _forwardingRepository.Update(forwarding);
            try
            {
                _globalRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            return Ok(forwarding);
        }
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteForwarding(int id)
        {
            var forwarding = _forwardingRepository.Get(id);
            if (forwarding == null)
            {
                return NotFound();
            }
            _forwardingRepository.Delete(forwarding);

            _globalRepository.Save();
            return NoContent();
        }
    }
}
