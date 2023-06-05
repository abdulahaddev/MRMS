using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MRMS.DAL;
using MRMS.Model.ForwardingSection;

namespace MRMS_Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FingerPrintsController : ControllerBase
    {
        private IGlobalRepository _globalRepository;
        private IGenericRepository<FingerPrint> _fingerPrintRepository;
        public FingerPrintsController(IGlobalRepository globalRepository)
        {
            this._globalRepository = globalRepository;
            this._fingerPrintRepository = _globalRepository.GetRepository<FingerPrint>();
        }
        // GET :
        [HttpGet]
        public IEnumerable<FingerPrint> GetFingerPrint()
        {
            return _fingerPrintRepository.GetAll();

        }
        //Insert:
        [HttpPost]
        public ActionResult PostFingerPrint(FingerPrint fingerPrint)
        {
            _fingerPrintRepository.Insert(fingerPrint);
            _globalRepository.Save();

            return Ok(fingerPrint);
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult PutFingerPrint(int id, FingerPrint fingerPrint)
        {
            if (id != fingerPrint.FingerPrintId)
            {
                return BadRequest();
            }
            _fingerPrintRepository.Update(fingerPrint);
            try
            {
                _globalRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            return Ok(fingerPrint);
        }
        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteFingerPrint(int id)
        {
            var fingerPrint = _fingerPrintRepository.Get(id);
            if (fingerPrint == null)
            {
                return NotFound();
            }
            _fingerPrintRepository.Delete(fingerPrint);

            _globalRepository.Save();
            return NoContent();
        }
    }
}
